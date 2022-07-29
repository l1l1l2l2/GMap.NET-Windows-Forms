using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    //Новая версия репозитория на хранимых процедурах
    public class StoredProcedureRepository<T> : RepositoryBase, IRepository<T> where T : DomainObject
    {
        private readonly string _tableName;
        public StoredProcedureRepository(string connectionString) : base(connectionString)
        {
            _tableName = this.GetType().GenericTypeArguments[0].Name;
        }
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
