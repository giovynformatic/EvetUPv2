using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventUPv2
{
	
	public partial class GestionePasswordPopupAzienda 
	{
		public GestionePasswordPopupAzienda ()
		{
			InitializeComponent ();
		}
        async void ModifyButton(object sender, EventArgs args)
        {
            if (oldpass.Text == Constants.CurrentAdmin.pass)
            {
                if (newpass.Text == confirm.Text)
                {
                    //  await App.AdManager.DeleteTaskAsync(Constants.CurrentAdmin);//codice per back-end
                    Constants.CurrentAdmin.pass = newpass.Text;
                    //   await App.AdManager.SaveTaskAsync(Constants.CurrentAdmin);//codice per back-end
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