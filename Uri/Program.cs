using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var taskLoadWeb = GetWebContent("https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/leaderboard.json");
        taskLoadWeb.Wait();
        var html = taskLoadWeb.Result;
        Console.WriteLine("GetWebContent: " + html);

        string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/leaderboard.json";
        HttpClient httpClient = new HttpClient();
        string serverConfig = await httpClient.GetStringAsync(url);
        List<Player> allPlayers;
        try
        {
            string json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/leaderboard.json");

            allPlayers = JsonConvert.DeserializeObject<List<Player>>(json);

            var goldPlayers = allPlayers
                .Where(p => p.Rank == "Gold")
                .OrderByDescending(p => p.Score)
                .ToList();
            int index = 0;
            foreach (var player in goldPlayers)
            {
                Console.WriteLine($"{++index}. {player.Name} - {player.Score} points");
            }
        }

        //string url = "http://www.google.com";
        //var uri = new Uri(url);
        //var uritype = typeof(Uri);
        //uritype.GetProperties().ToList().ForEach(p =>
        //{
        //    Console.WriteLine($"{p.Name,15} = {p.GetValue(uri)}");
        //});
        //Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");

        //Console.ReadLine();
        //VD01();
        GetWebContent(html).GetAwaiter().GetResult();
    }
    static void VD01()
    {
        string uriString = "https://www.example.com:8080/path/to/resource?query=123#fragment";
        Uri uri = new Uri(uriString);
        Console.WriteLine($"Absolute URI: {uri.AbsoluteUri}");
        Console.WriteLine($"Host: {uri.Host}");
        Console.WriteLine($"Port: {uri.Port}");
        Console.WriteLine($"Path: {uri.AbsolutePath}");
        Console.WriteLine($"Query: {uri.Query}");
        Console.WriteLine($"Fragment: {uri.Fragment}");
        Console.WriteLine($"Is Absolute: {uri.IsAbsoluteUri}");
        Console.WriteLine($"Is Loopback: {uri.IsLoopback}");
        Console.WriteLine($"Local Path: {uri.LocalPath}");
        Console.WriteLine($"Original String: {uri.OriginalString}");
        Console.WriteLine($"Scheme: {uri.Scheme}");
        Console.WriteLine($"User Info: {uri.UserInfo}");
        Console.WriteLine($"Host Name Type: {uri.HostNameType}");
        Console.WriteLine($"Dns Safe Host: {uri.DnsSafeHost}");
        Console.WriteLine($"Idn Host: {uri.IdnHost}");
        Console.WriteLine($"Port: {uri.Port}");
        Console.WriteLine($"Query String: {uri.Query}");
        Console.WriteLine($"Segments: {string.Join(", ", uri.Segments)}");
        Console.WriteLine($"Absolute Path: {uri.AbsolutePath}");
        Console.WriteLine($"User Escaped: {uri.UserEscaped}");
        Console.WriteLine($"Path and Query: {uri.PathAndQuery}");
        Console.WriteLine($"ToString: {uri.ToString()}");
        Console.WriteLine($"Authority: {uri.Authority}");
        Console.WriteLine($"Is Unc: {uri.IsUnc}");
        Console.WriteLine($"Is File: {uri.IsFile}");
    }
    public static async Task<string> GetWebContent(string url)
    {
        string html = "";
        try
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
            HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
            html = await httpResponse.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return html;
    }
    static void StringContent()
    {
        string jsonContent = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";
        var content = new System.Net.Http.StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
    }
    static void FormUrlEncodedContent()
    {
        var values = new System.Collections.Generic.Dictionary<string, string>
        {
            { "name", "John" },
            { "age", "30" },
            { "city", "New York" }
        };
        var content = new System.Net.Http.FormUrlEncodedContent(values);
    }
    static void MultipartFormDataContent()
    {
        var content = new System.Net.Http.MultipartFormDataContent();
        content.Add(new System.Net.Http.StringContent("value1"), "key1");
        content.Add(new System.Net.Http.StringContent("value2"), "key2");
        // Add files or other parts as needed
    }
    static async Task DelegatingHandler()
    {
        var handler = new HttpClientHandler() { AllowAutoRedirect = true, UseCookies = true };
        using (var client = new HttpClient(handler))
        {
            var response = await client.GetAsync("http://example.com");
            Console.WriteLine(response.StatusCode);
            // Use the client for requests
        }
    }
}