using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string hobbi;
            string nem="";

            listBox1.Items.Add("Uszas");
            listBox1.Items.Add("Horgaszat");
            listBox1.Items.Add("Futas");

            
            listBox1.SetSelected(0, true);

            button1.Click += (sender, e) =>
              {
                  String text = textBox3.Text;
                  listBox1.Items.Add(text);
                  textBox3.Text = "";
              };

            button2.Click += (sender, e) =>
            {
                  bool go = false; 

                if (string.IsNullOrWhiteSpace(textBox1.Text) || (dateTimePicker1.Value.Day >= DateTime.Now.Day) || (!(radioButton1.Checked) && !(radioButton2.Checked)))
                {
                    go = false;
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        nem = "Ferfi";
                    }
                    else
                    {
                        nem = "No";
                    }
                    go = true;
                }
                  if (go)
                  {
                    string outText = textBox1.Text+" "+dateTimePicker1.Value.ToShortDateString() +" " + nem + " " + listBox1.GetItemText(listBox1.SelectedItem);
                    using (System.IO.StreamWriter file= new System.IO.StreamWriter(@"C: \Users\user\source\repos\RegisztracioAlkalmazas\adatok.txt"))
                    {

                        file.WriteLine(outText);                         
                    }
                    textBox1.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;

                    MessageBox.Show("Sikeres bevitel");
                  }
                  else
                  {
                      MessageBox.Show("Nem töltötted ki a formot rendese");
                  }
              
            };

            button3.Click += (sender, e) =>
              {
                  using (StreamReader sr = new StreamReader(@"C: \Users\user\source\repos\RegisztracioAlkalmazas\adatok.txt"))
                  {
                      String line = sr.ReadToEnd();
                      String[] array = line.Split();
                      textBox1.Text = array[0];
                      dateTimePicker1.Value = DateTime.Parse(array[1]);
                      if (array[2] == "Ferfi")
                      {
                          radioButton1.Checked = true;
                      }
                      else
                      {
                          radioButton2.Checked = true;
                      }

                      

                  }
              };

        }
    }
}
