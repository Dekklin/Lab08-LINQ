using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Lab08_Linq
{
    class Program
    { // our main method that initiates the program.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            ReadFiles();

            Console.ReadKey();
        }
        // Reads the file then parses "deserialize" the json into object with objects in them.
        static void ReadFiles()
        {
            string path = "../../../../Data.json";
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    FeaturesObj items = JsonConvert.DeserializeObject<FeaturesObj>(json);
                    //Where I call LinqMePlease()
                    LinqMePlease(items);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        // This is the method that handles all the queries
        public static void LinqMePlease(FeaturesObj obj)
        {
            var hoods = from n in obj.Features
                        where n.Properties.Neighborhood != null
                        select n;
            // the Foreach for neighbors that aren't null
            foreach (var hood in hoods)
            {  
                Console.WriteLine(hood.Properties.Neighborhood);
            }
            Console.WriteLine("Now we are going to get all of the neighborhoods that have a name, press a key");
            Console.ReadKey();

            var noHood = from n in hoods
                         where n.Properties.Neighborhood != ""
                         select n.Properties.Neighborhood;
            // the Foreach for neighbors that aren't an empty string
            foreach (var hoodless in noHood)
            {
              Console.WriteLine(hoodless);
            }

            Console.WriteLine("Now we are going to get all of the unique neighborhoods, press a key");
            Console.ReadKey();
            var uniqueHood = noHood.Distinct();
            //My foreach to post the unique neighborhoods
            foreach (var coolhood in uniqueHood)
            {
                Console.WriteLine(coolhood);
            }

            Console.WriteLine("Now we're going to query all the above queries in one");
            Console.ReadKey();
            var allHoods = obj.Features.Where(n => n.Properties.Neighborhood != "")
                                       .GroupBy(g => g.Properties.Neighborhood)
                                       .Select(m => m.Key);
            // the Foreach for neighbors that aren't null or a string.

            foreach (var hood in allHoods)
            {
                Console.WriteLine(hood);
            }
            Console.ReadKey();
        }
    }
}
