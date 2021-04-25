using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdvinsBallaProgram.Models
{
    public enum Treatment
    {
        Amphetamines, Vehicles
    }
    public class Rat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public Treatment Treatment { get; set; }
        public RecordingSession RecordingSession { get; set; }
    }
}
