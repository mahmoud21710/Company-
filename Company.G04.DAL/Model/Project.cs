using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.DAL.Model
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string City { get; set; }

        public int? DepartmentsId { get; set; } //F.k
        public Department? Departments { get; set; }//Navigation Property
    }
}
