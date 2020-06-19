using System;
using System.Runtime.InteropServices;

namespace ontop {
    class Program {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowLongPtr(
            IntPtr hWnd,
            int nIndex
        );

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(
            IntPtr hWnd,
            int hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            uint uFlags
        );

        static void Main() {
            var hwnd = GetForegroundWindow();
            if (hwnd == null) return;

            var exStyles = (int)GetWindowLongPtr(hwnd, -20);
            var arg = (exStyles & 0x00000008) > 0 ? -2 : -1;

            SetWindowPos(hwnd, arg, 0, 0, 0, 0, 2 | 1);
        }
    }
}
