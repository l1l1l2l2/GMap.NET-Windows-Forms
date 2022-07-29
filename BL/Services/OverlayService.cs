using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using GMap.NET.WindowsForms;

namespace Controllers.Services
{
    internal class OverlayService
    {
        private readonly OverlayMarkersSelector _markersSelector;
        private readonly UnitOfWork _unitOfWork;
        public OverlayService()
        {
            _markersSelector = new OverlayMarkersSelector();
            _unitOfWork = new UnitOfWork();
        }
        //TODO: DI
        public OverlayService(OverlayMarkersSelector markersSelector, UnitOfWork unitOfWork)
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
