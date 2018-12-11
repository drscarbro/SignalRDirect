namespace SignalRDirect
{
    public class Call
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}