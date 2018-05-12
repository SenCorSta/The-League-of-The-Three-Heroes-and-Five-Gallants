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
    public partial class PalyerDataPanel : Form
    {
        
        ArrayList al = new ArrayList();
        public PalyerDataPanel(ArrayList player)
        {
            
            InitializeComponent();
            al = player;
            f5();
            loaddata();
            
            
        }

        private void PalyerDataPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {   
            
           
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            FileStream fs = new FileStream(".\\save\\save1.dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();//序列化
            bf.Serialize(fs,al);
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(".\\data\\character\\0999qiaofeng.bbc", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            ArrayList dog = new ArrayList();
            int j = 16;
            for (int i = 0; i <= j; i++)
                dog.Add(sr.ReadLine());
            sr.Close();
            fs.Close();
            FileStream fs2 = new FileStream(".\\data\\character\\0996kimi.bbc", FileMode.Open);
            StreamReader sr2 = new StreamReader(fs2);
            ArrayList dog2 = new ArrayList();
            int j2 = 16;
            for (int i = 0; i <= j2; i++)
                dog2.Add(sr2.ReadLine());
            sr2.Close();
            fs2.Close();
            battle bat = new battle();

            if (bat.battles(dog, dog2)==1)
            {
                this.richTextBox1.Text = Convert.ToString(dog[11]);//战报
                MessageBox.Show("你赢了");
                
            }
            else if (bat.battles(dog, dog2)==2)
            {
                this.richTextBox1.Text = Convert.ToString(dog[11]);//战报
                MessageBox.Show("不分输赢");
            }
            else
            {
                this.richTextBox1.Text = Convert.ToString(dog[11]);//战报
                
                MessageBox.Show("你输了,游戏失败");
                
            }
            
            
            
            
        }
        private void f5()
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();
            this.label211.Text = Convert.ToString(al[0]);//姓名
            this.label222.Text = Convert.ToString(al[1]);//性别
            this.label41.Text = Convert.ToString(al[2]);//力道
            this.label42.Text = Convert.ToString(al[3]);//根骨
            this.label43.Text = Convert.ToString(al[4]);//灵敏
            this.label44.Text = Convert.ToString(al[5]);//头脑
            this.label45.Text = Convert.ToString(al[6]);//精神
            this.label233.Text = Convert.ToString(al[7]);//等级
            this.label244.Text = Convert.ToString(al[8]) + "/" + Convert.ToString(al[9]);//经验
            this.progressBar1.Value = Convert.ToInt32(al[10]);//等级条
            this.richTextBox1.Text = Convert.ToString(al[11]);//战报
            this.label255.Text = Convert.ToString(al[12]) + "/" + Convert.ToString(al[13]);//血
            this.label266.Text = Convert.ToString(al[14]) + "/" + Convert.ToString(al[15]);//气
            unitconvert uc = new unitconvert();
            this.label277.Text = uc.moneytochina(Convert.ToInt32(al[16]));//钱

            this.label444.Text = Convert.ToString(al[17]);//武器id
            
            
            this.label411.Text = kungfuIDtostr(Convert.ToString(al[18])) + "等级" + Convert.ToString(al[19]);//武功代码转名字+等级
           
            this.label422.Text = Convert.ToString(al[20])+"层";//功力层次
            this.label21.Text = Convert.ToString(al[21]);//称号
            this.label433.Text = weaponIDtostr(Convert.ToString(al[23]));//武器代码转名字
            this.label50.Text = kungfuIDtostr(Convert.ToString(al[50]));//内功代码转名字
            this.label100.Text = Convert.ToString(al[100])+"-"+Convert.ToString(al[101]);//攻击力
            this.label102.Text = Convert.ToString(al[102]);//防御力
            this.label103.Text = Convert.ToString(al[103]);//闪躲
            this.label104.Text = Convert.ToString(al[104]);//暴伤
            this.label105.Text = Convert.ToString(al[105]);//暴击率
            this.label106.Text = Convert.ToString(al[106]);//命中率
            this.label107.Text = Convert.ToString(al[107]);//攻击次数
            this.label108.Text = "+"+Convert.ToString(Convert.ToDouble(al[108])*100)+"%";//武器附加伤害
            for (int i = 200; i < 400; i++)
            {
                //所学武功列表
                if (Convert.ToString(al[i]) != "0")
                {
                    this.listBox1.Items.Add(kungfuIDtostr(Convert.ToString(al[i])) + "等级" + Convert.ToString(al[i + 200]));
                    
                }
            }
            for (int i = 600; i < 700; i++)
            {
                //所持道具列表
                if (Convert.ToString(al[i]) != "0")
                {
                    this.listBox2.Items.Add(weaponIDtostr(Convert.ToString(al[i])) +"  "+ "数量" + Convert.ToString(al[i + 100]));
                    this.listBox3.Items.Add(Convert.ToString(al[i]));
                }
            }
            

        }

        private void loaddata()
        {
            ArrayList lsal = new ArrayList();
            this.checkedListBox1.Items.Clear();
            this.checkedListBox2.Items.Clear();
            this.checkedListBox11.Items.Clear();
            this.checkedListBox22.Items.Clear();
            DirectoryInfo dir2 = new DirectoryInfo(@".\\data\\kungfu\\");
            foreach (FileInfo dChild in dir2.GetFiles("*.dat"))
            {//如果用GetFiles("*.txt"),那么全部txt文件会被显示
                string fname = dChild.Name.Substring(0, dChild.Name.LastIndexOf("."));//去掉扩展名
                checkedListBox2.Items.Add(fname);
                FileStream fs = new FileStream(".\\data\\kungfu\\" + fname + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                lsal = bf.Deserialize(fs) as ArrayList;
                checkedListBox22.Items.Add(lsal[1]);
                fs.Close();

            }
            DirectoryInfo dir1 = new DirectoryInfo(@".\\data\\character\\");
            foreach (FileInfo dChild in dir1.GetFiles("*.dat"))
            {//如果用GetFiles("*.txt"),那么全部txt文件会被显示
                string fname = dChild.Name.Substring(0, dChild.Name.LastIndexOf("."));//去掉扩展名
                checkedListBox1.Items.Add(fname);
                FileStream fs = new FileStream(".\\data\\character\\" + fname + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                lsal = bf.Deserialize(fs) as ArrayList;
                checkedListBox11.Items.Add(lsal[0]+"Lv"+lsal[7]);
                fs.Close();

            }
            
        }
        private string kungfuIDtostr(string id)
        {
            string name;
            
            ArrayList kf = new ArrayList();
            FileStream fs = new FileStream(".\\data\\kungfu\\" + id + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            kf = bf.Deserialize(fs) as ArrayList;
            fs.Close();
            name = Convert.ToString(kf[1]);
            return name;
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

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(".\\data\\character\\0999qiaofeng.bbc", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            ArrayList dog = new ArrayList();
            int j = 16;
            for (int i = 0; i <= j; i++)
                dog.Add(sr.ReadLine());
            sr.Close();
            fs.Close();
            battle bat = new battle();

            if (bat.battles(al, dog)==1)
            {
                MessageBox.Show("你赢了");
                
            }
            else if (bat.battles(al, dog) == 2)
            {
                
                MessageBox.Show("不分输赢");
            }
            else
            {
               
                MessageBox.Show("你输了,游戏失败");
              
               this.Close();
            }

            f5();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < checkedListBox11.Items.Count; i++)
            {
                if (checkedListBox11.GetItemChecked(i))
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
            
            
            string name = "";
            foreach (string names in checkedListBox1.CheckedItems)
            {
                name += names;
            }



            try
            {
                selectedfight(name);
            }
            catch (Exception)
            {
                MessageBox.Show("请至少选择一个对手!");

            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double money, hp, hpmax, mp, mpmax,lv;
            lv = Convert.ToDouble(al[7]);
            money = Convert.ToDouble(al[16]);
            hp = Convert.ToDouble(al[12]);
            hpmax = Convert.ToDouble(al[13]);
            mp = Convert.ToDouble(al[14]);
            mpmax = Convert.ToDouble(al[15]);
            if (money < 10+(10 * lv))
            {
                MessageBox.Show("没钱还想来住店?!");
            }
            else
            {
                money -= 10 + (10 * lv);
                hp = hpmax;
                mp = mpmax;
                MessageBox.Show("睡了一觉后,你觉得身体充满了力量!");
                al[16] = money;
                al[12] = hp;
                al[14] = mp;
                f5();
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox22.Items.Count; i++)
            {
                if (checkedListBox22.GetItemChecked(i))
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }

            try
            {
                string name = "";
                foreach (string names in checkedListBox2.CheckedItems)
                {
                    name += names;
                }
                //读取武功

                ArrayList kfAL = new ArrayList();
                FileStream fs = new FileStream(".\\data\\kungfu\\" + name + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                kfAL = bf.Deserialize(fs) as ArrayList;
                fs.Close();
                studykungfu skf = new studykungfu();
                if (Convert.ToString(al[50])!=name)
                {
                    skf.studykungfus(al, kfAL);
                }
                else
                {
                    al[11] = "学习失败,你不能在运功的时候修炼。请先卸下武功";
                }
                f5();
                
            }
            catch (Exception)
            {

                MessageBox.Show("请选择一个武功!");
            }
                
           
            
            
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tradeweapon tw = new tradeweapon(al);
            
            //tw.ShowDialog();
            if (tw.ShowDialog()==DialogResult.OK)
            {
                f5();
            }

            
        }

        private void checkedListBox22_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox22.Items.Count; i++)
            {
                if (i != e.Index)//除去触发SelectedIndexChanged事件以外的选中项都处于未选中状态  
                {
                    
                    checkedListBox22.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }

            }
            
        }

        private void checkedListBox11_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox11.Items.Count; i++)
            {
                if (i != e.Index)//除去触发SelectedIndexChanged事件以外的选中项都处于未选中状态  
                {

                    checkedListBox11.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            } 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox22.Items.Count; i++)
            {
                if (checkedListBox22.GetItemChecked(i))
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }

            try
            {
                string name = "";
                foreach (string names in checkedListBox2.CheckedItems)
                {
                    name += names;
                }
                //读取武功
                ArrayList kf = new ArrayList();
                loaddat ld = new loaddat();
                kf=ld.loadkungfu(name);
                for (int i = 200; i < 400; i++)
                {
                    if (Convert.ToString(al[i])==name)
                    {
                        if (Convert.ToString(kf[12]) == "atk")
                        {
                            al[18] = al[i];
                            al[19] = al[i + 200];
                            al[107] = kf[50];
                        }
                        else
                        {
                            MessageBox.Show("所选武功不是攻击套路。");
                        }
                        break;
                    }

                    
                }
                f5();
            }
            catch (Exception)
            {

                MessageBox.Show("你没有学习这个武功或者没有选择!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            int money = Convert.ToInt32(al[16]);
            al[11] = "";
            if (ran.Next(100)<80)//是否有人响应
            {
                switch (ran.Next(1,6))
                {
                    case 1:
                        money+=ran.Next(100);
                        al[16] = money;
                        MessageBox.Show("一个好心人给了你一点钱");
                        break;
                    case 2:
                        money+=ran.Next(100,500);
                        al[16] = money;
                        MessageBox.Show("一个员外给了你许多钱");
                        break;
                    case 3:
                        MessageBox.Show("一个恶霸看到了你,不但不给钱还动手打了你!");
                        selectedfight("0008");
                        
                        break;
                    case 4:
                        MessageBox.Show("趁你不注意,一个小偷把你剩下的钱都偷走了!");
                        money = 0;
                        al[16] = money;

                        break;
                    case 5:
                        MessageBox.Show("一只疯狗袭击了你!!");
                        selectedfight("0009");

                        break;
                    default:
                        break;
                }
                
            }
            else
            {
                MessageBox.Show("没有任何人理睬你!");
            }
            f5();
        }
        private void selectedfight(string name)
        {
            //读取怪物
            ArrayList monster = new ArrayList();
            FileStream fs = new FileStream(".\\data\\character\\" + name + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            monster = bf.Deserialize(fs) as ArrayList;
            fs.Close();


            battle bat = new battle();
            int i = bat.battles(al, monster);

            if (i == 1)
            {
                MessageBox.Show("你赢了");

            }
            else if (i == 2)
            {

                MessageBox.Show("不分输赢");
            }
            else
            {
                
                if (MessageBox.Show("是否察看战报?", "你输了,游戏失败", MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    info inf = new info(al);
                    inf.ShowDialog();
                }
                

                this.Close();
            }

            f5();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(al[20]);
            i--;
            if (i>10)
            {
                MessageBox.Show("最大功力为10层");
            }
            else if(i<1)
            {
                MessageBox.Show("最小功力为1层");
            }
            else
            {
                al[20] = i;
                f5();
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(al[20]);
            i++;
            if (i > 10)
            {
                MessageBox.Show("最大功力为10层");
            }
            else if (i < 1)
            {
                MessageBox.Show("最小功力为1层");
            }
            else
            {
                al[20] = i;
                f5();
            }
        }

        private void checkedListBox22_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                string midname=Convert.ToString(al[23]);
                i = listBox2.SelectedIndex;
                listBox3.SelectedIndex = i;
                loaddat ld = new loaddat();
                shoptrade st = new shoptrade();
                equipmentwear ew= new equipmentwear();
                ew.equioff(al, ld.loadweapon(midname), 23);
                st.getsomething(al, ld.loadweapon(midname), 1);
                
                ew.equiwear(al, ld.loadweapon(listBox3.Text), 23);
                if (Convert.ToString(al[23])!="0")
                {
                    st.destroysomething(al, ld.loadweapon(listBox3.Text), 1);
                    MessageBox.Show("你成功装备了" + weaponIDtostr(Convert.ToString(listBox3.Text)) + "。");
                }
                else
                {
                    //ew.equiwear(al, ld.loadweapon(midname), 23);
                    //st.destroysomething(al, ld.loadweapon(midname), 1);
                    MessageBox.Show("装备" + weaponIDtostr(Convert.ToString(listBox3.Text)) + "失败。");

                }

                



                f5();
            }
            catch (Exception)
            {

                MessageBox.Show("请选择一个要装备的物品！");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = listBox2.SelectedIndex;
                listBox3.SelectedIndex = i;




                ArrayList newwp = new ArrayList();
                string name = listBox3.Text;
                //读取武器


                FileStream fs = new FileStream(".\\data\\weapon\\" + name + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                newwp = bf.Deserialize(fs) as ArrayList;
                fs.Close();
                shoptrade st = new shoptrade();
                st.destroysomething(al, newwp, 1);
                MessageBox.Show("你丢掉了一个" + weaponIDtostr(Convert.ToString(name)) + "。");



                f5();
            }
            catch (Exception)
            {

                MessageBox.Show("请选择一个要丢的物品！");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //解除装备
            string midname = Convert.ToString(al[23]);
            loaddat ld = new loaddat();
            shoptrade st = new shoptrade();
            equipmentwear ew = new equipmentwear();
            ew.equioff(al, ld.loadweapon(midname), 23);
            st.getsomething(al, ld.loadweapon(midname), 1);
            f5();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox22.Items.Count; i++)
            {
                if (checkedListBox22.GetItemChecked(i))
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }

            //try
            //{
                string name = "";
                foreach (string names in checkedListBox2.CheckedItems)
                {
                    name += names;
                }
                //读取武功
                string midname = Convert.ToString(al[50]);
                loaddat ld = new loaddat();
                
                kungfuwear kw = new kungfuwear();
                kw.kfoff(al, ld.loadkungfu(midname));
                ArrayList kf = new ArrayList();
                kf = ld.loadkungfu(name);
                for (int i = 200; i < 400; i++)
                {
                    if (Convert.ToString(al[i])==name)
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

        private void button14_Click(object sender, EventArgs e)
        {
            //解除内功
            string midname = Convert.ToString(al[50]);
            loaddat ld = new loaddat();
            kungfuwear kw = new kungfuwear();
            kw.kfoff(al, ld.loadkungfu(midname));
            
            f5();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox11.Items.Count; i++)
            {
                if (checkedListBox11.GetItemChecked(i))
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }



            //try
            //{

                string name = "";
                foreach (string names in checkedListBox1.CheckedItems)
                {
                    name += names;
                }
                ArrayList npc = new ArrayList();
                FileStream fs = new FileStream(".\\data\\character\\" + name + ".dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();//反序列化
                npc = bf.Deserialize(fs) as ArrayList;
                fs.Close();
                FormBattle fb = new FormBattle(al, npc);

                if (fb.ShowDialog() == DialogResult.OK)
                {
                    double hp=Convert.ToDouble(al[12]);
                    if (hp<=0)
                    {
                        MessageBox.Show("游戏失败");
                        this.Close();
                    }
                    f5();
                }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("请选择一个对手");
                
            //}


            
            
        }
    }
}
