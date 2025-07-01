using Lab6;
using System.Text;
using System.Text.Json;

class Program
{
    static async Task SendPlayerListToFirebaseAsync(List<Player> player)
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "Players";
        using var httpClient = new HttpClient();

        foreach (var pl in player)
        {
            var json = JsonSerializer.Serialize(pl);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{databaseUrl}/{node}/{pl.PlayerID}.json", content);
            response.EnsureSuccessStatusCode();
        }
    }
    static async Task<List<Player>> GetPlayerListFromFirebaseAsync()
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "Players";
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{databaseUrl}/{node}.json");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(json) || json == "null")
            return new List<Player>();

        var dict = JsonSerializer.Deserialize<Dictionary<string, Player>>(json);
        var list = dict?.Values.ToList() ?? new List<Player>();

        Console.WriteLine("==========================================================");
        Console.WriteLine("List of Player from Firebase:");
        foreach (var pl in list)
        {
            Console.WriteLine(pl);
        }

        return list;
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Firebase Admin SDK initialized.");

        var PlayerList = new List<Player>
        {
            new Player("pl001", "Mr.Todo", 300, 8),
            new Player("pl002", "Can't misssss", 900, 7),
            new Player("pl003", "PinkLover", 350, 4),
            new Player("pl004", "Terikarex", 700, 5),
            new Player("pl005", "Iamadmirable", 500, 6),
            new Player("pl006", "Robbob", 580, 9),
            new Player("pl007", "IHasEyes", 630, 7),
            new Player("pl008", "MindOfTerika", 950, 8),
            new Player("pl009", "T3r1k4", 780, 9)
        };

        Player.AddPlayer(PlayerList);
        Player.UpdateGoldScore(PlayerList);
        Player.DeletePlayer(PlayerList);
        Player.Top5GoldPlayer(PlayerList);
        Player.Top5ScorePlayer(PlayerList);

        SendPlayerListToFirebaseAsync(PlayerList).GetAwaiter().GetResult();
        GetPlayerListFromFirebaseAsync().GetAwaiter().GetResult();
        SendTop5PlayerToFirebaseAsync(PlayerList).GetAwaiter().GetResult();
        SendTop5ScoreToFirebaseAsync(PlayerList).GetAwaiter().GetResult();
    }
    static async Task SendTop5PlayerToFirebaseAsync(List<Player> player)
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "TopGold";
        using var httpClient = new HttpClient();

        var top5 = player.OrderByDescending(pl => pl.Gold).Take(5).ToList();
        var json = JsonSerializer.Serialize(top5);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }
    static async Task SendTop5ScoreToFirebaseAsync(List<Player> player)
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "TopScore";
        using var httpClient = new HttpClient();

        var top5 = player.OrderByDescending(pl => pl.Score).Take(5).ToList();
        var json = JsonSerializer.Serialize(top5);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }
}