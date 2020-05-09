using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Lab2.Models
{
    [Table("Employee")]
    public class Employee
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        [StringLength(120)]
        [EmailAddress]
        [Url]
        public string Email { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public Employee()
        {

        }
        public Employee(string _name, string _gender, string _email, string _address, int _salary)
        {
            Name = _name;
            Gender = _gender;
            Email = _email;
            Address = _address;
            Salary = _salary;
        }
    }
}