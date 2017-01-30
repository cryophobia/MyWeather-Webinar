using System;
using System.Net.Http;
using MyWeather.Exceptions;

namespace MyWeather.Services {
	public class BaseService {
		
		internal static void CheckConnection() {
			if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
				throw new NotConnectedException("You're device seems to be offline. Please check Cellular or Wifi access.");
		}

		internal static void CheckSuccess(HttpResponseMessage result) {
			if (!result.IsSuccessStatusCode) {
				switch (result.StatusCode) {

					case System.Net.HttpStatusCode.BadGateway:
						throw new RequestException("There seems to be a problem reaching the weather service . Please try again.");

					case System.Net.HttpStatusCode.Forbidden:
						throw new RequestException("The weather service no longer accepts requests.");

					case System.Net.HttpStatusCode.Unauthorized:
						throw new RequestException("The weather service requires you to log in.");

					default:
						throw new RequestException("The weather service did not understand the request. Please try again.");
				}
			}
		}
	}
}
