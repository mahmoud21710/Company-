using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.DAL.Model
{
    public class Dependent : BaseEntity
    {      
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int? ParentId { get; set; } //F.K
        public Employee? Parent { get; set; } //Navigation Property 
    }
}
