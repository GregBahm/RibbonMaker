using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace RibbonMaker
{
    class ControlCircle : INotifyPropertyChanged
    {
        private Point _pos;
        public Point Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                OnPropertyChanged(nameof(Pos));
            }
        }

        public float Radius { get; set; }

        private bool _isHighlit;
        public bool IsHighlit
        {
            get { return _isHighlit; }
            set
            {
                _isHighlit = value;
                OnPropertyChanged(nameof(IsHighlit));
                OnPropertyChanged(nameof(Fill));
            }
        }

        private Point _dragStartMousePos;
        private Point _dragStartObjPos;

        private bool _isDragging;
        public bool IsDragging
        {
            get { return _isDragging; }
            set
            {
                _isDragging = value;
                OnPropertyChanged(nameof(IsDragging));
                OnPropertyChanged(nameof(Fill));
            }
        }

        public SolidColorBrush Fill
        {
            get
            {
                if(IsDragging)
                {
                    return Brushes.Blue;
                }
                return IsHighlit ? Brushes.Red : Brushes.Black;
            }
        }

        private readonly ViewModel _mothership;

        public event PropertyChangedEventHandler PropertyChanged;

        public ControlCircle(ViewModel mothership, float xPos, float yPos, float radius)
        {
            Pos = new Point(xPos, yPos);
            Radius = radius;
            _mothership = mothership;
        }
        
        internal void OnMouseLeave()
        {
            IsHighlit = false;
        }

        internal void OnMouseEnter()
        {
            IsHighlit = true;
        }

        internal void OnMouseDown(Point startPos)
        {
            IsDragging = true;
            _dragStartMousePos = startPos;
            _dragStartObjPos = Pos;
        }

        internal void OnMouseMove(MouseButtonState leftButton, Point currentPos)
        {
            if(IsDragging)
            {
                Vector dif = _dragStartMousePos - currentPos;
                Pos = _dragStartObjPos - dif;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void OnMouseUp()
        {
            IsDragging = false;
        }
    }
}
