using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkforceManagement.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }

        public virtual List<Computers> Computers { get; set; }
        public virtual Departments Departments { get; set; }
        public virtual List<TrainingPrograms> TrainingPrograms { get; set; }

    }
}