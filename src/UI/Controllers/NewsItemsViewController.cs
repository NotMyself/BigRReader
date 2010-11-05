using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.IO;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UI
{
	public class NewsItemsViewController : UITableViewController
	{
		public NewsItemsViewController(UITableViewStyle style) : base(style) {}
				
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
			
			Title = "Russell News";
        }	
	}
}

