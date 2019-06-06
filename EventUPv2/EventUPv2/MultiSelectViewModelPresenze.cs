using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventUPv2
{
	public class MultiSelectViewModelPresenze
	{
        

        public MultiSelectViewModelPresenze(List<SelectableData<ExampleDataPresenze>> data)
		{
			DataList = data;
		}

 

        // As example if you need to convert
        //private void LoadData(List<ExampleData> data)
        //{
        //	var list = new List<SelectableData<ExampleData>>();

        //	foreach (var item in data)
        //		list.Add(new SelectableData<ExampleData>() { Data = item });

        //	DataList = list;
        //}

        public List<SelectableData<ExampleDataPresenze>> DataList { get; set; }

		public List<SelectableData<ExampleDataPresenze>> GetNewData()
		{
			var list = new List<SelectableData<ExampleDataPresenze>>();

			foreach (var data in DataList)
				list.Add(new SelectableData<ExampleDataPresenze>() { Data = data.Data.Clone(), Selected = data.Selected });

			return list;
		}

	

	}
}
