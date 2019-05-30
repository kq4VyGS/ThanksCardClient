using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThanksCardClient.Models
{
    public class Section
    {
        public int Id { get; set; }
        public int CD { get; set; }
        public string Name { get; set; }
        public virtual Department Department { get; set; }
    }
}
