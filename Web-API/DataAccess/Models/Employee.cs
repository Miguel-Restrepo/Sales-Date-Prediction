namespace DataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string TitleOfCourtesy { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [MaxLength(20)]
        public string PostalCode { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        // Relationship with Manager (opcional)
        [ForeignKey("Manager")]
        public int? MgrId { get; set; }
        public Employee Manager { get; set; }

        // Relationship with Order (1 to many)
        public ICollection<Order> Orders { get; set; }
    }
}