using FieldPotentialRecordingsProcessor.Data;
using FieldPotentialRecordingsProcessor.Models;
using FieldPotentialRecordingsProcessor.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FieldPotentialRecordingsProcessor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        private IWebHostEnvironment _environment;

        [BindProperty]
        public IFormFile Upload { get; set; }
        [BindProperty]
        public string Separator { get; set; }
        [BindProperty]
        public string LineSeparator { get; set; }
        public RecordingSession UploadedRecordingSession { get; set; }

        public IndexModel(ApplicationDbContext context,
            ILogger<IndexModel> logger,
            IWebHostEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _environment = environment;
        }

        public void OnGet()
        {

        }

        public async Task OnPostUploadRecordingSessionAsync()
        {
            var path = Path.Combine(_environment.ContentRootPath, "CSVData", $"{DateTime.Now.ToShortDateString()}.csv");
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }
                var parser = new ParseCsv(path);
                parser.Parse(_context);

            }
            catch
            {

            }
        }
    }
}
