using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FieldPotentialRecordingsProcessor.Data;
using FieldPotentialRecordingsProcessor.Models;

namespace FieldPotentialRecordingsProcessor.Pages.RecordingSessions
{
    public class CreateModel : PageModel
    {
        private readonly FieldPotentialRecordingsProcessor.Data.ApplicationDbContext _context;

        public CreateModel(FieldPotentialRecordingsProcessor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecordingSession RecordingSession { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecordingSessions.Add(RecordingSession);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
