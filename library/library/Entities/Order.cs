namespace library.Entities
{
    public class Order
    {
        public int Code { get; set; }
        public string BookName { get; set; }
        public int BookCode { get; set; }
        public string PublishName { get; set; }
        public string Tel { get; set; }
        public DateTime OrderDate { get; set; }
        public int Copies { get; set; }
        public double Price { get; set; }
        public double ShippingPrice { get; set; }
        //status-----------
    }
}
