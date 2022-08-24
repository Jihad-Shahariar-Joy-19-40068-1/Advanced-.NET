using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone_no { get; set; }
        public string Type { get; set; }
        public string Blood_group { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public byte[] Image { get; set; }
    }
}
