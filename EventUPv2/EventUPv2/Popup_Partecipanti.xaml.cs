﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventUPv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup_Partecipanti
    {
        public List<String[]> listaPartecipanti = new List<String[]>();
        public List<SelectableData<ExampleDataPresenze>> SelectedData;

        public Popup_Partecipanti()
        {
            InitializeComponent();
            SelectedData = new List<SelectableData<ExampleDataPresenze>>();
            for (int a = 0; a < listaPartecipanti.Count(); a++)
            {
                SelectableData<ExampleDataPresenze> s;
                SelectedData.Add(s = new SelectableData<ExampleDataPresenze>() { Data = new ExampleDataPresenze() { Nome = listaPartecipanti.ElementAt(a).ElementAt(0) } });
                bool p = bool.Parse(listaPartecipanti.ElementAt(a).ElementAt(2));
                s.Selected = p;

            }
            BindingContext = new MultiSelectViewModelPresenze(SelectedData);
        }
   

    async void AssegnaPresenze()
    {
        listaPartecipanti = new List<String[]>();
        // listaPartecipanti = await App.AdManager.GetTasksAsync();// codice da usare per connessione back-end



        String[] ad1 = {"fdgs", "gdsg", "1"};
        String[] ad2 = { "fdgs", "gdsg", "0" };
        String[] ad3 = { "fdgs", "gdsg", "0" };

        listaPartecipanti.Add(ad1);
        listaPartecipanti.Add(ad2);
        listaPartecipanti.Add(ad3);
       

    }


}
}