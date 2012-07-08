using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Quiz
{
    public partial class QuizViewController : UIViewController
    {
        List<string> questions;
        int currentQuestionIndex = 0;
        
        List<string> answers;
    
        static bool UserInterfaceIdiomIsPhone {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public QuizViewController ()
            : base (UserInterfaceIdiomIsPhone ? "QuizViewController_iPhone" : "QuizViewController_iPad", null)
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
            
            questions = new List<string>() {
                "What is 7 + 7?",
                "What is the capital of Vermont?",
                "From what is Cognac made?",
            };
            
            answers = new List<string>() {
                "14",
                "Montpelier",
                "Grapes",
            };
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
            if (UserInterfaceIdiomIsPhone) {
                return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
            } else {
                return true;
            }
        }
        
        partial void showQuestion (MonoTouch.Foundation.NSObject sender)
        {
            var qu = questions[++currentQuestionIndex % questions.Count];
            Console.WriteLine("Displaying question: {0}", qu);
            
            questionField.Text = qu;
            answerField.Text = "";
        }
        
        partial void showAnswer (MonoTouch.Foundation.NSObject sender)
        {
            var ans = answers[currentQuestionIndex % answers.Count];
            answerField.Text = ans;
        }
    }
}
