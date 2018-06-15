using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Lab08_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            ReadFiles();

            Console.ReadKey();
        }
        static void ReadFiles()
        {
            string path = "../../../../Data.json";
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    FeaturesObj items = JsonConvert.DeserializeObject<FeaturesObj>(json);
                    //QueryPlease(items);
                    LinqMePlease(items);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public static void LinqMePlease(FeaturesObj obj)
        {
            var hoods = from n in obj.Features
                            where n.Properties.Neighborhood != null
                            select n;

            //foreach (var hood in hoods)
            //{
            //    Console.WriteLine(hood.Properties.Neighborhood);
            //}
            Console.WriteLine("Now we are going to get all of the neighborhoods that have a name, press a key");
            Console.ReadKey();

            var noHood = from n in hoods
                         where n.Properties.Neighborhood != ""
                         select n.Properties.Neighborhood;
            foreach (var hoodless in noHood)
            {
              //  Console.WriteLine(hoodless.Properties.Neighborhood);
            }
            Console.WriteLine("Now we are going to get all of the unique neighborhoods, press a key");
            Console.ReadKey();
            var uniqueHood = noHood.Distinct();
            //var uniqueHood = noHood.GroupBy(h => )
            foreach (var hoodie in uniqueHood)
            {
              //  Console.WriteLine(hoodie);
            }
            Console.WriteLine("Now we're going to query all the above queries in one");
            Console.ReadKey();
            var allHoods = obj.Features.Where(n => n.Properties.Neighborhood != "").Distinct();
            foreach(var hood in allHoods)
            {
                Console.WriteLine(hood.Properties.Neighborhood);
            }
            Console.ReadKey();
        }
    }
}
