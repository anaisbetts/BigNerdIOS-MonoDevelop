using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;

namespace Whereami
{
    public partial class WhereamiViewController : UIViewController
    {
        CLLocationManager locationManager;
    
        public WhereamiViewController () : base ("WhereamiViewController", null)
        {
        }
        
        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();
            
            // Release any cached data, images, etc that aren't in use.
        }
        
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            
            locationManager = new CLLocationManager();
            locationManager.DesiredAccuracy = 0.2;
            locationManager.Delegate = new WhereAmILocationDelegate(x => foundLocation(x));
            
            activityIndicator.Hidden = true;
            
            worldView.ShowsUserLocation = true;
            worldView.Delegate = new WhereAmIMapKitDelegate();
            
            locationTitleField.Delegate = new WAIAnonFieldDelegate(field => {
                findLocation();
                field.ResignFirstResponder();
                return true;
            });
        }
        
        public override void ViewDidUnload ()
        {
            base.ViewDidUnload ();
            
            // Clear any references to subviews of the main view in order to
            // allow the Garbage Collector to collect them sooner.
            //
            // e.g. myOutlet.Dispose (); myOutlet = null;
            
            ReleaseDesignerOutlets ();
        }
        
        public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
        }
        
        void findLocation()
        {
            locationManager.StartUpdatingLocation();
            activityIndicator.StartAnimating();
            locationTitleField.Hidden = true;
        }
        
        void foundLocation(CLLocation loc)
        {
            var mapPoint = new BNRMapPoint(locationTitleField.Text) { 
                Coordinate = loc.Coordinate,
            };
            
            worldView.AddAnnotation(mapPoint);
            
            locationTitleField.Text = "";
            activityIndicator.StopAnimating();
            locationTitleField.Hidden = false;
            locationManager.StopUpdatingLocation();
        }
    }
    
    public class WhereAmILocationDelegate : CLLocationManagerDelegate
    {
        readonly Action<CLLocation> reallyFoundLocation;
        
        public WhereAmILocationDelegate(Action<CLLocation> reallyFoundLocation)
        {
            this.reallyFoundLocation = reallyFoundLocation;
        }
    
        public override void UpdatedLocation (CLLocationManager manager, CLLocation newLocation, CLLocation oldLocation)
        {
            Console.WriteLine("{0},{1}", newLocation.Coordinate.Latitude, newLocation.Coordinate.Longitude);
            
            if ((DateTime.Now - ((DateTime)newLocation.Timestamp)) > TimeSpan.FromMinutes(3)) {
                return;
            }
            
            reallyFoundLocation(newLocation);
        }
        
        public override void Failed (CLLocationManager manager, NSError error)
        {
            Console.WriteLine("Could not find location: {0}", error);
        }
    }
    
    public class WhereAmIMapKitDelegate : MKMapViewDelegate
    {
        public override void DidUpdateUserLocation (MKMapView mapView, MKUserLocation userLocation)
        {
            mapView.SetRegion(new MKCoordinateRegion(userLocation.Coordinate, new MKCoordinateSpan(0.1, 0.1)), true);
        }
    }
    
    public class WAIAnonFieldDelegate : UITextFieldDelegate
    {
        readonly Func<UITextField, bool> shouldReturn;
        public WAIAnonFieldDelegate(Func<UITextField, bool> shouldReturn)
        {
            this.shouldReturn = shouldReturn;
        }
    
        public override bool ShouldReturn (UITextField textField)
        {
            return shouldReturn(textField);
        }
    }
}
