using insertForDb.Core;
using insertForDb.Inrerface;
using insertForDb.tablesClass;

using System;
using System.Linq;

using System.Threading.Tasks;

namespace insertForDb
{
	class Factorie
	{
		private GetRandomPerson randomPerson;
		public Factorie()
		{
			randomPerson = new GetRandomPerson();
			

		}

		public async Task<IPeople> CreatePeople(int num)
		{
			IPeople person;
			var propertyPerson = await Task.Run(()=>randomPerson.RandomPerson().Result.ToArray());
			string[] FIO = propertyPerson[0].Split(" ");
			if (num==0)
			{
				person = new Husbands();
			}
			else
			{
				person = new Clients();
				
			}
			person.name = FIO[0]; 
			person.surname = FIO[2];
			person.address = propertyPerson[2];
			string[] badSign = { "(", "-", ")", " " };
			foreach(string i in badSign)
				propertyPerson[3] = propertyPerson[3].Replace(i,"");
			person.numperPhone = propertyPerson[3];

			return person;
		}


		public Ordering CreateOrdering(int husbandId,int clientId)
		{
			Ordering ordering = new Ordering();
			ordering.husbandId = husbandId;
			ordering.clientId = clientId;
			ordering.numberService = BeginProgram.random.Next(1, 6);
			return ordering;
		}


	}
}
