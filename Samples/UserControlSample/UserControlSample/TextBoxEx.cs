using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

class TextBoxEx : TextBox
{
    // http://note.phyllo.net/?eid=1106271
    private const int WM_PAINT = 0xF;

    // カスタム境界色
    private Color _CustomBorderColor = System.Drawing.SystemColors.ControlText;
    //private Color _CustomBorderColor = Color.FromArgb(171, 173, 179);

    [EditorBrowsable(EditorBrowsableState.Always),
        Browsable(true),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        //DefaultValue(GetType(Color), "ControlText"),
        Category("カスタム"),
      Description("境界線の色です。BorderStyleプロパティがWindows.Forms.BorderStyle.FixedSingleの場合のみ有効です。")]
    public Color CustomBorderColor
    {
        get { return _CustomBorderColor; }
        set
        {
            this._CustomBorderColor = value;
            this.Invalidate();
        }
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_PAINT)
        {
            Graphics graphics = CreateGraphics();
            Rectangle rect = this.ClientRectangle;
            if (_CustomBorderColor != Color.FromArgb(171, 173, 179))
            {
                var pen = new System.Drawing.Pen(_CustomBorderColor);
                try
                {
                    graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
                finally
                {
                    pen.Dispose();
                }
            }
            else
            {
                ControlPaint.DrawVisualStyleBorder(graphics, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }

        }
    }
}
