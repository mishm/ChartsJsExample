using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartsExample.Models
{
    public class RefreshedDataModel
    {
        public List<string> XStackLabels { get; set; }
        public List<IEnumerable<int>> YValues { get; set; }
        public List<string> XLabels { get; set; }
    }
}
