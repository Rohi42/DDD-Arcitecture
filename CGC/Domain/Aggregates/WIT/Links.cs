namespace CGC.Domain.Aggregates.WIT
{
    public class Links
    {
       
            public Link Self { get; set; }
            public Link WorkItemUpdates { get; set; }
            public Link WorkItemRevisions { get; set; }
            public Link WorkItemComments { get; set; }
            public Link Html { get; set; }
            public Link WorkItemType { get; set; }
            public Link Fields { get; set; }
        
       
    }
    public class Link
    {
        public string Href { get; set; }
    }
}
