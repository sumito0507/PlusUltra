namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox_dragdrop = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(194, 15);
            label1.TabIndex = 0;
            label1.Text = "Textboxへのドラッグ＆ドロップのサンプル";
            // 
            // textBox_dragdrop
            // 
            textBox_dragdrop.AllowDrop = true;
            textBox_dragdrop.BorderStyle = BorderStyle.None;
            textBox_dragdrop.Location = new Point(12, 26);
            textBox_dragdrop.Multiline = true;
            textBox_dragdrop.Name = "textBox_dragdrop";
            textBox_dragdrop.ScrollBars = ScrollBars.Both;
            textBox_dragdrop.Size = new Size(644, 39);
            textBox_dragdrop.TabIndex = 1;
            textBox_dragdrop.DragDrop += textBox_dragdrop_DragDrop;
            textBox_dragdrop.DragEnter += textBox_dragdrop_DragEnter;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "複数ファイル選択のサンプル";
            // 
            // button1
            // 
            button1.BackColor = Color.YellowGreen;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(687, 27);
            button1.Name = "button1";
            button1.Size = new Size(83, 38);
            button1.TabIndex = 2;
            button1.Text = "ファイル選択のサンプル";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox_dragdrop);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_dragdrop;
        private OpenFileDialog openFileDialog1;
        private Button button1;
    }
}