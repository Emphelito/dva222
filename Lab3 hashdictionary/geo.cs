using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_alt
{
    public class GeoLocation
    {
        public double Latitude;
        public double Longitude;

        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude; //cordinates
            Longitude = longitude;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = hash * 37 + Latitude.GetHashCode();
            hash = hash * 37 + Longitude.GetHashCode();
            hash = Math.Abs(hash % 31); //31 size of hashtable
            return hash;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GeoLocation);
        }

        //GeoLocation(90.12, 34.56), "London" && GeoLocation(73.12, 34.00), "Manchester"
        //if we call this from "London" and use "Manchester" as argument, "Manchester" would be other.logitude/latitude
        public bool Equals(GeoLocation other)
        {
            return other != null && Latitude == other.Latitude && Longitude == other.Longitude; 
        }

        public override string ToString() //Just for testing purposes, so i can get a usable output in my own testing function
        {
            return $"({Latitude}, {Longitude})";
        }
    }
}
