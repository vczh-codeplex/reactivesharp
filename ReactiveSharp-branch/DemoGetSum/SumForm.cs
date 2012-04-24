using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReactiveSharp;

namespace DemoGetSum
{
    public partial class SumForm : Form
    {
        public SumForm()
        {
            InitializeComponent();
            buttonEnter.AttachEvent<EventArgs>("Click")
                .Branch(_ =>
                    {
                        try
                        {
                            int.Parse(textNumber.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    })
                .Where(_ => { int result; return int.TryParse(textNumber.Text, out result); })
                .Select(_ => int.Parse(textNumber.Text))
                .Branch(_ => { textNumber.Text = ""; textNumber.Focus(); })
                .Branch(i => listNumbers.Items.Add(i))
                .Where(i => i % 2 == 1)
                .Select(i => i * i)
                .Branch(i => listSquares.Items.Add(i))
                .Sum()
                .Listen(i => textResult.Text = i.ToString());
        }
    }
}
