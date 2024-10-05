﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.DAL.Model
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int? Age { get; set; }       
        public string Address { get; set; }       
        public decimal Salary { get; set; }
        public string Email { get; set; }        
        public string PhoneNumber { get; set; }
        public string? ImageName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfCreation { get; set; }= DateTime.Now;
        public int? WorkForId { get; set; } //F.k
        public Department? WorkFor { get; set; }  //Navigation Property
        public ICollection<Dependent>? dependents { get; set; } //Navigation Property

    }
}
