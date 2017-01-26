using Contentful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boilerplate.net.web.Models
{
    public class ContentfulExampleModel
    {
        public Space Space { get; set; }

        public List<Entry<dynamic>> Entries { get; set; }

        public List<Asset> Assets { get; set; }
    }
}
