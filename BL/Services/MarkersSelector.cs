using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data;
using GMap.NET.WindowsForms;

namespace Controllers
{
    internal class MarkersSelector
    {
        internal GMarkerGoogle GetMarker(Coordinate coordinate, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
        {
            GMarkerGoogle mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng(coordinate.Latitude, coordinate.Longitude), gMarkerGoogleType);
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);
            mapMarker.ToolTipText = coordinate.Id.ToString();
            mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            mapMarker.Tag = coordinate.Id;
            return mapMarker;
        }
        internal GMapOverlay GetOverlayMarkers(IEnumerable<Coordinate> coordinates, string name, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
        {
            GMapOverlay gMapMarkers = new GMapOverlay(name);
            foreach (Coordinate coordinate in coordinates)
            {
                gMapMarkers.Markers.Add(GetMarker(coordinate, gMarkerGoogleType));
            }
            return gMapMarkers;
        }
    }
}
