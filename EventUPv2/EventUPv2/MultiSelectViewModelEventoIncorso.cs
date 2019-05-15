
using System.Collections.Generic;
using System;
namespace EventUPv2
{
    public class MultiSelectViewModelEventoIncorso
    {
        public MultiSelectViewModelEventoIncorso(List<SelectableDataEventoIncorso<ExampleDataEvento>> data)
        {
            DataListEventoIncorso = data;
        }



        // As example if you need to convert
        //private void LoadData(List<ExampleData> data)
        //{
        //  var list = new List<SelectableData<ExampleData>>();

        //  foreach (var item in data)
        //      list.Add(new SelectableData<ExampleData>() { Data = item });

        //  DataList = list;
        //}

        public List<SelectableDataEventoIncorso<ExampleDataEvento>> DataListEventoIncorso { get; set; }

        public List<SelectableDataEventoIncorso<ExampleDataEvento>> GetNewData()
        {
            var list = new List<SelectableDataEventoIncorso<ExampleDataEvento>>();

            foreach (var data in DataListEventoIncorso)
                list.Add(new SelectableDataEventoIncorso<ExampleDataEvento>() { Data1 = data.Data1.Clone(), Selected = data.Selected });

            return list;
        }
    }
}
