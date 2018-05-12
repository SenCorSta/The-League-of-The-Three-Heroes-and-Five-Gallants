using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICeRPGgame
{
    class loaddat
    {
        public ArrayList loadweapon(string name)
        {
            ArrayList newwp = new ArrayList();
            
            //读取武器
            FileStream fs = new FileStream(".\\data\\weapon\\" + name + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            newwp = bf.Deserialize(fs) as ArrayList;
            fs.Close();
            return newwp;
        }
        public ArrayList loadkungfu(string name)
        {
            ArrayList newkf = new ArrayList();

            //读取功夫
            FileStream fs = new FileStream(".\\data\\kungfu\\" + name + ".dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//反序列化
            newkf = bf.Deserialize(fs) as ArrayList;
            fs.Close();
            return newkf;
        }
    }
}
