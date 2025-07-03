using Lab12;
using Newtonsoft.Json;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        //FirebaseApp.Create(new AppOptions()
        //{
        //    Credential = GoogleCredential.FromFile("C:\\Users\\Predator\\Documents\\GitHub\\Learning\\Lab11\\fir-bcb83-firebase-adminsdk-fbsvc-a2fb1a32b0.json")
        //});
        List<Player> players = await GetPlayerListFromFirebaseAsync();
        // Danh sách người chơi không hoạt động
        //var inactivePlayers = players.Where(p => !p.IsActive)
        //                            .Select(p => new
        //                            { 
        //                                p.Name,
        //                                p.IsActive,
        //                                p.LastLogin 
        //                            });
        //foreach (var player in inactivePlayers) Console.WriteLine($"Name: {player.Name}, Is Active: {player.IsActive}, Last Login: {player.LastLogin}");

        // Danh sách người chơi không hoạt động quá 5 ngày
        Console.WriteLine("Danh sách người chơi không hoạt động quá 5 ngày:");
        DateTime now = new DateTime(2025, 06, 30,0, 0, 0, DateTimeKind.Utc);
        var lastLogin = players.Where(p => (now - p.LastLogin).TotalDays > 5)
                            .Select(p => new
                            {
                                p.Name,
                                p.IsActive,
                                p.LastLogin,
                            });
        foreach (var player in lastLogin) Console.WriteLine($"Name: {player.Name}, Is Active: {player.IsActive}, Last Login: {player.LastLogin}");
        await Send5PlayerNotActiveToFirebaseAsync();

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Danh sách người chơi cấp thấp:");
        var lowLevelPlayers = players.Where(p => p.Level < 10)
                                    .OrderByDescending(p => p.Level)
                                    .Select(p => new
                                    {
                                        p.Name,
                                        p.Level,
                                        p.Gold,
                                    });
        foreach (var player in lowLevelPlayers) Console.WriteLine($"Name: {player.Name}, Level: {player.Level}, Gold: {player.Gold}");
        await SendLowLevelPlayerToFirebaseAsync();

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("TOP 3 người chơi VIP có Level cao nhất:");
        var topVipPlayers = players.Where(p => p.VipLevel > 0)
                                   .OrderByDescending(p => p.Level).Take(3)
                                   .Select((p, Awarded) => new
                                   {
                                       p.Name,
                                       p.Level,
                                       p.VipLevel,
                                       p.Gold,
                                       Awarded = (Awarded == 0 ? 2000 : 0) + (Awarded == 1 ? 1500 : 0) + (Awarded == 2 ? 1000 : 0),
                                   });
        foreach (var player in topVipPlayers) Console.WriteLine($"Name: {player.Name}, Level: {player.Level}, Vip Level: {player.VipLevel}, Current Gold: {player.Gold}, Awarded Gold: {player.Awarded}");
        await SendTop3VipPlayerToFireBaseAsync();
    }
    static async Task Send5PlayerNotActiveToFirebaseAsync()
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "final_exam_bai1_inactive_players";

        using var httpClient = new HttpClient();

        List<Player> players = await GetPlayerListFromFirebaseAsync();
        DateTime now = new DateTime(2025, 06, 30,0, 0, 0, DateTimeKind.Utc);
        var lastLogin = players.Where(p => (now - p.LastLogin).TotalDays > 5)
            .Select((p, index) => new
            {
                Rank = index + 1,
                p.Name,
                p.IsActive,
                p.LastLogin,
            });

        var dict = lastLogin.ToDictionary(p => p.Rank.ToString(), p => p);
        var json = JsonConvert.SerializeObject(dict);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }
    static async Task SendLowLevelPlayerToFirebaseAsync()
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "final_exam_bai1_low_level_players";
        using var httpClient = new HttpClient();
        List<Player> players = await GetPlayerListFromFirebaseAsync();
        var lowLevelPlayers = players.Where(p => p.Level < 10)
                                    .OrderByDescending(p => p.Level)
                                    .Select((p, index) => new
                                    {
                                        Rank = index + 1,
                                        p.Name,
                                        p.Level,
                                        p.Gold,
                                    });
        var dict = lowLevelPlayers.ToDictionary(p => p.Rank.ToString(), p => p);
        var json = JsonConvert.SerializeObject(dict);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }
    static async Task SendTop3VipPlayerToFireBaseAsync()
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "final_exam_bai2_top3_vip_awards";
        using var httpClient = new HttpClient();
        List<Player> players = await GetPlayerListFromFirebaseAsync();
        var topVipPlayers = players.Where(p => p.VipLevel > 0)
                                   .OrderByDescending(p => p.Level).Take(3)
                                   .Select((p, Awarded) => new
                                   {
                                       Rank = Awarded + 1,
                                       p.Name,
                                       p.Level,
                                       p.VipLevel,
                                       p.Gold,
                                       Awarded = (Awarded == 0 ? 2000 : 0) + (Awarded == 1 ? 1500 : 0) + (Awarded == 2 ? 1000 : 0),
                                   });
        var dict = topVipPlayers.ToDictionary(p => p.Rank.ToString(), p => p);
        var json = JsonConvert.SerializeObject(dict);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }
    static async Task<List<Player>> GetPlayerListFromFirebaseAsync()
    {
        try
        {
            var url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/lab12_players.json";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<Player>>(json);
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Lỗi HTTP khi tải dữ liệu: {e.Message}");
            return null;
        }
    }
}