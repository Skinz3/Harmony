using Harmony.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Scales
{
    public class Scale
    {
        public string Name
        {
            get;
            set;
        }
        public IEnumerable<Note> Notes
        {
            get;
            set;
        }
    }
}
