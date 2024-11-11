namespace library.Entities
{
    public class Lending
    {
        public static int code = 1;
        public int Code { get; }
        public int Book { get; set; }
        public int Member { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime ReturningDate { get; set; }
        public Lending()
        {
            Code = code++;
        }
    }

}
