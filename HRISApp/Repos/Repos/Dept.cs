using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Repos
{
    public class Dept : IDept
    {
        private readonly RepoContext _context;
        public Dept(RepoContext context)
        {
            _context = context;
        }
        public string AddDept(Department dept)
        {
            try
            {
                _context.Departments.Add(dept);
                _context.SaveChanges();
                return $"Successful addition of department by name {dept.Name}";
            }
            catch(Exception ex)
            {
                return "Department Addition failed with error: " + ex.InnerException;
            }

        }

        public string EditDept(Department dept)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public string RemoveDept(int id)
        {
            _context.Remove(_context.Departments.Find(id));
            return "Success";
        }
    }
}
