using System.Text.Json;
using System.Text;
using Lab6;
using System.Runtime.CompilerServices;

class Program
{
    static async Task SendSinhVienListToFirebaseAsync(List<SinhVien> sinhVien)
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "sinhviens";
        using var httpClient = new HttpClient();

        foreach (var sv in sinhVien)
        {
            var json = JsonSerializer.Serialize(sv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{databaseUrl}/{node}/{sv.MSSV}.json", content);
            response.EnsureSuccessStatusCode();
        }
    }
    static async Task<List<SinhVien>> GetSinhVienListFromFirebaseAsync()
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "sinhviens";
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{databaseUrl}/{node}.json");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(json) || json == "null")
            return new List<SinhVien>();

        var dict = JsonSerializer.Deserialize<Dictionary<string, SinhVien>>(json);
        var list = dict?.Values.ToList() ?? new List<SinhVien>();

        Console.WriteLine("Danh sách SinhVien từ Firebase:");
        foreach (var sv in list)
        {
            Console.WriteLine(sv);
        }

        return list;
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Firebase Admin SDK initialized. Realtime Database access is not supported in this SDK.");

        var sinhVienList = new List<SinhVien>
                {           new SinhVien(101, "MeiMei", 10, 8),
                            new SinhVien(102, "Gojo", 8, 5),
                            new SinhVien(103, "Geto", 9, 10)
                };
        SinhVien.ThemSinhVien(sinhVienList);
        SinhVien.XoaSinhVien(sinhVienList);
        SinhVien.Top5SinhVien(sinhVienList);

        SendSinhVienListToFirebaseAsync(sinhVienList).GetAwaiter().GetResult();
        GetSinhVienListFromFirebaseAsync().GetAwaiter().GetResult();
    }
    static async Task SendTop5SinhVienToFirebaseAsync(List<SinhVien> sinhVien)
    {
        string databaseUrl = "https://fir-bcb83-default-rtdb.asia-southeast1.firebasedatabase.app/";
        string node = "top5";
        using var httpClient = new HttpClient();

        // Get top 5 students by Diem descending
        var top5 = sinhVien.OrderByDescending(sv => sv.Diem).Take(5).ToList();
        var json = JsonSerializer.Serialize(top5);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"{databaseUrl}/{node}.json", content);
        response.EnsureSuccessStatusCode();
    }
}