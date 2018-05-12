using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICeRPGgame
{
    class studykungfu
    {
        unitconvert uc = new unitconvert();
        weaponID wi = new weaponID();
        public void studykungfus(ArrayList player, ArrayList kfalnew)
        {
            ArrayList qiantikf = new ArrayList();
            qiantikf = kfalnew;
            int need = 0;
            string info = "";
            bool newkf = true;
            bool oldkfok = false;
            int newkfnub = 0;
            info+=Convert.ToString(kfalnew[24])+"\n";
            for (int i = 200; i < 400; i++)
            {
                //判断是否学习新武功
                if (Convert.ToString(player[i]) == Convert.ToString(kfalnew[0]))
                {
                    newkf = false;
                }
            }
            if (newkf)
            {
                //如果新学习判断是否满足要求
                for (int i = 200; i < 400; i++)
                {
                    if (Convert.ToString(kfalnew[14]) == Convert.ToString(player[i]) && Convert.ToString(kfalnew[14]) != "0")
                    {
                        oldkfok = true;
                        if (Convert.ToInt32(kfalnew[15]) > Convert.ToInt32(player[i + 200]))
                        {
                            need++;
                            info += "前提武功等级不符合要求。需要" + kungfuIDtostr(Convert.ToString(qiantikf[14])) + Convert.ToInt32(kfalnew[15]) + "级" + "。\n";
                            
                        }
                        break;
                        

                    }


                }
                if (oldkfok == false && Convert.ToString(kfalnew[14])!="0")
                {
                    need++;

                    info += "前提武功不符合要求。需要" + kungfuIDtostr(Convert.ToString(qiantikf[14])) + Convert.ToInt32(kfalnew[15])+ "级"+ "。\n";


                }


            }
            if (newkf)//为新武功找到一个位置
            {
                for (int i = 200; i < 400; i++)
                {
                    if (Convert.ToString(player[i])=="0")
                    {
                        newkfnub = i;
                        break;
                    }
                }
                
            }
            else//找到存在武功的位置
            {
                for (int i = 200; i < 400; i++)
                {
                    if (Convert.ToString(kfalnew[0]) == Convert.ToString(player[i]))
                    {
                         newkfnub = i;
                        break;
                    }
                }
            }
            
            if (Convert.ToInt32(kfalnew[2]) <= Convert.ToInt32(player[newkfnub + 200]))
            {
                need++;
                info += "已经达到当前武功所能达到的最大等级。\n";
            }
   
                
           
            
            
            if (Convert.ToInt32(kfalnew[13]) > Convert.ToInt32(player[7]))
            {
                need++;
                info += "等级不符合要求。需要"+Convert.ToInt32(kfalnew[13])+"。\n";

            }
            if (Convert.ToString(kfalnew[6]) != Convert.ToString(player[17]))
            {
                if (Convert.ToString(kfalnew[6])!="0")
                {
                    need++;
                    info += "武器不符合要求。需要" + wi.weaponIDtostr(Convert.ToString(kfalnew[6])) + "。\n";
                }
                

            }
           
            
            if (Convert.ToInt32(kfalnew[16]) > Convert.ToInt32(player[2]))
            {
                need++;
                info += "力道不符合要求。需要" + Convert.ToInt32(kfalnew[16]) + "。\n";

            }
            if (Convert.ToInt32(kfalnew[17]) > Convert.ToInt32(player[3]))
            {
                need++;
                info += "根骨不符合要求。需要" + Convert.ToInt32(kfalnew[17]) + "。\n";

            }
            if (Convert.ToInt32(kfalnew[18]) > Convert.ToInt32(player[4]))
            {
                need++;
                info += "灵敏不符合要求。需要" + Convert.ToInt32(kfalnew[18]) + "。\n";

            }
            if (Convert.ToInt32(kfalnew[19]) > Convert.ToInt32(player[5]))
            {
                need++;
                info += "头脑不符合要求。需要" + Convert.ToInt32(kfalnew[19]) + "。\n";

            }
            if (Convert.ToInt32(kfalnew[20]) > Convert.ToInt32(player[6]))
            {
                need++;
                info += "精神不符合要求。需要" + Convert.ToInt32(kfalnew[20]) + "。\n";

            }



            if (Convert.ToInt32(kfalnew[5]) * 100 * (Convert.ToInt32(player[newkfnub + 200])+1) > Convert.ToInt32(player[8]))
            {
                need++;
                info += "你的经验不符合要求。需要" + (Convert.ToInt32(kfalnew[5]) * 100 * (Convert.ToInt32(player[newkfnub + 200])+1)) + "点经验。\n";
            }
            if (need == 0)
            {
                //player[16] = Convert.ToInt32(player[16]) - Convert.ToInt32(kfalnew[5]) * 100;//学习金钱

                player[8] = Convert.ToInt32(player[8]) - Convert.ToInt32(kfalnew[5]) * 100 * (Convert.ToInt32(player[newkfnub + 200])+1);//学习经验
                player[10] = Convert.ToInt32(Convert.ToDouble(player[8]) / Convert.ToDouble(player[9]) * 100);
                player[newkfnub] = kfalnew[0];
                player[newkfnub + 200] = Convert.ToInt32(player[newkfnub + 200])+1;

                
                player[2] = Convert.ToInt32(player[2]) + Convert.ToInt32(kfalnew[7]);
               
                player[3] = Convert.ToInt32(player[3]) + Convert.ToInt32(kfalnew[8]);
                
                player[4] = Convert.ToInt32(player[4]) + Convert.ToInt32(kfalnew[9]);
                
                player[5] = Convert.ToInt32(player[5]) + Convert.ToInt32(kfalnew[10]);
                
                player[6] = Convert.ToInt32(player[6]) + Convert.ToInt32(kfalnew[11]);
                
                player[100] = Convert.ToInt32(player[100]) + Convert.ToInt32(kfalnew[7]);
                player[101] = Convert.ToInt32(player[101]) + Convert.ToInt32(kfalnew[7]);
                player[102] = Convert.ToInt32(player[102]) + Convert.ToInt32(kfalnew[8]);
                player[103] = Convert.ToDouble(player[103]) + Convert.ToDouble(kfalnew[9]) * 0.002;
                player[104] = Convert.ToDouble(player[104]) + Convert.ToDouble(kfalnew[10]) * 0.004;
                player[105] = Convert.ToDouble(player[105]) + Convert.ToDouble(kfalnew[11]) * 0.001;
                if (Convert.ToString(player[18]) ==Convert.ToString(kfalnew[0]))
                {
                    int i = Convert.ToInt32(player[19]);
                    i++;
                    player[19] = i;
                }
                info += "学习成功。\n";
               
            }
            player[11] = info;
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
        
            
    }
}
