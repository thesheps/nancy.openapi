namespace Nancy.OpenApi.Models
{
    public class Response
    {
        public string Description { get; set; }
        public Schema Schema { get; set; }
        public Headers Headers { get; set; }
        public Example Examples { get; set; }

        public Response()
        {
            Schema = new Schema();
            Headers = new Headers();
            Examples = new Example();
        }
    }
}