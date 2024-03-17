namespace ClassDiagram
{
    public class Vote
    {
        public int Id { get; set; }
        public int VoterId { get; set; } 
        public int CandidateId { get; set; }  
        public int PropositionId { get; set; }  
        public DateTime VoteDate { get; set; } = DateTime.Now;
    }
}
