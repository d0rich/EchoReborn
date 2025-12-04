namespace EchoReborn.Data.Models
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int MaxHP { get; set; }

        // HP courant pour le combat (non XSD, comme pour Character)
        public int CurrentHP { get; set; }
    }
}
