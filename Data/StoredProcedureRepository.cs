using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Repository version on stored procedures
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StoredProcedureRepository<T> : RepositoryBase, IRepository<T> where T : DomainObject
    {
        private readonly string _tableName;
        public StoredProcedureRepository(string connectionString) : base(connectionString)
        {
            _tableName = this.GetType().GenericTypeArguments[0].Name;
        }
        public IEnumerable<T> GetAll()
        {
            string procedure = $"Get{_tableName}";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);

                return MapDataTableToList(ds.Tables[0]);
            }
        }

        public void Update(T item)
        {
            string procedure = $"Update{_tableName}";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var property in typeof(T).GetProperties())
                {
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = $"@{property.Name}",
                        Value = property.GetValue(item)
                    });
                }
                command.ExecuteScalar();
            }
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
