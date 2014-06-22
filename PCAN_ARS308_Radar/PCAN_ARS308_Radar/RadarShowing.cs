using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PCAN_ARS308_Radar
{
    class RadarShowing
    {
        public int X0 { get; set; }
        public int Y0 { get; set; }

        public RadarShowing(int x0, int y0)
        {
            this.X0 = x0;
            this.Y0 = y0;
        }



        public Point ToMonitorPoint(double R, double Angle )
         {
             return new Point((int)(this.X0 + R * Math.Cos(Angle * Math.PI / 180)), (int)(this.Y0 - R * Math.Sin(Angle * Math.PI / 180)));
         }

        public Point ToMonitorPoint(Point pt)
        {
            return new Point(this.X0 + pt.X, this.Y0 - pt.Y);
        }

        public void DrawCircle(Graphics g, uint n)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (uint i = 0; i < n; i++)
                g.DrawEllipse(new Pen(new SolidBrush(Color.DarkGreen)), i * X0 / n, i * Y0 / n, 2 * (X0 - i * X0 / n), 2 * (Y0 - i * Y0 / n));
        }

        public void DrawCrossLine(Graphics g, uint n)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (uint i = 0; i < n; i++)
                g.DrawLine(new Pen(new SolidBrush(Color.DarkGreen)), new Point(X0, Y0), this.ToMonitorPoint(X0, 360 / n * i));
        }

        public void DrawObject(Graphics g, Point pt)
        {
            pt = ToMonitorPoint(pt);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawEllipse(new Pen(new SolidBrush(Color.White)), Convert.ToInt16(pt.X - 2), Convert.ToInt16(pt.Y - 2), 4, 4);      
        }


     
    }
}
