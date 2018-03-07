using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screenprinter
{
    static class Util
    {
        public static String GenName()
        {
            return "screenprinter " + DateTime.Now.ToString("" +
                "yyyy年MM月dd日HH时mm分ss秒") + ".bmp";
        }
        public static void Save(Bitmap hbitmap)
        {
            if (!Directory.Exists(DevConfig.folder))
            {
                (new DirectoryInfo(DevConfig.folder)).Create();
            }
            hbitmap.Save(DevConfig.folder+GenName());
        }
        public static void PrintFullScreen()
        {
            Bitmap hbitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics pen = Graphics.FromImage(hbitmap);  
            pen.CopyFromScreen(new Point(0, 0), new Point(0, 0), hbitmap.Size);
            Util.Save(hbitmap);
            pen.Dispose();
            hbitmap.Dispose();
        }
    }
}
