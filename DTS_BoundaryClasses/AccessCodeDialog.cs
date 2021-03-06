//////////////////////////////////////////////////////////////////
//  Domestic Telephone System (DTS)                             //
//    Written by Masaaki Mizuno, (c) 2007, 2008                 //
//      for K-State Course cis501                               //
//      also for Learning Tree Course, 123P, 230Y               //
//////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DTS_Project
{
    public partial class AccessCodeDialog : Form
    {
        public AccessCodeDialog()
        {
            InitializeComponent();
        }

        public string AccessCode
        {
            get
            {
                return tbAccessCode.Text.Trim();
            }
        }
    }
}