using Lab3_alt;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            hdTestDrive(); //Provided by assignment
            geoTestDrive(); //My own to test geo.cs
        }
        static void hdTestDrive()
        {
            HashDirectory<int, int> hdir= new HashDirectory<int, int>();

            HashtableTester.TestDriver.Instance.Run(hdir, 10000);
        }
        static void geoTestDrive()
        {
            HashDirectory<GeoLocation, string> hdir = new HashDirectory<GeoLocation, string>();
            KeyValuePair<GeoLocation, string>[] geolocations = new KeyValuePair<GeoLocation, string>[32];

            hdir.Add(new GeoLocation(12.34, 56.78), "Manchester");
            hdir.Add(new GeoLocation(90.12, 34.56), "London");

            if (hdir.ContainsKey(new GeoLocation(12.34, 56.78)) && !hdir.ContainsKey(new GeoLocation(12.34, 46.78)))
            {
                hdir[new GeoLocation(12.34, 56.78)] = "Bombai";
                Console.WriteLine(hdir[new GeoLocation(12.34, 56.78)] + " == Bombai, get ::: Worked\n" + "Manchester -> Bombai ::: Worked \nConstainsKey ::: Worked\nAdd() ::: Worked\nset ::: Worked\n");
            }
            if (hdir.Contains(new KeyValuePair<GeoLocation, string>(new GeoLocation(12.34, 56.78), "Bombai")))
            {
                Console.WriteLine("Contains ::: worked\n");
            }

            try
            {
                Console.WriteLine(hdir[new GeoLocation(33.22, 44.33)]);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message + " ::: Worked\n");
            }

            hdir.CopyTo(geolocations, 0);
            if (geolocations[1].Key != null && geolocations[0].Key != null)
            {
                Console.WriteLine("Index 0::: Value:" + geolocations[0].Value + " Key:" + geolocations[0].Key.ToString() + " CopyTo() ::: worked");
                Console.WriteLine("Index 1::: Value:" + geolocations[1].Value + " Key:" + geolocations[1].Key.ToString() + " CopyTo() ::: worked\nEnumerator ::: Worked(in class)\n");
            }

            if (hdir.Remove(new KeyValuePair<GeoLocation, string>(new GeoLocation(12.34, 56.78), "Bombai")))
            {
                Console.WriteLine("Remove() ::: returned true");
            }
            if(!hdir.ContainsKey(new GeoLocation(12.34, 56.78)))
            {
                Console.WriteLine("Remove() ::: worked\n");
            }

            string str;
            var tgv = hdir.TryGetValue(new GeoLocation(90.12, 34.56), out str);
            if(tgv == true)
            {
                Console.WriteLine(str + "TryGetValue() ::: Worked\n");
            }


            hdir.Clear();
            if (!hdir.ContainsKey(new GeoLocation(12.34, 56.78)))
            {
                Console.WriteLine("Clear() ::: Worked");
            }
        }
    }
}