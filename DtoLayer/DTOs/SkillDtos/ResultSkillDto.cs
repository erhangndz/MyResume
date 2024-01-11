using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.SkillDtos
{
    public class ResultSkillDto
    {
        public string Id { get; set; }
        public string SkillName { get; set; }
        public int Value { get; set; }
        public string BgColor { get; set; }
    }
}
