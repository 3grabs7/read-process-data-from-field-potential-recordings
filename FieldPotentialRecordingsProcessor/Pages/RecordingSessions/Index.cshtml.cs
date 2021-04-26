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
    public class IndexModel : PageModel
    {
        private readonly FieldPotentialRecordingsProcessor.Data.ApplicationDbContext _context;

        public IndexModel(FieldPotentialRecordingsProcessor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RecordingSession> RecordingSession { get;set; }

        public async Task OnGetAsync()
        {
            RecordingSession = await _context.RecordingSessions.ToListAsync();
        }
    }
}
