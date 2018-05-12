using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICeRPGgame
{
    public partial class weapon : Form
    {
        ArrayList wp = new ArrayList();
        public weapon()
        {
            InitializeComponent();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList createwp = new ArrayList();

            for (int i = 0; i < 100; i++)
            {
                createwp.Add("0");
            }
            wp = createwp;
            wp[0] = "0001";//ID
            wp[1] = "新武器";//名字
            wp[2] = "0";//品质
            wp[3] = "1";//伤害
            wp[4] = "1";//攻击距离
            wp[5] = "1";//价值
            wp[6] = "0";//需要性别
            wp[7] = "0";//力道+
            wp[8] = "0";//体质+
            wp[9] = "0";//灵敏+
            wp[10] = "0";//头脑+
            wp[11] = "0";//精神+
            wp[12] = "1";//武器类别
            wp[13] = "0";//人物等级需求
            wp[14] = "0";//武功需求
            wp[15] = "0";//武功等级需求
            wp[16] = "0";//力道需求
            wp[17] = "0";//体质需求
            wp[18] = "0";//灵敏需求
            wp[19] = "0";//头脑需求
            wp[20] = "0";//精神需求
            wp[21] = "0";//剧情需求
            wp[22] = "新武器的描述";//文字描述
            wp[23] = "0";//特别效果1
            wp[24] = "0";//特别效果2
            wp[25] = "0";//特别效果3
            f5();

        }
        private void f5()
        {
            try
            {
                this.textBox0.Text = Convert.ToString(wp[0]);//ID
                this.textBox1.Text = Convert.ToString(wp[1]);//名字
                this.textBox2.Text = Convert.ToString(wp[2]);//品质
                this.textBox3.Text = Convert.ToString(wp[3]);//伤害
                this.textBox4.Text = Convert.ToString(wp[4]);//攻击距离
                this.textBox5.Text = Convert.ToString(wp[5]);//价值
                this.textBox6.Text = Convert.ToString(wp[6]);//需要性别
                this.textBox7.Text = Convert.ToString(wp[7]);//力道+
                this.textBox8.Text = Convert.ToString(wp[8]);//体质+
                this.textBox9.Text = Convert.ToString(wp[9]);//灵敏+
                this.textBox10.Text = Convert.ToString(wp[10]);//头脑+
                this.textBox11.Text = Convert.ToString(wp[11]);//精神+
                this.textBox12.Text = Convert.ToString(wp[12]);//武器类别
                this.textBox13.Text = Convert.ToString(wp[13]);//人物等级需求
                this.textBox14.Text = Convert.ToString(wp[14]);//武功需求
                this.textBox15.Text = Convert.ToString(wp[15]);//武功等级需求
                this.textBox16.Text = Convert.ToString(wp[16]);//力道需求
                this.textBox17.Text = Convert.ToString(wp[17]);//体质需求
                this.textBox18.Text = Convert.ToString(wp[18]);//灵敏需求
                this.textBox19.Text = Convert.ToString(wp[19]);//头脑需求
                this.textBox20.Text = Convert.ToString(wp[20]);//精神需求
                this.textBox21.Text = Convert.ToString(wp[21]);//剧情需求
                this.richTextBox22.Text = Convert.ToString(wp[22]);//文字描述
                this.textBox23.Text = Convert.ToString(wp[23]);//特别效果1
                this.textBox24.Text = Convert.ToString(wp[24]);//特别效果2
                this.textBox25.Text = Convert.ToString(wp[25]);//特别效果3
                this.textBox30.Text = Convert.ToString(wp[30]);//命中修正
                this.textBox31.Text = Convert.ToString(wp[31]);//攻击修正
                

            }
            catch (Exception)
            {
                MessageBox.Show("数据有误,确认是否为空");

            }
        }
        private void f6()
        {
            try
            {
               wp[0] = textBox0.Text;//ID
               wp[1] = textBox1.Text;//名字
               wp[2] = textBox2.Text;//品质
               wp[3] = textBox3.Text;//伤害
               wp[4] = textBox4.Text;//攻击距离
               wp[5] = textBox5.Text;//价值
               wp[6] = textBox6.Text;//需要性别
               wp[7] = textBox7.Text;//力道+
               wp[8] = textBox8.Text;//体质+
               wp[9] = textBox9.Text;//灵敏+
               wp[10] =textBox10.Text;//头脑+
               wp[11] =textBox11.Text;//精神+
               wp[12] =textBox12.Text;//武器类别
               wp[13] =textBox13.Text;//人物等级需求
               wp[14] =textBox14.Text;//武功需求
               wp[15] =textBox15.Text;//武功等级需求
               wp[16] =textBox16.Text;//力道需求
               wp[17] =textBox17.Text;//体质需求
               wp[18] =textBox18.Text;//灵敏需求
               wp[19] =textBox19.Text;//头脑需求
               wp[20] =textBox20.Text;//精神需求
               wp[21] =textBox21.Text;//剧情需求
               wp[22]=richTextBox22.Text;//文字描述
               wp[23] =textBox23.Text;//特别效果1
               wp[24] =textBox24.Text;//特别效果2
               wp[25] =textBox25.Text;//特别效果3
               wp[30] = textBox30.Text;//命中修正
               wp[31] = textBox31.Text;//攻击修正


            }
            catch (Exception)
            {
                MessageBox.Show("数据有误,确认是否为空");

            }
        }
        private void loaddata()
        {
            this.checkedListBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(@".\\data\\weapon\\");
            foreach (FileInfo dChild in dir.GetFiles("*.dat"))
            {//如果用GetFiles("*.txt"),那么全部txt文件会被显示
                string fname = dChild.Name.Substring(0, dChild.Name.LastIndexOf("."));//去掉扩展名
                checkedListBox1.Items.Add(fname);

            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i != e.Index)//除去触发SelectedIndexChanged事件以外的选中项都处于未选中状态  
                {
                    checkedListBox1.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //读取武器
                string name = "";
                foreach (string names in checkedListBox1.CheckedItems)
                {
                    name += names;
                }

                FileStream fs = new FileStream(".\\data\\weapon\\" + name + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                wp = bf.Deserialize(fs) as ArrayList;
                fs.Close();
                f5();
                this.textBox9999.Text = name;


            }
            catch (Exception)
            {

                MessageBox.Show("没有输入正确的文件名,或者文件不存在!");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //删除武器
            string name = "";
            foreach (string names in checkedListBox1.CheckedItems)
            {
                name += names;
            }
            FileInfo fi = new FileInfo(".\\data\\weapon\\" + name + ".dat");

            fi.Delete();
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //保存武器
            f6();
            string name = "";
            name = textBox9999.Text;
            wp[0] = name;
            FileStream fs = new FileStream(".\\data\\weapon\\" + name + ".dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();//序列化
            bf.Serialize(fs, wp);
            fs.Close();

            loaddata();
        }

        private void weapon_Load(object sender, EventArgs e)
        {

        }
    }
}
