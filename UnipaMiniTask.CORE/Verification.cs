using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnipaMiniTask.CORE.Kernel;

namespace UnipaMiniTask.CORE
{
    public class Verification : BaseCore
    {
        public string TR_IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string BirthPlace { get; set; }
        public string RecidanceCity { get; set; }
        public bool IsApproved { get; set; }
        public DateTime VerificationDate { get; set; }
    }
}
