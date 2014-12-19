using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ACM.Library
{
    /// <summary>
    /// Provides for debug logging.
    /// </summary>
    public class Logging
    {
        public static void DebugMessage(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            Debug.WriteLine("message: " + message);
            Debug.WriteLine("member name: " + memberName);
            Debug.WriteLine("source file path: " + sourceFilePath);
            Debug.WriteLine("source line number: " + sourceLineNumber);
        }
    }
}
