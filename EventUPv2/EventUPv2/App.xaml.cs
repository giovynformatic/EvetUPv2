using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EventUPv2
{
    public partial class App : Application
    {
        public static UserManager UsManager { get; private set; }
        public static AdminManager AdManager { get; private set; }
        public static EventoManager EvManager { get; private set; }
    //   public static PresenzeManager PrManager { get; private set; }
        public static NewsManager NManager { get; private set; }
        public static PartecipaEventoManager ParManager { get; private set; }
        public App()
        {
            InitializeComponent();
            UsManager = new UserManager(new RestServiceUser());
            EvManager = new EventoManager(new RestServiceEvento());
            AdManager = new AdminManager(new RestServiceAdmin());
            //PrManager = new PresenzeManager(new RestServicePresenze());
            NManager = new NewsManager(new RestServiceNews());
            ParManager = new PartecipaEventoManager(new RestServicePartecipaEvento());
            MainPage = new NavigationPage(new MainPage());
          
        }

        protected override void OnStart()
        {
            // Handle when your app starts
          //  Constants.listaEventiCorso =await EvManager.GetTasksAsync();
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
