namespace library.Entities
{
    public class Lending
    {
        public int Code { get; set; }
        public int Book { get; set; }
        public int Member { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime ReturningDate { get; set; }
    }
}
