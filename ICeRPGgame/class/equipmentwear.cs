using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICeRPGgame
{
    class equipmentwear
    {
        weaponID wi = new weaponID();
        public void equiwear(ArrayList player, ArrayList equi, int location)
        {
            
            
            int need = 0;
            string info = "";
            bool oldkfok = false;
            
                //判断是否满足要求
            for (int i = 200; i < 400; i++)
            {
                if (Convert.ToString(equi[14]) == Convert.ToString(player[i]) && Convert.ToString(equi[14]) != "0")
                {
                    oldkfok = true;
                    if (Convert.ToInt32(equi[15]) > Convert.ToInt32(player[i + 200]))
                    {
                        need++;
                        info += "前提武功等级不符合要求。需要" + kungfuIDtostr(Convert.ToString(equi[14])) + Convert.ToInt32(equi[15]) + "级" + "。\n";

                    }
                    break;


                }


            }
            if (oldkfok == false && Convert.ToString(equi[14]) != "0")
            {
                need++;

                info += "前提武功不符合要求。需要" + kungfuIDtostr(Convert.ToString(equi[14])) + Convert.ToInt32(equi[15]) + "级" + "。\n";


            }
            if (Convert.ToInt32(equi[13]) > Convert.ToInt32(player[7]))
            {
                need++;
                info += "等级不符合要求。需要" + Convert.ToInt32(equi[13]) + "。\n";

            }
           
            


            if (Convert.ToInt32(equi[16]) > Convert.ToInt32(player[2]))
            {
                need++;
                info += "力道不符合要求。需要" + Convert.ToInt32(equi[16]) + "。\n";

            }
            if (Convert.ToInt32(equi[17]) > Convert.ToInt32(player[3]))
            {
                need++;
                info += "根骨不符合要求。需要" + Convert.ToInt32(equi[17]) + "。\n";

            }
            if (Convert.ToInt32(equi[18]) > Convert.ToInt32(player[4]))
            {
                need++;
                info += "灵敏不符合要求。需要" + Convert.ToInt32(equi[18]) + "。\n";

            }
            if (Convert.ToInt32(equi[19]) > Convert.ToInt32(player[5]))
            {
                need++;
                info += "头脑不符合要求。需要" + Convert.ToInt32(equi[19]) + "。\n";

            }
            if (Convert.ToInt32(equi[20]) > Convert.ToInt32(player[6]))
            {
                need++;
                info += "精神不符合要求。需要" + Convert.ToInt32(equi[20]) + "。\n";

            }
            if (need == 0)
            {

                double lv = Convert.ToInt32(player[7]);
                player[location] = equi[0];
                player[17] = equi[12];


                player[2] = Convert.ToInt32(player[2]) + Convert.ToInt32(equi[7]);//力道
                player[3] = Convert.ToInt32(player[3]) + Convert.ToInt32(equi[8]);
                player[4] = Convert.ToInt32(player[4]) + Convert.ToInt32(equi[9]);
                player[5] = Convert.ToInt32(player[5]) + Convert.ToInt32(equi[10]);
                player[6] = Convert.ToInt32(player[6]) + Convert.ToInt32(equi[11]);
                player[100] = Convert.ToInt32(player[100]) + Convert.ToInt32(equi[3]);//武器攻击力
                player[101] = Convert.ToInt32(player[101]) + Convert.ToInt32(equi[4]);//武器攻击力
                player[106] = Convert.ToDouble(player[106]) + Convert.ToDouble(equi[30]);
                
                player[103] = Convert.ToDouble(player[103]) + Convert.ToDouble(equi[9]) * 0.002;
                player[104] = Convert.ToDouble(player[104]) + Convert.ToDouble(equi[10]) * 0.004;
                player[105] = Convert.ToDouble(player[105]) + Convert.ToDouble(equi[11]) * 0.001;
                player[108] = Convert.ToDouble(player[108]) + Convert.ToDouble(equi[31]);//攻击
                if (Convert.ToInt32(player[12])>Convert.ToInt32(player[13]))
                {
                    player[12] = player[13];
                }
                if (Convert.ToInt32(player[14]) > Convert.ToInt32(player[15]))
                {
                    player[15] = player[15];
                }
                
                info += "装备成功。\n";

            }
            player[11] = info;
        }
        public void equioff(ArrayList player, ArrayList equi, int location)
        {
            int need = 0;
            string info = "";
            
            if (need == 0 && Convert.ToString(player[location])!="0")
            {

                double lv = Convert.ToInt32(player[7]);
                player[location] = "0";
                player[17] = "0";


                player[2] = Convert.ToInt32(player[2]) - Convert.ToInt32(equi[7]);
                player[3] = Convert.ToInt32(player[3]) - Convert.ToInt32(equi[8]);
                player[4] = Convert.ToInt32(player[4]) - Convert.ToInt32(equi[9]);
                player[5] = Convert.ToInt32(player[5]) - Convert.ToInt32(equi[10]);
                player[6] = Convert.ToInt32(player[6]) - Convert.ToInt32(equi[11]);
                player[100] = Convert.ToInt32(player[100]) - Convert.ToInt32(equi[3]);
                player[101] = Convert.ToInt32(player[101]) - Convert.ToInt32(equi[4]);
                player[106] = Convert.ToDouble(player[106]) - Convert.ToDouble(equi[30]);
                
                player[103] = Convert.ToDouble(player[103]) - Convert.ToDouble(equi[9]) * 0.002;
                player[104] = Convert.ToDouble(player[104]) - Convert.ToDouble(equi[10]) * 0.004;
                player[105] = Convert.ToDouble(player[105]) - Convert.ToDouble(equi[11]) * 0.001;
                player[108] = Convert.ToDouble(player[108]) - Convert.ToDouble(equi[31]);
                if (Convert.ToInt32(player[12]) > Convert.ToInt32(player[13]))
                {
                    player[12] = player[13];
                }
                if (Convert.ToInt32(player[14]) > Convert.ToInt32(player[15]))
                {
                    player[14] = player[15];
                }
                info += "成功。\n";

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
