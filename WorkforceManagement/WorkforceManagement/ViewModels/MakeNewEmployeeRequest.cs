using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WorkforceManagement.Models;

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
        public int ComputerId { get; set; }
        public List<TrainingPrograms>  TrainingPrograms { get; set; }

         
    }
}