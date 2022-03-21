namespace DinoGameTeam
{
    public class ConsolePixel
    {
        public string? TextColor { get; set; }
        public string? BackGroundColor { get; set; }
        public char Representation { get; set; }
        public bool BackgroundNecessary { get; set; }

        public override string ToString()
        {
            if (!BackgroundNecessary)
            {
                return $"{Representation}";
            }
            else
            {
                return $"{TextColor}{BackGroundColor}{Representation}\x1b[0m\u001b[0m";
            }
        }
    }
}