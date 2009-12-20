using System;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace _GetWindowHandle
{
	/// <summary>
	/// HandleMethods 的摘要说明。
	/// </summary>
	public class _WHandleMethods
	{
		//FindWindow
		[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		//GetTopWindow
		[DllImport("user32.dll", EntryPoint = "GetTopWindow", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern IntPtr GetTopWindow(IntPtr hWnd);

		//FindWindowEx
		[DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, 
			string lpszWindow);

		//SetWindowPos
		[DllImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		//GetWindowTextLength
		[DllImport("user32.dll", EntryPoint = "GetWindowTextLength", SetLastError = true, 
			 CharSet = CharSet.Unicode)]
		internal static extern int GetWindowTextLength(IntPtr hWnd);

		//GetWindowText
		[DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		//GetClassName
		[DllImport("user32.dll", EntryPoint = "GetClassName", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GetClassName(IntPtr hWnd, StringBuilder buf, int nMaxCount);

		//SendMessage
		[DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Unicode)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, string lParam);
		[DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, IntPtr lParam);

		//GetWindow
		[DllImport("user32.dll", EntryPoint = "GetWindow", SetLastError = true)]
		internal static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);

		//IsWindow
		[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool IsWindow(IntPtr hWnd);

		//SetWindowLong
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		//GetWindowLong
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		//GetSystemMenu
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		//RemoveMenu
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

		//DrawMenuBar
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool DrawMenuBar(IntPtr hWnd);

		//GetMenuItemCount
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint GetMenuItemCount(IntPtr hMenu);

		//DeleteMenu
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);

		//GetCursorPos
		[DllImport("user32.dll")]
		internal static extern bool GetCursorPos(out Point lpPoint);

		//WindowFromPoint
		[DllImport("user32.dll")]
		internal static extern IntPtr WindowFromPoint(Point Point);

		internal const uint SWP_NOACTIVATE = 0x10;
		internal const uint SWP_SHOWWINDOW = 0x40;		
	}
}
