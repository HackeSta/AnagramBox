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

       static int defNumberBoxes = 4;  //Default number of boxes
        static Size defSize = new Size(20, 20);  //Default size of a box
      static  RichTextBox[] textBoxes;     //Array of all boxes
        static Font defFont = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);  //Default Font
       static string anagramText, shuffledText;   //anagramText = Unscrambled, shuffledText = Scrambled
        static HorizontalAlignment defTextAlignment = HorizontalAlignment.Center;
       
        
        public AnagramBox()
        {
            InitializeComponent();
            this.Size = new Size(defSize.Width * defNumberBoxes, defSize.Height);   //Makes the size of the whole control equal to all boxes combined together
            CreateBoxes();   //Method to display all boxes
        }


        
        public void CreateBoxes()   //Method to display all boxes
        {
            this.Controls.Clear();   //Removes all existing boxes
            textBoxes = new RichTextBox[defNumberBoxes];           
            defSize = new Size(this.Size.Width / defNumberBoxes, defSize.Height);        //Sets the size of each box so that they fit the control completely
            for (int i = 0; i < defNumberBoxes; i++)                           //For loop to initialize all boxes
            {
                textBoxes[i] = new RichTextBox();
                
                textBoxes[i].Visible = true;
                textBoxes[i].MaxLength = 1;                 //We want one character in each box
                textBoxes[i].ReadOnly = false;
                textBoxes[i].Font = defFont;
                textBoxes[i].Size = defSize;
                textBoxes[i].Multiline = false;
                textBoxes[i].AutoSize = false;
                
                textBoxes[i].Location = new Point(i * defSize.Width, 0);

                this.Controls.Add(textBoxes[i]);
            }
        }

        public void Shuffler()              //Method to shuffle the text
        {
            shuffledText = anagramText.ToCharArray().Shuffle();   //Shuffle() is a method in extended class for Char Array
            DistributeText(shuffledText);   //Method to give one character each to all the boxes

        }

        public void UnShuffle()  //Method to restore the original text
        {
            DistributeText(anagramText);
        }

        public void DistributeText(string text)     //Method to give one character each to all the boxes
        {
            int characters = text.Length;
            NumberOfBoxes = characters;         //NumberOfBoxes is a property which gets/sets the numberBoxes Variable and remakes all the boxes
            char[] characterArray = text.ToCharArray();
            for(int i = 0; i < characters; i++)
            {
                textBoxes[i].Text = characterArray[i].ToString();
                textBoxes[i].SelectAll();
                textBoxes[i].SelectionAlignment = defTextAlignment;
            }

        }

       override public string Text              //Property to set the anagramText variable
        {
            get
            {
                return anagramText;
            }
            set
            {
                anagramText = value;
                DistributeText(anagramText);    //Distributes the text among the boxes
               
            }
        }
        public override Font Font   //Property to set the Font of the Boxes
        {
            get
            {
                return defFont;
            }

            set
            {
               defFont = value;
                foreach (RichTextBox textbox in textBoxes) textbox.Font = defFont;

            }
        }

        public HorizontalAlignment TextAlign //Sets text Alignment
        {
            get
            {
                return defTextAlignment;
            }
            set
            {
                defTextAlignment = value;
                foreach (RichTextBox textbox in textBoxes) { textbox.SelectAll(); textbox.SelectionAlignment = defTextAlignment; } 
            }
        }


        private void AnagramBox_Resize(object sender, EventArgs e)  //Resizes all the boxes when the Control is resized
        {
            defSize.Height = this.Size.Height;
            defSize.Width = this.Size.Width / defNumberBoxes;
            CreateBoxes();  
        }

        public int NumberOfBoxes    //Property to set the numberBoxes variable
        {
            get
            {
                return defNumberBoxes;
            }
            set
            {
                defNumberBoxes = value;
                CreateBoxes();
            }
        }
    }

   public static class CharArrayExten    //Extended class for Char Array
    {
        public static string Shuffle(this char[] array)   //Shuffles all the characters in an array
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
