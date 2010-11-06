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
	public class RssFeedViewController : UITableViewController
	{
		Uri feed; 
		string title;
		
		public RssFeedViewController(Uri feed, string title) : base(UITableViewStyle.Plain) 
		{
			this.feed = feed;
			this.title = title;
			
		}
				
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
			
			Title = title;
        }
	}
}

