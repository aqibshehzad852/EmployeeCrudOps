﻿namespace NewCrudApp.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string City { get; set; }

    }
}
