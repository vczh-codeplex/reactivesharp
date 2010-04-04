using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReactiveSharp;

namespace DemoClickButtons
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Controls
                .Cast<Control>()
                .Where(c => c.GetType() == typeof(Button))
                .AttachEvent<EventArgs>("Click")
                .Count()
                .Listen(i => this.Text = "You have clicked " + i.ToString() + " times.");
        }
    }
}
