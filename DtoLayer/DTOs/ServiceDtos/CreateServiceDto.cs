using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.ServiceDtos
{
    public class CreateServiceDto
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
