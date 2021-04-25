using EdvinsBallaProgram.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdvinsBallaProgram
{
    static class Seed
    {
        private static readonly string CSVFolderPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\", "CSVData");
        private static string FilePath { get; set; }

        public static void InitializeSeed(string CSVName)
        {
            FilePath = Path.Combine(CSVFolderPath, CSVName);
            ParseCSV();
        }

        private static void ParseCSV()
        {
            var readCsv = File.ReadAllLines(FilePath);
            var recordingSession = new RecordingSession()
            {
                Date = DateTime.Now,
                Rat = null
            };
            var rawDataCollection = new List<RawData>();
            for (int i = 1; i < readCsv.Length; i++)
            {
                var row = readCsv[i].Split(";");
                rawDataCollection.Add(new RawData()
                {
                    Ch1Stim1 = Convert.ToDecimal(row[0]),
                    Ch1Stim2 = Convert.ToDecimal(row[1]),
                    Ch2Stim1 = Convert.ToDecimal(row[2]),
                    Ch2Stim2 = Convert.ToDecimal(row[3]),
                    Ch3Stim1 = Convert.ToDecimal(row[4]),
                    Ch3Stim2 = Convert.ToDecimal(row[5]),
                    Ch4Stim1 = Convert.ToDecimal(row[6]),
                    Ch4Stim2 = Convert.ToDecimal(row[7]),
                    RecordingSession = recordingSession

                });
            }
        }
    }
}

