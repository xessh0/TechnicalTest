using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Models.Window
{
    public class WinApiFetcher : IFetcher
    {
        static List<Window> windows = new List<Window>();

        const int MAXTITLE = 255;
        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowText",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int _GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;     
            public int Top;  
            public int Right;   
            public int Bottom; 
        }


        public static string GetWindowText(IntPtr hWnd)
        {
            var title = new StringBuilder(MAXTITLE);
            int length = _GetWindowText(hWnd, title, title.Capacity + 1);
            title.Length = length;
            return title.ToString();
        }

        private static bool EnumWindowsProc(IntPtr hWnd, int lParam)
        {
            GetWindowRect(hWnd, out RECT rect);
            var window = new Window()
            {
                Name = GetWindowText(hWnd),
                IsVisible = IsWindowVisible(hWnd),
                X = rect.Left,
                Y = rect.Top,
                Width = rect.Right - rect.Left + 1,
                Height = rect.Bottom - rect.Top + 1
            };

            windows.Add(window);

            return true;
        }

        private static void GetDesktopWindows()
        {
            windows.Clear();
            EnumDelegate delEnumfunc = new EnumDelegate(EnumWindowsProc);
            EnumDesktopWindows(IntPtr.Zero, delEnumfunc, IntPtr.Zero);

        }

        public IReadOnlyList<Window> FetchAll()
        {
            GetDesktopWindows();
            return windows;
        }
    }
}
