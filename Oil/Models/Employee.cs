using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oil.Models
{
    public class Employee
        {
            public int Id { get; set; }
            public int SexId { get; set; }
            public int EducationLevelId { get; set; }
            public int DepartmentId { get; set; }
            public int PostId { get; set; }
            public int QualificationId { get; set; }
            public string LastName { get; set; }
            public string Name { get; set; }
            public string MiddleName { get; set; }
            public string PassportSeries { get; set; }
            public string PassportNumber { get; set; }
            public DateTime PassportIssueDate { get; set; }
            public string WhoIssuedPassport { get; set; }
            public string SubdivisionCode { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string ResidentialAddress { get; set; }
            public string RegistrationAddress { get; set; }

        public Employee() { }

            public Employee(
                int id,
                int sexId,
                int educationLevelId,
                int departmentId,
                int postId,
                int qualificationId,
                string lastName,
                string name,
                string middleName,
                string passportSeries,
                string passportNumber,
                DateTime passportIssueDate,
                string whoIssuedPassport,
                string subdivisionCode,
                string phoneNumber,
                string email,
                string residentialAddress,
                string registrationAddress)
            {
                Id = id;
                SexId = sexId;
                EducationLevelId = educationLevelId;
                DepartmentId = departmentId;
                PostId = postId;
                QualificationId = qualificationId;
                LastName = lastName;
                Name = name;
                MiddleName = middleName;
                PassportSeries = passportSeries;
                PassportNumber = passportNumber;
                PassportIssueDate = passportIssueDate;
                WhoIssuedPassport = whoIssuedPassport;
                SubdivisionCode = subdivisionCode;
                PhoneNumber = phoneNumber;
                Email = email;
                ResidentialAddress = residentialAddress;
                RegistrationAddress = registrationAddress;
            }
        }
    }