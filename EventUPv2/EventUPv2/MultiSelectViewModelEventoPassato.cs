using System;
using System.Collections.Generic;
namespace EventUPv2
{
    public class MultiSelectViewModelEventoPassato
    {
       
            public MultiSelectViewModelEventoPassato(List<SeletableDataEventoPassato<ExampleDataEvento>> data)
            {
            DataListEventoPassato = data;
            }



        // As example if you need to convert
        //private void LoadData(List<ExampleData> data)
        //{
        //  var list = new List<SelectableData<ExampleData>>();

            //  foreach (var item in data)
            //      list.Add(new SelectableData<ExampleData>() { Data = item });

            //  DataList = list;
            //}

        public List<SeletableDataEventoPassato<ExampleDataEvento>> DataListEventoPassato { get; set; }

        public List<SeletableDataEventoPassato<ExampleDataEvento>> GetNewData()
        {
            var list = new List<SeletableDataEventoPassato<ExampleDataEvento>>();

            foreach (var data in DataListEventoPassato)
                list.Add(new SeletableDataEventoPassato<ExampleDataEvento>() { Data2 = data.Data2.Clone(), Selected = data.Selected });

            return list;
        }
    
    }
}
