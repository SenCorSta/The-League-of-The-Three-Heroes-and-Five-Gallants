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
    public partial class kungfu : Form
    {
        ArrayList kfAL = new ArrayList();
        
        public kungfu()
        {
            InitializeComponent();
            
                for (int i = 0; i < 100; i++)
            {
                kfAL.Add(0);
            }
                f5();
            
            loaddata();
        }
        private void f5()
        {
            try
            {
                this.textBox0.Text = Convert.ToString(kfAL[0]);//ID
                this.textBox1.Text = Convert.ToString(kfAL[1]);//名字
                this.textBox2.Text = Convert.ToString(kfAL[2]);//最大等级
                //this.textBox63.Text = Convert.ToString(kfAL[3]);//威力系数
                //this.textBox61.Text = Convert.ToString(kfAL[4]);//精力系数
                this.textBox5.Text = Convert.ToString(kfAL[5]);//学习难度
                this.textBox6.Text = Convert.ToString(kfAL[6]);//需要兵器
                this.textBox7.Text = Convert.ToString(kfAL[7]);//每级力道
                this.textBox8.Text = Convert.ToString(kfAL[8]);//每级体质
                this.textBox9.Text = Convert.ToString(kfAL[9]);//每级灵敏
                this.textBox10.Text = Convert.ToString(kfAL[10]);//每级头脑
                this.textBox11.Text = Convert.ToString(kfAL[11]);//每级精神
                this.textBox12.Text = Convert.ToString(kfAL[12]);//武功类别
                this.textBox13.Text = Convert.ToString(kfAL[13]);//人物等级需求
                this.textBox14.Text = Convert.ToString(kfAL[14]);//武功需求
                this.textBox15.Text = Convert.ToString(kfAL[15]);//武功等级需求
                this.textBox16.Text = Convert.ToString(kfAL[16]);//力道需求
                this.textBox17.Text = Convert.ToString(kfAL[17]);//体质需求
                this.textBox18.Text = Convert.ToString(kfAL[18]);//灵敏需求
                this.textBox19.Text = Convert.ToString(kfAL[19]);//头脑需求
                this.textBox20.Text = Convert.ToString(kfAL[20]);//精神需求
                this.textBox21.Text = Convert.ToString(kfAL[21]);//道具需求
                this.textBox22.Text = Convert.ToString(kfAL[22]);//特别效果代码
                this.textBox23.Text = Convert.ToString(kfAL[23]);//特别效果说明
                this.richTextBox24.Text = Convert.ToString(kfAL[24]);//武功文字说明
                this.textBox50.Text = Convert.ToString(kfAL[50]);//攻击段数
                this.textBox51.Text = Convert.ToString(kfAL[51]);//力道
                this.textBox52.Text = Convert.ToString(kfAL[52]);//体质
                this.textBox53.Text = Convert.ToString(kfAL[53]);//灵敏
                this.textBox54.Text = Convert.ToString(kfAL[54]);//头脑
                this.textBox55.Text = Convert.ToString(kfAL[55]);//精神
                this.textBox56.Text = Convert.ToString(kfAL[56]);//小攻击
                this.textBox57.Text = Convert.ToString(kfAL[57]);//大攻击
                this.textBox58.Text = Convert.ToString(kfAL[58]);//防御
                this.textBox59.Text = Convert.ToString(kfAL[59]);//血量
                this.textBox60.Text = Convert.ToString(kfAL[60]);//精力
                this.textBox61.Text = Convert.ToString(kfAL[61]);//每级精力系数
                this.textBox62.Text = Convert.ToString(kfAL[62]);//基础精力系数
                this.textBox63.Text = Convert.ToString(kfAL[63]);//每级威力
                this.textBox64.Text = Convert.ToString(kfAL[64]);//基础威力
                
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
               kfAL[0]=textBox0.Text;//ID
               kfAL[1]=textBox1.Text;//名字
               kfAL[2]=textBox2.Text;//最大等级
               //kfAL[3]=textBox63.Text;//威力系数
               //kfAL[4]=textBox4.Text;//精力系数
               kfAL[5]=textBox5.Text;//学习难度
               kfAL[6]=textBox6.Text;//需要兵器
               kfAL[7]=textBox7.Text;//每级力道
               kfAL[8]=textBox8.Text;//每级体质
               kfAL[9]=textBox9.Text;//每级灵敏
               kfAL[10] = textBox10.Text;//每级头脑
               kfAL[11] = textBox11.Text;//每级精神
               kfAL[12] = textBox12.Text;//武功类别
               kfAL[13] = textBox13.Text;//人物等级需求
               kfAL[14] = textBox14.Text;//武功需求
               kfAL[15] = textBox15.Text;//武功等级需求
               kfAL[16] = textBox16.Text;//力道需求
               kfAL[17] = textBox17.Text;//体质需求
               kfAL[18] = textBox18.Text;//灵敏需求
               kfAL[19] = textBox19.Text;//头脑需求
               kfAL[20] = textBox20.Text;//精神需求
               kfAL[21] = textBox21.Text;//道具需求
               kfAL[22] = textBox22.Text;//特别效果1代码
               kfAL[23] = textBox23.Text;//特别效果1说明
               kfAL[24]=richTextBox24.Text;//武功文字说明
               kfAL[50] = textBox50.Text;//攻击段数
               kfAL[51] = textBox51.Text;//力道
               kfAL[52] = textBox52.Text;//体质
               kfAL[53] = textBox53.Text;//灵敏
               kfAL[54] = textBox54.Text;//头脑
               kfAL[55] = textBox55.Text;//精神
               kfAL[56] = textBox56.Text;//大攻击
               kfAL[57] = textBox57.Text;//小攻击
               kfAL[58] = textBox58.Text;//防御
               kfAL[59] = textBox59.Text;//血量
               kfAL[60] = textBox60.Text;//精力
               kfAL[61] = textBox61.Text;//每级消耗精力
               kfAL[62] = textBox62.Text;//基础消耗精力
               kfAL[63] = textBox63.Text;//每级威力
               kfAL[64] = textBox64.Text;//基础威力

            }
            catch (Exception)
            {
                MessageBox.Show("数据有误,确认是否为空");

            }
        }
        private void loaddata()
        {
            this.checkedListBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(@".\\data\\kungfu\\");
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

        private void button3_Click(object sender, EventArgs e)
        {
            //保存武功
            f6();
            string name = "";
            name = textBox9999.Text;
            kfAL[0] = name;
            FileStream fs = new FileStream(".\\data\\kungfu\\" + name + ".dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();//序列化
            bf.Serialize(fs, kfAL);
            fs.Close();

            loaddata();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //删除武功
            string name = "";
            foreach (string names in checkedListBox1.CheckedItems)
            {
                name += names;
            }
            FileInfo fi = new FileInfo(".\\data\\kungfu\\" + name + ".dat");

            fi.Delete();
            loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //读取武功
                string name = "";
                foreach (string names in checkedListBox1.CheckedItems)
                {
                    name += names;
                }

                FileStream fs = new FileStream(".\\data\\kungfu\\" + name + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                kfAL = bf.Deserialize(fs) as ArrayList;
                fs.Close();
                f5();
                this.textBox9999.Text = name;


            }
            catch (Exception)
            {

                MessageBox.Show("没有输入正确的文件名,或者文件不存在!");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("0无 d刀 d2双刀 j剑 j2双剑 g棍 b棒 q枪 bz鞭子 f斧头 z爪 gj弓箭 fb飞镖 qt其他");      
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //读取武功
            string name = "";
            string path1 = ".\\data\\kungfu\\";
            string path2 = ".dat";
            foreach (string names in checkedListBox1.CheckedItems)
            {
                name += names;
            }
            

            FileStream fs = new FileStream(path1 + name + path2, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            kfAL = bf.Deserialize(fs) as ArrayList;
            fs.Close();

            if (kfAL.Count == 100)
            {
                MessageBox.Show("已经是最新版本档案,无须修复");

            }
            else
            {
                int j = kfAL.Count;
                for (int i = j; i < 100; i++)
                {
                    kfAL.Add("0");
                }

                
                f5();

                f6();
                FileStream fs1 = new FileStream(path1 + name + path2, FileMode.OpenOrCreate);
                BinaryFormatter bf1 = new BinaryFormatter();//序列化
                bf1.Serialize(fs1, kfAL);
                fs1.Close();

                loaddata();



                MessageBox.Show("修复成功" + Convert.ToString(kfAL.Count));


            }
        }
    }
}
