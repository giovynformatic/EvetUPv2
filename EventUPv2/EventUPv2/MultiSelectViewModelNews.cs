using System;
using System.Collections.Generic;
namespace EventUPv2
{
    public class MultiSelectViewModelNews
    {
       
            public MultiSelectViewModelNews(List<SelectableDataNews<ExampleDataNews>> data)
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

            public List<SelectableDataNews<ExampleDataNews>> DataList { get; set; }

            public List<SelectableDataNews<ExampleDataNews>> GetNewData()
            {
                var list = new List<SelectableDataNews<ExampleDataNews>>();

                foreach (var data in DataList)
                    list.Add(new SelectableDataNews<ExampleDataNews>() { Data3 = data.Data3.Clone(), Selected = data.Selected });

                return list;
            }

        }

}
