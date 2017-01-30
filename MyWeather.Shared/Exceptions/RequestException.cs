
using System;
namespace MyWeather.Exceptions {
	public class RequestException : Exception {
		public RequestException() {
		}

		public RequestException(string message) : base(message) {
		}

		public RequestException(string message, Exception innerException) : base(message, innerException) {
		}
	}
}
