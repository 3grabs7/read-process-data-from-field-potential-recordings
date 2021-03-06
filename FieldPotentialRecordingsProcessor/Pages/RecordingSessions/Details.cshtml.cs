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
    public class DetailsModel : PageModel
    {
        private readonly FieldPotentialRecordingsProcessor.Data.ApplicationDbContext _context;

        public DetailsModel(FieldPotentialRecordingsProcessor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public RecordingSession RecordingSession { get; set; }
        public IEnumerable<RawData> RawDatas { get; set; }
        public IEnumerable<ProcessedDataSet> ProcessedDataSets { get; set; }

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

            RawDatas = _context.RawDatas
                .Where(d => d.RecordingSession.Id == id);
            ProcessedDataSets = _context.ProcessedDataSets
                .Where(pd => pd.RecordingSession.Id == id);

            return Page();
        }
    }
}
