using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventUPv2
{
	public class MultiSelectViewModel
	{
        

        public MultiSelectViewModel(List<SelectableData<ExampleData>> data)
		{
			DataList = data;
		}
        public List<SelectableData<ExampleData>> DataList { get; set; }

		public List<SelectableData<ExampleData>> GetNewData()
		{
			var list = new List<SelectableData<ExampleData>>();

			foreach (var data in DataList)
				list.Add(new SelectableData<ExampleData>() { Data = data.Data.Clone(), Selected = data.Selected });

			return list;
		}

	

	}
}
