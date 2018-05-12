using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICeRPGgame
{
    class weaponID
    {
        public string weaponIDtostr(string id)
        {
            string name = "";

            switch (id)
            {
                case "0":
                    name = "无";
                    break;
                case "d":
                    name = "刀";
                    break;
                case "d2":
                    name = "双刀";
                    break;
                case "j":
                    name = "剑";
                    break;
                case "j2":
                    name = "双剑";
                    break;
                case "g":
                    name = "棍";
                    break;
                case "b":
                    name = "棒";
                    break;
                case "q":
                    name = "枪";
                    break;
                case "bz":
                    name = "鞭子";
                    break;
                case "f":
                    name = "斧";
                    break;
                case "f2":
                    name = "双斧";
                    break;
                case "z":
                    name = "其他";
                    break;
                case "gj":
                    name = "弓箭";
                    break;
                case "fb":
                    name = "飞镖";
                    break;
                case "qt":
                    name = "其他";
                    break;
                default:
                    name = "其他";
                    break;
            }

            return name;
        }
    }
}
