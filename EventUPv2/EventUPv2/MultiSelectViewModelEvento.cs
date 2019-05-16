using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace EventUPv2
{
    public class MultiSelectViewModelEvento
    {
      public ObservableCollection<ExampleDataEvento> DataListEvento { get; set; }
        public List<Evento> listaEv;
       // public List<SelectableDataEvento<ExampleDataEvento>> SelectedDataEventi;
        
        public MultiSelectViewModelEvento() {
              DataListEvento = new ObservableCollection<ExampleDataEvento>();

             // DataListEvento.Add(new Evento( "Corso Cisco", "25/05/2019", null, "Cisco", "adsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdfadsdsdsdsdsdsdsddsdsdsddsdsdsdsddsdsdsdfsdfdsfhajgfyufgasdyugfyusdgyugfsgfhjsagkfhjgjhsdafghjfdsgajhgdsfahjghjsdagjhsdf") );

            
            listaEv = Constants.listaEventi; 
           // SelectedDataEventi = new List<SelectableDataEvento<ExampleDataEvento>>();
           
            
            for (int a = 0; a < listaEv.Count(); a++)
            {
                DataListEvento.Add( new ExampleDataEvento() { Titolo = listaEv.ElementAt(a).Titolo } );


            }
        }

        /*
                private ExampleDataEvento _selectedEvento { get; set; }
                public ExampleDataEvento SelectedEvento {
                    get { return _selectedEvento; }
                    set {
                        if (_selectedEvento != value) {
                            _selectedEvento = value;
                            HandleSelectedItem();
                        }
                    }
                }

                private void HandleSelectedItem() {
                    Page page = new Page();
                     page.DisplayAlert("Selected Item ", "name : "+ SelectedEvento.Titolo, "ok");
                }
                public MultiSelectViewModelEvento(List<ObservableCollection<ExampleDataEvento>> data)
                {
                    DataListEvento = data;
                }

               */

        /*    public MultiSelectViewModelEvento(List<SelectableDataEvento<ExampleDataEvento>> data)
            {
                DataListEvento = data;



            }



            // As example if you need to convert
            //private void LoadData(List<ExampleData> data)
            //{
            //	var list = new List<SelectableData<ExampleData>>();

            //	foreach (var item in data)
            //		list.Add(new SelectableData<ExampleData>() { Data = item });

            //	DataList = list;
            //}

             public List<SelectableDataEvento<ExampleDataEvento>> DataListEvento { get; set; }

            public List<SelectableDataEvento<ExampleDataEvento>> GetNewData()
                    {
                        var list = new List<SelectableDataEvento<ExampleDataEvento>>();

                        foreach (var data in DataListEvento)
                            list.Add(new SelectableDataEvento<ExampleDataEvento>() { Data = data.Data.Clone(), Selected = data.Selected });

                        return list;
                    }
    */
      


    }


}
