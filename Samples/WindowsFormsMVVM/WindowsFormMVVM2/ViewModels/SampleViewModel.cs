using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormMVVM2.ViewModels
{
    using System.ComponentModel;
    using WindowsFormMVVM2.Models;

    public class SampleViewModel : INotifyPropertyChanged
    {
        private SampleModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SampleText
        {
            get { return _model.SampleText; }
            set
            {
                _model.SampleText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SampleText)));
                SampleRichText = value;
            }
        }

        public string SampleRichText
        {
            get { return _model.SampleRichText; }
            set
            {
                _model.SampleRichText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SampleRichText)));
            }
        }

        public List<string> SampleComboBoxItems
        {
            get { return _model.SampleComboBoxItems; }
            set
            {
                _model.SampleComboBoxItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SampleComboBoxItems)));
            }
        }
        public string SampleComboBoxSelectedText
        {
            get { return _model.SampleComboBoxSelectedText; }
            set
            {
                _model.SampleComboBoxSelectedText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SampleComboBoxSelectedText)));
            }
        }

        public SampleViewModel()
        {
            _model = new SampleModel();
            SampleComboBoxItems.AddRange(new List<string> { "ネザーランドドワーフ", "ミニレッキス", "ドワーフホト", "ホーランドロップ", "ロップイヤー" });
            SampleComboBoxSelectedText = "ミニレッキス";
        }
    }
}
