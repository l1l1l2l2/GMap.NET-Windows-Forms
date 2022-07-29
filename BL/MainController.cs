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
    //Контроллер представления MainWindow
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
        /// <summary>
        /// Update Coordinate in DB
        /// </summary>
        /// <param name="idCoordinate"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="isDeleted"></param>
        public void OnUpdate(int idCoordinate, double latitude, double longitude)
        {
            _coordinateService.UpdateCoordinate(new Coordinate
            {
                Id = idCoordinate,
                Latitude = latitude,
                Longitude = longitude,
            });
        }
    }
}
