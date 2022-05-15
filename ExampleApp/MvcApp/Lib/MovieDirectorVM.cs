using ExampleApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleApp.Lib
{
    public class MovieDirectorVM
    {
        public Movie Movie { get; set; }
        public SelectList Directors { get; set; }
    }
}
