using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeContainer
{
    public class ContainerHelper
    {
        public Process AppProcess;
        private IntPtr _handle;
        private int w, h;
        private void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= Application_Idle;

            if (this.AppProcess == null) return;
            if (this.AppProcess.HasExited)
            {
                this.AppProcess = null;
                return;
            }
            for (int i = 0; i < 100; i++)
            {
                if (AppProcess.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(1);
                    continue;
                }
            }
            if (AppProcess.MainWindowHandle == IntPtr.Zero)
            {
                return;
            }

            if (this._handle == null || this._handle == IntPtr.Zero) return;

            var result = EmbedProcess(AppProcess, this._handle, w, h);
            Console.WriteLine($"嵌入返回值：{result}");
        }
        private bool EmbedProcess(Process app, IntPtr handle, int w, int h)
        {
            // Get the main handle
            if (app == null || app.MainWindowHandle == IntPtr.Zero) return false;

            int embedResult = 0;

            try
            {
                // Put it into this container
                embedResult = Win32Api.SetParent(app.MainWindowHandle, handle);
            }
            catch (Exception)
            { }
            try
            {
                // Remove border and whatnot               
                Win32Api.SetWindowLong(new HandleRef(this._handle, app.MainWindowHandle), Win32Api.GWL_STYLE, Win32Api.WS_VISIBLE);
            }
            catch (Exception)
            { }
            try
            {
                // Move the window to overlay it on this window
                Win32Api.MoveWindow(app.MainWindowHandle, 0, 0, w, h, true);
            }
            catch (Exception)
            { }

            return (embedResult != 0);
        }

        public async Task<bool> StartEmbedProcess(string fileName, IntPtr handle, int w, int h)
        {
            try
            {
                this._handle = handle;
                this.w = w;
                this.h = h;

                ProcessStartInfo info = new ProcessStartInfo(fileName)
                {
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Minimized
                };
                //info.WindowStyle = ProcessWindowStyle.Hidden;
                AppProcess = System.Diagnostics.Process.Start(info);

                AppProcess.Refresh();

                // Wait for process to be created and enter idle condition
                AppProcess.WaitForInputIdle();
                //todo:下面这两句会引发 NullReferenceException 异常，不知道怎么回事                
                //AppProcess.Exited += new EventHandler(AppProcess_Exited);
                //AppProcess.EnableRaisingEvents = true;
                if (!await WaitForMainWindowHandle(AppProcess, TimeSpan.FromSeconds(20)))
                {
                    return false;
                }

                EmbedProcess(AppProcess, handle, w, h);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{1}{0}{2}{0}{3}"
                    , Environment.NewLine
                    , "*" + ex.ToString()
                    , "*StackTrace:" + ex.StackTrace
                    , "*Source:" + ex.Source
                    ), "Failed to load app.");
                if (AppProcess != null)
                {
                    if (!AppProcess.HasExited)
                        AppProcess.Kill();
                    AppProcess = null;
                }
                return false;
            }
        }

        private async Task<bool> WaitForMainWindowHandle(Process process, TimeSpan timeout)
        {
            if (process == null) return false;

            var startTime = DateTime.Now;

            while (DateTime.Now - startTime < timeout)
            {
                try
                {
                    // 刷新进程信息
                    process.Refresh();

                    // 检查主窗口句柄是否有效
                    if (process.MainWindowHandle != IntPtr.Zero)
                    {
                        // 检查窗口是否可见
                        if (Win32Api.IsWindowVisible(process.MainWindowHandle))
                        {
                            return true; // 窗口已准备好
                        }
                    }

                    await Task.Delay(100);
                }
                catch
                {
                    await Task.Delay(100);
                }
            }
            return false;
        }

        public void SetSize(int x, int y, int w, int h)
        {
            if (AppProcess == null) return;

            if (AppProcess.HasExited) return;

            Win32Api.MoveWindow(AppProcess.MainWindowHandle, x, y, w, h, true);
        }
    }
}
