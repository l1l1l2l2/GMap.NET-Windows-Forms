using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using GMap.NET.WindowsForms;

namespace Controllers
{
    internal class OverlayService
    {
        private readonly MarkersSelector _markersSelector;
        private readonly UnitOfWork _unitOfWork;
        public OverlayService()
        {
            _markersSelector = new MarkersSelector();
            _unitOfWork = new UnitOfWork();
        }
        //Для будущего DI
        public OverlayService(MarkersSelector markersSelector, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _markersSelector = markersSelector;
        }
        public GMapOverlay GetGMapOverlay()
        {
            return _markersSelector.GetOverlayMarkers(_unitOfWork.Coordinates.GetAll(), "Overlay");
        }
    }
}
