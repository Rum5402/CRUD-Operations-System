using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; } //pk

        [Required(ErrorMessage="Name Is Required")]
        [MaxLength(50,ErrorMessage ="MaxLength is 50 chars.")]
        [MinLength(5,ErrorMessage ="MinLength is 5 chars.")]  //Not in db but in frontend validation
        public string Name { get; set; }

        [Range(22,35,ErrorMessage ="Age Must be in range from 22 to 35")]
        public int? Age { get; set; }

        [RegularExpression("^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address Must be Like 123-Street-City-Country")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        //FK Optional => OnDelete : Restrict
        //FK Required => OnDelete : Cascade
        [InverseProperty("Employees")]
        public Department Department { get; set; }
    }
}
