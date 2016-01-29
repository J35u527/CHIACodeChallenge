using System;

using UIKit;

namespace ChaiOne.AppNet
{
	public partial class ViewController : UIViewController
	{
		UIButton _testButton;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			_testButton = new UIButton (View.Bounds);
			Add (_testButton);
			_testButton.TouchUpInside += _testButton_TouchUpInside;
		}

		async void _testButton_TouchUpInside (object sender, EventArgs e)
		{
			var service = ChaiOne.AppNet.Core.Service.AppNetService.Instance;
			var x = await service.GetGlobalStream ();
			var y = 0;
		}

		protected override void Dispose (bool disposing)
		{
			_testButton.TouchUpInside -= _testButton_TouchUpInside;
			_testButton.RemoveFromSuperview ();
			_testButton.Dispose ();
			_testButton = null;
			base.Dispose (disposing);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

