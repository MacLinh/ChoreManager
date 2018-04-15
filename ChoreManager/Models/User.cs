using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreManager.Models
{
    public class User
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public HashSet<Chore> Chores { get; set; } = new HashSet<Chore>();
    }
}
