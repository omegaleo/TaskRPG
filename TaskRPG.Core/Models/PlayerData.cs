using System;
using System.Collections.Generic;
using System.Linq;
using GameDevLibrary.Extensions;
using GameDevLibrary.Models;
using Newtonsoft.Json;

namespace TaskRPG.Core.Models
{
    public class PlayerData
    {
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        
        public string Stats { get; set; }

        public List<Stat> StatList
        {
            get
            {
                return Stats.Split(";").Select(s =>
                {
                    var parts = s.Split(':');
                    return new Stat
                    {
                        Type = Enum.Parse<Stat.StatType>(parts[0]),
                        Value = int.Parse(parts[1])
                    };
                }).ToList();
            }
            set
            {
                Stats = string.Join(";", value.Select(s => $"{s.Type}:{s.Value}"));
            }
        } // List of player stats

        public List<Equipment> EquippedItems { get; set; } // List of currently equipped items
        
        public string Inventory { get; set; } // Serialized inventory data
        
        public List<IItem> InventoryList
        {
            get
            {
                if (Inventory.IsNullOrEmpty())
                    return new List<IItem>();
                
                return JsonConvert.DeserializeObject<List<IItem>>(Inventory);
            }
            set
            {
                Inventory = JsonConvert.SerializeObject(value);
            }
        } // List of items in inventory
        
        public PlayerData(string playerName)
        {
            Id = Guid.NewGuid();
            PlayerName = playerName;
            Level = 1;
            ExperiencePoints = 0;
            Stats = "";
            EquippedItems = new List<Equipment>();
        }
        
        public int ExperienceToNextLevel()
        {
            return Level * 100;
        }
        
        public void GainExperience(int points, out bool leveledUp)
        {
            ExperiencePoints += points;
            while (ExperiencePoints >= ExperienceToNextLevel())
            {
                ExperiencePoints -= ExperienceToNextLevel();
                LevelUp();
                
                leveledUp = true;
            }
            
            leveledUp = false;
        }
        
        private void LevelUp()
        {
            Level++;
        }
        
        public override string ToString()
        {
            return $"{PlayerName} (Level {Level}) - XP: {ExperiencePoints}/{ExperienceToNextLevel()} {Environment.NewLine}Stats:  {Environment.NewLine} - {string.Join($"{Environment.NewLine} - ", Stats)} {Environment.NewLine}Equipped:  {Environment.NewLine} - {string.Join($"{Environment.NewLine} - ", EquippedItems)}";
        }
    }
}