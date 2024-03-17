namespace ClassDiagram
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }  
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }  
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
