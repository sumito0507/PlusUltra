using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormMVVM2.Models
{
    public class SampleModel
    {
        /// <summary>
        /// テキストボックスの文字列
        /// </summary>
        public string TextSample { get; set; } = "";
        /// <summary>
        /// リッチテキストの文字列
        /// </summary>
        public string RichTextBoxSample { get; set; } = "";
        /// <summary>
        /// コンボボックスのアイテムリスト
        /// </summary>
        public List<string> ComboBoxSampleItems { get; set; } = new List<string>();
        /// <summary>
        /// コンボボックスの選択テキスト
        /// </summary>
        public string ComboBoxSampleSelectedText { get; set; } = "";
    }
}
