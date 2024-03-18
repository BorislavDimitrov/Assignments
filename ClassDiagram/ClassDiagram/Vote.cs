namespace ClassDiagram
{
    public class Vote
    {
        public int Id { get; set; }
        public int VoterId { get; set; }
        public User Voter { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.Now;
    }
}
