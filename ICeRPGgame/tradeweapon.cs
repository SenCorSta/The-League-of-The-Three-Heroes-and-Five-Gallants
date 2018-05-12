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
    public partial class tradeweapon : Form
    {
        ArrayList al=new ArrayList();
        unitconvert uc = new unitconvert();
        weaponID wi = new weaponID();
        public tradeweapon(ArrayList pal)
        {
            al = pal;
            InitializeComponent();
            f5();
            loaddata();
            
        }
        private void loaddata()
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();
            this.listBox4.Items.Clear();

            ArrayList wp = new ArrayList();
            
            DirectoryInfo dir2 = new DirectoryInfo(@".\\data\\weapon\\");
            foreach (FileInfo dChild in dir2.GetFiles("*.dat"))
            {//如果用GetFiles("*.txt"),那么全部txt文件会被显示
                string fname = dChild.Name.Substring(0, dChild.Name.LastIndexOf("."));//去掉扩展名
                if (fname!="0")
                {
                    listBox2.Items.Add(fname);
                    FileStream fs = new FileStream(".\\data\\weapon\\" + fname + ".dat", FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();//反序列化
                    wp = bf.Deserialize(fs) as ArrayList;

                    listBox1.Items.Add(wp[1]);//名字
                    listBox3.Items.Add(uc.moneytochina(Convert.ToInt32(wp[5])));//价值
                    listBox4.Items.Add(wi.weaponIDtostr(Convert.ToString(wp[12])));//武器类别


                    fs.Close();
                    
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = listBox1.SelectedIndex;
                listBox2.SelectedIndex = i;
                listBox3.SelectedIndex = i;
                listBox4.SelectedIndex = i;
                int j = Convert.ToInt32(textBox1.Text);


                ArrayList newwp = new ArrayList();
                string name = listBox2.Text;
                //读取武器


                FileStream fs = new FileStream(".\\data\\weapon\\" + name + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                newwp = bf.Deserialize(fs) as ArrayList;
                fs.Close();
                shoptrade st = new shoptrade();
                if (Convert.ToInt32(al[16]) >= Convert.ToInt32(newwp[5]) * Convert.ToInt32(textBox1.Text))
                {
                    st.buysomething(al, newwp, j);
                    MessageBox.Show("购买成功");

                }
                else
                {
                    MessageBox.Show("你的钱不够,需要" + uc.moneytochina(Convert.ToInt32(newwp[5]) * Convert.ToInt32(textBox1.Text)) + "。");
                }

                f5();
            }
            catch (Exception)
            {
                MessageBox.Show("请选择一个武器。");

            }
                

            
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void f5()
        {
            
            
            label4.Text = uc.moneytochina(Convert.ToInt32(al[16]));
            
            listBox5.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            for (int i = 600; i < 700; i++)
            {
                //所持道具列表
                if (Convert.ToString(al[i]) != "0")
                {
                    this.listBox5.Items.Add(weaponIDtostr(Convert.ToString(al[i])) + "  " + "数量" + Convert.ToString(al[i + 100]));
                    this.listBox7.Items.Add(uc.moneytochina(Convert.ToInt32(weaponIDtoprice(Convert.ToString(al[i])))));
                    this.listBox8.Items.Add(Convert.ToString(al[i]));
                }
            }
        }

        private string weaponIDtostr(string id)
        {
            string name;

            ArrayList wp = new ArrayList();
            FileStream fs = new FileStream(".\\data\\weapon\\" + id + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            wp = bf.Deserialize(fs) as ArrayList;
            fs.Close();
            name = Convert.ToString(wp[1]);
            return name;
        }
        private string weaponIDtoprice(string id)
        {
            string name;

            ArrayList wp = new ArrayList();
            FileStream fs = new FileStream(".\\data\\weapon\\" + id + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            wp = bf.Deserialize(fs) as ArrayList;
            fs.Close();
            name = Convert.ToString(wp[5]);
            return name;
        }
        private string weaponneedtostr(string id)
        {
            string name;

            ArrayList wp = new ArrayList();
            FileStream fs = new FileStream(".\\data\\weapon\\" + id + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            wp = bf.Deserialize(fs) as ArrayList;
            fs.Close();
            name = Convert.ToString(wp[1]);
            return name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = listBox5.SelectedIndex;
                listBox7.SelectedIndex = i;
                listBox8.SelectedIndex = i;
                int j = Convert.ToInt32(textBox1.Text);

                if (true)
                {
                    ArrayList newwp = new ArrayList();
                    string name = listBox8.Text;
                    //读取武器


                    FileStream fs = new FileStream(".\\data\\weapon\\" + name + ".dat", FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();//反序列化
                    newwp = bf.Deserialize(fs) as ArrayList;
                    fs.Close();
                    shoptrade st = new shoptrade();
                    st.sellsomething(al, newwp, j);
                    

                }
                else
                {
                    MessageBox.Show("出错");
                }

                f5();
            }
            catch (Exception)
            {

                MessageBox.Show("请选择一个武器！");
            }
               
           
            
        }

        private void tradeweapon_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            i = listBox1.SelectedIndex;
            listBox2.SelectedIndex = i;
            listBox3.SelectedIndex = i;
            listBox4.SelectedIndex = i;
        }
    }
}
