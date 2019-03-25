using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventUPv2
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            TableView Swit = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new SwitchCell
                        {
                            Text = "SwitchCell:"
                        }
                    }
                }
            };
        }
    }
}
