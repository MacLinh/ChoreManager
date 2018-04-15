using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreManager.Models
{
    public class Chore
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public bool Done { get; set; }

        public int Points { get; set; }
    }
}
