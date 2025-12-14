using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskRPG.Core.Models
{
    public class Equipment : EquipmentData, IItem
    {
        public new Guid Id { get; set; }
        
        public Equipment() : base()
        {
            Id = Guid.NewGuid();
        }
        
        public void ImportFromData(EquipmentData data)
        {
            Slot = data.Slot;
            Rarity = data.Rarity;
            Name = data.Name;
            Type = data.Type;
            Stats = data.Stats;
        }
    }
}