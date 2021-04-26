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
        public async static Task Parse(Func<object, Task> addToDb,
            string filepath,
            string separator)
        {
            var recordingSession = NewSession();
            await addToDb(recordingSession);

            var enumerator = 1;
            var reflections = GetReflections();
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
                    reflections[j].SetValue(rawData, Convert.ToDecimal(row[j].Replace(".", ",")));
                }
                await addToDb(rawData);
            }
        }

        private static RecordingSession NewSession() => new RecordingSession()
        {
            Date = DateTime.Now,
            Rat = null
        };
        private static PropertyInfo[] GetReflections() => new RawData().GetType().GetProperties()
                .Where(p => !new string[] { "Id", "RecordingSession", "TimeInterval" }.Contains(p.Name))
                .ToArray();
    }
}