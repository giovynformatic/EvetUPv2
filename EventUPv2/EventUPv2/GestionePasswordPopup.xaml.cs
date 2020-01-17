using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventUPv2
{
    public partial class GestionePasswordPopup 
    {
        public GestionePasswordPopup()
        {
            InitializeComponent();
        }

        async void ModifyButton(object sender, EventArgs args)
        {
            if (oldpass.Text == Constants.CurrentUser.password)
            {
                if (newpass.Text == confirm.Text)
                {
                  //  await App.UsManager.DeleteTaskAsync(Constants.CurrentUser);//codice per back-end
                    Constants.CurrentUser.password = newpass.Text;
                    //   await App.UsManager.SaveTaskAsync(Constants.CurrentUser);//codice per back-end
                    await DisplayAlert("Attenzione", "Password modificata", "OK");
                    await PopupNavigation.Instance.PopAsync();
                }
                else
                {
                    await DisplayAlert("Attenzione", "la nuova password non corrisponde con la conferma", "OK");
                }
            }
            else
            {
                await DisplayAlert("Attenzione", "la vecchia password è sbagliata", "OK");
            }
           
        }
    }
}
