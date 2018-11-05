using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string name;
            DateTime szul;
            string nem;
            string hobbi;
            

            listBox1.Items.Add("Uszas");
            listBox1.Items.Add("Horgaszat");
            listBox1.Items.Add("Futas");

            button1.Click += (sender, e) =>
              {
                  String text = textBox3.Text;
                  listBox1.Items.Add(text);
                  textBox3.Text = "";
              };

            button2.Click += (sender, e) =>
              {
                  if (string.IsNullOrEmpty(textBox1.Text))
                  {
                      name = textBox1.Text;
                      if (dateTimePicker1.Value != DateTime.Now)
                      {
                          szul = dateTimePicker1.Value;
                          if(radioButton1.Checked || radioButton2.Checked)
                          {
                              if (radioButton1.Checked)
                              {
                                  nem = "Ferfi";
                              }
                              nem = "No";
                              if (listBox1.SelectedIndex == -1)
                              {
                                  Console.WriteLine("Nem valasztottal hobbit");
                              }
                              else
                              {
                                  hobbi = listBox1.GetItemText(listBox1.SelectedItem);
                              }
                          }
                      }
                  }
              };

        }
    }
}
