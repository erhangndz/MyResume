using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Skill:IMongoEntity
    {
        public string SkillName { get; set; }
        public int Value { get; set; }
        public string BgColor { get; set; }
    }
}
