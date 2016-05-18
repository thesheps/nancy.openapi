namespace Nancy.OpenApi.Models
{
    public class Parameter
    {
        public string Name { get; set; }
        public string In { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public Schema Schema { get; set; }

        public Parameter()
        {
            Schema = new Schema();
        }
    }
}