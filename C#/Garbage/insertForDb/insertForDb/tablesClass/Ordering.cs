using insertForDb.Inrerface;
using System;
using System.Collections.Generic;
using System.Text;

namespace insertForDb.tablesClass
{
	class Ordering: IValueForTable
	{
		private static int _id = 0;
		public int id { get { return _id; } set { _id++; } }
		public int husbandId { get; set; }
		public int clientId { get; set; }

		public int numberService { get; set; }

		public void GetValueForTable()
		{
			throw new NotImplementedException();
		}
	}
}
