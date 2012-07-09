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
            
            var viewFrame = new RectangleF(160, 240, 100, 150);
            var view = new HypnosisView() { Frame = viewFrame };
            view.BackgroundColor = UIColor.Red;
            window.AddSubview(view);
            
            var anotherFrame = new RectangleF(20, 30, 50, 50);
            var anotherView = new HypnosisView() { Frame = anotherFrame };
            anotherView.BackgroundColor = UIColor.Blue;
            window.AddSubview(anotherView);
            
            window.BackgroundColor = UIColor.White;
            
            // make the window visible
            window.MakeKeyAndVisible ();
            
            return true;
        }
    }
}

