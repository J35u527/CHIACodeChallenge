using System;

namespace ChaiOne.AppNet.Core.Mappers
{
	public class User
	{
		public string username { get; set; }

		public AvatarImage avatar_image { get; set; }

		public Description description { get; set; }

		public string locale { get; set; }

		public string created_at { get; set; }

		public string canonical_url { get; set; }

		public CoverImage cover_image { get; set; }

		public string timezone { get; set; }

		public Counts counts { get; set; }

		public string type { get; set; }

		public string id { get; set; }

		public string name { get; set; }

		public string verified_link { get; set; }

		public string verified_domain { get; set; }
	}
}

