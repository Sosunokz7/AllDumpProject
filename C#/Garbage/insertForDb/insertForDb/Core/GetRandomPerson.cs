using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace insertForDb.Core
{
	class GetRandomPerson
	{
		private HttpClient httpClient ;
		public GetRandomPerson()
		{
			httpClient = new HttpClient();
		}

		public async  Task<IEnumerable<string>> RandomPerson()
		{

			var html =await httpClient.GetAsync("https://kabanin.ru/articles/generator-sluchaienix-lichnosteie.html");
			if (html != null && html.StatusCode == System.Net.HttpStatusCode.OK)
			{
				string strHtml = html.Content.ReadAsStringAsync().Result;
				
				HtmlParser htmlParser = new HtmlParser();
				var doc = await htmlParser.ParseDocumentAsync(strHtml);
				int lennResult = 0;
				var result = doc.QuerySelectorAll("input").Where(element => element.ClassName == "form-control").
					Where(element => { lennResult++; return lennResult < 5; })
					.Select(s => s.GetAttribute("value")).Select(s=>s.Replace("\n", " "));
				
				return result;
			}
			throw new Exception("Cant get request 'GET' ");
		}


	}
}
