using System;

namespace TaskRPG.Core.Models
{
    public class ShopEquipment : EquipmentData
    {
        public Guid Id { get; set; }
        
        public ShopEquipment() : base()
        {
            Id = Guid.NewGuid();
        }
    }
}