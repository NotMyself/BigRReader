using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UI
{
	public class MainMenuViewController : UITableViewController
	{
		private List<string> items;

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
			
			NavigationItem.TitleView = new UIImageView(UIImage.FromFile("Images/RusLogoStackBlkPPT.png"));
			
			items = new List<string>()
			{
				"Market Insights",
				"Russell Newsroom",
				"Twitter"
			};
			
			UIBarButtonItem about = new UIBarButtonItem("About", UIBarButtonItemStyle.Bordered, null);
			about.Clicked += delegate(object sender, EventArgs e) {
				AboutViewController aboutView = new AboutViewController();
				aboutView.Title = "About";
				this.NavigationController.PushViewController(aboutView, true);				
			};
			ToolbarItems = new UIBarButtonItem[] {about};
			
			TableView.DataSource = new TableViewDataSource(items);
			TableView.Delegate = new TableViewDelegate(this);
			TableView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight|UIViewAutoresizing.FlexibleWidth;
			TableView.BackgroundColor = UIColor.Clear;
			TableView.Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height);

		}
			
	}
	
	public class TableViewDataSource : UITableViewDataSource
    {
		private string cellId = "cellid";
		private List<string> items;

		public TableViewDataSource (List<string> items)
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
                cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
            }
            cell.TextLabel.Text = items[indexPath.Row];
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            return cell;
        }
    }	
	
	public class TableViewDelegate : UITableViewDelegate
        {
			private MainMenuViewController controller;
			private Uri twitterFeed = new Uri("http://twitter.com/statuses/user_timeline/47657595.rss");
			private Uri newsFeed = new Uri("http://feeds.feedburner.com/RussellcomNewsRelease");
			private Uri marketFeed = new Uri("http://feeds.feedburner.com/RussellInvestmentsEducationCenter");
		
            public TableViewDelegate(MainMenuViewController controller)
            {
				this.controller = controller;
            }

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
            {
				try
				{
					UITableViewController nextController = null;
	
					switch (indexPath.Row)
					{
					case 0:
						nextController = new RssFeedViewController(marketFeed, "Market Insights");
						break;
					case 1:
						nextController = new RssFeedViewController(newsFeed, "Russell Newsroom");
						break;
					case 2:
						nextController = new RssFeedViewController(twitterFeed, "Twitter");
						break;
					default:
						break;
					}
					
					if (nextController != null)
						controller.NavigationController.PushViewController(nextController, true);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
        }

}

