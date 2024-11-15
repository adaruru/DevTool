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
        private bool isSpinning = false;
        private Thread spinThread;


        private void pointSpinBtnClick(object sender, EventArgs e)
        {
            starSpin();
        }

        private void AutoSpinPointerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (isSpinning)
                {
                    stopSpin();
                }
                else
                {
                    starSpin();
                }

                e.Handled = true; // 標記事件已處理 另 Space KeyDown 來模擬click效果
            }
        }
        private void stopSpin()
        {
            isSpinning = false;
            if (spinThread != null && spinThread.IsAlive)
            {
                spinThread.Join();
            }
        }
        private void starSpin()
        {

            if (isSpinning)
                return;

            isSpinning = true;
            spinThread = new Thread(() =>
            {
                const double radius = 10; // 半徑為3公分（約10像素）
                double angle = 0;

                while (isSpinning)
                {
                    double x = radius * Math.Cos(angle);
                    double y = radius * Math.Sin(angle);

                    Invoke(new Action(() =>
                    {
                        // 設定滑鼠位置
                        SetCursorPos(Cursor.Position.X + (int)x, Cursor.Position.Y + (int)y);
                    }));

                    angle += Math.PI / 30; // 每次增加角度，形成5秒轉一圈
                    if (angle >= 2 * Math.PI)
                        angle -= 2 * Math.PI;

                    Thread.Sleep(30);//30毫秒
                }
            });
            spinThread.IsBackground = true;
            spinThread.Start();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            stopSpin();
            base.OnFormClosing(e);
        }
    }
}
