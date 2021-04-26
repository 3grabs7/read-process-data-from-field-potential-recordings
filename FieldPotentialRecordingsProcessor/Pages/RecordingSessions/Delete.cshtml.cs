using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FieldPotentialRecordingsProcessor.Data;
using FieldPotentialRecordingsProcessor.Models;

namespace FieldPotentialRecordingsProcessor.Pages.RecordingSessions
{
    public class DeleteModel : PageModel
    {
        private readonly FieldPotentialRecordingsProcessor.Data.ApplicationDbContext _context;

        public DeleteModel(FieldPotentialRecordingsProcessor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecordingSession RecordingSession { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecordingSession = await _context.RecordingSessions.FirstOrDefaultAsync(m => m.Id == id);

            if (RecordingSession == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecordingSession = await _context.RecordingSessions.FindAsync(id);

            if (RecordingSession != null)
            {
                _context.RecordingSessions.Remove(RecordingSession);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
