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
    public partial class modify : Form
    {
        ArrayList al = new ArrayList();
        public modify()
        {
            InitializeComponent();
            
            loaddata();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
        private void f5()
        {
            try
            {
                this.textBox0.Text = Convert.ToString(al[0]);//姓名
            this.textBox1.Text = Convert.ToString(al[1]);//性别
            this.textBox2.Text = Convert.ToString(al[2]);//力道
            this.textBox3.Text = Convert.ToString(al[3]);//根骨
            this.textBox4.Text = Convert.ToString(al[4]);//灵敏
            this.textBox5.Text = Convert.ToString(al[5]);//头脑
            this.textBox6.Text = Convert.ToString(al[6]);//精神
            this.textBox7.Text = Convert.ToString(al[7]);//等级
            this.textBox8.Text = Convert.ToString(al[8]);//经验
            this.textBox9.Text = Convert.ToString(al[9]);//经验最大
            this.textBox10.Text = Convert.ToString(al[10]);//等级条
            this.textBox11.Text = Convert.ToString(al[11]);//战报
            this.textBox12.Text = Convert.ToString(al[12]);//血
            this.textBox13.Text = Convert.ToString(al[13]);//血最大
            this.textBox14.Text = Convert.ToString(al[14]);//气
            this.textBox15.Text = Convert.ToString(al[15]);//最大气
            this.textBox16.Text = Convert.ToString(al[16]);//钱
            this.textBox17.Text = Convert.ToString(al[17]);//武器类型
            this.textBox18.Text = Convert.ToString(al[18]);//武功
            this.textBox19.Text = Convert.ToString(al[19]);//武功等级
            this.textBox20.Text = Convert.ToString(al[20]);//功力
            this.textBox21.Text = Convert.ToString(al[21]);//外号
            this.richTextBox22.Text = Convert.ToString(al[22]);//描述
            this.textBox23.Text = Convert.ToString(al[23]);//装备武器
            this.textBox50.Text = Convert.ToString(al[50]);//装备内功
            //this.textBox51.Text = Convert.ToString(al[51]);//内功等级
            this.textBox100.Text = Convert.ToString(al[100]);//基础攻击力
            this.textBox101.Text = Convert.ToString(al[101]);//基础攻击力
            this.textBox102.Text = Convert.ToString(al[102]);//防御
            this.textBox103.Text = Convert.ToString(al[103]);//躲避
            this.textBox104.Text = Convert.ToString(al[104]);//爆伤
            this.textBox105.Text = Convert.ToString(al[105]);//暴击
            this.textBox106.Text = Convert.ToString(al[106]);//命中
            this.textBox107.Text = Convert.ToString(al[107]);//躲避
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
                al[0] = textBox0.Text;
                al[1] = textBox1.Text;
                al[2] = textBox2.Text;
                al[3] = textBox3.Text;
                al[4] = textBox4.Text;
                al[5] = textBox5.Text;
                al[6] = textBox6.Text;
                al[7] = textBox7.Text;
                al[8] = textBox8.Text;
                al[9] = textBox9.Text;
                al[10] = textBox10.Text;
                //al[11] = textBox11.Text;
                al[12] = textBox12.Text;
                al[13] = textBox13.Text;
                al[14] = textBox14.Text;
                al[15] = textBox15.Text;
                al[16] = textBox16.Text;
                al[17] = textBox17.Text;
                al[18] = textBox18.Text;
                al[19] = textBox19.Text;
                al[20] = textBox20.Text;
                al[21] = textBox21.Text;
                al[22] = richTextBox22.Text;
                al[23] = textBox23.Text;
                
               
                al[50] = textBox50.Text;
                //al[51] = textBox51.Text;
                al[100] = textBox100.Text;
                al[101] = textBox101.Text;
                al[102] = textBox102.Text;
                al[103] = textBox103.Text;
                al[104] = textBox104.Text;
                al[105] = textBox105.Text;
                al[106] = textBox106.Text;
                al[107] = textBox107.Text;
            
            }
            catch (Exception)
            {
                MessageBox.Show("数据有误,确认是否为空");

            }
           

            

        }
        private void auto()
        {

            try
            {
                double i, j, lv;
            lv = Convert.ToDouble(textBox7.Text);
            i = Convert.ToDouble(textBox3.Text);
            j = Convert.ToDouble(textBox6.Text);
            //this.textBox13.Text = Convert.ToString(lv * i + 10);
            this.textBox12.Text = textBox13.Text;
            //this.textBox15.Text = Convert.ToString(lv * j + 10);
            this.textBox14.Text = textBox15.Text;
                
                this.textBox103.Text=Convert.ToString(Convert.ToDouble(al[4])*0.002);
                this.textBox104.Text = Convert.ToString(1+Convert.ToDouble(al[5]) * 0.004);
                this.textBox105.Text = Convert.ToString(Convert.ToDouble(al[6]) * 0.001);


            }
            catch (Exception)
            {

                MessageBox.Show("数据有误");
            }
            


        }
        private void button1_Click(object sender, EventArgs e)
        {
            //读取存档
            FileStream fs = new FileStream(".\\save\\save1.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            al = bf.Deserialize(fs) as ArrayList;
            
            fs.Close();
            f5();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //保存存档
            f6();
            FileStream fs = new FileStream(".\\save\\save1.dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();//序列化
            bf.Serialize(fs, al);
            fs.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //读取人物
                string name = "";
                foreach (string names in checkedListBox1.CheckedItems)
                {
                    name += names;
                }
                
                FileStream fs = new FileStream(".\\data\\character\\" + name + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                al = bf.Deserialize(fs) as ArrayList;
                fs.Close();
                
                f5();
                this.textBox9999.Text=name;


            }
            catch (Exception)
            {

                MessageBox.Show("发生错误!确认是否选中档案,或者使用档案修复功能进行修复");
                
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //保存人物
           
            f6();
            string name = "";
            name = textBox9999.Text;
            FileStream fs = new FileStream(".\\data\\character\\" + name + ".dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();//序列化
            bf.Serialize(fs, al);
            fs.Close();

            loaddata();
            
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            auto();
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
        private void loaddata()
        {
            this.checkedListBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(@".\\data\\character\\");
            foreach (FileInfo dChild in dir.GetFiles("*.dat"))
            {//如果用GetFiles("*.txt"),那么全部txt文件会被显示
                string fname = dChild.Name.Substring(0, dChild.Name.LastIndexOf("."));//去掉扩展名
                checkedListBox1.Items.Add(fname);
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //删除人物
            string name = "";
            foreach (string names in checkedListBox1.CheckedItems)
            {
                name += names;
            }
            FileInfo fi = new FileInfo(".\\data\\character\\" + name + ".dat");
            
            fi.Delete();
            loaddata();
        }

        private void modify_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("即将开放!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("即将开放!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //读取人物
            string name = "";
            string path1 = ".\\data\\character\\";
            string path2 = ".dat";
            foreach (string names in checkedListBox1.CheckedItems)
            {
                name += names;
            }
            if (name == "")
            {
                
                path1 = ".\\save\\save1.dat";
                path2 = "";
                name = "";
            }
            else
            {

            }

            FileStream fs = new FileStream(path1 + name + path2, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            al = bf.Deserialize(fs) as ArrayList;
            fs.Close();
            
            if (al.Count==1000)
            {
                MessageBox.Show("已经是最新版本档案,无须修复");
                
            }
            else
            {
                int j = al.Count;
                for (int i = j; i < 1000; i++)
                {
                    al.Add("0");
                }
                
                al[20] = 1;
                al[21] = "输入一个称号";
                al[22] = "输入一段文字";
                al[23] = "0";
                al[24] = "0";
                al[25] = "0";
                f5();
               
                f6();
                FileStream fs1 = new FileStream(path1 + name + path2, FileMode.OpenOrCreate);
                BinaryFormatter bf1 = new BinaryFormatter();//序列化
                bf1.Serialize(fs1, al);
                fs1.Close();

                loaddata();
                
                
               
                MessageBox.Show("修复成功" + Convert.ToString(al.Count));
                

            }
        }

        private void label17_Click(object sender, EventArgs e)
        {


        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            string name = "";
            name = textBox50.Text;
            
            //读取武功
            string midname = Convert.ToString(al[50]);
            loaddat ld = new loaddat();

            kungfuwear kw = new kungfuwear();
            kw.kfoff(al, ld.loadkungfu(midname));
            ArrayList kf = new ArrayList();
            kf = ld.loadkungfu(name);
            al[200] = textBox50.Text;
            al[400] = textBox51.Text;
            for (int i = 200; i < 400; i++)
            {
                if (Convert.ToString(al[i]) == name)
                {
                    if (Convert.ToString(kf[12]) == "def")
                    {
                        
                        kw.kfwear(al, kf);

                    }
                    else
                    {
                        MessageBox.Show("所选武功不是心法。");
                    }
                    break;
                }


            }
            f5();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("你没有学习这个武功或者没有选择!");
            //}
        }   
    }
}
