namespace Nancy.OpenApi.Models
{
    public class Header
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public Items Items { get; set; }

        public Header()
        {
            Items = new Items();
        }
    }
}