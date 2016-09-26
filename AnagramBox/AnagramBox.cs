using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnagramBox
{
    public partial class AnagramBox: UserControl
    {

       static int numberBoxes = 4;
        static Size size = new Size(20, 20);
      static  RichTextBox[] textBoxes;
       static string anagramText, shuffledText;
        
        
        public AnagramBox()
        {
            InitializeComponent();
            this.Size = new Size(size.Width * numberBoxes, size.Height);
           
            CreateBoxes();
        }

        public void CreateBoxes()
        {
            this.Controls.Clear();
            textBoxes = new RichTextBox[numberBoxes];
            size = new Size(this.Size.Width / numberBoxes, size.Height);
            for (int i = 0; i < numberBoxes; i++)
            {
                textBoxes[i] = new RichTextBox();
                textBoxes[i].Size = size;
                textBoxes[i].Visible = true;
                textBoxes[i].MaxLength = 1;
                textBoxes[i].ReadOnly = false;
                textBoxes[i].Font = this.Font;
                textBoxes[i].Multiline = false;
                textBoxes[i].Location = new Point(i * size.Width, 0);

                this.Controls.Add(textBoxes[i]);
            }
        }

        public void Shuffler()
        {
            shuffledText = anagramText.ToCharArray().Shuffle();
            DistributeText(shuffledText); 
        }

        public void DistributeText(string text)
        {
            int characters = text.Length;
            NumberOfBoxes = characters;
            char[] characterArray = text.ToCharArray();
            for(int i = 0; i < characters; i++)
            {
                textBoxes[i].Text = characterArray[i].ToString();
            }
        }

       override public string Text
        {
            get
            {
                return anagramText;
            }
            set
            {
                anagramText = value;
                DistributeText(anagramText);
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
                CreateBoxes();
            }
        }




        private void AnagramBox_Resize(object sender, EventArgs e)
        {
            size.Height = this.Size.Height;
            size.Width = this.Size.Width / numberBoxes;
            CreateBoxes();  
        }

        public int NumberOfBoxes
        {
            get
            {
                return numberBoxes;
            }
            set
            {
                numberBoxes = value;
                CreateBoxes();
            }
        }
    }

   public static class CharArrayExten
    {
        public static string Shuffle(this char[] array)
        {
            var random = new Random();
            for (int x = 0; x < 100; x++)
            {
                for (int i = array.Length; i > 1; i--)
                {
                    // Pick random element to swap.
                    int j = random.Next(i); // 0 <= j <= i-1
                                            // Swap.
                    char tmp = array[j];
                    array[j] = array[i - 1];
                    array[i - 1] = tmp;
                }
            }
            string s = new string(array);
            return s;
        }

    }
}
