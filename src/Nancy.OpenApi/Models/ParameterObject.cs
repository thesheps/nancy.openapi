namespace Nancy.OpenApi.Models
{
    public class ParameterObject
    {
        public string Name { get; set; }
        public string In { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public SchemaObject Schema { get; set; }
    }
}