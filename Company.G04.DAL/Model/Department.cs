using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.DAL.Model
{
    public class Department : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }        
        public DateTime DateOfCreation { get; set; }
        public ICollection<Employee>? employees { get; set; } //Navigation Property
        public ICollection<Project>? Projects { get; set; } //Navigation Property
    }
}
