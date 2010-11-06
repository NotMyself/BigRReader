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
													Title = x.Element("title").Value,
													PubDate = x.Element("pubDate").Value,
													Content = x.Element("description").Value,
													Link = x.Element("link").Value
												});

			}
			return items.ToList();
		}
	}
}

