using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab23v2.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Policy;

namespace Lab23v2.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Lab23v2Context _context;

        public ItemsController(Lab23v2Context context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("NotLoggedInError", "Users");
            }
            if (HttpContext.Session.GetString("First Name") != null)
            {
            ViewBag.User = HttpContext.Session.GetString("First Name");
            ViewBag.Wallet = int.Parse(HttpContext.Session.GetString("Wallet"));
            }
            return View(await _context.Items.ToListAsync());
        }

        public IActionResult Purchased()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("NotLoggedInError", "Users");
            }
            string email = HttpContext.Session.GetString("Email");
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            List<Items> items = PurchasedList(user);
            return View(items);
        }
        public IActionResult Return(int? id)
        {
            List<Items> items = new List<Items>();
            string email = HttpContext.Session.GetString("Email");
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            items = PurchasedList(user);
            foreach (Items item in items)
            {
                if (item.ItemId == id)
                {
                    user.Wallet += item.Price;
                    HttpContext.Session.SetString("Wallet", user.Wallet.ToString());
                    var delete = _context.UserItems.Where(x => x.UserID == user.UserId && x.ItemID == item.ItemId).FirstOrDefault();
                    _context.UserItems.Remove(delete);
                    _context.Users.Update(user);
                    var update = _context.Items.Where(x => x.ItemId == item.ItemId).FirstOrDefault();
                    update.Quantity++;
                    _context.Items.Update(update);
                    _context.SaveChanges();
                    break;
                }
            }
                return RedirectToAction("Purchased");
        }

        public List<Items> PurchasedList(Users user)
        {
            List<Items> items = new List<Items>();
            List<Items> evaluate = new List<Items>();
            var temp = _context.UserItems.Where(x => x.UserID == user.UserId).ToList();
            foreach (var itemID in temp)
            {
                Items add = _context.Items.Where(x => x.ItemId == itemID.ItemID).FirstOrDefault();
                add.Quantity = 1;
                evaluate.Add(add);
            }
            foreach (Items check in evaluate)
            {
                if (items.Contains(check))
                {
                    int index = items.FindIndex(x => x.ItemId == check.ItemId);
                    Items edit = items[index];
                    items.Remove(items[index]);
                    edit.Quantity++;
                    items.Add(edit);
                }
                else
                {
                    items.Add(check);
                }
            }
            return items;
        }
        public IActionResult Buy(int? id)
        {
            string email = HttpContext.Session.GetString("Email");
            var item = _context.Items.Where(x => x.ItemId == id).FirstOrDefault();
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            if (item.Price < user.Wallet && item.Quantity > 0)
            {
                item.Quantity--;
                _context.Items.Update(item);
                _context.SaveChanges();
                user.Wallet -= item.Price;
                HttpContext.Session.SetString("Wallet", user.Wallet.ToString());
                _context.Users.Update(user);
                UserItems tempItem = new UserItems()
                {
                    UserID = user.UserId,
                    ItemID = item.ItemId
                };
                _context.UserItems.Add(tempItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemDesc,Quantity,Price")] Items items)
        {
            if (ModelState.IsValid)
            {
                _context.Add(items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(items);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }
            return View(items);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemDesc,Quantity,Price")] Items items)
        {
            if (id != items.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(items);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsExists(items.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(items);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var items = await _context.Items.FindAsync(id);
            _context.Items.Remove(items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
