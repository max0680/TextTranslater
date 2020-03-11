using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTranslater
{
    public partial class Form1 : Form
    {

        public bool isCheckTranslate=false;
        public Form1()
        {
            InitializeComponent();
        }
                          

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                isCheckTranslate = true;
            listView1.Items.Clear();
                      
            var AllwordList = richTextBox1.Text.Split(new Char[] { ' ', '\t' }).ToList();
                           
            var wordlist2 = AllwordList.Where(x=>x.Length>2)
                                       .GroupBy(x=>x)
                                       .OrderByDescending(x=>x.Count());
            
            label3.Text = AllwordList.Count().ToString();       //количество вех строк
            label4.Text = wordlist2.Count().ToString();            // количество выдранных слов  
            label6.Text = wordlist2.Sum(x=>x.Key.Length+x.Key.Length).ToString();


            MyTranslator tr = new MyTranslator();

            


            foreach (var group in wordlist2)
            {
                var item = new ListViewItem(group.Key);
                item.SubItems.Add(group.Count().ToString());
                if (isCheckTranslate)
                item.SubItems.Add(tr.Translateword(group.Key));
                listView1.Items.Add(item );
            }

        
        
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
