namespace Nancy.OpenApi.Models
{
    public class HeaderObject
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public ItemsObject Items { get; set; }

        public HeaderObject()
        {
            Items = new ItemsObject();
        }
    }
}