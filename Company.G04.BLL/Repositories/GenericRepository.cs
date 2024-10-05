using Company.G04.BLL.Interfaces;
using Company.G04.DAL.Data.Contexts;
using Company.G04.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Employee)) 
            {
                return (IEnumerable<T>)await _context.Employees.Include(E=>E.WorkFor).ToListAsync();
            }
            if(typeof(T) == typeof(Dependent))
            {
                return (IEnumerable<T>)await _context.Dependents.Include(D=>D.Parent).ToListAsync();
            }
            if(typeof(T) == typeof(Project))
            {
                return (IEnumerable<T>)await _context.Projects.Include(P=>P.Departments).ToListAsync();
            }
           return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {
            //_context.Set<T>().Add(entity);
            await _context.AddAsync(entity);
           
        }
        public void Update(T entity)
        {
            _context.Update(entity);
            
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
           
        }

       

        

        
    }
}
