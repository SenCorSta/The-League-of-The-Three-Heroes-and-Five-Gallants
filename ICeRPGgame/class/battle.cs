using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICeRPGgame
{
    class battle
    {
        unitconvert uc = new unitconvert();
        ArrayList mykf = new ArrayList();
        ArrayList enemykf = new ArrayList();
        ArrayList my = new ArrayList();
        ArrayList enemy = new ArrayList();
        public int battles(ArrayList my1, ArrayList enemy1)
        {
           
            my = my1;
            enemy = enemy1;
            int mkfpowlv = Convert.ToInt32(my[20]);//功力层数
            int ekfpowlv = Convert.ToInt32(enemy[20]);
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
            mkf = Convert.ToString(my[18]);
            ekf = Convert.ToString(enemy[18]);
            int matkmin = Convert.ToInt32(my[100]), eatkmin = Convert.ToInt32(enemy[100]);//基础攻击力
            int matkmax = Convert.ToInt32(my[101]), eatkmax = Convert.ToInt32(enemy[101]);//基础攻击力
            string mkfname = "", ekfname = "";//功夫名字
            int mzhaoshi = 1, ezhaoshi = 1;//招式威力系数
            int mzhaoshipp = 1, ezhaoshipp = 1;//招式需要精力
            int mzhaoshilv = 1, ezhaoshilv = 1;//招式等级
            int mzhaoshilvmax = 1, ezhaoshilvmax = 1;//招式最大等级
            for (int i = 0; i < 30; i++)
            {
                mykf.Add(0);
                enemykf.Add(0);
            }
            loadkungfu(mkf, mykf);//读取对应武功赋值
           
            mkfname = Convert.ToString(mykf[1]);
            
            mzhaoshi = Convert.ToInt32(mykf[3]);
            mzhaoshilv = Convert.ToInt32(my[19]);
            mzhaoshilvmax = Convert.ToInt32(mykf[2]);
            mzhaoshipp = Convert.ToInt32(mykf[4]);
            
            loadkungfu(ekf, enemykf);
            ekfname = Convert.ToString(enemykf[1]);
            ezhaoshi = Convert.ToInt32(enemykf[3]); 
            ezhaoshilv = Convert.ToInt32(enemy[19]); 
            ezhaoshilvmax = Convert.ToInt32(enemykf[2]);
            ezhaoshipp = Convert.ToInt32(enemykf[4]);          
            
            double mspd, espd;//速度
            mspd = Convert.ToDouble(my[4]);
            espd = Convert.ToDouble(enemy[4]);
            double mclv, eclv;//智力
            mclv = Convert.ToDouble(my[5]);
            eclv = Convert.ToDouble(enemy[5]);
            double mpow, epow;//力量
            mpow = Convert.ToDouble(my[2]);
            epow = Convert.ToDouble(enemy[2]);
            double mstr,estr;//体质
            mstr = Convert.ToDouble(my[3]);
            estr = Convert.ToDouble(enemy[3]);
            double mphy,ephy;//精神
            mphy = Convert.ToDouble(my[6]);
            ephy = Convert.ToDouble(enemy[6]);
            double mhp, ehp;//hp
            mhp = Convert.ToDouble(my[12]);
            ehp = Convert.ToDouble(enemy[12]);
            int mmp, emp;//mp
            mmp = Convert.ToInt32(my[14]);
            emp = Convert.ToInt32(enemy[14]);
            double mhpmax, ehpmax;//hpmax
            mhpmax = Convert.ToDouble(my[13]);
            ehpmax = Convert.ToDouble(enemy[13]);
            double mmpmax, empmax;//mpmax
            mmpmax = Convert.ToDouble(my[15]);
            empmax = Convert.ToDouble(enemy[15]);
            double mexp = Convert.ToDouble(my[8]);//经验
            double mexpmax = Convert.ToDouble(my[9]);//最大经验
            double elv = Convert.ToDouble(enemy[7]);//敌人等级
            double mlv = Convert.ToDouble(my[7]);//自己等级
            int mmoney = Convert.ToInt32(my[16]);//自己金钱
            int mmoneyadd = 0;
            double damadd = 0;
            
            int win=1;
            int timeover = 0;
            string zhanbao = "";
            Random ran = new Random();
            for (int i = 1; i < 99999999; i++)
            {
                
                zhanbao += "第" + i + "回合开始:\n";
                if (mmp > 0 || emp > 0)
                {


                    if (ran.Next(100) > 50)
                    {
                        zhanbao += "你对" + Convert.ToString(enemy[0]) + "展开攻击，使用了" + mkfname + "，";
                        //mmp -= 1 + mzhaoshipp;//自己使用的精力
                        mmp -= (mzhaoshipp*mkfpowlv);
                        if (ran.Next(95) < 100 * (mspd + 100) / (mspd + espd + 100) && mmp > 0)//是否命中
                        {
                            damadd = (ran.Next(matkmin,matkmax)+mpow / 10) * ((1 - estr / (estr + 100)) + (mzhaoshi * mzhaoshilv / mzhaoshilvmax))*mkfpowlvdam;
                            if (ran.Next(80) < 100 * (1-(ephy + 100) / (mphy + ephy + 100)))//是否暴击
                            {
                                
                                damadd = damadd * 2 + mclv;
                                ehp -= damadd;
                                zhanbao += "击中要害!!造成了" + damadd.ToString("f2") + "点伤害。\n";
                                if (mspd > espd && ran.Next(30, 125) < mspd - espd)
                                {
                                    ehp -= damadd;
                                    zhanbao += "对方还没有反应过来,你收手又攻击了一次造成" + damadd.ToString("f2") + "点伤害。\n";
                                }
                            }
                            else
                            {
                                

                                ehp -= damadd;
                                zhanbao += "造成了" + damadd.ToString("f2") + "点伤害。\n";
                                if (mspd > espd && ran.Next(30, 123) < mspd - espd)
                                {
                                    ehp -= damadd;
                                    zhanbao += "对方还没有反应过来,你收手又攻击了一次造成" + damadd.ToString("f2") + "点伤害。\n";
                                }
                            }

                        }
                        else if (mmp <= 0)
                        {
                            zhanbao += "你的精气用尽,攻击无力。\n";
                        }


                        else
                        {
                            zhanbao += Convert.ToString(enemy[0]) + "躲开了攻击\n";
                        }
                        if (ehp <= 0)
                        {
                            if (i == 1)
                            {
                                zhanbao += "手起刀落。\n" + Convert.ToString(enemy[0]) + "被你一招就解决了。";
                            }
                            else
                            {
                                zhanbao += "大战" + i + "回合后。\n" + Convert.ToString(enemy[0]) + "被你杀了。";

                            }
                            break;
                        }
                        zhanbao += Convert.ToString(enemy[0]) + "对你进行反击，使用了" + ekfname + "，";
                        emp -=(ezhaoshipp * ekfpowlv);//敌人精力
                        if (ran.Next(95) < 100 * (espd + 100) / (mspd + espd + 100) && emp > 0)//是否命中
                        {
                            damadd = (ran.Next(eatkmin, eatkmax) + epow / 10) * ((1 - mstr / (mstr + 100)) + (ezhaoshi * ezhaoshilv / ezhaoshilvmax)) * ekfpowlvdam;
                            if (ran.Next(80) < 100 * (1 - (mphy + 100) / (mphy + ephy + 100)))//是否暴击
                            {

                                damadd = damadd * 2 + eclv;
                                mhp -= damadd;
                                zhanbao += "击中要害!!造成了" + damadd.ToString("f2") + "点伤害。\n";
                                if (espd > mspd && ran.Next(30, 123) < espd - mspd)
                                {
                                    mhp -= damadd;
                                    zhanbao += "你的动作太慢,被一招连打两下,造成" + damadd.ToString("f2") + "点伤害。\n";
                                }


                            }
                            else
                            {
                                
                                mhp -= damadd;
                                zhanbao += "造成了" + damadd.ToString("f2") + "点伤害。\n";
                                if (espd > mspd && ran.Next(30, 123) < espd - mspd)
                                {
                                    mhp -= damadd;
                                    zhanbao += "你的动作太慢,被一招连打两下,造成" + damadd.ToString("f2") + "点伤害。\n";
                                }
                            }

                        }
                        else if (emp <= 0)
                        {
                            zhanbao += Convert.ToString(enemy[0]) + "的精气用尽,毫无还手之力。\n";
                        }
                        else
                        {
                            zhanbao += "攻击被你躲开了\n";
                        }
                        if (mhp <= 0)
                        {
                            if (i == 1)
                            {
                                zhanbao += "能耐相差太大，" + Convert.ToString(enemy[0]) + "轻而易举就赢了。";
                            }
                            else
                            {
                                zhanbao += "大战" + i + "回合后。\n" + Convert.ToString(enemy[0]) + "把你弄死了。";

                            }
                            break;
                        }
                    }
                    else
                    {
                        zhanbao += Convert.ToString(enemy[0]) + "对你展开攻击，使用了" + ekfname + "，";
                        emp -=(ezhaoshipp * ekfpowlv);
                        if (ran.Next(95) < 100 * (espd + 100) / (mspd + espd + 100) && emp > 0)//是否命中
                        {
                            damadd = (ran.Next(eatkmin, eatkmax) + epow / 10) * ((1 - mstr / (mstr + 100)) + (ezhaoshi * ezhaoshilv / ezhaoshilvmax)) * ekfpowlvdam;
                            if (ran.Next(80) < 100 * (1 - (mphy + 100) / (mphy + ephy + 100)))//是否暴击
                            {

                                damadd = damadd * 2 + eclv;
                                mhp -= damadd;
                                zhanbao += "击中要害!!造成了" + damadd.ToString("f2") + "点伤害。\n";
                                if (espd > mspd && ran.Next(30, 123) < espd - mspd)
                                {
                                    mhp -= damadd;
                                    zhanbao += "你的动作太慢,被一招连打两下,造成" + damadd.ToString("f2") + "点伤害。\n";
                                }

                            }
                            else
                            {
                                

                                mhp -= damadd;
                                zhanbao += "造成了" + damadd.ToString("f2") + "点伤害。\n";
                                if (espd > mspd && ran.Next(30, 123) < espd - mspd)
                                {
                                    mhp -= damadd;
                                    zhanbao += "你的动作太慢,被一招连打两下,造成" + damadd.ToString("f2") + "点伤害。\n";
                                }
                            }

                        }
                        else if (emp <= 0)
                        {
                            zhanbao += Convert.ToString(enemy[0]) + "的精气用尽,攻击无力。\n";
                        }

                        else
                        {
                            zhanbao += "攻击被你躲开了\n";
                        }
                        if (mhp <= 0)
                        {
                            if (i == 1)
                            {
                                zhanbao += Convert.ToString(enemy[0]) + "只出了一招就把你击败了。";
                            }
                            else
                            {
                                zhanbao += "大战" + i + "回合后。\n" + Convert.ToString(enemy[0]) + "把你弄死了。";

                            }

                            break;
                        }
                        zhanbao += "你对" + Convert.ToString(enemy[0]) + "进行反击，使用了" + mkfname + "，";
                        mmp -=(mzhaoshipp * mkfpowlv);
                        if (ran.Next(95) < 100 * (mspd + 100) / (mspd + espd + 100) && mmp > 0)//是否命中
                        {
                            damadd = (ran.Next(matkmin, matkmax) + mpow / 10) * ((1 - estr / (estr + 100)) + (mzhaoshi * mzhaoshilv / mzhaoshilvmax)) * mkfpowlvdam;
                            if (ran.Next(80) < 100 * (1 - (ephy + 100) / (mphy + ephy + 100)))//是否暴击
                            {
                                damadd = damadd * 2 + mclv;
                                ehp -= damadd;
                                zhanbao += "击中要害!!造成了" + damadd.ToString("f2") + "点伤害。\n";
                                if (mspd > espd && ran.Next(30, 123) < mspd - espd)
                                {
                                    ehp -= damadd;
                                    zhanbao += "对方还没有反应过来,你收手又攻击了一次造成" + damadd.ToString("f2") + "点伤害。\n";
                                }
                            }
                            else
                            {
                                
                                ehp -= damadd;
                                zhanbao += "造成了" + damadd.ToString("f2") + "点伤害。\n";
                                if (mspd > espd && ran.Next(30, 123) < mspd - espd)
                                {
                                    ehp -= damadd;
                                    zhanbao += "对方还没有反应过来,你收手又攻击了一次造成" + damadd.ToString("f2") + "点伤害。\n";
                                }
                            }

                        }
                        else if (mmp <= 0)
                        {
                            zhanbao += "你的精气用尽,毫无招架之力。\n";
                        }
                        else
                        {
                            zhanbao += Convert.ToString(enemy[0]) + "躲开了攻击\n";
                        }
                        if (ehp <= 0)
                        {
                            if (i == 1)
                            {
                                zhanbao += "招架住" + Convert.ToString(enemy[0]) + "的攻击后,你不费吹灰之力就取下他的首级。";
                            }
                            else
                            {
                                zhanbao += "大战" + i + "回合后。\n" + Convert.ToString(enemy[0]) + "被你杀了。";

                            }

                            break;
                        }
                    }
                }
                else
                {
                    zhanbao += "棋逢敌手,大战" + i + "回合后。\n" + "你们双方都精疲力尽不分输赢。";
                    break;
                }
                if (i == 1000)
                {
                    timeover = 1;
                    zhanbao += "你们打了一千回合不分输赢!!决定择日再战。\n";
                    break;
                }
            }
            if (mmp < 0)
            {
                mmp = 0;
            }
            if (mhp < 1&&mhp>0)
            {
                mhp = 1;
            }
            if (mhp <= 0)
            {
                win = 0;
            }
            else if (mhp > 0 && mmp > 0 && timeover == 0)
            {
                win = 1;
                mmoneyadd = Convert.ToInt32(enemy[16]);
                mmoney += mmoneyadd;
                zhanbao += "你得到金钱" + uc.moneytochina(mmoneyadd) + "。\n";
                mexp += ran.Next(100, 300) * elv * mclv / (mclv+100) + 1;
                if (mexp > mexpmax)//升级
                {

                    mexpmax +=mlv * 33;
                    mlv++;
                    if (mexp>mexpmax)
                    {
                        mexp = mexpmax;
                        zhanbao += "已经达到经验值上限!\n";
                    }
                    //mexp = 0;
                    mhpmax = mstr*10;
                    mmpmax = mphy*10;
                    zhanbao += "等级上升!\n";
                }
                my1[12] = mhp.ToString("f0");

                my1[7] = mlv;
                my1[8] = mexp.ToString("f0");
                my1[9] = mexpmax.ToString("f0");
                if (mexp / mexpmax < 1)
                {
                    my1[10] = Convert.ToInt32(mexp / mexpmax * 100);
                }
                else
                {
                    my1[10] = 100;
                }

                my1[13] = mhpmax;
                my1[14] = mmp;
                my1[15] = mmpmax;
                my1[16] = mmoney;

            }
            else
            {
                win = 2;
                
            }
            my1[14] = mmp;
            my1[12] = mhp.ToString("f0");
            my1[11] = zhanbao;
            return win;

        }
        private void loadkungfu(string id,ArrayList kfals)
        {
            //读取武功


            ArrayList kfal=new ArrayList();
            FileStream fs = new FileStream(".\\data\\kungfu\\" + id + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            kfal = bf.Deserialize(fs) as ArrayList;
            fs.Close();
            kfals[3] = Convert.ToInt32(kfal[3]);
            kfals[4] = Convert.ToInt32(kfal[4]);
            kfals[1] = Convert.ToString(kfal[1]);
            kfals[2] = Convert.ToInt32(kfal[2]);
            
        }
    }
}
