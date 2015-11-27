using System;
using System.Runtime.InteropServices;
using System.Text;

namespace InputHive.Classes
{
    using System.Drawing;
    using System.Drawing.Imaging;

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
        public static extern bool GetWindowRect(IntPtr hWnd, out REKT pLpRekt);
        /// <summary>
        /// The PrintWindow win32 api will capture a window bitmap even if the window is covered by other windows or if it is off screen
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        public static Bitmap PrintWindow(IntPtr hwnd)
        {
            REKT rc;
            GetWindowRect(hwnd, out rc);

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hwnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }

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

    [StructLayout(LayoutKind.Sequential)]
    public struct REKT
    {
        private int _left;
        private int _top;
        private int _right;
        private int _bottom;

        public REKT(REKT Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
        {
        }
        public REKT(int Left, int Top, int Right, int Bottom)
        {
            this._left = Left;
            this._top = Top;
            this._right = Right;
            this._bottom = Bottom;
        }

        public int X
        {
            get { return this._left; }
            set
            {
                this._left = value;
            }
        }
        public int Y
        {
            get { return this._top; }
            set
            {
                this._top = value;
            }
        }
        public int Left
        {
            get { return this._left; }
            set
            {
                this._left = value;
            }
        }
        public int Top
        {
            get { return this._top; }
            set
            {
                this._top = value;
            }
        }
        public int Right
        {
            get { return this._right; }
            set
            {
                this._right = value;
            }
        }
        public int Bottom
        {
            get { return this._bottom; }
            set
            {
                this._bottom = value;
            }
        }
        public int Height
        {
            get { return this._bottom - this._top; }
            set
            {
                this._bottom = value + this._top;
            }
        }
        public int Width
        {
            get { return this._right - this._left; }
            set
            {
                this._right = value + this._left;
            }
        }
        public Point Location
        {
            get { return new Point(this.Left, this.Top); }
            set
            {
                this._left = value.X;
                this._top = value.Y;
            }
        }
        public Size Size
        {
            get { return new Size(this.Width, this.Height); }
            set
            {
                this._right = value.Width + this._left;
                this._bottom = value.Height + this._top;
            }
        }

        public static implicit operator Rectangle(REKT Rectangle)
        {
            return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
        }
        public static implicit operator REKT(Rectangle Rectangle)
        {
            return new REKT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
        }
        public static bool operator ==(REKT Rectangle1, REKT Rectangle2)
        {
            return Rectangle1.Equals(Rectangle2);
        }
        public static bool operator !=(REKT Rectangle1, REKT Rectangle2)
        {
            return !Rectangle1.Equals(Rectangle2);
        }

        public override string ToString()
        {
            return "{Left: " + this._left + "; " + "Top: " + this._top + "; Right: " + this._right + "; Bottom: " + this._bottom + "}";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public bool Equals(REKT Rectangle)
        {
            return Rectangle.Left == this._left && Rectangle.Top == this._top && Rectangle.Right == this._right && Rectangle.Bottom == this._bottom;
        }

        public override bool Equals(object Object)
        {
            if (Object is REKT)
            {
                return this.Equals((REKT)Object);
            }
            else if (Object is Rectangle)
            {
                return this.Equals(new REKT((Rectangle)Object));
            }

            return false;
        }
    }

}
