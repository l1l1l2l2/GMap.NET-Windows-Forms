using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class MainController
    {
        private readonly OverlayService _service;
        public GMapOverlay Overlay
        {
            get => _service.GetGMapOverlay();
            set { }
        }
        public MainController()
        {
            _service = new OverlayService();
        }
        //Для будущего DI
        //public MainController(OverlayService service)
        //{
        //    _service = service;
        //}
    }
}
