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
        public Form1()
        {
            InitializeComponent();
        }
                          

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            String[] words = richTextBox1.Text.Split(new Char[] { ' ', '\t' });
            var wordList = words.Reverse().ToList();
            
            List<String> newwordList = wordList;











            foreach (String cl in newwordList)
            {
                var item = new ListViewItem(cl.ToString());
                listView1.Items.Add(item);
            }

        
        
        
        } 



    }
}
