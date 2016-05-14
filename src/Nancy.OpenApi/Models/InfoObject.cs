namespace Nancy.OpenApi.Models
{
    public class InfoObject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public string Version { get; set; }
        public ContactObject Contact { get; set; }
        public LicenceObject Licence { get; set; }

        public InfoObject()
        {
            Contact = new ContactObject();
            Licence = new LicenceObject();
        }
    }
}