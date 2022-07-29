using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class RepositoryBase
    {
        protected readonly string _connectionString;
        public RepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
