using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace InTurn_Model
{
    public interface IContact
    {
        string Email { get; }
        string PhoneNum { get; }
    }

    //START EMPLOYER METADATA
    [MetadataType(typeof(EmployerMetaData))]
    public partial class Employer:IContact
    {
        public HttpPostedFileBase FileName { get; set; }
        private sealed class EmployerMetaData
        {
            [Display(Name = "Employer ID")]
            public int EmployerID { get; set; }
            [Display(Name = "Phone Number")]
            public string PhoneNum { get; set; }
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
        }
    }//END EMPLOYER METADATA

    //START EMPLOYEE METADATA
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
        private sealed class EmployeeMetaData
        {
            [Display(Name = "Employee ID")]
            public int EmployeeID { get; set; }
            [Display(Name = "Student ID")]
            public int StudentID { get; set; }
            [Display(Name = "Faculty ID")]
            public Nullable<int> FacultyID { get; set; }
            [Display(Name = "Midterm Grade")]
            public string MidtermExam { get; set; }
            [Display(Name = "Final Grade")]
            public string FinalExam { get; set; }
        }
    }//END EMPLOYEE METADATA

    //START STUDENT METADATA
    [MetadataType(typeof(StudentMetaData))]
    public partial class Student:IContact
    {
        public HttpPostedFileBase FileName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        private sealed class StudentMetaData
        {
            [Display(Name = "Student ID")]
            public int StudentID { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Phone Number")]
            public string PhoneNum { get; set; }
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
            [Display(Name ="Name")]
            public string FullName { get; set;}
            [Display(Name = "Current Student")]
            public bool Current { get; set; }
        }
    }//END STUDENT METADATA

    //START FACULTY METADATA
    [MetadataType(typeof(FacultyMetaData))]
    public partial class Faculty : IContact
    {
        public HttpPostedFileBase FileName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        private sealed class FacultyMetaData
        {
            [Display(Name = "Faculty ID")]
            public int FacultyID { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Phone Number")]
            public string PhoneNum { get; set; }
            [Display(Name ="Name")]
            public string FullName { get; set; }
        }
    }//END FACULTY METADATA

    //START COURSE METADATA
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
        private sealed class CourseMetaData
        {
            [Display(Name = "Course ID")]
            public int CourseID { get; set; }
            [Display(Name = "Description")]
            public string Desc { get; set; }
            [Display(Name = "Department")]
            public string Dept { get; set; }
        }
    }//END COURSE METADATA

    //START MAJOR METADATA
    [MetadataType(typeof(MajorMetaData))]
    public partial class Major
    {
        private sealed class MajorMetaData
        {
            [Display(Name = "Major ID")]
            public int MajorID { get; set; }
            [Display(Name = "Description")]
            public string Desc { get; set; }
        }
    }//END MAJOR METADATA

    //START JOB METADATA
    [MetadataType(typeof(JobMetaData))]
    public partial class Job
    {
        private sealed class JobMetaData
        {
            [Display(Name = "Job ID")]
            public int JobID { get; set; }
            [Display(Name = "Employer ID")]
            public int EmployerID { get; set; }
            [Display(Name = "Employee ID")]
            public int EmployeeID { get; set; }
        }
    }//END JOB METADATA

    //START JOBPOSTING METADATA
    [MetadataType(typeof(JobPostingMetaData))]
    public partial class JobPosting
    {
        public int AppCount => Applications.Count;
        private sealed class JobPostingMetaData
        {
            [Display(Name = "Job Posting ID")]
            public int JobPostingID { get; set; }
            [Display(Name = "Employer ID")]
            public int EmployerID { get; set; }
            [Display(Name = "Description")]
            public string Desc { get; set; }
            [Display(Name = "Job Type")]
            public JobType JobType { get; set; }
            [Display(Name = "Employment Type")]
            public TimeType TimeType { get; set; }
            [DataType(DataType.Currency)]
            public decimal Wage { get; set; }

            
        }
    }//END JOBPOSTING METADATA

    //Application partial class for Uploading

    public partial class Application:IContact
    {

        //For uploading documents like Resume and Transcript
        public HttpPostedFileBase FileName { get; set; }

        public string Email => ((IContact)Student).Email;

        public string PhoneNum => ((IContact)Student).PhoneNum;
    }

}

