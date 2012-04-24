using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReactiveSharp;

namespace DemoClickCounter
{
    public partial class CounterForm : Form
    {
        public CounterForm()
        {
            InitializeComponent();
            buttonClickMe.AttachEvent<EventArgs>("Click")
                .Count()
                .Listen(i =>
                {
                    buttonClickMe.Text = "You have clicked " + i.ToString() + " times.";
                });
        }
    }
}
