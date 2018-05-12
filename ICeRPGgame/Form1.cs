using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICeRPGgame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.currentPlaylist=axWindowsMediaPlayer1.newPlaylist("aa","");
            axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(".\\data\\mp3\\001.mp3"));
            axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(".\\data\\mp3\\002.mp3"));
            
            //axWindowsMediaPlayer1.URL = ".\\data\\mp3\\002.mp3";
            
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Createplayer CP = new Createplayer();
            CP.ShowDialog();
            //this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ArrayList al = new ArrayList();
            FileStream fs = new FileStream(".\\save\\save1.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();//序列化
            al=bf.Deserialize(fs)as ArrayList;
            fs.Close();
            PalyerDataPanel PDP = new PalyerDataPanel(al);
            
            PDP.ShowDialog();
            //this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.next();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            modify modify = new modify();
            modify.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者:HitCat\nemail:icemaker@qq.com\nqq群:151534467\n对游戏有建议请加群讨论\n游戏版本:Alpha.0.0.9");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            kungfu kf = new kungfu();
            kf.ShowDialog();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            weapon wp=new weapon();
            wp.ShowDialog();
        }
    }
}
