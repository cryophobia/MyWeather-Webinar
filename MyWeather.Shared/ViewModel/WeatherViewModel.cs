using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Humanizer;
using MyWeather.Exceptions;
using MyWeather.Helpers;
using MyWeather.Models;
using MyWeather.Services;
using Plugin.Geolocator;
using Plugin.TextToSpeech;

namespace MyWeather.ViewModels {
	public class WeatherViewModel : ViewModelBase {

		WeatherService WeatherService { get; } = new WeatherService();

		#region Properties

		string location = Settings.City;
		public string Location {
			get { return location?.Humanize(LetterCasing.Title); }
			set {
				location = value;
				RaisePropertyChanged();
				Settings.City = value;
			}
		}

		bool useGPS;
		public bool UseGPS {
			get { return useGPS; }
			set {
				useGPS = value;
				RaisePropertyChanged();
			}
		}

		bool isImperial = Settings.IsImperial;
		public bool IsImperial {
			get { return isImperial; }
			set {
				isImperial = value;
				RaisePropertyChanged();
				Settings.IsImperial = value;
			}
		}

		string temp = string.Empty;
		public string Temp {
			get { return temp; }
			set { temp = value; RaisePropertyChanged(); }
		}

		WeatherRoot slot1;
		public WeatherRoot Slot1 {
			get { return slot1; }
			set {
				slot1 = value;
				Slot1Image = SelectImage(value);
				RaisePropertyChanged();
			}
		}

		string slot1Image = string.Empty;
		public string Slot1Image {
			get { return slot1Image; }
			set {
				slot1Image = value;
				RaisePropertyChanged();
			}
		}

		string slot2Image = string.Empty;
		public string Slot2Image {
			get { return slot2Image; }
			set {
				slot2Image = value;
				RaisePropertyChanged();
			}
		}

		string slot3Image = string.Empty;
		public string Slot3Image {
			get { return slot3Image; }
			set {
				slot3Image = value;
				RaisePropertyChanged();
			}
		}

		string slot4Image = string.Empty;
		public string Slot4Image {
			get { return slot4Image; }
			set {
				slot4Image = value;
				RaisePropertyChanged();
			}
		}

		string slot5Image = string.Empty;
		public string Slot5Image {
			get { return slot5Image; }
			set {
				slot5Image = value;
				RaisePropertyChanged();
			}
		}

		WeatherRoot slot2;
		public WeatherRoot Slot2 {
			get { return slot2; }
			set {
				slot2 = value;
				Slot2Image = SelectImage(value);
				RaisePropertyChanged();
			}
		}

		WeatherRoot slot3;
		public WeatherRoot Slot3 {
			get { return slot3; }
			set {
				slot3 = value;
				Slot3Image = SelectImage(value);
				RaisePropertyChanged();
			}
		}

		WeatherRoot slot4;
		public WeatherRoot Slot4 {
			get { return slot4; }
			set {
				slot4 = value;
				Slot4Image = SelectImage(value);
				RaisePropertyChanged();
			}
		}

		WeatherRoot slot5;
		public WeatherRoot Slot5 {
			get { return slot5; }
			set {
				slot5 = value;
				Slot5Image = SelectImage(value);
				RaisePropertyChanged();
			}
		}

		string condition = string.Empty;
		public string Condition {
			get { return condition?.Humanize(LetterCasing.Title); }
			set { condition = value; RaisePropertyChanged(); }
		}

		string conditionImage = string.Empty;
		public string ConditionImage {
			get { return conditionImage; }
			set {
				conditionImage = value;
				RaisePropertyChanged();
			}
		}

		bool isBusy;
		public bool IsBusy {
			get { return isBusy; }
			set {
				isBusy = value;
				RaisePropertyChanged();
			}
		}

		public bool IsDataAvailable {
			get { return Forecast != null; }
		}


		WeatherForecastRoot forecast;

		public WeatherForecastRoot Forecast {
			get {
				return forecast;
			}
			set {
				forecast = value;
				RaisePropertyChanged();
				RaisePropertyChanged("IsDataAvailable");
			}
		}

		#endregion

		#region Commands

		ICommand getWeather;
		public ICommand GetWeatherCommand =>
				getWeather ??
				(getWeather = new RelayCommand(async () => await ExecuteGetWeatherCommand()));

		#endregion

		#region Private Methods

