using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static HospitalEntities db = new HospitalEntities();
        public static IRepo_Patient<Registration, int, bool> GetRegistrationDataAccess()
        {
            return new PatientRepo(db);
        }
        public static IRepo_Patient<Appointment, int, bool> GetAppointmentDataAccess()
        {
            return new AppointmentRepo(db);
        }
        public static IRepo_Patient<Donor, int, bool> GetDonorDataAccess()
        {
            return new DonorRepo(db);
        }
        public static IRepo_Patient<Epatient, int, bool> GetEpatientDataAccess()
        {
            return new EpatientRepo(db);
        }
        public static IAuth<Registration> GetAuthDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepo_Patient<Token, string, Token> GetTokenDataAccess()
        {
            return new TokenRepo(db);
        }
    }
}
