using DMSUpload_Helper.Service.Interface;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;

namespace DMSUpload_Helper.Service.Implement
{
    public enum LogonProvider : int
    {
        Default = 0,  // LOGON32_PROVIDER_DEFAULT
        WinNT35 = 1,
        WinNT40 = 2,  // Use the NTLM logon provider.
        WinNT50 = 3   // Use the negotiate logon provider.
    }

    public enum LogonType : int
    {
        Interactive = 2,
        Network = 3,
        Batch = 4,
        Service = 5,
        Unlock = 7,
        NetworkClearText = 8,
        NewCredentials = 9
    }

    public class SharePoint : ISharePoint
    {
        private WindowsImpersonationContext _context;
        private string _domain, _ps, _us;
        private IntPtr _token;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Logon()
        {
            if (IsInContext()) return;
            _token = IntPtr.Zero;
            bool logonSuccessfull = LogonUser(_us, _domain, _ps, LogonType.NewCredentials, LogonProvider.WinNT50, ref _token);
            if (!logonSuccessfull) throw new Win32Exception(Marshal.GetLastWin32Error());

            WindowsIdentity identity = new WindowsIdentity(_token);
            _context = identity.Impersonate();
        }

        public void Logout()
        {
            if (IsInContext())
            {
                _context.Dispose();
                _context = null;
                if (!RevertToSelf())
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
        }

        public bool IsInContext()
        {
            return _context != null;
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool LogonUser(String username, String domain, string password, LogonType logonType, LogonProvider logonProvider, ref IntPtr token);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool RevertToSelf();

        public void WrappedImpersonationContext(string domain, string us, string ps)
        {
            _domain = string.IsNullOrEmpty(domain) ? "." : domain;
            _us = us;
            _ps = ps;
        }
    }
}
