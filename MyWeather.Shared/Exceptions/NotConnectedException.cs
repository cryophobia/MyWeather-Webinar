using System;

namespace MyWeather.Exceptions {
	class NotConnectedException : Exception {
		public NotConnectedException() {
		}

		public NotConnectedException(string message) : base(message) {
		}

		public NotConnectedException(string message, Exception innerException) : base(message, innerException) {
		}
	}
}