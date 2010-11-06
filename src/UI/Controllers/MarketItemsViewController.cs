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
	public class MarketItemsViewController: UITableViewController
	{
		public MarketItemsViewController(UITableViewStyle style) : base(style) {}
				
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
			
			Title = "Market Insights";
        }	
	}
}

