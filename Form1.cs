using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using KAutoHelper;
using AutoItX3Lib;
using System.Windows.Forms;
using System.Threading;

namespace autoSeed
{
   
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData,
           UIntPtr dwExtraInfo);
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;
        
        public Form1()
        {
            InitializeComponent();
        }
        void dothing()
        {
            int x = 800;
            int y = 173;
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle("Qt5QWindowIcon", null);
            var child = AutoControl.FindHandle(hWnd, "Chrome_WidgetWin_0", null);
            MessageBox.Show(child.ToString());
            var pointoClick = AutoControl.GetGlobalPoint(hWnd, x, y);
            AutoControl.SendClickOnPosition(child, x, y);
            SendKeys.SendWait("hello");
            
            //AutoControl.BringToFront(hWnd);
            //AutoControl.MouseClick(pointoClick);
           
            AutoControl.SendClickOnControlByHandle(child);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScrollDown();
            
            
        }
        void ScrollDown()
        {
            Point startpoint = new Point(951, 12);
            Point endPoint = new Point(952, 202);

            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, "Garena - Game Center");
            var child = AutoControl.FindHandle(hWnd, "Chrome_RenderWidgetHostHWND", null);
            var spoint = AutoControl.GetGlobalPoint(child,startpoint);
            var endP = AutoControl.GetGlobalPoint(child, endPoint);
            int[] arrEndPoint = {202,315,341,358, 432,471,500,570,630};
            AutoControl.BringToFront(hWnd);  
            AutoItX3Lib.AutoItX3 autoItX = new AutoItX3();
            autoItX.MouseMove(spoint.X, spoint.Y);
            autoItX.MouseDown("LEFT");
            autoItX.MouseMove(endP.X, endP.Y);
            autoItX.MouseUp("LEFT");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            int x = 947;
            int y = 118;
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null,"Garena - Game Center");
            var child = AutoControl.FindHandle(hWnd, "Chrome_RenderWidgetHostHWND", null);
            var point = AutoControl.GetGlobalPoint(child,x , y);
            AutoControl.BringToFront(hWnd);
            AutoControl.MouseClick(AutoControl.GetGlobalPoint(child, 10, 10));
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -720, (UIntPtr)0);
            AutoControl.Click();
            //AutoControl.SendKeyDown()
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle("Notepad", null);
            var child = AutoControl.FindHandle(hWnd, "edit", null);
            AutoControl.BringToFront(hWnd);
            AutoControl.MouseClick(400,400);
            Thread.Sleep(300);
            
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -720, (UIntPtr)0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AutoItX3 autoItX3 = new AutoItX3();
            Point LOLlocation = new Point(805, 175);
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, "Garena - Game Center");
            var child = AutoControl.FindHandle(hWnd, "Chrome_RenderWidgetHostHWND", null);
            var point = AutoControl.GetGlobalPoint(child,LOLlocation);
            int num = Convert.ToInt32(textBox1.Text);
            AutoControl.BringToFront(hWnd);
            AutoControl.MouseClick(point);
            Thread.Sleep(3000);
            autoItX3.MouseWheel("down", 2);
            Thread.Sleep(3000);
            //var postPoint = AutoControl.GetGlobalPoint(child, 147, 113);// 147 113
            //AutoControl.MouseClick(postPoint);
            //Thread.Sleep(2000);
            int[] arrEndPoint = { 202, 315, 341, 358, 432, 471, 500, 570, 630 }; // for y
            for (int i = 0; i < 2; i++)
            {
                Point startpoint = new Point(951, 12);
                Point endPoint = new Point(952, 202);
                var fpoint = AutoControl.GetGlobalPoint(child, 150,149);
                for (int j = 0; j < 3; j++)
                {                   
                    AutoControl.MouseClick(fpoint);
                    Thread.Sleep(3000);
                    var spoint = AutoControl.GetGlobalPoint(child, startpoint);
                    autoItX3.MouseMove(spoint.X, spoint.Y);
                    autoItX3.MouseDown("LEFT");
                    Bitmap screen;
                    for (int p = 0; p < arrEndPoint.Length; p++)
                    {
                        endPoint.Y = arrEndPoint[p];
                        var endP = AutoControl.GetGlobalPoint(child, endPoint);
                        autoItX3.MouseMove(endP.X, endP.Y);
                        screen = (Bitmap)CaptureHelper.CaptureScreen();
                        var subBit = ImageScanOpenCV.GetImage("commentSection.PNG");
                        var sendpost = ImageScanOpenCV.GetImage("SendComment.PNG");
                        var ComsecLocation = ImageScanOpenCV.FindOutPoint((Bitmap)screen, subBit);
                        if(ComsecLocation != null)
                        {
                            autoItX3.MouseUp("LEFT");
                            AutoControl.MouseClick((Point)ComsecLocation);
                            autoItX3.Send("Hello");
                            Thread.Sleep(1000);                            
                            screen = (Bitmap)CaptureHelper.CaptureScreen();
                            var sendLocation = ImageScanOpenCV.FindOutPoint((Bitmap)screen, sendpost);
                            Point sendlo = (Point)sendLocation;  // can not find  the right so find the near and add a few unit to right point
                            sendlo.X += 3;
                            sendlo.Y += 7;
                            AutoControl.MouseClick((Point)sendlo);
                            screen.Dispose();
                            break;
                        }
                    }
                    var exitpost = AutoControl.GetGlobalPoint(child, 62, 6);
                    exitpost.Y -= 37;
                    AutoControl.MouseClick(exitpost);
                    Thread.Sleep(2000);
                    fpoint.X += 325;
                }
                Thread.Sleep(1000);
                Point zone = AutoControl.GetGlobalPoint(child, 20, 20);
                autoItX3.MouseMove(zone.X,zone.Y);
                autoItX3.MouseWheel("down", 4);
                Thread.Sleep(3000);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var screen = CaptureHelper.CaptureScreen();
            screen.Save("mainScreen.png");
            var subBit = ImageScanOpenCV.GetImage("commentSection.PNG");
            var sendpost = ImageScanOpenCV.GetImage("SendComment.PNG");
            var ComsecLocation = ImageScanOpenCV.FindOutPoint((Bitmap)screen, subBit);
            AutoControl.MouseClick((Point)ComsecLocation);
            //autoItX3.Send("Hello");
            Thread.Sleep(1000);
            screen = CaptureHelper.CaptureScreen();
            var sendLocation = ImageScanOpenCV.FindOutPoint((Bitmap)screen, sendpost);
            Point sendlo = (Point)sendLocation;
            sendlo.X += 3;
            sendlo.Y += 7;
            AutoControl.MouseClick((Point)sendlo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AutoItX3 autoItX3 = new AutoItX3();
            Point LOLlocation = new Point(805, 175);
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, "Garena - Game Center");
            var child = AutoControl.FindHandle(hWnd, "Chrome_RenderWidgetHostHWND", null);
            var point = AutoControl.GetGlobalPoint(child, LOLlocation);
            int num = Convert.ToInt32(textBox1.Text);
            AutoControl.BringToFront(hWnd);
            AutoControl.MouseClick(point);
            Thread.Sleep(3000);
            var belowdiendan = new Point(425,4);
            var pointBelowdiendan = (Point)AutoControl.GetGlobalPoint(child, belowdiendan);
            pointBelowdiendan.Y -= 20;
            AutoControl.MouseClick(pointBelowdiendan);
            Thread.Sleep(3000);
            Point writebutton = new Point(774, 578);
            var WritePostButton = (Point)AutoControl.GetGlobalPoint(child, writebutton);
            //autoItX3.MouseMove(WritePostButton)
            AutoControl.MouseClick(WritePostButton);
            Thread.Sleep(2000);
            var title = (Point)AutoControl.GetGlobalPoint(child, 172, 221);
            AutoControl.MouseClick(title);
            autoItX3.Send("some trash title i can put in");
            Thread.Sleep(1000);
            var content = (Point)AutoControl.GetGlobalPoint(child, 170, 269);
            AutoControl.MouseClick(content);
            autoItX3.Send("test");
            Thread.Sleep(1000);
            var uploadImage = (Point)AutoControl.GetGlobalPoint(child, 178, 493);
            AutoControl.MouseClick(uploadImage);
            Thread.Sleep(2000);
            //Thread. Sleep and send key like someimage.png;
            autoItX3.Send("Normal.png");          
            Thread.Sleep(1000);
            AutoControl.SendKeyPress(KeyCode.ENTER);
            Thread.Sleep(2000);
            var link = (Point)AutoControl.GetGlobalPoint(child, 232, 535);
            AutoControl.MouseClick(link);
            var linkloc = (Point)AutoControl.GetGlobalPoint(child, 186, 560);
            AutoControl.MouseClick(linkloc);
            autoItX3.Send("https://www.youtube.com/watch?v=HKS6cp5OGMo&list=RDzhqvxdx8kIM&index=2");
            var Send = (Point)AutoControl.GetGlobalPoint(child, 772, 516);
            AutoControl.MouseClick(Send);
            // done
        }
    }
}
