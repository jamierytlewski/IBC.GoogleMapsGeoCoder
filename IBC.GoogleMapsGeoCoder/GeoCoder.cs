using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace IBC.GoogleMapsGeoCoder
{
    public class GeoCoder
    {
        public static Location Geocode(string address)
        {
            WebRequest request = WebRequest.Create("http://maps.googleapis.com/maps/api/geocode/json?sensor=false&address=" + System.Web.HttpContext.Current.Server.UrlEncode(address));
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            var results = JsonConvert.DeserializeObject<GoogleMapsGeocode>(responseFromServer);
            reader.Close();
            response.Close();
            return results.results[0].geometry.location;
        }
        private class GoogleMapsGeocode
        {
            public Results[] results { get; set; }
        }

        private class Results
        {
            public Geometry geometry { get; set; }
        }

        private class Geometry
        {
            public Location location { get; set; }
        }

        public struct Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
    }
}
