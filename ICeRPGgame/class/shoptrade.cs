using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ICeRPGgame
{
    class shoptrade
    {
        public void buysomething(ArrayList player, ArrayList weapon,int number)
        {
            
            int need = 0;
            bool newweapon = true;
            int newkfnub = 0;
            for (int i = 600; i < 700; i++)
            {
                //判断是否购买新物品
                if (Convert.ToString(player[i]) == Convert.ToString(weapon[0]))
                {
                    newweapon = false;
                }
            }
            if (newweapon)
            {
                //如果新判断是否满足要求
            }
            if (newweapon)//为新找到一个位置
            {
                for (int i = 600; i < 700; i++)
                {
                    if (Convert.ToString(player[i]) == "0")
                    {
                        newkfnub = i;
                        break;
                    }
                }

            }
            else//找到存在的位置
            {
                for (int i = 600; i < 700; i++)
                {
                    if (Convert.ToString(weapon[0]) == Convert.ToString(player[i]))
                    {
                        newkfnub = i;
                        break;
                    }
                }
            }
            if (Convert.ToInt32(player[16]) < Convert.ToInt32(weapon[5]))
            {
                need++;
                //钱不符合要求
            }
            if (need==0)
            {
                player[16] = Convert.ToInt32(player[16])-number * Convert.ToInt32(weapon[5]);
                player[newkfnub] = weapon[0];
                player[newkfnub + 100] = Convert.ToInt32(player[newkfnub + 100]) + number;
                
            }
      
        }
        public void getsomething(ArrayList player, ArrayList weapon, int number)
        {

            int need = 0;
            bool newweapon = true;
            int newkfnub = 0;
            for (int i = 600; i < 700; i++)
            {
                //判断是否得到新物品
                if (Convert.ToString(player[i]) == Convert.ToString(weapon[0]))
                {
                    newweapon = false;
                }
            }
            if (newweapon)
            {
                //如果新判断是否满足要求
            }
            if (newweapon)//为新找到一个位置
            {
                for (int i = 600; i < 700; i++)
                {
                    if (Convert.ToString(player[i]) == "0")
                    {
                        newkfnub = i;
                        break;
                    }
                }

            }
            else//找到存在的位置
            {
                for (int i = 600; i < 700; i++)
                {
                    if (Convert.ToString(weapon[0]) == Convert.ToString(player[i]))
                    {
                        newkfnub = i;
                        break;
                    }
                }
            }
            
            if (need == 0)
            {
                
                player[newkfnub] = weapon[0];
                if (Convert.ToString(weapon[0])=="0")
                {
                    player[newkfnub + 100] = "0";
                }
                else
                {
                    player[newkfnub + 100] = Convert.ToInt32(player[newkfnub + 100]) + number;
                }
                

            }

        }
        public void sellsomething(ArrayList player, ArrayList weapon, int number)
        {

            int need = 0;
            bool newweapon = false;
            bool lastone = false;
            int newkfnub = 0;
            
            if (newweapon)
            {
                //如果新判断是否满足要求
            }
            if (newweapon)//为新找到一个位置
            {
                

            }
            else//找到存在的位置
            {
                for (int i = 600; i < 700; i++)
                {
                    if (Convert.ToString(weapon[0]) == Convert.ToString(player[i]))
                    {
                        newkfnub = i;
                        break;
                    }
                }
            }
            if (Convert.ToInt32(player[newkfnub+100]) < number)
            {
                need++;
                //数量不符合要求
            }
            if (Convert.ToInt32(player[newkfnub+100])-number==0)
            {
               lastone=true;
            }
            if (need == 0)
            {
                player[16] = Convert.ToInt32(player[16]) + number * Convert.ToInt32(weapon[5]);
                
                player[newkfnub + 100] = Convert.ToInt32(player[newkfnub + 100]) - number;
                if (lastone)
                {
                    player[newkfnub] = "0";
                }
                else
                {
                    player[newkfnub] = weapon[0];
                }

            }
            

        }
        public void destroysomething(ArrayList player, ArrayList weapon, int number)
        {

            int need = 0;
            bool newweapon = false;
            bool lastone = false;
            int newkfnub = 0;

            if (newweapon)
            {
                //如果新判断是否满足要求
            }
            if (newweapon)//为新找到一个位置
            {


            }
            else//找到存在的位置
            {
                for (int i = 600; i < 700; i++)
                {
                    if (Convert.ToString(weapon[0]) == Convert.ToString(player[i]))
                    {
                        newkfnub = i;
                        break;
                    }
                }
            }
            if (Convert.ToInt32(player[newkfnub + 100]) < number)
            {
                need++;
                //数量不符合要求
            }
            if (Convert.ToInt32(player[newkfnub + 100]) - number == 0)
            {
                lastone = true;
            }
            if (need == 0)
            {
                

                player[newkfnub + 100] = Convert.ToInt32(player[newkfnub + 100]) - number;
                if (lastone)
                {
                    player[newkfnub] = "0";
                }
                else
                {
                    player[newkfnub] = weapon[0];
                }

            }


        }
    }
}
