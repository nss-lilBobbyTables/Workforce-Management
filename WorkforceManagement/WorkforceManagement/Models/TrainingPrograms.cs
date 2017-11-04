using System;
using System.Collections.Generic;

namespace WorkforceManagement.Models
{
    public class TrainingPrograms
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual List<Employees> Employees { get; set; }
    }
}