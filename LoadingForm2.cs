﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterTool
{
    public partial class LoadingForm2 : Form
    {
        public LoadingForm2()
        {
            InitializeComponent();
        }

        private void LoadingForm2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 100;
            }
            else
            {
                timer1.Stop();
                Close();
            }
        }
    }
}
