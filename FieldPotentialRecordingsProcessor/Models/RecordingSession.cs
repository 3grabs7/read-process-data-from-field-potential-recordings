using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldPotentialRecordingsProcessor.Models
{
    public class RecordingSession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Rat Rat { get; set; }
        public ICollection<RawData> RawDatas { get; set; }
        public ICollection<ProcessedDataSet> ProcessedDataSets { get; set; }
    }
}
