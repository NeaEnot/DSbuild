namespace DS1core.Models
{
    public class Armor : Item
    {
        public double PhisycalProtection { get; set; }
        public double PhisycalHitProtection { get; set; }
        public double PhisycalSharpProtection { get; set; }
        public double PhisycalLungeProtection { get; set; }
        public double MagicalProtection { get; set; }
        public double FirelProtection { get; set; }
        public double LightningProtection { get; set; }

        public int BleedProtection { get; set; }
        public int PoisonProtection { get; set; }
        public int CurseProtection { get; set; }
        public int Poise { get; set; }
    }
}
