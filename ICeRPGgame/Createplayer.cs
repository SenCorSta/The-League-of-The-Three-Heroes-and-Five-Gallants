using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ICeRPGgame
{
    public partial class Createplayer : Form
    {
        public Createplayer()
        {
            InitializeComponent();
        }

        private void Createplayer_Load(object sender, EventArgs e)
        {
            chognzhi();
        }
        private void chognzhi()
        {
            int nub1, nub2, nub3, nub4, nub5, nub6, nub7;
            bool over=true;
            while (over)
            {
                Random ran = new Random();
                nub1 = ran.Next(1,5);
                nub2 = ran.Next(1,5);
                nub3 = ran.Next(1,5);
                nub4 = ran.Next(1,5);
                nub5 = ran.Next(1,5);
                nub6 = 3;
                nub7 = nub1 + nub2 + nub3 + nub4 + nub5;
                if (nub7 > 10 && nub7 < 23)
                {
                    this.label41.Text = nub1.ToString();
                    this.label42.Text = nub2.ToString();
                    this.label43.Text = nub3.ToString();
                    this.label44.Text = nub4.ToString();
                    this.label45.Text = nub5.ToString();
                    this.label46.Text = nub6.ToString();
                    over=false;
                }
            }
        }
 
        
        private void button2_Click(object sender, EventArgs e)
        {
            chognzhi();
            }

        private void button41_Click(object sender, EventArgs e)
        {
            if (label46.Text != "0")
            {
                int mid = Convert.ToInt32(label46.Text);
                mid--;
                label46.Text = mid.ToString();
                int midd = Convert.ToInt32(label41.Text);
                midd++;
                label41.Text = midd.ToString();

            }
            else
                MessageBox.Show("剩余点数不足");
                
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (label46.Text != "0")
            {
                int mid = Convert.ToInt32(label46.Text);
                mid--;
                label46.Text = mid.ToString();
                int midd = Convert.ToInt32(label42.Text);
                midd++;
                label42.Text = midd.ToString();

            }
            else
                MessageBox.Show("剩余点数不足");
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (label46.Text != "0")
            {
                int mid = Convert.ToInt32(label46.Text);
                mid--;
                label46.Text = mid.ToString();
                int midd = Convert.ToInt32(label43.Text);
                midd++;
                label43.Text = midd.ToString();

            }
            else
                MessageBox.Show("剩余点数不足");
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (label46.Text != "0")
            {
                int mid = Convert.ToInt32(label46.Text);
                mid--;
                label46.Text = mid.ToString();
                int midd = Convert.ToInt32(label44.Text);
                midd++;
                label44.Text = midd.ToString();

            }
            else
                MessageBox.Show("剩余点数不足");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (label46.Text != "0")
            {
                int mid = Convert.ToInt32(label46.Text);
                mid--;
                label46.Text = mid.ToString();
                int midd = Convert.ToInt32(label45.Text);
                midd++;
                label45.Text = midd.ToString();

            }
            else
                MessageBox.Show("剩余点数不足");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text != "")
            {
                if (label46.Text == "0")
                {
                    //在这儿输入确定后的事情
                    ArrayList player = new ArrayList();
                    player.Add(textBox1.Text);//0
                    if(radioButton1.Checked)
                        player.Add("男");//1
                    else
                        player.Add("女");

                    player.Add(label41.Text);//2力
                    player.Add(label42.Text);//3体
                    player.Add(label43.Text);//4敏
                    player.Add(label44.Text);//5智
                    player.Add(label45.Text);//6精
                    player.Add("1");//等级7
                    player.Add("0");//当前经验8
                    player.Add("100");//升级所需要的经验9
                    player.Add("0");//经验条比率10
                    player.Add("");//消息框
                    player.Add("30");//血12
                    player.Add("30");//最大血13
                    player.Add("20");//气14
                    player.Add("20");//最大气15
                    player.Add("100");//钱16
                    
                    player.Add("0");//武器类型代码17


                    player.Add("0001");//当前装备武功代码18

                    player.Add("1");//当前装备武功等级19
                    player.Add("1");//功力层数20
                    player.Add("主角");//外号21
                    player.Add("主角的介绍");//人物介绍22
                    player.Add("0");//装备武器ID23
                    player.Add("0");//装备防具ID24
                    player.Add("0");//装备道具ID25

                    for (int i = 25+1; i < 200; i++)
                    {
                        //留为备用
                        player.Add("0");
                    }
                    player[50] = "0";//装备心法
                    player[100] = label41.Text;//人物基础最小攻击力100
                    player[101] = label41.Text;//人物基础最大攻击力101
                    player[102] = label42.Text;//防御
                    player[103] = Convert.ToDouble(label43.Text)*0.002;//闪躲
                    player[104] = 1+Convert.ToDouble(label44.Text) * 0.004;//暴伤
                    player[105] = Convert.ToDouble(label45.Text) * 0.001;//暴击率
                    player[106] = "1";//命中
                    player[107] = "3";//攻击次数
                    for (int i = 200; i < 400; i++)
                    {
                        //留为所学武功id
                        player.Add("0");
                    }
                    for (int i = 400; i < 600; i++)
                    {
                        //留为所学武功等级
                        player.Add("0");
                    }
                    player[200] = "0001";
                    player[400] = "1";
                    for (int i = 600; i < 700; i++)
                    {
                        //留为持有物品id
                        player.Add("0");
                    }
                    
                    for (int i = 700; i < 800; i++)
                    {
                        //留为持有物品数量
                        player.Add("0");
                    }

                    for (int i = 800; i < 1000; i++)
                    {
                        //留为备用
                        player.Add("0");
                    }
                    player[600] = "d0001";
                    player[700] = "1";
                    

                    PalyerDataPanel PDP = new PalyerDataPanel(player);
                    
                    PDP.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("还有剩余点数");
            }
            else
                MessageBox.Show("请输入一个名字");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            int i = 0;
            string s = "";
            i = ran.Next(1, 11);
            switch (i)
            {
                case  1:
                    s = "白玉堂";
                    break;
                case 2:
                    s = "展昭";
                    break;
                case 3:
                    s = "刘世杰";
                    break;
                case 4:
                    s = "李杨";
                    break;
                case 5:
                    s = "杨继";
                    break;
                case 6:
                    s = "李娟";
                    break;
                case 7:
                    s = "王亚园";
                    break;
                case 8:
                    s = "李迪";
                    break;
                case 9:
                    s = "花俊";
                    break;
                case 10:
                    s = "李晓月";
                    break;
                default:
                    s = "玩家";
                    break;
            }
            this.textBox1.Text = s;
        }

        }
    }
    

