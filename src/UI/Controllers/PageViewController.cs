using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UI
{
	public class PageViewController: UIViewController
	{
		Uri page;
		
		public PageViewController(Uri page, string title) : base()
		{
			this.page = page;
			this.Title = title;
		}
		
		public UIWebView webView;
		
		public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
			
			webView = new UIWebView { ScalesPageToFit = true, BackgroundColor = UIColor.Cyan  };
			webView.Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height - 44);
			
			webView.LoadStarted += delegate {
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
			};
			webView.LoadFinished += delegate {
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
				webView.SizeToFit();
			};
			

			webView.LoadRequest(new NSUrlRequest(new NSUrl(page.AbsoluteUri)));
            webView.SizeToFit();
            
            this.View.AddSubview(webView);
		}
	}
}

