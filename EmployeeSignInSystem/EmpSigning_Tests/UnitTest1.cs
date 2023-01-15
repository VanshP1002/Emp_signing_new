using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Services;
using EmployeeSignInSystem.Repositories;

using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace EmpSigning_Tests
{
    public class UnitTest1
    {
        private readonly Mock<IEmployeeRepository> _Userdb;

        
        public UnitTest1()
        {
            _Userdb = new Mock<IEmployeeRepository>();

        }

        public List<EmployeeTempBadge> newRec()
        {
            List<EmployeeTempBadge> newrec = new List<EmployeeTempBadge> {
                new EmployeeTempBadge(){
                Id = 103,
                EmployeeId = "1032",
                EmployeeFirstName = "bobby",
                EmployeeLastName = null,
                SignInT = DateTime.Now,
                SignOutT = null,
                AssignT = DateTime.Now,
                TempBadge = "abcsd"
                },
                new EmployeeTempBadge(){
                Id = 103,
                EmployeeId = "192",
                EmployeeFirstName = null,
                EmployeeLastName = "pra",
                SignInT = DateTime.Now,
                SignOutT = null,
                AssignT = null,
                TempBadge = null
                }

        };

            return newrec;
        }
        [Fact]
        public void SaveSignInTime_Test()
        {
            var data = newRec();
            _Userdb.Setup(a => a.SaveSignOutTime(data[1].EmployeeId)).Returns(1);
            var q = new EmployeeService(_Userdb.Object);


        }
    }
}
