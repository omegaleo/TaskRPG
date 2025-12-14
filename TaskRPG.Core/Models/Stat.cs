namespace TaskRPG.Core.Models
{
    public class Stat
    {
        public enum StatType
        {
            Strength, // Physical Attack
            Dexterity,  // Accuracy and Evasion
            Constitution,  // Health and Defense
            Intelligence,  // Magic Attack
            Wisdom,  // Magic Defense
        }
        
        public StatType Type { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }
    }
}