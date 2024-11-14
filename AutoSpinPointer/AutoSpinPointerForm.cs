// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using System.Runtime.InteropServices;

namespace AutoSpinPointer
{
    public partial class AutoSpinPointerForm : Form
    {
        public AutoSpinPointerForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        private static Thread cursorThread;
        private static bool isRunning = false;

        private void pointSpinBtnClick(object sender, EventArgs e)
        {
            if (isRunning)
                return; // 防止重複啟動

            isRunning = true;
            int centerX = Cursor.Position.X;
            int centerY = Cursor.Position.Y;
            int radius = 100; // 旋轉半徑
            int angle = 0; // 起始角度

            cursorThread = new Thread(() =>
            {
                while (isRunning)
                {
                    // 計算新位置
                    int x = centerX + (int)(radius * Math.Cos(angle * Math.PI / 180));
                    int y = centerY + (int)(radius * Math.Sin(angle * Math.PI / 180));

                    // 設置滑鼠位置
                    SetCursorPos(x, y);

                    // 更新角度
                    angle = (angle + 5) % 360;

                    // 延遲以達到旋轉效果
                    Thread.Sleep(50);
                }
            });

            cursorThread.Start();
        }
        private void pointSpinStopBtnClick(object sender, EventArgs e)
        {
            if (!isRunning)
                return; // 如果未運行，則不操作

            isRunning = false;
            cursorThread.Join(); // 等待執行緒結束
        }

        private void AutoSpinPointerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRunning)
                return; // 如果未運行，則不操作

            isRunning = false;
            if (cursorThread != null && cursorThread.IsAlive)
            {
                cursorThread.Join(); // 等待執行緒結束
            }
        }
    }
}
