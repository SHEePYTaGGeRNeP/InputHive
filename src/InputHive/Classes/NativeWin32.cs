using System;
using System.Runtime.InteropServices;
using System.Text;

namespace InputHive.Classes
{
    class NativeWin32
    {
        public struct ProcessWindow
        {
            public IntPtr HWnd;
            public string Title;
            public ProcessWindow(IntPtr pHwnd, string pTitle)
            {
                this.HWnd = pHwnd;
                this.Title = pTitle;
            }
        }

        public const int WM_SETTEXT = 0x000c;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr pHwndParent, IntPtr pHwndChildAfter, string pLpszClass, string pLpszWindow);

        [DllImport("user32.dll")]
        public static extern int FindWindow(
            string pLpClassName, // class name 
            string pLpWindowName // window name 
        );


        [DllImport("user32.dll")]
        public static extern int SendMessage(
            int pHWnd, // handle to destination window 
            uint pMsg, // message 
            int pWParam, // first message parameter 
            int pLParam // second message parameter 
        );

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(
            int pHWnd // handle to window
            );

        private const int _GWL_EXSTYLE = (-20);
        private const int _WS_EX_TOOLWINDOW = 0x80;
        private const int _WS_EX_APPWINDOW = 0x40000;

        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GW_OWNER = 4;
        public const int GW_CHILD = 5;

        public static void SetTitle(IntPtr pHwnd, string pText)
        {
            const int WM_SETTEXT = 0x000C;
            SendMessage(pHwnd, WM_SETTEXT, (IntPtr)pText.Length, pText);
        }
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr pHWnd, int pUMsg, int pWParam, string pLParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr pHwnd, int pMsg, IntPtr pWParam, [MarshalAs(UnmanagedType.LPStr)] string pLParam);

        public delegate int EnumWindowsProcDelegate(int pHWnd, int pLParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr pHWnd, StringBuilder pText, int pCount);

        public static ProcessWindow GetActiveProcessWindow()
        {
            const int lvN_CHARS = 256;
            StringBuilder lvBuff = new StringBuilder(lvN_CHARS);
            IntPtr lvHandle = GetForegroundWindow();

            if (GetWindowText(lvHandle, lvBuff, lvN_CHARS) > 0)
            {
                return new ProcessWindow(lvHandle, lvBuff.ToString());
            }
            return new ProcessWindow();
        }


        [DllImport("user32")]
        public static extern int EnumWindows(EnumWindowsProcDelegate pLpEnumFunc, int pLParam);

        [DllImport("User32.Dll")]
        public static extern void GetWindowText(int pH, StringBuilder pS, int pNMaxCount);

        [DllImport("user32", EntryPoint = "GetWindowLongA")]
        public static extern int GetWindowLongPtr(int pHwnd, int pNIndex);

        [DllImport("user32")]
        public static extern int GetParent(int pHwnd);

        [DllImport("user32")]
        public static extern int GetWindow(int pHwnd, int pWCmd);

        [DllImport("user32")]
        public static extern int IsWindowVisible(int pHwnd);

        [DllImport("user32")]
        public static extern int GetDesktopWindow();

    }
}
