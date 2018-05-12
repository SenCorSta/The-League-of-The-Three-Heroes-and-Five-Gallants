using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICeRPGgame
{
    class unitconvert
    {
        public String moneytochina(int money)
        {
            string china="";
            string chinamid;
            chinamid=Convert.ToString(money);
            int i=chinamid.Length;
            
            
            if (i<4)
            {
                china=chinamid+"文";
            }
            else if(i==4)
            {
                china = chinamid.Substring(0, 1) + "银";
                if (chinamid.Substring(i - 3, 3) == "000")
                {
                    //无
                }
                else if (chinamid.Substring(i - 3, 2) == "00")
                {
                    china += chinamid.Substring(i - 1, 1) + "文";
                }
                else if (chinamid.Substring(i - 3, 1) == "0")
                {
                    china += chinamid.Substring(i - 2, 2) + "文";
                }
                else
                {
                    china += chinamid.Substring(i - 3, 3) + "文";
                }
                

                
                
            }
            else if (i==5)
            {
                china = chinamid.Substring(0, 1) + "金";
                if (chinamid.Substring(i - 4, 1) != "0")
                {
                    china += chinamid.Substring(i - 4, 1) + "银";
                }
                if (chinamid.Substring(i - 3, 3) == "000")
                {
                    //无
                }
                else if (chinamid.Substring(i - 3, 2) == "00")
                {
                    china += chinamid.Substring(i - 1, 1) + "文";
                }
                else if (chinamid.Substring(i - 3, 1) == "0")
                {
                    china += chinamid.Substring(i - 2, 2) + "文";
                }
                else
                {
                    china += chinamid.Substring(i - 3, 3) + "文";
                }
                    
            }
            else
            {
                china = chinamid.Substring(0, i - 5) + "锭";
                if (chinamid.Substring(i - 5, 1) != "0")
                {
                    china += chinamid.Substring(i - 5, 1) + "金";
                }
                if (chinamid.Substring(i - 4, 1) != "0")
                {
                    china += chinamid.Substring(i - 4, 1) + "银";
                }
                if (chinamid.Substring(i - 3, 3) == "000")
                {
                    //无
                }
                else if (chinamid.Substring(i - 3, 2) == "00")
                {
                    china += chinamid.Substring(i - 1, 1) + "文";
                }
                else if (chinamid.Substring(i - 3, 1) == "0")
                {
                    china += chinamid.Substring(i - 2, 2) + "文";
                }
                else
                {
                    china += chinamid.Substring(i - 3, 3) + "文";
                }
            }
            if (chinamid=="0")
            {
                china = "0文";
            }
            return china;
        }
    }
}
