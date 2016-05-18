namespace Nancy.OpenApi.Models
{
    public class Info
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public string Version { get; set; }
        public Contact Contact { get; set; }
        public License Licence { get; set; }

        public Info()
        {
            Contact = new Contact();
            Licence = new License();
        }
    }
}