using System;
using System.Drawing;
using MonoTouch.UIKit;

namespace Hypnosister
{
    public class HypnosisView : UIView
    {
        public HypnosisView ()
        {
            BackgroundColor = UIColor.Clear;
        }
        
        public override void Draw (RectangleF rect)
        {
            base.Draw (rect);
            var ctx = UIGraphics.GetCurrentContext();
            
            var center = new PointF(Bounds.X + Bounds.Width / 2.0f, Bounds.Y + Bounds.Height / 2.0f);
            
            var maxRadius = distance(Bounds.Width, Bounds.Height) / 4.0f;
            
            ctx.SetLineWidth(10);
            ctx.SetRGBStrokeColor(0.6f, 0.6f, 0.6f, 1.0f);
            ctx.AddArc(center.X, center.Y, maxRadius, 0.0f, (float)Math.PI * 2.0f, true);
            
            ctx.StrokePath();
        }
        
        // In the book they call the C function hypot()
        float distance(float x, float y)
        {
            return (float)Math.Sqrt(x*x + y*y);
        }
    }
}

