using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class EpatientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone_no { get; set; }
        public string Type { get; set; }
        public string Blood_group { get; set; }
        public string Checked { get; set; }
    }
}
