using System;
using System.Collections.Generic;

namespace ChaiOne.AppNet.Core.Mappers
{
	public class RootObject
	{
		public Meta meta { get; set; }

		public List<Datum> data { get; set; }
	}
}

