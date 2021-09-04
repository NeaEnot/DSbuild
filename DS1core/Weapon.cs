namespace DS1core
{
    public class Weapon : Item
    {
        public int PhisycalDamage { get; set; }
        public int MagicalDamage { get; set; }
        public int FirelDamage { get; set; }
        public int LightningDamage { get; set; }
        public int CriticalDamage { get; set; }
        public int Bleed { get; set; }
        public int Poison { get; set; }
        public int DivineDamage { get; set; }
        public int DarkDamage { get; set; }
        public int PhisycalProtection { get; set; }
        public int MagicalProtection { get; set; }
        public int FirelProtection { get; set; }
        public int LightningProtection { get; set; }
        public int Stability { get; set; }
        public char StrengthBonus { get; set; }
        public char DexterityBonus { get; set; }
        public char IntelligenceBonus { get; set; }
        public char FaithBonus { get; set; }
        public int StrengthRequirement { get; set; }
        public int DexterityRequirement { get; set; }
        public int IntelligenceRequirement { get; set; }
        public int FaithRequirement { get; set; }
    }
}
