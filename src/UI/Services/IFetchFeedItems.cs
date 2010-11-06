using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Net;
using System.Collections.Generic;

namespace UI
{
	public interface IFetchFeedItems
	{
		IList<FeedItem> Get(Uri feed);
	}
	
	public class FeedFetcher : IFetchFeedItems 
	{
		public IList<FeedItem> Get(Uri feed)
		{
			var items = Enumerable.Empty<FeedItem>();
			var request = WebRequest.Create(feed);
			using (var response = request.GetResponse())
			{
				var xmlReader = XmlReader.Create(response.GetResponseStream());
				var document = XDocument.Load(xmlReader);

				items = document.Descendants("channel")
								.Elements("item")
								.Select(x => new FeedItem 
						        				{ 
													Title = x.Element("title").Value,								 //Thu, 04 Nov 2010 16:44:08 +0000
													PubDate = x.Element("pubDate").Value//DateTime.ParseExact(, "ddd, dd MMM yyyy HH:mm:ss zzz", null)
												});

			}
			return items.ToList();
		}
	}
}

