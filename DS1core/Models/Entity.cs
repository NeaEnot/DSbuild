using System.Collections.Generic;

namespace DS1core.Models
{
    public class Entity
    {
        public string Name { get; set; }
        public string WikiLink { get; set; }
        public string ImgLink { get; set; }
        public List<string> Categories { get; set; }
    }
}
