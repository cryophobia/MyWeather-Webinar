// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MyWeather
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UILabel cityLabel { get; set; }


        [Outlet]
        UIKit.UITextField cityTextField { get; set; }


        [Outlet]
        UIKit.UILabel dateLabel { get; set; }


        [Outlet]
        UIKit.UILabel dayLabel { get; set; }


        [Outlet]
        UIKit.UIButton getWeatherButton { get; set; }


        [Outlet]
        UIKit.UILabel tempLabel { get; set; }


        [Outlet]
        UIKit.UILabel weatherConditionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView mainConditionImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot1ConditionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot1DateTimeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView slot1Image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot2ConditionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot2DateTimeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView slot2Image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot3ConditionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot3DateTimeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView slot3Image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot4ConditionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot4DateTimeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView slot4Image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot5ConditionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel slot5DateTimeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView slot5Image { get; set; }


        [Action ("getWeatherTouchUp:")]
        partial void getWeatherTouchUp (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (cityLabel != null) {
                cityLabel.Dispose ();
                cityLabel = null;
            }

            if (cityTextField != null) {
                cityTextField.Dispose ();
                cityTextField = null;
            }

            if (dateLabel != null) {
                dateLabel.Dispose ();
                dateLabel = null;
            }

            if (dayLabel != null) {
                dayLabel.Dispose ();
                dayLabel = null;
            }

            if (getWeatherButton != null) {
                getWeatherButton.Dispose ();
                getWeatherButton = null;
            }

            if (mainConditionImage != null) {
                mainConditionImage.Dispose ();
                mainConditionImage = null;
            }

            if (slot1ConditionLabel != null) {
                slot1ConditionLabel.Dispose ();
                slot1ConditionLabel = null;
            }

            if (slot1DateTimeLabel != null) {
                slot1DateTimeLabel.Dispose ();
                slot1DateTimeLabel = null;
            }

            if (slot1Image != null) {
                slot1Image.Dispose ();
                slot1Image = null;
            }

            if (slot2ConditionLabel != null) {
                slot2ConditionLabel.Dispose ();
                slot2ConditionLabel = null;
            }

            if (slot2DateTimeLabel != null) {
                slot2DateTimeLabel.Dispose ();
                slot2DateTimeLabel = null;
            }

            if (slot2Image != null) {
                slot2Image.Dispose ();
                slot2Image = null;
            }

            if (slot3ConditionLabel != null) {
                slot3ConditionLabel.Dispose ();
                slot3ConditionLabel = null;
            }

            if (slot3DateTimeLabel != null) {
                slot3DateTimeLabel.Dispose ();
                slot3DateTimeLabel = null;
            }

            if (slot3Image != null) {
                slot3Image.Dispose ();
                slot3Image = null;
            }

            if (slot4ConditionLabel != null) {
                slot4ConditionLabel.Dispose ();
                slot4ConditionLabel = null;
            }

            if (slot4DateTimeLabel != null) {
                slot4DateTimeLabel.Dispose ();
                slot4DateTimeLabel = null;
            }

            if (slot4Image != null) {
                slot4Image.Dispose ();
                slot4Image = null;
            }

            if (slot5ConditionLabel != null) {
                slot5ConditionLabel.Dispose ();
                slot5ConditionLabel = null;
            }

            if (slot5DateTimeLabel != null) {
                slot5DateTimeLabel.Dispose ();
                slot5DateTimeLabel = null;
            }

            if (slot5Image != null) {
                slot5Image.Dispose ();
                slot5Image = null;
            }

            if (tempLabel != null) {
                tempLabel.Dispose ();
                tempLabel = null;
            }

            if (weatherConditionLabel != null) {
                weatherConditionLabel.Dispose ();
                weatherConditionLabel = null;
            }
        }
    }
}