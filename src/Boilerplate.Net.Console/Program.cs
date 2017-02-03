using Contentful.Core;
using Contentful.Core.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

class Program
{
    static void Main(string[] args)
    {
        var httpClient = new HttpClient();
        var client = new ContentfulClient(
            httpClient,
            "<delivery_api_key>",
            "<space_id>");
        var entries = client.GetEntriesAsync<Entry<dynamic>>().Result;
        Console.WriteLine(JsonConvert.SerializeObject(entries, Formatting.Indented));
        Console.ReadLine();
    }
}