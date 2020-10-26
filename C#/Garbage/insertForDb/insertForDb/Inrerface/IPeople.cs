using System;
using System.Collections.Generic;
using System.Text;

namespace insertForDb.Inrerface
{
	interface IPeople
	{
		 int id { get; }
		 string name { get; set; }
		 string surname { get; set; }
		 string numperPhone { get; set; }

		 string address { get; set; }
	}
}
