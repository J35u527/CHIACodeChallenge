using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ChaiOne.AppNet.Core.Service
{
	public class AppNetService
	{
		HttpClient _client;
		int _timeout = 15;

		static AppNetService _instance;

		public static AppNetService Instance {
			get { 
				if (_instance == null) {
					_instance = new AppNetService ();
				} 
				return _instance;
			}
		}

		AppNetService ()
		{
			_client = new HttpClient ();
			_client.BaseAddress = new Uri ("https://alpha-api.app.net/");
			_client.Timeout = new TimeSpan (0, 0, _timeout);
		}

		public async Task<ChaiOne.AppNet.Core.Mappers.RootObject> GetGlobalStream ()
		{
			var res = await _client.GetStringAsync ("stream/0/posts/stream/global");
			var obj = JsonConvert.DeserializeObject <ChaiOne.AppNet.Core.Mappers.RootObject> (res);
			return obj;
		}
	}
}

