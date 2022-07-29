using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    /// <summary>
    /// Old version of repository in SQL. Update method is not implemented.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlRepository<T> : RepositoryBase, IRepository<T> where T : DomainObject
    {
        private readonly string _tableName;

        public SqlRepository(string connectionString) : base(connectionString)
        {
            _tableName = this.GetType().GenericTypeArguments[0].Name;
        }
        public IEnumerable<T> GetAll()
        {
            string sql = $"SELECT * FROM {_tableName}";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();
                adapter.Fill(ds);

                return MapDataTableToList(ds.Tables[0]);
            }

        }
        //Не имплементирован т.к переключился на репозиторий с хранимыми процедурами
        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<T> MapDataTableToList(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).AsEnumerable();
        }
    }
}
