using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonMaker
{
    class ViewModel
    {
        private readonly string _basisSvgPath = @"D:\RibbonMaker\basisSvg.svg"; // TODO: Make this relative
        private readonly string _workingSvgPath = @"D:\RibbonMaker\workingSvg.svg"; // TODO: Make this relative
        public string WorkingSvgPath { get { return _workingSvgPath; } }

        private readonly string svgBaseContent;

        public ObservableCollection<ControlCircle> Circles { get; }

        public ViewModel()
        {
            svgBaseContent = File.ReadAllText(_basisSvgPath);

            Circles = new ObservableCollection<ControlCircle>();
            Circles.Add(new ControlCircle(this, 50, 50, 50));
            Circles.Add(new ControlCircle(this, 40, 200, 50));
            Circles.Add(new ControlCircle(this, 300, 200, 50));
            Circles.Add(new ControlCircle(this, 300, 400, 50));

            UpdateSvg();
        }

        public void Save(string filePath)
        {
            throw new NotImplementedException();
        }

        public static ViewModel Load(string filePath)
        {
            throw new NotImplementedException();
        }

        internal void Export(string exportPath)
        {
            throw new NotImplementedException();
        }

        internal void UpdateSvg()
        {
            string newStrokeContent = GetNewStrokeContent();
            string newContent = svgBaseContent.Replace("XXX", newStrokeContent);
            File.WriteAllText(WorkingSvgPath, newContent);
        }

        private string GetNewStrokeContent()
        {
            StringBuilder ret = new StringBuilder();

            ControlCircle firstCircle = Circles.First();
            ret.AppendFormat("M{0} {1}", firstCircle.Pos.X, firstCircle.Pos.Y);

            foreach (ControlCircle circle in Circles.Skip(1))
            {
                ret.AppendFormat(" L{0} {1}", circle.Pos.X, circle.Pos.Y);
            }

            return ret.ToString();
        }
    }
}
