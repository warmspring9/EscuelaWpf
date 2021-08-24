using System;
using System.Runtime.InteropServices;
using System.Security;

namespace EscuelaWPF.Core
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecures a <see cref="SecureString"/> to plain text
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString securePassword)
        {
            //make sure its an actual secure string
            if (securePassword == null)
                return string.Empty;
            
            //Get a pointer for a unsecure string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }

        }
    }
}
