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
            var path = Path.Combine(_environment.ContentRootPath, "CSVData", $"{DateTime.Now.ToString("ddd-dd-M-yy-HH-mm-ss")}.csv");

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }

            await ParseCsv.Parse(SaveChangesAsync, path, Separator);
            await _context.SaveChangesAsync();
        }

        // tim corey use delegate async
        private async Task SaveChangesAsync(object entity)
        {
            await _context.AddAsync(entity);
            if (entity.GetType() == new RecordingSession().GetType())
            {
                await _context.SaveChangesAsync();
                UploadedRecordingSession = (RecordingSession)entity;
            }
        }

    }
}
