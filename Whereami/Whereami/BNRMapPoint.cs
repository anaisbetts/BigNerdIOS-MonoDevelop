using System;
using MonoTouch.CoreLocation;
using MonoTouch.MapKit;

namespace Whereami
{
    public class BNRMapPoint : MKAnnotation
    {
        public override CLLocationCoordinate2D Coordinate { get; set;}
        
        string title;
        public override string Title {
            get { return title; }
        }
        
        public BNRMapPoint (string title)
        {
            this.title = title;
        }
    }
}

