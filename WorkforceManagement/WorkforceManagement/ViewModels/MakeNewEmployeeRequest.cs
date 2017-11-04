using System;
using System.ComponentModel.DataAnnotations;

namespace WorkforceManagement.ViewModels
{
    public class MakeNewEmployeeRequest
    {
        [Required]
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public int DepartmentId { get; set; }
    }
}