// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Whereami
{
	[Register ("WhereamiViewController")]
	partial class WhereamiViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField locationTitleField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView activityIndicator { get; set; }

		[Outlet]
		MonoTouch.MapKit.MKMapView worldView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (locationTitleField != null) {
				locationTitleField.Dispose ();
				locationTitleField = null;
			}

			if (activityIndicator != null) {
				activityIndicator.Dispose ();
				activityIndicator = null;
			}

			if (worldView != null) {
				worldView.Dispose ();
				worldView = null;
			}
		}
	}
}
