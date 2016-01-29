using System;

namespace ChaiOne.AppNet.Core.Mappers
{
	public class Datum
	{
		public string created_at { get; set; }

		public int num_stars { get; set; }

		public int num_replies { get; set; }

		public Source source { get; set; }

		public string text { get; set; }

		public int num_reposts { get; set; }

		public string id { get; set; }

		public string canonical_url { get; set; }

		public Entities entities { get; set; }

		public string html { get; set; }

		public bool machine_only { get; set; }

		public User user { get; set; }

		public string thread_id { get; set; }

		public string pagination_id { get; set; }
	}
}

