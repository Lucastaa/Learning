using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Lab11;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Firebase installed successfully!");

        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("C:\\Users\\Predator\\Documents\\GitHub\\Learning\\Lab11\\fir-bcb83-firebase-adminsdk-fbsvc-a2fb1a32b0.json")
        });
        

        List <Player> players = await GetPlayerListFromFirebaseAsync();

        var findPlayers = players.Where(p => p.Gold > 1000 && p.Coins > 100)
            .OrderByDescending(p => p.Gold)
            .Select(p => new
            {
                p.Name,
                p.Gold,
                p.Coins
            });
        foreach (var player in findPlayers)
        {
            Console.WriteLine($"Tên: {player.Name}, Gold: {player.Gold}, Coins: {player.Coins}");
        }
        await SendTopRichPlayerToFirebaseAsync();
        // Tổng VIP Players
        int vipPlayers = players.Count(p => p.VipLevel > 0);
        Console.WriteLine($"Tổng Vip Players: {vipPlayers}");

        // VIP Players Khu vực Asian
        var asianPlayers = players.Where(p => p.Region == "Asia" && p.VipLevel > 0);
        int asianVipPlayers = asianPlayers.Count();
        Console.WriteLine($"Khu vực: Asian, Số người chơi VIP: {asianVipPlayers}");

        // VIP Players khu vực American
        var americanPlayers = players.Where(p => p.Region == "America" && p.VipLevel > 0);
        int americanVipPlayers = americanPlayers.Count();
        Console.WriteLine($"Khu vực: American, Số người chơi VIP: {americanVipPlayers}");

        // VIP Players khu vực European
        var europeanPlayers = players.Where(p => p.Region == "Europe" && p.VipLevel > 0);
        int europeanVipPlayers = europeanPlayers.Count();
        Console.WriteLine($"Khu vực: European, Số người chơi VIP: {europeanVipPlayers}");

        Console.WriteLine("Người chơi VIP mới đăng nhập");
        var now = new DateTime(2025, 06, 30, 0, 0, 0);
        var bai2 = players.Where(p => p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2)
            .Select(p => new
            {
                p.Name,
                p.VipLevel,
                p.LastLogin
            });
        foreach (var player in bai2) Console.WriteLine($"Tên: {player.Name}, VipLevel: {player.VipLevel}, LastLogin: {player.LastLogin}");

        
        await SendVipPlayers2Days();

        Console.WriteLine("Top 3 người chơi giàu nhất");
        var Top3Richest = players.OrderByDescending(p => p.Gold).Take(3)
            .Select(p => new
            {
                p.Name,
                p.Gold,
                p.Coins
            });
        foreach (var player in Top3Richest)
        {
            Console.WriteLine($"Tên: {player.Name}, Gold: {player.Gold}, Coins: {player.Coins}");
        }

        await SendTop3Richest();
    }

    static async Task SendTopRichPlayerToFirebaseAsync()
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "quiz_bai1_richPlayers";

        using var httpClient = new HttpClient();

        List<Player> players = await GetPlayerListFromFirebaseAsync();

        var findPlayers = players.Where(p => p.Gold > 1000 && p.Coins > 100)
            .OrderByDescending(p => p.Gold)
            .Select((p, index) => new
             {
                Rank = index + 1,
                p.Name,
                p.Gold,
                p.Coins
             });

        var dict = findPlayers.ToDictionary(p => p.Rank.ToString(), p => p);
        var json = JsonConvert.SerializeObject(dict);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }

    static async Task<List<Player>> GetPlayerListFromFirebaseAsync()
    {
        try
        {
            var url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
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
    static async Task SendVipPlayers2Days()
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "quiz_bai2_recentVipPlayers";

        using var httpClient = new HttpClient();

        List<Player> players = await GetPlayerListFromFirebaseAsync();

        var now = new DateTime(2025, 06, 30, 0, 0, 0);
        var bai2 = players.Where(p => p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2)
            .Select((p, index) => new
            {
                Rank = index + 1,
                p.Name,
                p.VipLevel,
                p.LastLogin
            });

        var list = bai2.ToDictionary(p => p.Rank.ToString(), p => p);
        var json = JsonConvert.SerializeObject(list);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }
    static async Task SendTop3Richest()
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "quiz_bai3_Top3";

        using var httpClient = new HttpClient();

        List<Player> players = await GetPlayerListFromFirebaseAsync();

        var Top3Richest = players.OrderByDescending(p => p.Gold).Take(3)
            .Select((p, index) => new
            {
                Rank = index + 1,
                p.Name,
                p.Gold,
                p.Coins
            });

        var list = Top3Richest.ToDictionary(p => p.Rank.ToString(), p => p);
        var json = JsonConvert.SerializeObject(list);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }
}
//Top 3 nguoi choi giau nhat