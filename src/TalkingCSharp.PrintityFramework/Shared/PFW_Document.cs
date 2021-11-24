using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared
{
    public class PFW_Document
    {
        public Size Size { get; set; }
        public List<PFW_Table> Tables { get; set; } = new List<PFW_Table>();
        public List<PFW_PlaceTextBox> PlaceTextBoxes { get; set; } = new List<PFW_PlaceTextBox>();
        public List<PFW_PlaceHeaderValue> PlaceHeaderValues { get; set; } = new List<PFW_PlaceHeaderValue>();
    }
}
