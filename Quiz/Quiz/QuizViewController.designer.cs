// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Quiz
{
	[Register ("QuizViewController")]
	partial class QuizViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel questionField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel answerField { get; set; }

		[Action ("showQuestion:")]
		partial void showQuestion (MonoTouch.Foundation.NSObject sender);

		[Action ("showAnswer:")]
		partial void showAnswer (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (questionField != null) {
				questionField.Dispose ();
				questionField = null;
			}

			if (answerField != null) {
				answerField.Dispose ();
				answerField = null;
			}
		}
	}
}
