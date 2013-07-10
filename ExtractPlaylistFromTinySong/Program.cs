using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractPlaylistFromTinySong
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("first parameter is tinysong api key, second parameter is file name with queries");
                return;
            }

            var client = new RestClient("http://tinysong.com/");
            client.AddHandler("text/html", new JsonDeserializer());
            var results = new List<Song>();
            var queries = File.ReadAllLines(args[1]);
            foreach (var query in queries)
            {
                results.AddRange(GetSongs(args[0], client, query));
            }

            var jsonSerializer = new JsonSerializer();
            Console.WriteLine(jsonSerializer.Serialize(results));
        }

        private static IEnumerable<Song> GetSongs(string apiKey, IRestClient client, string query)
        {
            var request = new RestRequest("s/{query}", Method.GET);
            request.AddParameter("format", "json"); 
            request.AddParameter("limit", 32);
            request.AddParameter("key", apiKey);
            request.AddUrlSegment("query", query); 
                        
            var response = client.Execute<List<Song>>(request);
            return response.Data;
        }
    }
}
