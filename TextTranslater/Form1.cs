using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            label7.Text = "переведено слов";
        }
                          

        private async void button1_Click(object sender, EventArgs e)
        {
            Type type = listView1.GetType();
            PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            propertyInfo.SetValue(listView1, true, null);
            MyTranslator tr = new MyTranslator();
            
            listView1.Items.Clear();
            if (checkBox1.Checked)  isCheckTranslate = true;

            #region getList           
            var AllwordList = richTextBox1.Text.Split(new Char[] { ' ', '\t' }).ToList();
                           
            var wordlist2 = AllwordList.Where(x=>x.Length>2)
                                       .GroupBy(x=>x)
                                       .OrderByDescending(x=>x.Count()).ToList();
            #endregion


            #region label
            label3.Text = AllwordList.Count().ToString();       //количество вех строк
            label4.Text = wordlist2.Count().ToString();            // количество выдранных слов  
            label6.Text = wordlist2.Sum(x => x.Key.Length + x.Key.Length).ToString();  // количество символов

            progressBar1.Maximum = wordlist2.Count();
            progressBar1.Value = 0;
            #endregion

            

            foreach (var group in wordlist2)
            {
                
                var item = new ListViewItem(group.Key);
                item.SubItems.Add(group.Count().ToString());
                if (isCheckTranslate)
                {
                    var AssyncTranslate = tr.TranslateWordAsync(group.Key);
                    item.SubItems.Add(await AssyncTranslate);
                }
                
                listView1.Items.Add(item);
                progressBar1.Value += 1;
                label7.Text = $"переведено {progressBar1.Value} слов из {label4.Text} ";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
