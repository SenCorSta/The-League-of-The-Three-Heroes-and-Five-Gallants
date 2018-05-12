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
    public partial class FormBattle : Form
    {
        ArrayList playeral = new ArrayList();
        ArrayList npcal = new ArrayList();
        ArrayList mykf = new ArrayList();
        ArrayList enemykf = new ArrayList();
        string tips = "";
        int atkchose=0,defchose=0;
        int over = 0;
        public FormBattle(ArrayList player,ArrayList npc)
        {
            playeral = player;
            npcal = npc;
            InitializeComponent();
            f5();

            //tips = "对你进行攻击!";

            
        }
        private void atkmotion(int iii,int jjj)
        {
            ArrayList playeralmid = new ArrayList();
            ArrayList npcalmid = new ArrayList();
            if (iii==0)
            {
                playeralmid = playeral;
                npcalmid = npcal;
                
            }
            else
            {
                playeralmid = npcal;
                npcalmid = playeral;
            }
            string msg = "";
            int mkfpowlv = Convert.ToInt32(playeralmid[20]), ekfpowlv = Convert.ToInt32(npcalmid[20]); ;//功力层数
            double mkfpowlvdam = 1;//层数伤害加成系数
            double ekfpowlvdam = 1;
            for (int i = 2; i <= mkfpowlv; i++)
            {
                mkfpowlvdam += 1 * (1 - ((i - 1) / 12.5));//每多一层少0.08
            }
            for (int i = 2; i <= ekfpowlv; i++)
            {
                ekfpowlvdam += 1 * (1 - ((i - 1) / 12.5));
            }

            string mkf = "", ekf = "";//功夫id
            mkf = Convert.ToString(playeralmid[18]);
            ekf = Convert.ToString(npcalmid[18]);
            string mkfname = "", ekfname = "";//功夫名字
            double mzhaoshi = 1, ezhaoshi = 1;//招式威力系数
            int mzhaoshipp = 1, ezhaoshipp = 1;//招式需要精力
            int mzhaoshilv = 1, ezhaoshilv = 1;//招式等级
            int mzhaoshilvmax = 1, ezhaoshilvmax = 1;//招式最大等级
            int mhittimes = 1, ehittimes = 1;
            
            for (int i = 0; i < 100; i++)
            {
                mykf.Add(0);
                enemykf.Add(0);
            }
            loadkungfu(mkf, mykf);//读取对应武功赋值

            mkfname = Convert.ToString(mykf[1]);
            mzhaoshilv = Convert.ToInt32(playeralmid[19]);
            mzhaoshilvmax = Convert.ToInt32(mykf[2]);
            mzhaoshipp = Convert.ToInt32(mykf[61]) * mzhaoshilv + Convert.ToInt32(mykf[62]);
            mzhaoshi = Convert.ToDouble(mykf[63]) * mzhaoshilv + Convert.ToDouble(mykf[64]);
            //playeralmid[107] = Convert.ToInt32(mykf[50]);//攻击段数
            mhittimes = Convert.ToInt32(mykf[50]);//次数
           

            loadkungfu(ekf, enemykf);
            ekfname = Convert.ToString(enemykf[1]);
            
            ezhaoshilv = Convert.ToInt32(npcalmid[19]);
            ezhaoshilvmax = Convert.ToInt32(enemykf[2]);
            ezhaoshipp = Convert.ToInt32(enemykf[61]) * ezhaoshilv + Convert.ToInt32(enemykf[62]);
            ezhaoshi = Convert.ToDouble(enemykf[63]) * ezhaoshilv + Convert.ToDouble(enemykf[64]);
            //npcalmid[107] = Convert.ToInt32(enemykf[50]);
            ehittimes = Convert.ToInt32(enemykf[50]);
            double mpow, epow;//力量
            mpow = Convert.ToDouble(playeral[2]);
            epow = Convert.ToDouble(npcal[2]);
            double mstr,estr;//体质
            mstr = Convert.ToDouble(playeral[3]);
            estr = Convert.ToDouble(npcal[3]);

            double mhp = Convert.ToDouble(playeralmid[12]), ehp = Convert.ToDouble(npcalmid[12]);//hp
            double mmp = Convert.ToDouble(playeralmid[14]), emp = Convert.ToDouble(npcalmid[14]);//mp
            double mmpmax = Convert.ToDouble(playeralmid[15]), empmax = Convert.ToDouble(npcalmid[15]);//mpmax
            int matkmin = Convert.ToInt32(playeralmid[100]), eatkmin = Convert.ToInt32(npcalmid[100]);//基础攻击力
            int matkmax = Convert.ToInt32(playeralmid[101]), eatkmax = Convert.ToInt32(npcalmid[101]);//基础攻击力
            double mdef = Convert.ToDouble(playeralmid[102]), edef = Convert.ToDouble(npcalmid[102]);//防御
            double mmiss = Convert.ToDouble(playeralmid[103]), emiss = Convert.ToDouble(npcalmid[103]);//躲避
            double mhit = Convert.ToDouble(playeralmid[106]), ehit = Convert.ToDouble(npcalmid[106]);//命中
            
            
            double mcrit = Convert.ToDouble(playeralmid[105]), ecrit = Convert.ToDouble(npcalmid[105]);//暴击
            double mcritdam = Convert.ToDouble(playeralmid[104]), ecritdam = Convert.ToDouble(npcalmid[104]);//暴击伤害
            double mweapondam = Convert.ToDouble(playeralmid[108]), eweapondam = Convert.ToDouble(npcalmid[108]);//武器伤害
            Random ran= new Random();
            double dam = 0,damall=0;
            int j = 0,m=0;

            if (mpow - estr>0)
            {
                if (edef > mpow)//力道减防御
                {
                    edef -= (mpow - estr);
                }
                else
                {
                    edef = 0;
                }
            }
            
            
            

            
            if (jjj==1)//招架
            {
                edef = edef * 1.3;
                msg += "对手使用了招架\n";
            }
            else if(jjj==2)//miss
            {
                emiss += 0.3;
                msg += "对手使用了躲避\n";
            }
            else if (jjj == 3)//运功
            {
                emp += empmax * 0.1;
                if (emp>empmax)
                {
                    emp = empmax;
                }
                edef = edef * 0.3;
                emiss -= 0.3;
                msg += "对手运功回气\n";
            }
            if (mzhaoshipp * mkfpowlv > mmp)
            {
                msg +="内力不足无法发招\n";
            }
            else
            {
                mmp -= mzhaoshipp * mkfpowlv;
                msg += "使用了" + mkfname + "一共" + mhittimes + "段攻击\n";
                for (int i = 1; i <= mhittimes; i++)
                {

                    msg += "\n第" + i + "击:";
                    if (ran.Next(0, 1000) < (mhit - emiss) * 1000)//是否命中
                    {
                        j++;
                        dam = ran.Next(matkmin, matkmax);
                        if (dam - edef < 0)//是否防御过大
                        {
                            dam = 1;
                            msg += "伤害:" + dam;
                        }
                        else
                        {
                            dam = dam - edef;//基础伤害
                            dam = dam * (mkfpowlvdam+mzhaoshi);//层数加成
                            //dam = dam * mzhaoshi;//招式加成
                            dam = dam * (1 + mweapondam);//武器加成
                            dam = dam * (1-(estr / 1000));
                            if (ran.Next(0, 1000) < (mcrit * 1000))//是否暴击
                            {
                                m++;
                                dam = dam * (1+mcritdam);
                                msg += "造成暴击!伤害:" + dam.ToString("f0");
                            }
                            else
                            {
                                msg += "伤害:" + dam;
                            }
                        }

                    }
                    else
                    {
                        dam = 0;
                        msg += "未命中";
                    }

                    damall += dam;

                }
            }
            
            
            //damall = damall;
            msg += "\n共命中" + j + "击,共造成" + damall.ToString("f0") + "伤害.暴击" + m + "次";
            ehp -= damall;
            if (ehp<0)
            {
                over = 1;
            }
            npcalmid[12] = ehp.ToString("f0");
            npcalmid[14] = emp.ToString("f0");
            playeralmid[14] = mmp.ToString("f0");
            playeralmid[12] = mhp.ToString("f0");
            playeralmid[11] = msg;
            npcalmid[11] = msg;
            if (iii == 0)
            {
                playeral = playeralmid;
                npcal = npcalmid;

            }
            else
            {
                playeral = npcalmid;
                npcal = playeralmid;
            }
            richTextBox1.Text += msg;
            f5();
            
        }

        
        
        private void f5()
        {
            //this.richTextBox1.Text = tips;
            this.labela0.Text = Convert.ToString(playeral[0]);//姓名
            //this.labela0.Text = Convert.ToString(playeral[1]);//性别
            this.labela2.Text = Convert.ToString(playeral[2]);//力道
            this.labela3.Text = Convert.ToString(playeral[3]);//根骨
            this.labela4.Text = Convert.ToString(playeral[4]);//灵敏
            this.labela5.Text = Convert.ToString(playeral[5]);//头脑
            this.labela6.Text = Convert.ToString(playeral[6]);//精神
            this.labela7.Text = Convert.ToString(playeral[7]);//等级
            //this.labela8.Text = Convert.ToString(playeral[8]);//经验
            //this.labela9.Text = Convert.ToString(playeral[9]);//经验最大
            //this.labela10.Text = Convert.ToString(playeral[10]);//等级条
            this.richTextBox11.Text = Convert.ToString(playeral[11]);//战报
            this.labela12.Text = Convert.ToString(playeral[12])+"/"+Convert.ToString(playeral[13]);//血
            
            this.labela14.Text = Convert.ToString(playeral[14]) + "/" + Convert.ToString(playeral[15]);//气
            
            //this.labela16.Text = Convert.ToString(playeral[16]);//钱
            //this.labela17.Text = Convert.ToString(playeral[17]);//武器类型
            this.labela18.Text = Convert.ToString(playeral[18]);//武功
            //this.labela19.Text = Convert.ToString(playeral[19]);//武功等级
            this.labela20.Text = Convert.ToString(playeral[20]);//功力
            this.labela21.Text = Convert.ToString(playeral[21]);//外号
            //this.richlabela22.Text = Convert.ToString(playeral[22]);//描述
            this.labela23.Text = Convert.ToString(playeral[23]);//装备武器
            this.labela50.Text = Convert.ToString(playeral[50]);//装备内功
            //this.labela50000000.Text = Convert.ToString(playeral[24]);//装备道具
            this.labela100.Text = Convert.ToString(playeral[100])+"-"+Convert.ToString(playeral[101]);//基础攻击力
            
            this.labela102.Text = Convert.ToString(playeral[102]);//防御
            this.labela103.Text = Convert.ToString(playeral[103]);//躲避
            this.labela104.Text = Convert.ToString(playeral[104]);//爆伤
            this.labela105.Text = Convert.ToString(playeral[105]);//暴击
            this.labela106.Text = Convert.ToString(playeral[106]);//命中
            this.labela107.Text = Convert.ToString(playeral[107]);//次数


            this.labelb0.Text = Convert.ToString(npcal[0]);//姓名
            //this.labela0.Text = Convert.ToString(npcal[1]);//性别
            this.labelb2.Text = Convert.ToString(npcal[2]);//力道
            this.labelb3.Text = Convert.ToString(npcal[3]);//根骨
            this.labelb4.Text = Convert.ToString(npcal[4]);//灵敏
            this.labelb5.Text = Convert.ToString(npcal[5]);//头脑
            this.labelb6.Text = Convert.ToString(npcal[6]);//精神
            this.labelb7.Text = Convert.ToString(npcal[7]);//等级
            //this.labela8.Text = Convert.ToString(npcal[8]);//经验
            //this.labela9.Text = Convert.ToString(npcal[9]);//经验最大
            //this.labela10.Text = Convert.ToString(npcal[10]);//等级条
            //this.labela11.Text = Convert.ToString(npcal[11]);//战报
            this.labelb12.Text = Convert.ToString(npcal[12]) + "/" + Convert.ToString(npcal[13]);//血
                      
            this.labelb14.Text = Convert.ToString(npcal[14]) + "/" + Convert.ToString(npcal[15]);//气

            //this.labela16.Text = Convert.ToString(npcal[16]);//钱
            //this.labela17.Text = Convert.ToString(npcal[17]);//武器类型
            //this.labelb18.Text = Convert.ToString(npcal[18]);//武功
            //this.labela19.Text = Convert.ToString(npcal[19]);//武功等级
            //this.labelb20.Text = Convert.ToString(npcal[20]);//功力
            this.labelb21.Text = Convert.ToString(npcal[21]);//外号
            //this.richlabela22.Text = Convert.ToString(npcal[22]);//描述
            //this.labelb23.Text = Convert.ToString(npcal[23]);//装备武器
            //this.labelb50.Text = Convert.ToString(npcal[50]);//装备内功
            //this.labela50000000.Text = Convert.ToString(npcal[24]);//装备道具
            this.labelb100.Text = Convert.ToString(npcal[100]) + "-" + Convert.ToString(npcal[101]);//基础攻击力
                      
            this.labelb102.Text = Convert.ToString(npcal[102]);//防御
            this.labelb103.Text = Convert.ToString(npcal[103]);//躲避
            this.labelb104.Text = Convert.ToString(npcal[104]);//爆伤
            this.labelb105.Text = Convert.ToString(npcal[105]);//暴击
            this.labelb106.Text = Convert.ToString(npcal[106]);//命中
            this.labelb107.Text = Convert.ToString(npcal[107]);//次数
        }
        private void loadkungfu(string id, ArrayList kfals)
        {
            //读取武功


            ArrayList kfal = new ArrayList();
            FileStream fs = new FileStream(".\\data\\kungfu\\" + id + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            kfal = bf.Deserialize(fs) as ArrayList;
            fs.Close();

            kfals[1] = Convert.ToString(kfal[1]);
            kfals[2] = Convert.ToInt32(kfal[2]);
            kfals[61] = Convert.ToInt32(kfal[61]);
            kfals[62] = Convert.ToInt32(kfal[62]);
            kfals[63] = Convert.ToDouble(kfal[63]);
            kfals[64] = Convert.ToDouble(kfal[64]);
            kfals[50] = Convert.ToInt32(kfal[50]);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random ran = new Random();

            atkmotion(0,ran.Next(1,4));
            if (over==1)
            {
                    MessageBox.Show("你赢了");
                    win();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
            }
            panel3.Visible = false;
            panel4.Visible = true;
            
        }
        private void win()
        {
            int mmoneyadd = 0;
            int mmoney = Convert.ToInt32(playeral[16]);
            string zhanbao = "";
            double mexp = Convert.ToDouble(playeral[8]);
            double mexpmax = Convert.ToDouble(playeral[9]);
            mmoneyadd = Convert.ToInt32(npcal[16]);
            mmoney += mmoneyadd;//加钱
            unitconvert uc = new unitconvert();
            zhanbao += "你得到金钱" + uc.moneytochina(mmoneyadd) + "。\n";
            Random ran = new Random();
            int elv = Convert.ToInt32(npcal[7]);
            int mlv = Convert.ToInt32(playeral[7]);
            int mclv = Convert.ToInt32(playeral[5]);
            double xpadd = 0;
            xpadd = ran.Next(10, 10 + mclv) * elv;//加经验
            mexp += xpadd;//加经验
            mexpmax += xpadd;//加经验
            
            if (mexpmax>100*mlv)
            {
                mlv++;
            }
            


            playeral[7] = mlv;
            playeral[8] = mexp.ToString("f0");
            playeral[9] = mexpmax.ToString("f0");
            if (mexp / mexpmax < 1)
            {
                playeral[10] = Convert.ToInt32(mexp / mexpmax * 100);
            }
            else
            {
                playeral[10] = 100;
            }

                                              
            playeral[16] = mmoney;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(playeral[20]);
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
                playeral[20] = i;
                f5();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(playeral[20]);
            i--;
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
                playeral[20] = i;
                f5();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //atkmotion(1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            Random ran = new Random();
            int i=0;
            while (true)
            {
                double mhp = Convert.ToDouble(playeral[12]), ehp = Convert.ToDouble(npcal[12]);//hp
                i++;
                if (ran.Next(0, 1000) < 500)
                {
                    atkmotion(0,ran.Next(1,4));
                    atkmotion(1,ran.Next(1,4));
                }
                else
                {
                    atkmotion(1,ran.Next(1,4));
                    atkmotion(0,ran.Next(1,4));
                }
                if (mhp <= 0)
                {
                    MessageBox.Show("你输了");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                }
                else if (ehp <= 0)
                {
                    MessageBox.Show("你赢了");
                    win();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                }
                else if(i==100)
                {
                    MessageBox.Show("100回合后不分输赢");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                }
                
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            if (ran.Next(0, 1000) < 500)
            {
                panel3.Visible = true;
            }
            else
            {
                panel4.Visible = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            atkmotion(1, 3);
            if (over == 1)
            {
                MessageBox.Show("你输了");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            panel4.Visible = false;
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            atkmotion(1, 1);
            if (over == 1)
            {
                MessageBox.Show("你输了");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            panel4.Visible = false;
            panel3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            atkmotion(1, 2);
            if (over == 1)
            {
                MessageBox.Show("你输了");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            panel4.Visible = false;
            panel3.Visible = true;
        }
    }
}
