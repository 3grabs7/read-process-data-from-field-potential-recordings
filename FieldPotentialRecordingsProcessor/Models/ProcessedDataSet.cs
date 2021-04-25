using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldPotentialRecordingsProcessor.Models
{
    public class ProcessedDataSet
    {
        public int Id { get; set; }

        public RecordingSession RecordingSession { get; set; }
    }
}
