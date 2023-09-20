namespace DMSUpload_Helper.Service.Interface
{
    public interface ISharePoint
    {
        void WrappedImpersonationContext(string domain, string us, string ps);
        void Logon();
        void Logout();
        bool IsInContext();
    }
}
