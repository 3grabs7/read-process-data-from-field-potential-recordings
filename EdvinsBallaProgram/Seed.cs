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

        }
    }
}
