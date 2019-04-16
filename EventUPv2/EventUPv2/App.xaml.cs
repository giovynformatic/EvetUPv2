﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EventUPv2
{
    public partial class App : Application
    {
        public static UserManager UsManager { get; private set; }
        public App()
        {
            InitializeComponent();
            UsManager = new UserManager(new RestServiceUser());
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
