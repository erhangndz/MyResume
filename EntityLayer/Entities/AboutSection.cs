using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AboutSection: IMongoEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
    }
}
