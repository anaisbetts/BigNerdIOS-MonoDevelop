using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Hypnosister
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            // create a new window instance based on the screen size
            window = new UIWindow (UIScreen.MainScreen.Bounds);
            
            var scrollView = new UIScrollView(window.Bounds);
            window.AddSubview(scrollView);
            
            var view = new HypnosisView() { Frame = window.Bounds };
            var anotherView = new HypnosisView() { Frame = new RectangleF(window.Bounds.Width, 0.0f, window.Bounds.Width, window.Bounds.Height) };
            
            scrollView.AddSubview(view);
            scrollView.AddSubview(anotherView);
            scrollView.ContentSize = new SizeF(window.Bounds.Width * 2.0f, window.Bounds.Height);
            
            window.BackgroundColor = UIColor.White;
            
            // make the window visible
            window.MakeKeyAndVisible ();
            
            return true;
        }
    }
}

