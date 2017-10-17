namespace WorkforceManagement.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DepartmentType Type { get; set; }
        
    }

    public enum DepartmentType
    {
        Apparel,
        Shoes,
        Housewares,
        Electronics,
        Toys,
        PartySupplies,
        Beer
    }
}