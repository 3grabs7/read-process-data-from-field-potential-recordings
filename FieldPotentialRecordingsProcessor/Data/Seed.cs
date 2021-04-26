using FieldPotentialRecordingsProcessor.Data;
using FieldPotentialRecordingsProcessor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldPotentialRecordingsProcessor
{
    static class Seed
    {
        private static readonly string[] CsvFilePaths = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "CSVData"));
        private static ApplicationDbContext _context;

        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            // Dependency Injection
            _context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            foreach (var filepath in CsvFilePaths)
            {
                await ParseCSV(filepath);
            }
        }

        private async static Task ParseCSV(string filePath)
        {
            var recordingSession = new RecordingSession()
            {
                Date = DateTime.Now,
                Rat = null
            };
            await _context.AddAsync(recordingSession);
            await _context.SaveChangesAsync();

            var enumerator = 1;
            var readCsv = File.ReadAllLines(filePath);
            for (int i = 1; i < readCsv.Length; i++)
            {
                var row = readCsv[i].Split(";");
                await _context.AddAsync(new RawData()
                {
                    Ch1Stim1 = Convert.ToDecimal(row[0]),
                    Ch1Stim2 = Convert.ToDecimal(row[1]),
                    Ch2Stim1 = Convert.ToDecimal(row[2]),
                    Ch2Stim2 = Convert.ToDecimal(row[3]),
                    Ch3Stim1 = Convert.ToDecimal(row[4]),
                    Ch3Stim2 = Convert.ToDecimal(row[5]),
                    Ch4Stim1 = Convert.ToDecimal(row[6]),
                    Ch4Stim2 = Convert.ToDecimal(row[7]),
                    TimeInterval = enumerator,
                    RecordingSession = recordingSession
                });
                enumerator++;
            }
            await _context.SaveChangesAsync();
        }
    }
}

