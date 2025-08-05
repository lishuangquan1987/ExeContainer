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
        /// <summary>
        /// 嵌入操作超时，默认20s
        /// </summary>
        public int EmbedOperationTimeoutSeconds { get; set; } = 20;
        public Process AppProcess = null;
        private IntPtr _handle = IntPtr.Zero;
        private int w, h;
        private bool EmbedProcess(Process app, IntPtr handle, int w, int h)
        {
            // Get the main handle
            if (app == null || app.MainWindowHandle == IntPtr.Zero) return false;

            int embedResult = 0;

            try
            {
                // Remove border and whatnot 
                long style = Win32Api.GetWindowLong(app.MainWindowHandle, Win32Api.GWL_STYLE);
                style &= ~Win32Api.WS_CAPTION;
                style &= ~Win32Api.WS_THICKFRAME;
                style &= ~Win32Api.WS_POPUP;
                style |= Win32Api.WS_CHILD;
                              
                Win32Api.SetWindowLong(app.MainWindowHandle, Win32Api.GWL_STYLE, style);
            }
            catch (Exception)
            { }
            try
            {
                // Put it into this container
                embedResult = Win32Api.SetParent(app.MainWindowHandle,handle);
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
                if (AppProcess != null && !AppProcess.HasExited)
                {
                    AppProcess.Kill();
                }

                this._handle = handle;
                this.w = w;
                this.h = h;

                ProcessStartInfo info = new ProcessStartInfo(fileName)
                {
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Minimized
                };
                AppProcess = System.Diagnostics.Process.Start(info);

                AppProcess.Refresh();

                // Wait for process to be created and enter idle condition
                AppProcess.WaitForInputIdle();

                if (!await WaitForMainWindowHandle(AppProcess, TimeSpan.FromSeconds(EmbedOperationTimeoutSeconds)))
                {
                    return false;
                }

                return EmbedProcess(AppProcess, handle, w, h);
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
