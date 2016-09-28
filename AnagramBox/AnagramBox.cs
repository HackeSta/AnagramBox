using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
namespace AnagramBox
{

    [Designer(typeof(AnagramBoxDesigner))]
    public partial class AnagramBox : UserControl
    {
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //--------------------------------------DECLERATIONS---------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        static int defNumberBoxes = 6;  //Default number of boxes
        static Size defSize = new Size(30, 30);  //Default size of a box
        static TextBox[] textBoxes;     //Array of all boxes
        static Font defFont = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);  //Default Font
        static string anagramText, shuffledText;  //anagramText = Unscrambled, shuffledText = Scrambled
        static HorizontalAlignment defTextAlignment = HorizontalAlignment.Center;
        Color defBoxColor = Color.White, defTextColor = Color.Black;
        CurrentText currentText;

        public AnagramBox()
        {
            InitializeComponent();
            this.Size = new Size(defSize.Width * defNumberBoxes, defSize.Height);   //Makes the size of the whole control equal to all boxes combined together
            this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            
            CreateBoxes();   //Method to display all boxes
            FixSize();
        }

        enum CurrentText    //Stores the type of text in the box
        {
            anagramText, shuffledText
        }

        public void CreateBoxes()   //Method to display all boxes
        {
            this.Controls.Clear();   //Removes all existing boxes
            textBoxes = new TextBox[defNumberBoxes];
            for (int i = 0; i < defNumberBoxes; i++)                           //For loop to initialize all boxes
            {
                textBoxes[i] = new TextBox();

                textBoxes[i].Visible = true;
                textBoxes[i].MaxLength = 1;                 //We want one character in each box
                textBoxes[i].ReadOnly = false;
                textBoxes[i].Font = defFont;
                textBoxes[i].Size = defSize;
                textBoxes[i].Multiline = false;
                textBoxes[i].AutoSize = true;
                textBoxes[i].BackColor = defBoxColor;
                textBoxes[i].ForeColor = defTextColor;
                textBoxes[i].Location = new Point(i * defSize.Width, 0);
                textBoxes[i].Multiline = false;
               
                this.Controls.Add(textBoxes[i]);
            }
            switch (currentText)            //Checks for the type of text in box before the method was called
            {
                case CurrentText.anagramText:
                    DistributeText(anagramText, false);
                    break;
                case CurrentText.shuffledText:
                    DistributeText(shuffledText, false);
                    break;
                default:
                    break;
            }
            
        }

      

        public void Shuffle()              //Method to shuffle the text
        {
            shuffledText = anagramText.ToCharArray().Shuffle();   //Shuffle() is a method in extended class for Char Array
            DistributeText(shuffledText);   //Method to give one character each to all the boxes

        }

        public void UnShuffle()  //Method to restore the original text
        {
            DistributeText(anagramText);
        }

        public void DistributeText(string text, bool createBoxes = true)     //Method to give one character each to all the boxes, createBoxes(default = true) indicates whether to recreate the boxes or not, false when called by CreateBoxes() to avoid loop
        {
            if (text == anagramText) currentText = CurrentText.anagramText;
            else if (text == shuffledText) currentText = CurrentText.shuffledText;

            if (!String.IsNullOrEmpty(text))
            {
                int characters = text.Length;
               if(createBoxes) NumberOfBoxes = characters;         //NumberOfBoxes is a property which gets/sets the numberBoxes Variable and remakes all the boxes
                char[] characterArray = text.ToCharArray();
                for (int i = 0; i < characters; i++)
                {
                    textBoxes[i].Text = characterArray[i].ToString();
                    textBoxes[i].SelectAll();
                    textBoxes[i].TextAlign = defTextAlignment;
                }
            }
            else
            {
                if (createBoxes) NumberOfBoxes = defNumberBoxes;
            }
            FixSize();
        }

        private void FixSize()  //Makes the control size equal to that occupied by the text boxes
        {
            this.Size = new Size(textBoxes[0].Width * defNumberBoxes, textBoxes[0].Size.Height);
        }

        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //--------------------------------------PROPERTIES-----------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text              //Property to set the anagramText variable
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
                defFont =  value;
                foreach (TextBox textbox in textBoxes) textbox.Font = defFont;
                CreateBoxes();
                FixSize();
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

                foreach (TextBox textbox in textBoxes) { textbox.SelectAll(); textbox.TextAlign = defTextAlignment; }
            }
        }




        private int NumberOfBoxes    //Property to set the numberBoxes variable
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
       public Color BoxColor   //Property to set background color
        {
            get
            {
                return defBoxColor;
            }
            set
            {
                defBoxColor = value;
                foreach (TextBox textbox in textBoxes) textbox.BackColor = value;
            }
        }

        public Color TextColor  //Property to set text font color
        {
            get
            {
                return defTextColor;
            }

            set
            {
                defTextColor = value;
                foreach (TextBox textbox in textBoxes) textbox.ForeColor = value;
            }
        }
     

        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //--------------------------------------EVENTS---------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------

        private void AnagramBox_Resize(object sender, EventArgs e)  //Resizes all the boxes when the Control is resized
        {
            
            defSize = new Size(this.Size.Width / defNumberBoxes, this.Size.Height);
            this.Size = new Size(defSize.Width * defNumberBoxes, defSize.Height);
            CreateBoxes();
        }
    }

    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------
    //--------------------------------------EXTENSIONS-----------------------------------------------
    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------


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

    public class AnagramBoxDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                return base.SelectionRules & ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable);
            }
        }
    }
}
