using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Update(T item);
    }
}
