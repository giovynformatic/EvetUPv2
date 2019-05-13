
using System.Collections.Generic;
using System;
namespace EventUPv2
{
    public class MultiSelectViewModelEventoIncorso
    {
        public MultiSelectViewModelEventoIncorso(List<SelectableDataEventoIncorso<ExampleDataEvento>> data)
        {
            DataList = data;
        }



        // As example if you need to convert
        //private void LoadData(List<ExampleData> data)
        //{
        //  var list = new List<SelectableData<ExampleData>>();

        //  foreach (var item in data)
        //      list.Add(new SelectableData<ExampleData>() { Data = item });

        //  DataList = list;
        //}

        public List<SelectableDataEventoIncorso<ExampleDataEvento>> DataList { get; set; }

        public List<SelectableDataEventoIncorso<ExampleDataEvento>> GetNewData()
        {
            var list = new List<SelectableDataEventoIncorso<ExampleDataEvento>>();

            foreach (var data in DataList)
                list.Add(new SelectableDataEventoIncorso<ExampleDataEvento>() { Data = data.Data.Clone(), Selected = data.Selected });

            return list;
        }
    }
}
