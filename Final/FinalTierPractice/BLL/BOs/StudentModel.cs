using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Uid { get; set; }
        public string Dob { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}
