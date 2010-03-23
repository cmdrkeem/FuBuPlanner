using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuBuPlanner.Domain
{
    public class Person
    {
        public Person(string openIdIdentifier)
        {
            OpenIdIdentifier = openIdIdentifier;
        }

        public string OpenIdIdentifier { get; set; }

        public string Name { get; set; }
    }
}
