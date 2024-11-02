namespace library.Entities
{
    public enum Statuses
    {
        active = 1, inactive = 2
    }
    public class Member
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public int Children { get; set; }
        public Statuses Status { get; set; }
        //public int MaxBooks { get; set; }
        public DateTime JoiningDate { get; set; }


    }
}
