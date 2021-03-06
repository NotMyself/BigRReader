using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UI
{
	public class RssFeedItemViewController: UIViewController
	{
		FeedItem item;
		
		public RssFeedItemViewController(FeedItem item) : base()
		{
			this.item = item;
			this.Title = item.Title;
		}
		
		public UIWebView webView;
		
		public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
			
			webView = new UIWebView { ScalesPageToFit = true };
			
			webView.LoadStarted += delegate {
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
			};
			webView.LoadFinished += delegate {
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
			};

			webView.LoadHtmlString(FormatText(), new NSUrl());
            webView.SizeToFit();
            webView.Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height - 44);
            this.View.AddSubview(webView);
		}

		private string FormatText()
		{
			var sb = new StringBuilder();
            
			sb.Append("<html><head><meta name=\"viewport\" content=\"width=320\"/>" +
				"<style>body,b,p,h2{font-family:Helvetica;}</style></head><body>");
			sb.Append(item.Content);
			sb.Append("<br><br>");
			sb.AppendFormat("<p><a href='{0}'>Read More</a></p>", item.Link);
			sb.Append("</body></html>");
				
			return sb.ToString();
		}
	}
}

