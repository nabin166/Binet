using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BinetWebsite.Models;
using Microsoft.AspNetCore.Hosting;

namespace BinetWebsite.Controllers
{
    public class jobAppliesController : Controller
    {
        private readonly Binetcontext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public jobAppliesController(Binetcontext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: jobApplies
        public async Task<IActionResult> Jobapply()
        {
            return View();
        }

        public async Task<IActionResult> Investorapply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Applicantapply([Bind("JobTitle,applicantName,applicantEmail,applicantDescription,portfolioLink,applicantCoverletter,CV,PhotoPath")] jobApply jobApply , IFormFile PhotoPath)
        {
            try
            {
                jobApply photoSend = new jobApply();

                // Handling Image
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(PhotoPath.FileName);
                string folderPath = Path.Combine("PhotoSend", uniqueFileName);
                string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

                using (var fileStream = new FileStream(serverFolderPath, FileMode.Create))
                {
                    await PhotoPath.CopyToAsync(fileStream);
                }

                photoSend.CV = folderPath;
                photoSend.applicantName = jobApply.applicantName;
                photoSend.applicantEmail = jobApply.applicantEmail;
                photoSend.applicantCoverletter = jobApply.applicantCoverletter;
                photoSend.portfolioLink = jobApply.portfolioLink;
                photoSend.JobTitle = jobApply.JobTitle;

                _context.Add(photoSend);
                await _context.SaveChangesAsync(); // Use SaveChangesAsync for asynchronous database operations
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors
                // Example: Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Investorapply([Bind("JobTitle,applicantName,applicantEmail,applicantDescription,portfolioLink,applicantCoverletter,CV,PhotoPath")] jobApply jobApply, IFormFile PhotoPath)
        {

            try
            {
                jobApply photoSend = new jobApply();

                // Handling Image
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(PhotoPath.FileName);
                string folderPath = Path.Combine("PhotoSend", uniqueFileName);
                string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

                using (var fileStream = new FileStream(serverFolderPath, FileMode.Create))
                {
                    await PhotoPath.CopyToAsync(fileStream);
                }

                photoSend.CV = folderPath;
                photoSend.applicantName = jobApply.applicantName;
                photoSend.applicantEmail = jobApply.applicantEmail;
                photoSend.applicantDescription = jobApply.applicantDescription;
                photoSend.portfolioLink = jobApply.portfolioLink;
                photoSend.JobTitle = jobApply.JobTitle;

                _context.Add(photoSend);
                await _context.SaveChangesAsync(); // Use SaveChangesAsync for asynchronous database operations
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors
                // Example: Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: jobApplies
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobApplies.ToListAsync());
        }
        //Contact Page
        [HttpPost]
        public async Task<IActionResult> jobApplies(jobApply model)
        {
            if (!ModelState.IsValid)
            {
                // Handle form submission logic here
                return View(model);
                // Redirect or return a view
                // Example redirect
            }
          

            // If model state is not valid, return the view with the model
            return RedirectToAction("Applynow", "Home");
        }



        // GET: jobApplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApply = await _context.JobApplies
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobApply == null)
            {
                return NotFound();
            }

            return View(jobApply);
        }

        // GET: jobApplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: jobApplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,JobTitle,applicantName,applicantDescription,portfolioLink,applicantCoverletter,CV")] jobApply jobApply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobApply);
        }

        // GET: jobApplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApply = await _context.JobApplies.FindAsync(id);
            if (jobApply == null)
            {
                return NotFound();
            }
            return View(jobApply);
        }

        // POST: jobApplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,JobTitle,applicantName,applicantDescription,portfolioLink,applicantCoverletter,CV")] jobApply jobApply)
        {
            if (id != jobApply.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!jobApplyExists(jobApply.JobId))
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
            return View(jobApply);
        }

        // GET: jobApplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApply = await _context.JobApplies
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobApply == null)
            {
                return NotFound();
            }

            return View(jobApply);
        }

        // POST: jobApplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApply = await _context.JobApplies.FindAsync(id);
            if (jobApply != null)
            {
                _context.JobApplies.Remove(jobApply);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool jobApplyExists(int id)
        {
            return _context.JobApplies.Any(e => e.JobId == id);
        }
    }
}
