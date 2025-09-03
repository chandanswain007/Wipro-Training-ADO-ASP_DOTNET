using Repos.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServiceInterface<T> where T : class
    {
        IEnumerable<T> GetList();
    }
    public class ServiceClass<T>:IServiceInterface<T> where T:class
    {
        private readonly IRepogeneric<T> _repo;
        public ServiceClass(IRepogeneric<T> repo)
        {
            _repo = repo; 
        }
        public IEnumerable<T> GetList()
        {
            return _repo.GetAll();
        }
    }
}
