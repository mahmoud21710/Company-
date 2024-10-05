using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentRepository DepartmentRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IDependentRepository DependentRepository { get; }
        public IProjectRepository ProjectRepository { get;  }

        Task<int> CompleteAsync();
    }
}
