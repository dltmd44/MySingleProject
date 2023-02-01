using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySingleProject
{
    public class PatientDTO
    {
        public string PCode { get; set; }
        public string PName { get; set; }
        public DateTime PBirthday { get; set; }
        public bool PGender { get; set; }
        public string PPhoneNum { get; set; }
        public string PId { get; set; }
        public string PPwd { get; set; }
    }
}
