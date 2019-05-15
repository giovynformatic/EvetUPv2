using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
    public class MultiSelectViewModelEvento
    {
        public MultiSelectViewModelEvento(List<SelectableDataEvento<ExampleDataEvento>> data)
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

    }
}
