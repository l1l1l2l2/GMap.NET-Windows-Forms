using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class UnitOfWork
    {
        public Repository<Coordinate> Coordinates { get; private set; }
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public UnitOfWork()
        {
            Coordinates = new Repository<Coordinate>(_connectionString);
        }
        
    }
}
