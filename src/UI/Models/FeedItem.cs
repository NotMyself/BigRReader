using System;
namespace UI
{
	public class FeedItem
	{
		public string Title {get; set;}
		public string PubDate {get; set;}
		public string Content {get; set;}
		public string Link {get; set; }
		
		public DateTime PublishedDate
		{
			get 
			{
				return GetDate(PubDate);
			}	
		}
		
		private DateTime GetDate (string value)
		{
			//Thu, 26 Aug 2010 05:00:00 PDT
			//Thu, 04 Nov 2010 16:44:08 +0000
			
			if (value.EndsWith ("PDT"))
				return DateTime.ParseExact (value.Substring (5), "dd MMM yyyy HH:mm:ss PDT", null);
			
			if (value.EndsWith ("PST"))
				return DateTime.ParseExact (value.Substring (5), "dd MMM yyyy HH:mm:ss PST", null);
			
			return DateTime.ParseExact(value, "ddd, dd MMM yyyy HH:mm:ss zzz", null);
		}
	}
}

