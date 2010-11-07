using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace UI.Tests
{
	[TestFixture()]
	public class FeedItemTests
	{
		
		[Test()]
		public void can_parse_twitter_custom_date ()
		{
			var item = new FeedItem { PubDate = "Thu, 04 Nov 2010 16:44:08 +0000" };
			var expected = new DateTime (2010, 11, 4, 9, 44, 08);
			
			Assert.That (item.PublishedDate, Is.EqualTo (expected));
		}
		
		[Test]
		public void can_parse_russell_feed_custom_date()
		{
			var item = new FeedItem { PubDate = "Thu, 26 Aug 2010 05:00:00 PDT" };
			var expected = new DateTime (2010, 8, 26, 5, 00, 00);
			
			Assert.That (item.PublishedDate, Is.EqualTo (expected));
		}
		
		[Test]
		public void can_parse_russell_feed_custom_date_that_errors()
		{
			var item = new FeedItem { PubDate = "Wed, 08 Aug 2010 01:25:00 PDT" };
			var expected = new DateTime(2010, 8, 8, 1, 25, 00);
			
			Assert.That (item.PublishedDate, Is.EqualTo (expected));
		}
	}
}

