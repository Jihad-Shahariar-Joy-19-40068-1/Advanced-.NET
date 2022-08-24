using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class DonorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string Phone_no { get; set; }
        public string Blood_group { get; set; }
        public string Organ_type { get; set; }
        public string Blood_pressure { get; set; }
        public string Diabetes { get; set; }
        public string Allergy { get; set; }
        public string Asthama { get; set; }
        public string Approval { get; set; }
        public string Approved_by { get; set; }
        public string Location { get; set; }
    }
}
