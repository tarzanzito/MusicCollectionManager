using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MusicLibrariesManager
{
    

//retval = CopyFileApiW(StrPtr(source), StrPtr(StrConv(Dest), 0)

    
    public class Class1
    {
[DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
public static extern bool CopyFileW([MarshalAs(UnmanagedType.LPStr)] string lpExistingFileName, [MarshalAs(UnmanagedType.LPStr)] string lpNewFileName, [MarshalAs(UnmanagedType.Bool)] bool bFailIfExists);
    }
}
