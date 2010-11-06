using System;
using System.Linq;
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
		IFetchFeedItems fetcher;
		
		public RssFeedViewController(Uri feed, string title) : base(UITableViewStyle.Plain) 
		{
			this.feed = feed;
			this.title = title;
			this.fetcher = new FeedFetcher();
			
		}
				
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
			
			Title = title;
			var items = fetcher.Get(feed);
			
			TableView.DataSource = new FeedItemTableViewDataSource(items);
			TableView.Delegate = new FeedItemTableViewDelegate(this, items);
			TableView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight|UIViewAutoresizing.FlexibleWidth;
			TableView.BackgroundColor = UIColor.Clear;
			TableView.Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height);
			
        }
	}
	
	public class FeedItemTableViewDataSource : UITableViewDataSource
        {
			private string cellId = "cellid";
			private IList<FeedItem> items;

			public FeedItemTableViewDataSource (IList<FeedItem> items)
            {
				this.items = items;
            }

            public override int RowsInSection (UITableView tableview, int section)
            {
                return items.Count;
            }

            public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = tableView.DequeueReusableCell(cellId);
                if (cell == null)
                {
                    cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellId);
                }
				cell.TextLabel.Font = UIFont.FromName("Helvetica", 14.0f);
				cell.TextLabel.LineBreakMode = UILineBreakMode.TailTruncation;
                cell.TextLabel.Text = items[indexPath.Row].Title;
				cell.DetailTextLabel.Font = UIFont.FromName("Helvetica", 12.0f);
				cell.DetailTextLabel.Text = items[indexPath.Row].PubDate;
				
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                return cell;
            }
        }		
		
        public class FeedItemTableViewDelegate : UITableViewDelegate
        {
			private RssFeedViewController controller;
			private IList<FeedItem> items;
			
            public FeedItemTableViewDelegate(RssFeedViewController controller, IList<FeedItem> items)
            {
				this.controller = controller;
				this.items = items;
            }			
			
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
            {
				var item = items[indexPath.Row];
				//TwitterItemViewController twitterView = new TwitterItemViewController(i);
				//twitterView.Title = i.Title;
				//controller.NavigationController.PushViewController(twitterView, true);
			}
        }
}

