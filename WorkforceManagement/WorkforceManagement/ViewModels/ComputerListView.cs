using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkforceManagement.Models;

namespace WorkforceManagement.ViewModels
{
    public class ComputerListView
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Employees Employees { get; set; }
    }
}