namespace library.Entities
{
    public class Department
    {
        public static int code = 1;
        public int Code { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public Department()
        {
            Code = code++;
        }
    }
}
