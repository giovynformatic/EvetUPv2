using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Web;

namespace EventUPv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectAziende : ContentPage
    {

        public Admins listaAziende = new Admins();
        public String[] az;
        public List<SelectableData<ExampleData>> SelectedData;
        public SelectAziende()
        {
            InitializeComponent();
             SelectedData = new List<SelectableData<ExampleData>>();
            //AssegnaAziende();
            listaAziende = Constants.listaAziende;
            for (int a = 0; a < listaAziende.data.Length ; a++)
            {
                SelectableData<ExampleData> s;
                SelectedData.Add(s=new SelectableData<ExampleData>() { Data = new ExampleData() { NomeAzienda = listaAziende.data.ElementAt(a).nome }});   
                s.Selected = Constants.CurrentUser.valAz.ElementAt(a);


            }
           BindingContext = new MultiSelectViewModel(SelectedData);


        }
        async void AziendeUser(object sender, EventArgs args)

        {
           
                az = new String[listaAziende.data.Length];//uso due vettori da riempire con valori back end
                Boolean[] val = new Boolean[listaAziende.data.Length];// uso due vettori da riempire con valori back end

                for (int x = 0; x < listaAziende.data.Length; x++)
                {
                    az[x] = listaAziende.data.ElementAt(x).nome;
                }
                for (int x = 0; x < listaAziende.data.Length; x++)
                {
                    SelectableData<ExampleData> s;
                    s = SelectedData.ElementAt(x);
                    val[x] = s.Selected;
                }


                IReadOnlyList<Page> pagine = Navigation.NavigationStack;

            if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.RegistratiInteressi")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente
            {
                Constants.CurrentUser.valAz = val;
                //  await Navigation.PushAsync(new HomePage());

                UserToBack usBack = new UserToBack();
                usBack.nome = Constants.CurrentUser.Nome;
                usBack.cognome = Constants.CurrentUser.Cognome;
                usBack.datanascita = Constants.CurrentUser.Data;
                usBack.email = Constants.CurrentUser.email;
                usBack.cf = Constants.CurrentUser.cf;
                usBack.citta = Constants.CurrentUser.Città;
                usBack.sesso = Constants.CurrentUser.Sesso;
                usBack.password = Constants.CurrentUser.pass;
                usBack.nazionalita = Constants.CurrentUser.Nazionalità;
                usBack.username = Constants.CurrentUser.Username;
                int[] AzId = new int[Constants.listaAziende.data.Length];
                for (int x = 0; x < Constants.listaAziende.data.Length; x++)
                {

                    AzId[x] = Constants.listaAziende.data.ElementAt(x).id;
                }
                int[] IntId = new int[Constants.inter.data.Length];
                for (int x = 0; x < Constants.inter.data.Length; x++)
                {

                    IntId[x] = Constants.inter.data.ElementAt(x).id;
                }
                usBack.interessi = new int[Constants.CurrentUser.interessi.Length];
                for (int x=0;x<Constants.CurrentUser.interessi.Length;x++)
                 {
                     if(Constants.CurrentUser.valIn.ElementAt(x)==true)
                     {
                        usBack.interessi[x] = IntId[x];
                     }
                 }
                usBack.aziende = new int[Constants.CurrentUser.aziende.Length];
                for (int y = 0; y < Constants.CurrentUser.aziende.Length; y++)
                {
                    if (Constants.CurrentUser.valAz.ElementAt(y) == true)
                    {
                        usBack.aziende[y] =AzId[y];
                    }
                }
              //  var json = JsonConvert.SerializeObject(usBack);
              //  var content = new StringContent(json, Encoding.UTF8, "application/json");
              //  await DisplayAlert("Attendere", json+"chiamata:"+content, "OK");
               var response= await App.UsManager.SaveTaskAsync(usBack);//codice da usare per connesione backend
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Attendere", "Attendere conferma registrazione tramite mail", "OK");
                }
                else {
                    String s = await response.Content.ReadAsStringAsync();
                    await Navigation.PushAsync(new MainPage());
                    string[] s1 =s.Split(':');
               
                    string S1 = s1[2].TrimEnd(new char[] { '}', '"' });
                    byte[] bytes = Encoding.Default.GetBytes(S1);
                    String S2 = Encoding.UTF32.GetString(bytes);
                    await DisplayAlert("Errore", S2, "OK");
                    await Navigation.PushAsync(new Registrati());

                }

            }
                else
                {
                    if (pagine.ElementAt(pagine.Count - 2).ToString() == "EventUPv2.HomePage")//utilizzo count-2 perchè all'interno della pila di navigazione da la pagina precedente

                    {

                        //await App.UsManager.DeleteTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                        Constants.CurrentUser.valAz = val;
                        Constants.CurrentUser.aziende = az;
                        //  await App.UsManager.SaveTaskAsync(Constants.CurrentUser);//codice da usare per connesione backend
                        await Navigation.PopAsync();

                    }

                }
            }
            
   
       

    }
}
