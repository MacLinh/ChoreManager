using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using ChoreManager.Models;
using Dapper;

namespace ChoreManager.DataAccess
{
    public class JSIInMemoryDb : IRepository<JSISms>
    {
        private List<JSISms> _parsedResults;

        public JSIInMemoryDb()
        {
            this._parsedResults = new List<JSISms>();
	    this.readFile("resources/Sms.txt");
        }

	private void readFile(string fileName) {
	    using(StreamReader file = new StreamReader(fileName)) {  
 		int counter = 0;  
 		string ln;  
  
 		while ((ln = file.ReadLine()) != null) {  
  			this._parsedResults.Add(new JSISms{
				From = "t",
				To = "f",
				DateTime = "g",
				Text = ln});  
  			counter++;  
 		}  
 		file.Close();  
 		Console.WriteLine($"File has {counter} lines.");  
		} 
	}

        public void Add(JSISms o)
        {
            throw new NotImplementedException();
                  
        }

        public void Delete<TKey>(TKey key)
        {
            throw new NotImplementedException();

        }

        public JSISms Get<TKey>(TKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JSISms> GetAll()
        {
            return this._parsedResults;        }

        public void Update<TKey>(TKey key, JSISms o)
        {
            throw new NotImplementedException();
        }
    }
}