using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodTrace.Models;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodTrace.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DonarProfilePage : ContentPage
	{
	    private string _email;
	    private string _phoneNumber; 
        public DonarProfilePage (BloodUser bloodUser)
		{
			InitializeComponent ();
		    ImgDonar.Source = bloodUser.FullLogoPath;
		    LblDonarName.Text = bloodUser.UserName;
		    LblBloodGroup.Text = bloodUser.BloodGroup;
		    LblCountry.Text = bloodUser.Country;
		    _email = bloodUser.Email;
		    _phoneNumber = bloodUser.Phone;
		}

	    private void TapEmail_OnTapped(object sender, EventArgs e)
	    {
	        var emailMessenger = CrossMessaging.Current.EmailMessenger;
	        if (emailMessenger.CanSendEmail)
	        {
	            // Send simple e-mail to single receiver without attachments, bcc, cc etc.
	            emailMessenger.SendEmail(_email, "Add a subject","Write Email Body");
	        }
	    }

            private void TapPhone_OnTapped(object sender, EventArgs e)
	    {
	        var phoneDialer = CrossMessaging.Current.PhoneDialer;
	        if (phoneDialer.CanMakePhoneCall)
	            phoneDialer.MakePhoneCall(_phoneNumber);

        }
    }
}