using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class AdminAppointmentModel
    {
        public int Id { get; set; }
        public string Doctor_Name { get; set; }
        public string Patient_Name { get; set; }
        public string Problem_list { get; set; }
        public string Prescription_File { get; set; }
        public string Prescription { get; set; }
        public string Payment_status { get; set; }
        public string Prescribed { get; set; }
    }
}
