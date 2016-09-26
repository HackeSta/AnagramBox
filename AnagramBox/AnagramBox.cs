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

       static int numberBoxes = 4;  //Default number of boxes
        static Size size = new Size(20, 20);  //Default size of a box
      static  RichTextBox[] textBoxes;     //Array of all boxes
       static string anagramText, shuffledText;   //anagramText = Unscrambled, shuffledText = Scrambled
        
        
        public AnagramBox()
        {
            InitializeComponent();
            this.Size = new Size(size.Width * numberBoxes, size.Height);   //Makes the size of the whole control equal to all boxes combined together
           
            CreateBoxes();   //Method to display all boxes
        }

        public void CreateBoxes()   //Method to display all boxes
        {
            this.Controls.Clear();   //Removes all existing boxes
            textBoxes = new RichTextBox[numberBoxes];           
            size = new Size(this.Size.Width / numberBoxes, size.Height);        //Sets the size of each box so that they fit the control completely
            for (int i = 0; i < numberBoxes; i++)                           //For loop to initialize all boxes
            {
                textBoxes[i] = new RichTextBox();
                textBoxes[i].Size = size;
                textBoxes[i].Visible = true;
                textBoxes[i].MaxLength = 1;                 //We want one character in each box
                textBoxes[i].ReadOnly = false;
                textBoxes[i].Font = this.Font;
                textBoxes[i].Multiline = false;
                textBoxes[i].Location = new Point(i * size.Width, 0);

                this.Controls.Add(textBoxes[i]);
            }
        }

        public void Shuffler()              //Method to shuffle the text
        {
            shuffledText = anagramText.ToCharArray().Shuffle();   //Shuffle() is a method in extended class for Char Array
            DistributeText(shuffledText);   //Method to give one character each to all the boxes
        }

        public void DistributeText(string text)     //Method to give one character each to all the boxes
        {
            int characters = text.Length;
            NumberOfBoxes = characters;         //NumberOfBoxes is a property which gets/sets the numberBoxes Variable and remakes all the boxes
            char[] characterArray = text.ToCharArray();
            for(int i = 0; i < characters; i++)
            {
                textBoxes[i].Text = characterArray[i].ToString();
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
        public override Font Font    //Property to set the Font of the Boxes
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




        private void AnagramBox_Resize(object sender, EventArgs e)  //Resizes all the boxes when the Control is resized
        {
            size.Height = this.Size.Height;
            size.Width = this.Size.Width / numberBoxes;
            CreateBoxes();  
        }

        public int NumberOfBoxes    //Property to set the numberBoxes variable
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
