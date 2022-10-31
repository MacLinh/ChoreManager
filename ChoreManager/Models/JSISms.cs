using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// From|To|DateTime|Text

namespace ChoreManager.Models
{
    public class JSISms
    {
        public string From { get; set; }

        public string To { get; set; }

        public string DateTime { get; set; }

	public string Text { get; set; }
    }
}
