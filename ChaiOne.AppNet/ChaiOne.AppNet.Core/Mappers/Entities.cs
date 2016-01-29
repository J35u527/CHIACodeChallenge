using System;
using System.Collections.Generic;

namespace ChaiOne.AppNet.Core.Mappers
{

	public class Entities
	{
		public List<object> mentions { get; set; }

		public List<object> hashtags { get; set; }

		public List<Link> links { get; set; }
	}
}

