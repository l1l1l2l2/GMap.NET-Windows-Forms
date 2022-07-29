using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Services
{
    internal class CoordinateService
    {
        private readonly UnitOfWork _unitOfWork;
        //TODO : DI
        public CoordinateService()
        {
            _unitOfWork = new UnitOfWork();
        }
        
        internal void UpdateCoordinate(Coordinate coordinate)
        {
            _unitOfWork.Coordinates.Update(coordinate);
        }
    }
}
