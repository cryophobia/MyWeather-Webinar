using System;
using System.Collections.Generic;
using System.Globalization;
using Acr.UserDialogs;
using GalaSoft.MvvmLight.Helpers;
using MyWeather.ViewModels;
using UIKit;

namespace MyWeather {
	public partial class ViewController : UIViewController {

		#region Fields
		readonly List<Binding> bindings = new List<Binding>();
		WeatherViewModel vm;
		bool falseFlag;
		#endregion

		protected ViewController(IntPtr handle) : base(handle) {
			vm = new WeatherViewModel();
		}

		#region Overrrides

		/// <summary>
		/// View the did load.
		/// </summary>
		public override void ViewDidLoad() {
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			CreateBindings();
			SetupData();
			SetupInteraction();
			HouseKeeping();
		}

		/// <summary>
		/// View the did appear.
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewDidAppear(bool animated) {
			base.ViewDidAppear(animated);
			FetchData();
		}
		#endregion

		#region Private Methods

		/// <summary>
		/// Fetch data.
		/// </summary>
		void FetchData() {
			vm?.GetWeatherCommand.Execute(null);
		}

		/// <summary>
		/// Sets up the interaction.
		/// </summary>
		void SetupInteraction() {
			base.View.AddGestureRecognizer(
				new UITapGestureRecognizer(ResignResponder)
			);
		}

		/// <summary>
		/// Creates the bindings.
		/// </summary>
		void CreateBindings() {
			TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

			bindings.Add(
				this.SetBinding(
					() => cityTextField.Text,
					() => vm.Location));

			bindings.Add(
				this.SetBinding(
					() => vm.Location,
					() => cityLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Condition,
					() => weatherConditionLabel.Text));

			bindings.Add(
			this.SetBinding(
					() => vm.ConditionImage).WhenSourceChanges(
					() => {
						mainConditionImage.Image = UIImage.FromBundle(vm.ConditionImage);
					})
			);

			bindings.Add(
			this.SetBinding(
					() => vm.Slot1Image).WhenSourceChanges(
					() => {
						slot1Image.Image = UIImage.FromBundle(vm.Slot1Image);
					})
			);

			bindings.Add(
			this.SetBinding(
					() => vm.Slot1Image).WhenSourceChanges(
					() => {
						slot1Image.Image = UIImage.FromBundle(vm.Slot1Image);
					})
			);

			bindings.Add(
			this.SetBinding(
					() => vm.Slot2Image).WhenSourceChanges(
					() => {
						slot2Image.Image = UIImage.FromBundle(vm.Slot2Image);
					})
			);

			bindings.Add(
			this.SetBinding(
					() => vm.Slot3Image).WhenSourceChanges(
					() => {
						slot3Image.Image = UIImage.FromBundle(vm.Slot3Image);
					})
			);

			bindings.Add(
			this.SetBinding(
					() => vm.Slot4Image).WhenSourceChanges(
					() => {
						slot4Image.Image = UIImage.FromBundle(vm.Slot4Image);
					})
			);

			bindings.Add(
			this.SetBinding(
					() => vm.Slot5Image).WhenSourceChanges(
					() => {
						slot5Image.Image = UIImage.FromBundle(vm.Slot5Image);
					})
			);

			bindings.Add(
			this.SetBinding(
					() => vm.IsBusy).WhenSourceChanges(
					() => {
						if (vm.IsBusy) {
							UserDialogs.Instance.ShowLoading("Loading weather results...");
						} else {
							UserDialogs.Instance.HideLoading();
						}
					})
			);

			bindings.Add(
				this.SetBinding(
					() => vm.Temp,
					() => tempLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot1.DisplayTime,
					() => slot1DateTimeLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot1.DisplayTemp,
					() => slot1ConditionLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot2.DisplayTime,
					() => slot2DateTimeLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot2.DisplayTemp,
					() => slot2ConditionLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot3.DisplayTime,
					() => slot3DateTimeLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot3.DisplayTemp,
					() => slot3ConditionLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot4.DisplayTime,
					() => slot4DateTimeLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot4.DisplayTemp,
					() => slot4ConditionLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot5.DisplayTime,
					() => slot5DateTimeLabel.Text));

			bindings.Add(
				this.SetBinding(
					() => vm.Slot5.DisplayTemp,
					() => slot5ConditionLabel.Text));

			getWeatherButton.SetCommand(vm.GetWeatherCommand);
		}

		/// <summary>
		/// Sets up the data.
		/// </summary>
		void SetupData() {
			vm.Location = "Kakamas";
			vm.IsImperial = false;
			vm.IsBusy = false;

			var unit = vm.IsImperial ? "F" : "C";
			vm.Temp = $"0°{unit}";


			dayLabel.Text = DateTime.Now.DayOfWeek.ToString();
			dateLabel.Text = DateTime.Now.ToString("MMMM dd");
		}

		/// <summary>
		/// House keeping.
		/// </summary>
		void HouseKeeping() {
			if (falseFlag) {
				cityTextField.EditingChanged += (s, e) => {
				};
				getWeatherButton.TouchUpInside += (s, e) => {
				};
			}
		}
		#endregion

		#region User Touch
		/// <summary>
		/// Gets the weather on touch up.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void getWeatherTouchUp(Foundation.NSObject sender) {
			ResignResponder();
		}

		/// <summary>
		/// Resigns the responder.
		/// </summary>
		void ResignResponder() {
			if (cityTextField.CanResignFirstResponder) {
				cityTextField.ResignFirstResponder();
			}
		}
		#endregion
	}
}
