using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int Gold { get; set; }
        public int Coins { get; set; }
        public bool IsActive { get; set; }
        public int VipLevel { get; set; }
        public string Region { get; set; }
        public DateTime LastLogin { get; set; }

        public Player(int id, string name, int level, int gold, int coins, bool isActive, int vipLevel, string region, DateTime lastLogin)
        {
            Id = id;
            Name = name;
            Level = level;
            Gold = gold;
            Coins = coins;
            IsActive = isActive;
            VipLevel = vipLevel;
            Region = region;
            LastLogin = lastLogin;
        }

        public override string ToString()
        {
            return $"Player(Id = {Id}, Name = {Name}, Level = {Level}, Gold = {Gold}, Coins = {Coins}, IsActive = {IsActive}, VipLevel = {VipLevel}, Region = {Region}, LastLogin {LastLogin})";
        }
    }
}
