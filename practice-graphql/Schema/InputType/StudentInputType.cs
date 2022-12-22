using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_graphql.Schema.InputType
{
    public class StudentInputType
    {
        public string? Name { get; set; }
        public string? Course { get; set; }
        public int Year { get; set; }
    }
}