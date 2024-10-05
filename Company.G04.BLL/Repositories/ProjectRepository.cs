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
    public class ProjectRepository : GenericRepository<Project>,IProjectRepository
    {
        public ProjectRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
