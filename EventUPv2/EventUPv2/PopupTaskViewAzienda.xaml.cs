using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EventUPv2
{

	public partial class PopupTaskViewAzienda 
	{
		public PopupTaskViewAzienda ()
		{
			InitializeComponent ();
            NomeAzienda.Text = Constants.CurrentAdmin.nome;
            Sede.Text = Constants.CurrentAdmin.Sede;
            Piva.Text = Constants.CurrentAdmin.piva;
            email.Text = Constants.CurrentAdmin.email;
		}
	}
}