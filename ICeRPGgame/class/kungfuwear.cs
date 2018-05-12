using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ICeRPGgame
{
    class kungfuwear
    {
        
        public void kfwear(ArrayList player, ArrayList kf)
        {


            int need = 0;
            int newkfnub = 0;
            string info = "";
            for (int i = 200; i < 400; i++)
            {
                if (Convert.ToString(kf[0]) == Convert.ToString(player[i]))
                {
                    newkfnub = i;
                    break;
                }
            }

            
            if (need == 0)
            {

                double lv = Convert.ToInt32(player[7]);
                player[50] = kf[0];
                int kflv = Convert.ToInt32(player[newkfnub+200]);


                player[2] = Convert.ToInt32(player[2]) + kflv * Convert.ToInt32(kf[51]);//力道
                player[3] = Convert.ToInt32(player[3]) + kflv * Convert.ToInt32(kf[52]);
                player[4] = Convert.ToInt32(player[4]) + kflv * Convert.ToInt32(kf[53]);
                player[5] = Convert.ToInt32(player[5]) + kflv * Convert.ToInt32(kf[54]);
                player[6] = Convert.ToInt32(player[6]) + kflv * Convert.ToInt32(kf[55]);
                player[100] = Convert.ToInt32(player[100]) + kflv * Convert.ToInt32(kf[56]);//攻击力
                player[101] = Convert.ToInt32(player[101]) + kflv * Convert.ToInt32(kf[57]);//攻击力
                player[102] = Convert.ToInt32(player[102]) + kflv * Convert.ToInt32(kf[58]);
                player[13] = Convert.ToInt32(player[13])+ kflv * Convert.ToInt32(kf[59]);//血
                player[15] = Convert.ToInt32(player[15]) + kflv * Convert.ToInt32(kf[60]);//气
                
                player[103] = Convert.ToDouble(player[103]) + kflv * Convert.ToDouble(kf[53]) * 0.002;
                player[104] = Convert.ToDouble(player[104]) + kflv * Convert.ToDouble(kf[54]) * 0.004;
                player[105] = Convert.ToDouble(player[105]) + kflv * Convert.ToDouble(kf[55]) * 0.001;
                if (Convert.ToInt32(player[12]) > Convert.ToInt32(player[13]))
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
        public void kfoff(ArrayList player, ArrayList kf)
        {


            int need = 0;
            int newkfnub = 0;
            string info = "";
            for (int i = 200; i < 400; i++)
            {
                if (Convert.ToString(kf[0]) == Convert.ToString(player[i]))
                {
                    newkfnub = i;
                    break;
                }
            }


            if (need == 0&&Convert.ToString(player[50])!="0")
            {

                double lv = Convert.ToInt32(player[7]);
                player[50] = "0";
                int kflv = Convert.ToInt32(player[newkfnub + 200]);


                player[2] = Convert.ToInt32(player[2]) - kflv * Convert.ToInt32(kf[51]);//力道
                player[3] = Convert.ToInt32(player[3]) - kflv * Convert.ToInt32(kf[52]);
                player[4] = Convert.ToInt32(player[4]) - kflv * Convert.ToInt32(kf[53]);
                player[5] = Convert.ToInt32(player[5]) - kflv * Convert.ToInt32(kf[54]);
                player[6] = Convert.ToInt32(player[6]) - kflv * Convert.ToInt32(kf[55]);
                player[100] = Convert.ToInt32(player[100]) - kflv * Convert.ToInt32(kf[56]);//武器攻击力
                player[101] = Convert.ToInt32(player[101]) - kflv * Convert.ToInt32(kf[57]);//武器攻击力
                player[102] = Convert.ToInt32(player[102]) - kflv * Convert.ToInt32(kf[58]);
                player[13] = Convert.ToInt32(player[13]) - kflv * Convert.ToInt32(kf[59]);//血
                player[15] = Convert.ToInt32(player[15]) - kflv * Convert.ToInt32(kf[60]);//气
                
                player[103] = Convert.ToDouble(player[103]) -kflv * Convert.ToDouble(kf[53]) * 0.002;
                player[104] = Convert.ToDouble(player[104]) -kflv * Convert.ToDouble(kf[54]) * 0.004;
                player[105] = Convert.ToDouble(player[105]) -kflv * Convert.ToDouble(kf[55]) * 0.001;
                if (Convert.ToInt32(player[12]) > Convert.ToInt32(player[13]))
                {
                    player[12] = player[13];
                }
                if (Convert.ToInt32(player[14]) > Convert.ToInt32(player[15]))
                {
                    player[15] = player[15];
                }

                info += "解除成功。\n";

            }
            player[11] = info;
        }
    }
}
