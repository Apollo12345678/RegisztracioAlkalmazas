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
            string nem="";
            listBox1.Items.Add("Uszas");
            listBox1.Items.Add("Horgaszat");
            listBox1.Items.Add("Futas");

            listBox1.SetSelected(0, true);

            button1.Click += (sender, e) =>
              {
                  if (string.IsNullOrWhiteSpace(textBox1.Text))
                  {
                      MessageBox.Show("Nem írtál új hobbit");
                  }
                  else
                  {
                       String text = textBox3.Text;
                       listBox1.Items.Add(text);
                       textBox3.Text = "";
                  }
                  
              };
            
            button2.Click += (sender, e) =>
            {
                  bool go; 

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
                    string outText = textBox1.Text+" "+dateTimePicker1.Value.ToShortDateString() +" " + nem + " " + listBox1.GetItemText(listBox1.SelectedItem)+" "+listBox1.SelectedIndex;
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = "adatok.txt";
                    sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                            sw.WriteLine(outText);
                    }


                    textBox1.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    listBox1.SelectedIndex = 0;
                    
                    MessageBox.Show("Sikeres bevitel");
                  }
                  else
                  {
                      MessageBox.Show("Nem töltötted ki a formot rendesen");
                  }
            };

            button3.Click += (sender, e) =>
              {
                  string line;

                  if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                  {
                      System.IO.StreamReader sr = new
                      System.IO.StreamReader(openFileDialog1.FileName);
                      line=(sr.ReadToEnd());
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
                      int szam;
                      bool van = true;
                      if (int.TryParse(array[4], out szam))
                      {
                          foreach(var i in listBox1.Items)
                          {
                              if (array[3].Equals(i))
                              {
                                  van = true;
                              }
                              else
                              {
                                  van = false;
                              }
                          }
                          if (szam > 2 && van==false)
                          {

                              listBox1.Items.Add(array[3]);
                              listBox1.SelectedIndex = 3;
                          }else if(szam>2 && van == true)
                          {
                              listBox1.SelectedIndex = szam;
                          }                        
                          
                      }
                      
                  }
                  
              };

        }
    }
}
