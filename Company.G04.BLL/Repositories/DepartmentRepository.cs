using Company.G04.BLL.Interfaces;
using Company.G04.DAL.Data.Contexts;
using Company.G04.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.BLL.Repositories
{
    //CLR
    public class DepartmentRepository : GenericRepository<Department> ,IDepartmentRepository
    {
       

        public DepartmentRepository(AppDbContext context):base(context)//Ask Clr Create Object From AppDbContext
        {
            
        }       
    }
}
