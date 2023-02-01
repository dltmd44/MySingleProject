using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingleProject
{
    public class Appointment_hisDTO
    {
        public int AppointCode { get; set; }
        public int PatientCode { get; set; }
        public int DoctorCode { get; set; }
        public DateTime AppointDate { get; set; }
        public Int16 AppointTimeH { get; set; }
        public string AppointTimeM { get; set; }
        public Int16 AppointStat { get; set; }
        public DateTime AppointMoment { get; set; }
        public DateTime DiagnosisTime { get; set; }
        public string DiagnosisDetail { get; set; }
    }
}
