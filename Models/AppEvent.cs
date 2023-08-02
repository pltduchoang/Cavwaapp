namespace CAVWAApp.Models
{
    public class AppEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime EventDate { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }

        public AppEvent()
        {
            
        }
    }
}
