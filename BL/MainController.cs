using Controllers.Services;
using GMap.NET.WindowsForms;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class MainController
    {
        private readonly OverlayService _overlayService;
        private readonly CoordinateService _coordinateService;
        public GMapOverlay Overlay
        {
            get => _overlayService.GetGMapOverlay();
            set { }
        }
        //TODO: DI
        public MainController()
        {
            _overlayService = new OverlayService();
            _coordinateService = new CoordinateService();
        }
        public void OnUpdate(int idCoordinate, double latitude, double longitude, bool isDeleted = false)
        {

            _coordinateService.UpdateCoordinate(new Coordinate
            {
                Id = idCoordinate,
                Latitude = latitude,
                Longitude = longitude,
                IsDeleted = isDeleted
            });
        }

        //TODO: DI
        //public MainController(OverlayService service)
        //{
        //    _service = service;
        //}
    }
}
