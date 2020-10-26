using insertForDb.Inrerface;
using System;

using insertForDb.tablesClass;

using insertForDb.DataBase;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace insertForDb.Core
{
	class BeginProgram
	{
		public static Random random=new Random();
		private const int numberRecords=20;
		private IPeople[] peoples=new IPeople[numberRecords];
		private List<int> allHusbandsId;

		private Ordering[] orderings = new Ordering[numberRecords / 2];
		private Factorie factorie;

		public BeginProgram()
		{
			factorie = new Factorie();
			allHusbandsId = new List<int>();
			
		}


		public async void Start()
		{
			int sec1 = DateTime.Now.Second;
			int p = 0;

			await Task.Run(() => MySqlDB.GetConnectDB().questions.QuestionCreateService());

		for (int i = 0; i != numberRecords; i++)
			{
				if (i  == numberRecords / 2)
					p = 1;
				peoples[i] = await Task.Run(()=>factorie.CreatePeople(p));
				switch (p)
				{
					case 0:
						{
							allHusbandsId.Add(peoples[i].id+1);
							await Task.Run(() => MySqlDB.GetConnectDB().questions.QuestionsCreatePeople(peoples[i] as Husbands)); 
							break;
						}
					case 1:
						{
							int randNum = random.Next(0, allHusbandsId.Count);
							await Task.Run(() => MySqlDB.GetConnectDB().questions.QuestionsCreatePeople(peoples[i] as Clients));
							await Task.Run(() => MySqlDB.GetConnectDB().questions.QyestionsCreateOrdering(factorie.CreateOrdering(allHusbandsId[randNum], peoples[i].id)));
							allHusbandsId.RemoveAt(randNum);
		
							break;
						}
				}
			}

			Console.WriteLine($"{sec1}--------{DateTime.Now.Second}");
			Console.ReadLine();
			Environment.Exit(1);
		}


	}
}
