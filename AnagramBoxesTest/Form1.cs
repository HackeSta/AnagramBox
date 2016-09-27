using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnagramBoxesTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            anagramBox1.Text = pushBox.Text;   //Sets the text in the control to the text in the TextBox
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anagramBox1.Shuffle();   //Shuffles the text
        }

        private void buttonUnShuffle_Click(object sender, EventArgs e)
        {
           anagramBox1.UnShuffle(); //UnShuffles the text
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            DialogResult result = fontDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                anagramBox1.Font = fontDialog.Font;
            }
        }
    }
}
