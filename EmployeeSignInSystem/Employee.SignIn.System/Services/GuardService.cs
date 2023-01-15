using EmployeeSignInSystem.DBContext;
using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSignInSystem.Services
{
    public class GuardService : IGuardService
    {
        private readonly IGuardRepository _guardRepo;
        public GuardService(IGuardRepository guardRepo)
        {
            _guardRepo = guardRepo;
        }


        public IEnumerable<EmpQueueDetails> BadgeQueueEmps()
        {
            return _guardRepo.BadgeQueueEmps();
        }

        public int SaveAssignTime(string TempBadge, string Id)
        {
            return _guardRepo.SaveAssignTime(TempBadge, Id);
        }

        public IEnumerable<EmpQueueDetails> BadgeOutEmps()
        {
            return _guardRepo.BadgeOutEmps();
        }
        EmployeeSigningSystemContext _context = new EmployeeSigningSystemContext();
        public IEnumerable<EmployeeTempBadge> GetReport(DateTime Sdate, DateTime Edate /*DateTime.MaxValue*/, string FirstName, string LastName )
        {
            //if(Edate == DateTime.MinValue)
            //{
            //    Edate = DateTime.MaxValue;
            //}
            IQueryable<EmployeeTempBadge> query = _context.EmployeeTempBadge.Where(x => x.EmployeeFirstName != null);
            if (!string.IsNullOrEmpty(FirstName))
            {
                query = query.Where(x=>x.EmployeeFirstName.Contains(FirstName));   

            }
            if(!string.IsNullOrEmpty(LastName))
            {
                query = query.Where(x => x.EmployeeLastName.Contains(LastName));

            }
            query = query.Where(x => x.SignInT >= Sdate && x.SignInT <= Edate && (x.SignOutT <= Edate || x.SignOutT == null)) ;

            return query.ToList();
        }
    }
}
