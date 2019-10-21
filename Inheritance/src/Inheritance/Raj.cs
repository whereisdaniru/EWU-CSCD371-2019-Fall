using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool womenArePresent { get; set; }

        public string getSpeakWomen()
        {
            return "*mumble*";
        }
        public string getSpeakNoWomen()
        {
            return "I haven't cried this hard since Toy Story 3.";
        }

    }

}