		/// <summary>
		/// Selects the image.
		/// </summary>
		/// <returns>The image.</returns>
		/// <param name="weatherRoot">Weather root.</param>
		/// <param name="main">If set to <c>true</c> main.</param>
		string SelectImage(WeatherRoot weatherRoot, bool main = false) {

			var str = main ? "_white" : string.Empty;

			switch (weatherRoot.Weather[0]?.Description) {
				case "clear sky":
					return $"01{str}.png";
				case "overcast clouds":
					return $"05{str}.png";
				case "scattered clouds":
				case "broken clouds":
				case "few clouds":
					return $"04{str}.png";
				case "moderate rain":
				case "heavy intensity rain":
				case "light intensity drizzle":
					return $"02{str}.png";
				case "light rain":
					return $"06{str}.png";
				case "moderate snow":
				case "heavy intensity snow":
				case "light snow":
					return $"07{str}.png";
				default:
					return $"01{str}.png";
			}
		}

		/// <summary>
		/// Execute get weather command.
		/// </summary>
		/// <returns>The get weather command.</returns>
		async Task ExecuteGetWeatherCommand() {
			if (IsBusy)
				return;

			IsBusy = true;

			try {
				WeatherRoot weatherRoot = null;
				var units = IsImperial ? Units.Imperial : Units.Metric;

				if (UseGPS) {
					var gps = await CrossGeolocator.Current.GetPositionAsync(10000);
					weatherRoot = await WeatherService.GetWeather(gps.Latitude, gps.Longitude, units);
					Forecast = await WeatherService.GetForecast(Location.Trim(), units);
				} else { //Get weather by city
					weatherRoot = await WeatherService.GetWeather(Location.Trim(), units);
					Forecast = await WeatherService.GetForecast(Location.Trim(), units);
				}

				PopulateTodaysWeather(weatherRoot);
				if (Forecast != null) {
					PopulateForecastWeather();
				}

				var speakTemp = (int)(weatherRoot?.MainWeather?.Temperature ?? 0);
				CrossTextToSpeech.Current.Speak(speakTemp + " ° " + (IsImperial ? "Fahrenheit" : "Celsius") + " " + Condition);

			} catch (Exception ex) {
				await DealWithExceptionAsync(ex);
			} finally {
				IsBusy = false;
			}
		}

		/// <summary>
		/// Populates the forecast weather.
		/// </summary>
		void PopulateForecastWeather() {
			Slot1 = Forecast.Items.Take(1).FirstOrDefault();
			Slot2 = Forecast.Items.Skip(1).Take(1).FirstOrDefault();
			Slot3 = Forecast.Items.Skip(2).Take(1).FirstOrDefault();
			Slot4 = Forecast.Items.Skip(3).Take(1).FirstOrDefault();
			Slot5 = Forecast.Items.Skip(4).Take(1).FirstOrDefault();
		}

		/// <summary>
		/// Populates todays weather.
		/// </summary>
		/// <param name="weatherRoot">Weather root.</param>
		void PopulateTodaysWeather(WeatherRoot weatherRoot) {
			var unit = IsImperial ? "F" : "C";
			var temperature = (int)(weatherRoot?.MainWeather?.Temperature ?? 0);
			Temp = $"{temperature}°{unit}";
			Condition = $"{weatherRoot?.Weather?[0]?.Description ?? string.Empty}";
			ConditionImage = SelectImage(weatherRoot, true);
		}


		/// <summary>
		/// Deals the with the exception async.
		/// </summary>
		/// <returns>The with exception async.</returns>
		/// <param name="ex">Ex.</param>
		async Task DealWithExceptionAsync(Exception ex) {

			if (ex.GetType() == typeof(RequestException)) {

				var toastConfig = new ToastConfig(ex.Message);
				toastConfig.Duration = TimeSpan.FromSeconds(5);
				toastConfig.SetBackgroundColor(System.Drawing.Color.OrangeRed);
				UserDialogs.Instance.Toast(toastConfig);

			} else if (ex.GetType() == typeof(NotConnectedException)) {

				var toastConfig = new ToastConfig(ex.Message);
				toastConfig.Duration = TimeSpan.FromSeconds(5);
				toastConfig.SetBackgroundColor(System.Drawing.Color.OrangeRed);
				UserDialogs.Instance.Toast(toastConfig);

			} else
				if (ex.InnerException?.GetType() == typeof(WebException)) {
				await UserDialogs.Instance.AlertAsync("We have an unrecoverable Error.", "Oops!", "Ok");
			} else {
				await UserDialogs.Instance.AlertAsync("We have an unrecoverable Error.", "Oops!", "Ok");
			}
		}

		#endregion
	}
}
