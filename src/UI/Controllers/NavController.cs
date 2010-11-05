using System;
using MonoTouch.UIKit;

namespace UI
{
	public class NavController : UINavigationController
	{
		public NavController () : base () { }
		public NavController (IntPtr handle) : base (handle) { }
		
		public override void ViewDidLoad ()
		{
			MainMenuViewController table = new MainMenuViewController(UITableViewStyle.Plain);
			SetViewControllers(new UIViewController[] {table},false);
			
			base.ViewDidLoad ();
		}
	}
}

