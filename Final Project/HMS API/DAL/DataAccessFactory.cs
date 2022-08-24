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
        public static IRepo<Registration, int, bool> GetRegistrationDataAccess()
        {
            return new RegistrationRepo(db);
        }
        public static IRepo<Appointment, int, bool> GetAppointmentDataAccess()
        {
            return new AppointmentRepo(db);
        }
        public static IRepo<Epatient, int, bool> GetEpatientDataAccess()
        {
            return new EpatientRepo(db);
        }
        public static IRepo<Notice, int, bool> GetNoticeDataAccess()
        {
            return new NoticeRepo(db);
        }
        public static IRepo<ProblemList, int, bool> GetProblemListDataAccess()
        {
            return new ProblemListRepo(db);
        }
        public static IRepo<Donor, int, bool> GetDonorDataAccess()
        {
            return new DonorRepo(db);
        }
        public static IAuth<Registration> GetAuthDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepo<Token, string, Token> GetTokenDataAccess()
        {
            return new TokenRepo(db);
        }
        /////
        public static AdminIRepo<Appointment, int> GetAdminAppointmentDataAccess()
        {
            return new AdminAppointmentRepo(db);
        }
        public static AdminIRepo<Epatient, int> GetAdminEpatientDataAccess()
        {
            return new AdminEpatientRepo(db);
        }
        public static AdminIRepo<Notice, int> GetAdminNoticeDataAccess()
        {
            return new AdminNoticeRepo(db);
        }
        public static AdminIRepo<Registration, int> GetAdminUserDataAccess()
        {
            return new AdminUserRepo(db);
        }
        public static AdmindoctorRepo<Registration, int> GetAdminDoctorDataAccess()
        {
            return new AdminUserRepo(db);
        }
        public static AdminPatientRepo<Registration, int> GetAdminPatientDataAccess()
        {
            return new AdminUserRepo(db);
        }
    }
}
