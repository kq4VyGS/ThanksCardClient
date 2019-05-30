using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThanksCardClient.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int CD { get; set; }
        public string Name { get; set; }

        // 多対1: User エンティティは1つの Department エンティティに属する
        //public virtual Department Department { get; set; }
    }
}
