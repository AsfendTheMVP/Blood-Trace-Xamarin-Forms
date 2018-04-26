﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BloodTrace.Pages;
using Xamarin.Forms;

namespace BloodTrace
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    if (!string.IsNullOrEmpty(Settings.AccessToken))
		    {
		        MainPage = new NavigationPage(new HomePage());
		    }
		    else if(string.IsNullOrEmpty(Settings.UserName)&&string.IsNullOrEmpty(Settings.Password))
		    {
		        MainPage = new NavigationPage(new SignInPage());
		    }
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
