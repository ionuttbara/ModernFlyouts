﻿using System;
using System.Runtime.InteropServices;
using System.Text;

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ModernFlyouts.WinUI.Helpers
{

    public static class NativeMethods
    {
        private const int GWL_STYLE = -16;
        private const int WS_POPUP = 1 << 31; // 0x80000000
        internal const int SPI_GETDESKWALLPAPER = 0x0073;
        internal const int SW_SHOWNORMAL = 1;
        internal const int SW_SHOWMAXIMIZED = 3;
        internal const int SW_HIDE = 0;

        [DllImport("user32.dll")]
        internal static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, NativeKeyboardHelper.INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        internal static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

#pragma warning disable CA1401 // P/Invokes should not be visible
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool AllowSetForegroundWindow(int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool FreeLibrary(IntPtr hModule);
#pragma warning restore CA1401 // P/Invokes should not be visible

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SystemParametersInfo(int uiAction, int uiParam, StringBuilder pvParam, int fWinIni);

        public static void SetPopupStyle(IntPtr hwnd)
        {
            _ = SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) | WS_POPUP);
        }


    }

}
