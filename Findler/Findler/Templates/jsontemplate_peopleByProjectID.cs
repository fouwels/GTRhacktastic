using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Findler.Templates.JsonTemplates.PeopleByProjectID
{
    public class OtherAttributes
    {
    }

    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public object start { get; set; }
        public object end { get; set; }
        public OtherAttributes otherAttributes { get; set; }
    }

    public class Links
    {
        public List<Link> link { get; set; }
    }

    public class Person
    {
        public Links links { get; set; }
        public object ext { get; set; }
        public string id { get; set; }
        public string href { get; set; }
        public long created { get; set; }
        public object updated { get; set; }
        public string firstName { get; set; }
        public object otherNames { get; set; }
        public string surname { get; set; }
        public object email { get; set; }
    }

    public class JsonTemplate_peopleByProjectID
    {
        public object links { get; set; }
        public object ext { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public int totalPages { get; set; }
        public int totalSize { get; set; }
        public List<Person> person { get; set; }
    }
}
