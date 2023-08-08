//namespace NewCrudApp.Views.Shared.Models
namespace NewCrudApp.Models
{
    public class AddEmployeeModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string City { get; set; }
    }
}
