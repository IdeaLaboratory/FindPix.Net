using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FlickrService
{
    public class FlickrService
    {
        const string url = "https://www.flickr.com/services/rest/" +
          "?method=flickr.photos.search" +
          "&api_key={0}" +
          "&tags={1}" +
          "&per_page ={2}" +
          "&format=json" +
          "&nojsoncallback=1";
        const string api = "f686f186ec2475cbb837b9fe525e67fe";
        const string photoUrl = "http://farm{0}.staticflickr.com/{1}/{2}_{3}_n.jpg";

        public static IEnumerable<string> FindPics(string Keyword, int PerPage = 20)
        {
            string html = string.Empty;
            string searchUrl = string.Format(url, api, Keyword, PerPage);

            html = connect(searchUrl);

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(html)))
            {
                FlickrData rootObject = null;
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(FlickrData));
                try
                {
                    rootObject = (FlickrData)deserializer.ReadObject(ms);
                }
                catch (Exception e)
                {

                }

                if (rootObject?.stat == "ok")
                {
                    foreach (var photo in rootObject.photos.photo)
                    {
                        yield return string.Format(photoUrl, photo.farm, photo.server, photo.id, photo.secret);
                    }
                }
            }
        }

        private static string connect(string searchUrl)
        {
            string html;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(searchUrl);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }
    }
}
