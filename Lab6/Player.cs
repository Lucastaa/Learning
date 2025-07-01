namespace Lab6
{
    class Player
    {
        public string PlayerID { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Score { get; set; }
        public Player()
        {
            PlayerID = string.Empty;
            Name = string.Empty;
            Gold = 0;
            Score = 0;
        }
        public Player(string id, string name, int gold, int score)
        {
        PlayerID = id;
        Name = name;
        Gold = gold;
        Score = score;
        }
        public static void AddPlayer(List<Player> player)
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Write("Do you want to add another player? (y/n): ");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "y")
                {
                    Console.Write("Your playerID: ");
                    string id = Console.ReadLine();
                    Console.Write("Your name: ");
                    string name = Console.ReadLine();
                    Console.Write("Gold you had: ");
                    int gold = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Your score: ");
                    int score = Convert.ToInt32(Console.ReadLine());
                    Player pl = new Player(id, name, gold, score);
                    player.Add(pl);
                    ShowAllPlayer(player);
                }
                else if (choice.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input (y/n).");
                }
            }
        }
        public static void UpdateGoldScore(List<Player> player)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Enter PlayerID to update value: ");
                string playerid = Console.ReadLine();
                Player pl = player.FirstOrDefault(s => s.PlayerID == playerid);
                if (pl != null)
                {
                    Console.WriteLine($"Found {pl}");
                    Console.Write("Do you want to update gold or score? (y/n): ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "y" && pl != null)
                    {
                        Console.Write("Amount gold change: ");
                        int gold = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount score change: ");
                        int score = Convert.ToInt32(Console.ReadLine());
                        pl.Gold += gold;
                        pl.Score += score;
                    }
                    else if (choice.ToLower() == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input (y/n).");
                    }
                }
                else if (playerid == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not found with this id.");
                    continue;
                }
                
            }
        }
        public static void DeletePlayer(List<Player> player)
        {
            Console.Write("PlayerID to delete: ");
            string playerid = Console.ReadLine();
            Player pl = player.FirstOrDefault(s => s.PlayerID == playerid);
            if (pl != null)
            {
                player.Remove(pl);
                Console.WriteLine($"Found {pl}");
            }
            else
            {
                Console.WriteLine("Not found with this id.");
            }
        }
        public static void Top5GoldPlayer(List<Player> player)
        {
            Console.WriteLine("==========================================================");
            var top5 = player.OrderByDescending(p => p.Gold).Take(5).ToList();
            Console.WriteLine("Top 5 Player had most gold:");
            foreach (var pl in top5)
            {
                Console.WriteLine(pl);
            }
        }
        public static void Top5ScorePlayer(List<Player> player)
        {
            Console.WriteLine("==========================================================");
            var top5 = player.OrderByDescending(p => p.Score).Take(5).ToList();
            Console.WriteLine("Top 5 Player had most score:");
            foreach (var pl in top5)
            {
                Console.WriteLine(pl);
            }
        }
        public static void ShowAllPlayer(List<Player> player)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("All Players:");
            foreach (var pl in player)
            {
                Console.WriteLine(pl);
            }
        }
        public override string ToString()
        {
                
                return $"{PlayerID} - Name: {Name}, Gold: {Gold}, Score: {Score}";
                
        }
    }
}
