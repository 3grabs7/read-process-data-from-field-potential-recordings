using FieldPotentialRecordingsProcessor.Data;
using FieldPotentialRecordingsProcessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FieldPotentialRecordingsProcessor.Utils
{

    public static class ParseCsv
    {
        public async static Task Parse(Func<object, Task> save, string filepath, string separator)
        {
            var recordingSession = new RecordingSession()
            {
                Date = DateTime.Now,
                Rat = null
            };
            await save(recordingSession);

            var enumerator = 1;
            var reflections = new RawData().GetType().GetProperties()
                .Where(p => !new string[] { "Id", "RecordingSession", "TimeInterval" }.Contains(p.Name))
                .ToArray();
            var readCsv = File.ReadAllLines(filepath);
            for (int i = 1; i < readCsv.Length; i++)
            {
                var row = readCsv[i].Split(separator);
                var rawData = new RawData()
                {
                    RecordingSession = recordingSession,
                    TimeInterval = enumerator
                };
                enumerator++;
                for (int j = 0; j < reflections.Length; j++)
                {
                    reflections[j].SetValue(rawData, Convert.ToDecimal(row[j]));
                }
                await save(rawData);
            }
        }
    }
    //public class ParseCsv
    //{
    //    private string FilePath { get; set; }
    //    private string Separator { get; set; }
    //    private string LineSeparator { get; set; }

    //    public bool Success { get; set; } = true;

    //    public ParseCsv(string filePath)
    //    {
    //        FilePath = filePath;
    //        Separator = ";";
    //    }

    //    public ParseCsv(string filePath, string separator)
    //    {
    //        FilePath = filePath;
    //        Separator = separator;
    //    }

    //    public ParseCsv(string filePath, string separator, string lineSeparator)
    //    {
    //        FilePath = filePath;
    //        Separator = separator;
    //        LineSeparator = lineSeparator;
    //    }

    //    public void Parse(ApplicationDbContext context)
    //    {
    //        var recordingSession = new RecordingSession()
    //        {
    //            Date = DateTime.Now,
    //            Rat = null
    //        };
    //        context.Add(recordingSession);
    //        context.SaveChanges();
    //        try
    //        {
    //            var reflections = new RawData().GetType().GetProperties()
    //                .Where(p => !new string[] { "Id", "RecordingSession" }.Contains(p.Name))
    //                .ToArray();
    //            var readCsv = File.ReadAllLines(FilePath);
    //            for (int i = 1; i < readCsv.Length; i++)
    //            {
    //                var row = readCsv[i].Split(Separator);
    //                var rawData = new RawData() { RecordingSession = recordingSession };
    //                for (int j = 0; j < reflections.Length; j++)
    //                {
    //                    reflections[j].SetValue(rawData, Convert.ToDecimal(row[j]));
    //                }
    //                context.Add(rawData);
    //                context.SaveChanges();
    //            }
    //        }
    //        finally
    //        {
    //            Success = true;
    //        }

    //    }
    //}
}



//public IEnumerable<RawData> Parse(ApplicationDbContext context)
//{
//    var recordingSession = new RecordingSession()
//    {
//        Date = DateTime.Now,
//        Rat = null
//    };
//    context.Add(recordingSession);
//    context.SaveChanges();
//    try
//    {
//        var reflections = new RawData().GetType().GetProperties()
//            .Where(p => !new string[] { "Id", "RecordingSession" }.Contains(p.Name))
//            .ToArray();
//        var readCsv = File.ReadAllLines(FilePath);
//        for (int i = 1; i < readCsv.Length; i++)
//        {
//            var row = readCsv[i].Split(Separator);
//            var rawData = new RawData() { RecordingSession = recordingSession };
//            for (int j = 0; j < reflections.Length; j++)
//            {
//                reflections[j].SetValue(rawData, Convert.ToDecimal(row[j]));
//            }
//            yield return rawData;
//        }
//    }
//    finally
//    {
//        Success = true;
//    }

//}