using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace MouseClick
{
    public partial class FormMain : Form
    {
        OperaThread m_operaThread = null;
        Thread m_threadOpera = null;
        private int m_num = 0;
        private int m_interval = 0;
        //private volatile bool m_isesc = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化
            textBoxX.Text = 1130.ToString();
            textBoxY.Text = 600.ToString();
            textBoxInterval.Text = (30 * 60 + 100).ToString();   // 15分钟加上20秒
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                timerGetCurpos.Enabled = false;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int x, y;
            try
            {

                x = Convert.ToInt32(textBoxX.Text);
                y = Convert.ToInt32(textBoxY.Text);
                m_interval = Convert.ToInt32(textBoxInterval.Text);

                int[] params1 = new int[] { x, y, m_interval };
                if (m_operaThread == null)
                {
                    m_operaThread = new OperaThread();
                    //ThreadStart thStart=new ThreadStart(m_operaThread.RunLoop);
                    //m_operaThread.is
                }
                if (m_threadOpera == null)
                {
                    m_threadOpera = new Thread(m_operaThread.RunLoop);
                }
                m_threadOpera.Name = "鼠标操作线程";
                m_threadOpera.IsBackground = true;
                m_threadOpera.Start(params1);

                timerUpdateUi.Interval = 2000;
                timerUpdateUi.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        // 获取坐标点
        private void buttonCapPos_Click(object sender, EventArgs e)
        {
            timerGetCurpos.Interval = 1000;
            timerGetCurpos.Enabled = true;
        }

        private void timerGetCurpos_Tick(object sender, EventArgs e)
        {
            textBoxX.Text = Cursor.Position.X.ToString();
            textBoxY.Text = Cursor.Position.Y.ToString();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerUpdateUi.Enabled = false;

            if (m_operaThread != null)
            {
                m_operaThread.StopThread();
            }
            m_threadOpera = null;
            m_num = 0;

            toolStripStatusLabelMain.Text = "就绪";
        }

        private void timerUpdateUi_Tick(object sender, EventArgs e)
        {
            if (m_threadOpera != null && m_threadOpera.IsAlive)
            {
                if (m_num != m_operaThread.m_num)
                {
                    toolStripStatusLabelNum.Text = m_operaThread.m_num + " -";
                    m_num = m_operaThread.m_num;
                }
                else if (m_operaThread.m_timenum > 0)
                {
                    toolStripStatusLabelMain.Text = "距离下一次点击还有" + (m_interval - m_operaThread.m_timenum) + "秒";
                }
            }
        }

    }

    class OperaThread
    {
        private volatile bool m_isRun = false;
        public volatile int m_num = 0;
        public volatile int m_timenum = 0;

        public enum MouseEventFlags
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            Wheel = 0x0800,
            Absolute = 0x8000
        }
        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);
        /// <summary>
        /// 引用user32.dll动态链接库（windows api），
        /// 使用库中定义 API：SetCursorPos
        /// </summary>
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);
        /// <summary>
        /// 移动鼠标到指定的坐标点
        /// </summary>
        public void MoveMouseToPoint(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }
        /// <summary>
        /// 设置鼠标的移动范围
        /// </summary>
        public void SetMouseRectangle(Rectangle rectangle)
        {
            System.Windows.Forms.Cursor.Clip = rectangle;
        }
        /// <summary>
        /// 设置鼠标位于屏幕中心
        /// </summary>
        public void SetMouseAtCenterScreen()
        {
            int winHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int winWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            Point centerP = new Point(0, 0);
            MoveMouseToPoint(centerP);
        }


        public void RunLoop(object param1)
        {
            int x, y, interval;
            int[] tempInts;
            Point curPos = new Point();
            //int m_timenum = 0;

            if (!(param1 is int[]))
            {
                Console.WriteLine("参数类型错误");
                return;
            }
            tempInts = param1 as int[];
            if (tempInts.Length != 3)
            {
                Console.WriteLine("参数数量错误");
                return;
            }
            x = tempInts[0];
            y = tempInts[1];
            interval = tempInts[2];
            m_isRun = true;
            m_num = 0;
            m_timenum = 0;
            curPos.X = x;
            curPos.Y = y;

            do
            {
                ++m_num;
                Console.WriteLine("第" + m_num + "次鼠标点击");
                MoveMouseToPoint(curPos);
                Thread.Sleep(500);
                mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                //Thread.Sleep(500);
                mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
#if false
                Thread.Sleep(2000);
                mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                //Thread.Sleep(500);
                mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
#endif
                // 等待一段时间
                while (m_timenum < interval)
                {
                    if (!m_isRun)
                    {
                        break;
                    }
                    // 一次两秒
                    m_timenum += 2;
                    Thread.Sleep(2000);
                }
                m_timenum = 0;
                //Thread.Sleep(interval * 1000);
            } while (m_isRun);

            //m_threadOpera = null;
            Console.WriteLine("鼠标定位点击线程结束");
        }

        public void StopThread()
        {
            m_isRun = false;
        }
    }


}
