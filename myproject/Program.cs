 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SadSmile
{
    public class Program
    {
        static void Main(string[] args)
        {
            //WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            //bool stop = false;
            //ThreadPool.QueueUserWorkItem
            //(_ =>
            //{
            //    player.URL = @"C:\Users\phyco\Documents\GitHub\04-oop-console-project-SadSmileXD\myproject\bin\Debug\music\s.mp3";

            //    //Url에 본인 컴퓨터에 저장된 노래 주소를 넣어주면 된다                
            //    // 무한 루프 시작
            //    //while (true)
            //    //{
            //    //}
            //}
            //);

            var App = new TextRPG();
            App.Run();
        }
    }
}


