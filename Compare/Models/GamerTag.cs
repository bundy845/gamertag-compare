namespace Site.Models
{
    public class GamerTag
    {
        public int TotalScore { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }

        public GamerTag()
        {
            Valid = false;
        }
    }
}