using insertForDb.Inrerface;
using System;


namespace insertForDb.tablesClass
{
	class HusbandsContract : IValueForTable
	{

		private static int _id = 0;
		public int id { get { return _id; } set { _id++; } }
		int husbandId { get; set; }
		int dataContract { get; set; }

		public void GetValueForTable()
		{
			throw new NotImplementedException();
		}
	}
}
