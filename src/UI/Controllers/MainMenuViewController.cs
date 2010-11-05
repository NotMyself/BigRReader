using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UI
{
	public class MainMenuViewController : UITableViewController
	{
		private List<string> _items;

		public MainMenuViewController(UITableViewStyle style) : base(style)
		{
		}

		public override void ViewWillAppear (bool animated)
  		{
			base.ViewWillAppear (animated);
			this.NavigationController.Toolbar.BarStyle = UIBarStyle.Black;
			this.NavigationController.SetToolbarHidden(false,true);
		}		

		public override void ViewWillDisappear (bool animated)
  		{
			base.ViewWillAppear (animated);
			this.NavigationController.SetToolbarHidden(true,true);
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			NavigationItem.TitleView = new UIImageView(/*UIImage.FromFile("Images/snakeoil.png")*/);
		}
			
	}
}

