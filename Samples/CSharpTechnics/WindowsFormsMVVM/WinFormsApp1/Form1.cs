namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_dragdrop_DragEnter(object sender, DragEventArgs e)
        {
            // �h���b�O���̃t�@�C����f�B���N�g���̎擾
            string[] sFileName = (string[])e.Data.GetData(DataFormats.FileDrop);

            //�t�@�C�����h���b�O����Ă���ꍇ�A
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // �z�񕪃��[�v
                foreach (string sTemp in sFileName)
                {
                    // �t�@�C���p�X���`�F�b�N
                    if (File.Exists(sTemp) == false)
                    {
                        // �t�@�C���p�X�ȊO�Ȃ̂ŉ������Ȃ�
                        return;
                    }
                    else
                    {
                        break;
                    }
                }

                // �J�[�\����[+]�֕ύX����
                // ������Effect��ύX���Ȃ��ƁA�ȍ~�̃C�x���g�iDrop�j�͔������Ȃ�
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void textBox_dragdrop_DragDrop(object sender, DragEventArgs e)
        {
            //�h���b�v���ꂽ�t�@�C���̈ꗗ���擾
            string[] sFileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (sFileName.Length <= 0)
            {
                return;
            }

            // �h���b�v�悪TextBox�ł��邩�`�F�b�N
            TextBox TargetTextBox = sender as TextBox;

            if (TargetTextBox == null)
            {
                // TextBox�ȊO�̂��߃C�x���g�����������C�x���g�𔲂���B
                return;
            }

            // �����TextBox���̃f�[�^���폜
            textBox_dragdrop.Text = "";

            // TextBox�h���b�N���ꂽ�������ݒ�
            textBox_dragdrop.Text = string.Join($";{Environment.NewLine}", sFileName); // �z��̐擪�������ݒ�

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_dragdrop.Text = string.Join($";{Environment.NewLine}", openFileDialog1.FileNames);
            }
        }
    }
}