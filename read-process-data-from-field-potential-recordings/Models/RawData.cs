using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdvinsBallaProgram.Models
{
    public class RawData
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(8,7)")]
        public decimal Ch1Stim1 { get; set; }

        [Column(TypeName = "decimal(8,7)")]
        public decimal Ch1Stim2 { get; set; }

        [Column(TypeName = "decimal(8,7)")]
        public decimal Ch2Stim1 { get; set; }

        [Column(TypeName = "decimal(8,7)")]
        public decimal Ch2Stim2 { get; set; }

        [Column(TypeName = "decimal(8,7)")]
        public decimal Ch3Stim1 { get; set; }

        [Column(TypeName = "decimal(8,7)")]
        public decimal Ch3Stim2 { get; set; }

        [Column(TypeName = "decimal(8,7)")]
        public decimal Ch4Stim1 { get; set; }

        [Column(TypeName = "decimal(8,7)")]
        public decimal Ch4Stim2 { get; set; }
        public RecordingSession RecordingSession { get; set; }

    }
}
