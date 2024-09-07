using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BinetWebsite.Models;

namespace BinetWebsite.Controllers
{
    public class ContactpagesController : Controller
    {
        private readonly Binetcontext _context;

        public ContactpagesController(Binetcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Contact()
        {
            return PartialView();
        }
        //Contact Page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createcontact(Contactpage model)
        {
           /* if (!ModelState.IsValid)
            {
                // Handle form submission logic here
                return View(model);
                // Redirect or return a view
                 // Example redirect
            }*/
           
            Contactpage contactpage = new Contactpage();
            contactpage.Contactfor = model.Contactfor;
            contactpage.Name = model.Name;
            contactpage.Email = model.Email;
            contactpage.Subject = model.Subject;
            contactpage.Message = model.Message;

            _context.Add(contactpage);
            _context.SaveChanges();

            // If model state is not valid, return the view with the model
            return RedirectToAction("Index", "Home");
        }


        // GET: Contactpages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactpages.ToListAsync());
        }

        // GET: Contactpages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactpage = await _context.Contactpages
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactpage == null)
            {
                return NotFound();
            }

            return View(contactpage);
        }

        // GET: Contactpages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactpages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,Name,Email,Subject,Message,Phoneno,CompanyName,CompanyWebsite,CompanyPost")] Contactpage contactpage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactpage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactpage);
        }

        // GET: Contactpages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactpage = await _context.Contactpages.FindAsync(id);
            if (contactpage == null)
            {
                return NotFound();
            }
            return View(contactpage);
        }

        // POST: Contactpages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,Name,Email,Subject,Message,Phoneno,CompanyName,CompanyWebsite,CompanyPost")] Contactpage contactpage)
        {
            if (id != contactpage.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactpage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactpageExists(contactpage.ContactId))
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
            return View(contactpage);
        }

        // GET: Contactpages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactpage = await _context.Contactpages
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactpage == null)
            {
                return NotFound();
            }

            return View(contactpage);
        }

        // POST: Contactpages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactpage = await _context.Contactpages.FindAsync(id);
            if (contactpage != null)
            {
                _context.Contactpages.Remove(contactpage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactpageExists(int id)
        {
            return _context.Contactpages.Any(e => e.ContactId == id);
        }
    }
}
