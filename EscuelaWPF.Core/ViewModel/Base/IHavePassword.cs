using System.Security;

namespace EscuelaWPF.Core
{
    /// <summary>
    /// A interface for a class that can provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
