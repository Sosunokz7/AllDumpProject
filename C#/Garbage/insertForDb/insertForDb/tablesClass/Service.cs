using insertForDb.Inrerface;
using System;
using System.Collections.Generic;
using System.Text;

namespace insertForDb.tablesClass
{
	class Service: IValueForTable
	{
		private static int _id = 0;
		public int id { get { return _id; } set { _id++; } }

		public string nameService { get; set; }

		public double price {get; set; }

		public void GetValueForTable()
		{
			throw new NotImplementedException();
		}
	}
}
