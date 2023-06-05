using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormMVVM2.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Input;
    using WindowsFormMVVM2.Command;
    using WindowsFormMVVM2.Models;

    /// <summary>
    /// WindowsFormsアプリでのMVVMパターンサンプル
    /// https://soft-rime.com/post-10769/
    /// </summary>
    public class SampleViewModel : INotifyPropertyChanged
    {
        private SampleModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

        #region プロパティ
        public string TextSample
        {
            get { return _model.TextSample; }
            set
            {
                _model.TextSample = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextSample)));
                RichTextBoxSample = value;
            }
        }

        public string RichTextBoxSample
        {
            get { return _model.RichTextBoxSample; }
            set
            {
                _model.RichTextBoxSample = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RichTextBoxSample)));
            }
        }

        public List<string> ComboBoxSampleItems
        {
            get { return _model.ComboBoxSampleItems; }
            set
            {
                _model.ComboBoxSampleItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComboBoxSampleItems)));
            }
        }
        public string ComboBoxSampleSelectedText
        {
            get { return _model.ComboBoxSampleSelectedText; }
            set
            {
                _model.ComboBoxSampleSelectedText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComboBoxSampleSelectedText)));
            }
        }

        public ICommand ButtonSample
        {
            //get { return new BaseICommand(ShowMessage); }
            get;
        }
        bool _enabled = true;
        bool canExecute() => _enabled;

        #endregion
        public SampleViewModel()
        {
            _model = new SampleModel();
            ComboBoxSampleItems.AddRange(new List<string> { "ネザーランドドワーフ", "ミニレッキス", "ドワーフホト", "ホーランドロップ", "ロップイヤー" });
            ComboBoxSampleSelectedText = "ミニレッキス";

            //ButtonSample = new SampleButtonCommand((() => ShowMessage()), canExecute);
            //ButtonSample = ShowMessage();
        }

        public void ShowMessage(object sender, EventArgs e)
        {
            string message = $"TextBox : {TextSample}\nRichTextBox : {RichTextBoxSample}\nComboBox : {ComboBoxSampleSelectedText}";
            MessageBox.Show(message, "コントロール");
        }
    }
}
