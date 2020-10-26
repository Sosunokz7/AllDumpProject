using insertForDb.Inrerface;
using System;


namespace insertForDb.tablesClass
{
	class Husbands : IPeople, IValueForTable
	{
		private static int _id = 0;
		public int id { get { return _id; } set { _id++; } }
		public string name { get; set; }
		public string surname { get; set; }
		public string numperPhone { get; set; }

		public string address { get; set; }

		public void GetValueForTable()
		{
			throw new NotImplementedException();
		}
	}
}
