using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskRPG.Core.Models
{
    public class EquipmentData
    {
        public enum EquipmentSlot
        {
            Head,
            Chest,
            Legs,
            Weapon,
            Shield
        }
        
        public enum EquipmentRarity
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary
        }
        
        public enum EquipmentType
        {
            Weapon,
            Armor,
            Accessory
        }
        
        public EquipmentSlot Slot { get; set; }
        public EquipmentRarity Rarity { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; } // e.g., "Weapon", "Armor"
        public string Stats { get; set; }

        public List<Stat> StatBuffs
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
        public byte[] IconData { get; set; } // Binary data for the icon image

        public byte[] SpriteData { get; set; } // Binary data for the sprite image
        
        public int LevelRequirement { get; set; } // Minimum level required to equip
        
        public int Cost { get; set; } // Cost in in-game currency
        
        public EquipmentData()
        {
            StatBuffs = new List<Stat>();
            IconData = Array.Empty<byte>();
            SpriteData = Array.Empty<byte>();
        }
        
        public EquipmentData(EquipmentSlot slot, EquipmentRarity rarity, string name, EquipmentType type, List<Stat> statBuffs, int levelRequirement, int cost, byte[] iconData)
        {
            Slot = slot;
            Rarity = rarity;
            Name = name;
            Type = type;
            StatBuffs = statBuffs;
            LevelRequirement = levelRequirement;
            Cost = cost;
            IconData = iconData;
        }
        
        public override string ToString()
        {
            return $"{Name} ({Rarity} {Type}) - Slot: {Slot}, Buffs: {string.Join(", ", StatBuffs)}";
        }
    }
}