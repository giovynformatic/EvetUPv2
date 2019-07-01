using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace EventUPv2
{
   public class MultiselectViewModelInteressi
    {

        public MultiselectViewModelInteressi(List<SelectableDataInteressi<ExampleDataInteressi>> data)
        {
            DataList = data;
        }
        public List<SelectableDataInteressi<ExampleDataInteressi>> DataList { get; set; }

        public List<SelectableDataInteressi<ExampleDataInteressi>> GetNewData()
        {
            var list = new List<SelectableDataInteressi<ExampleDataInteressi>>();

            foreach (var data in DataList)
                list.Add(new SelectableDataInteressi<ExampleDataInteressi>() { Data = data.Data.Clone(), Selected = data.Selected });

            return list;
        }


    }
}