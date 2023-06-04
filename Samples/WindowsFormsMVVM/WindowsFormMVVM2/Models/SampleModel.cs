using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormMVVM2.Models
{
    public class SampleModel
    {
        public string SampleText { get; set; } = "";
        public string SampleRichText { get; set; } = "";

        public List<string> SampleComboBoxItems { get; set; } = new List<string>();
        public string SampleComboBoxSelectedText { get; set; } = "";
    }
}
