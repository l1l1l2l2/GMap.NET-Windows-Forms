using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    internal class MainController
    {
        private readonly OverlayService _service;
        public GMapOverlay Overlay;
        public MainController()
        {
            _service = new OverlayService();
        }
        public MainController(OverlayService service)
        {
            _service = service;
        }
        public void GetOverlay()
        {
            Overlay = _service.GetGMapOverlay();
        }
    }
}
