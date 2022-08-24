using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IAuth<Registration>
    {
        HospitalEntities db;

        public UserRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public Registration Authenticate(string Email, string Password)
        {
            return db.Registrations.FirstOrDefault(u=>u.Email.Equals(Email)
            
            && u.Password.Equals(Password));
        }
    }
}
