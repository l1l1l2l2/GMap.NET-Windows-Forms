using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;

namespace View
{
    public partial class MainForm : Form
    {
        class MainFormState
        {
            internal bool IsMouseDown;
            internal GMapMarker HoverMarker;
            internal GMapMarker DraggingMarker;
        }
        internal MainController Controller;
        private MainFormState _state = new MainFormState();
        public MainForm()
        {
            Controller = new MainController();
            InitializeComponent();
        }

        private void gMapControl_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //выбор подгрузки карты – онлайн или из ресурсов
            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; //провайдер карты
            gMapControl.MinZoom = 2; //минимальный зум
            gMapControl.MaxZoom = 16; //максимальный зум
            gMapControl.Zoom = 4; //зум при открытии
            gMapControl.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);// точка в центре карты при открытии
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            gMapControl.CanDragMap = true; // перетаскивание карты мышью
            gMapControl.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            gMapControl.ShowCenter = false; //показывать или скрывать красный крестик в центре
            gMapControl.ShowTileGridLines = false; //показывать или скрывать тайлы

            gMapControl.Overlays.Add(Controller.Overlay);//добавление overlay
        }

        private void gMapControl_OnMarkerEnter(GMapMarker item)
        {
            _state.HoverMarker = item;
        }

        private void gMapControl_OnMarkerLeave(GMapMarker item)
        {

            _state.HoverMarker = null;
        }

        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            _state.IsMouseDown = true;
            if (_state.HoverMarker != null)
            {
                gMapControl.DragButton = MouseButtons.None;
                _state.DraggingMarker = _state.HoverMarker;
            }
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(_state.IsMouseDown == true && _state.DraggingMarker != null)
            {
                var latLong = gMapControl.FromLocalToLatLng(e.Location.X, e.Location.Y);
                _state.DraggingMarker.Position = latLong;
            }
        }

        private void gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            _state.IsMouseDown = false;
            if (_state.DraggingMarker != null)
            {
                Controller.OnUpdate(
                    Convert.ToInt32(_state.DraggingMarker.Tag), 
                    _state.DraggingMarker.Position.Lat,
                    _state.DraggingMarker.Position.Lng);
                gMapControl.DragButton = MouseButtons.Left;
                _state.DraggingMarker = null;
            }
        }
    }
    
}
