﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormMVVM2.ViewModels;

namespace WindowsFormMVVM2.Views
{
    public partial class SampleView : Form
    {
        private SampleViewModel _viewModel;
        public SampleView()
        {
            InitializeComponent();
            _viewModel = new SampleViewModel();
            // テキストボックスのバインド
            //this.textBox1.DataBindings.Add(nameof(textBox1.Text), _viewModel, nameof(_viewModel.SampleText));
            this.textBox1.DataBindings.Add(nameof(textBox1.Text), _viewModel, nameof(_viewModel.TextSample), true, DataSourceUpdateMode.OnPropertyChanged);
            // リッチテキストボックスのバインド
            this.richTextBox1.DataBindings.Add(nameof(richTextBox1.Text), _viewModel, nameof(_viewModel.RichTextBoxSample));
            // コンボボックス（選択し）のバインド
            this.comboBox1.DataBindings.Add(nameof(comboBox1.DataSource), _viewModel, nameof(_viewModel.ComboBoxSampleItems), true);
            // コンボボックス（表示名）のバインド
            this.comboBox1.DataBindings.Add(nameof(comboBox1.Text), _viewModel, nameof(_viewModel.ComboBoxSampleSelectedText), true, DataSourceUpdateMode.OnPropertyChanged);
            // ボタンのバインド
            this.button1.Click += _viewModel.ShowMessage;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}