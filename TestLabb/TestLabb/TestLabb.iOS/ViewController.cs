using Foundation;
using System;
using UIKit;

namespace TestLabb.iOS
{
	public partial class ViewController : UIViewController
	{
		

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            BildFranURL.Image = FromUrl("https://lh3.googleusercontent.com/-xcpvfNWFsyA/AAAAAAAAAAI/AAAAAAAADms/DKBvzfU3QSE/s640/photo.jpg");

            string translatedNumber = "";

            TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);

                PhoneNumberText.ResignFirstResponder();

                if(translatedNumber == "")
                {
                    CallButton.SetTitle("Call ", UIControlState.Normal);
                    CallButton.Enabled = false;
                } else
                {
                    CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };

            CallButton.TouchUpInside += (object sender, EventArgs e) => {
                // Use URL handler with tel: prefix to invoke Apple's Phone app...
                var url = new NSUrl("tel:" + translatedNumber);

                // ...otherwise show an alert dialog
                if (!UIApplication.SharedApplication.OpenUrl(url))
                {
                    var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);
                }
            };

            
        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}

