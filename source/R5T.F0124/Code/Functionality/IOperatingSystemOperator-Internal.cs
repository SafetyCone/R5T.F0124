using System;
using System.Runtime.InteropServices;

using R5T.T0132;
using R5T.T0180;
using R5T.T0180.Extensions;


namespace R5T.F0124.Internal
{
    [FunctionalityMarker]
    public partial interface IOperatingSystemOperator : IFunctionalityMarker
    {
        public string Get_UnknownOSPlatformExceptionMessage()
        {
            var message = $"Unknown {nameof(OSPlatform)} value. \nKnown {nameof(OSPlatform)} values:\n* {OSPlatform.Windows} (Windows)\n* {OSPlatform.OSX} (OSX)\n* {OSPlatform.Linux} (Linux)";
            return message;
        }

        public Exception Get_UnknownOSPlatformException()
        {
            var message = this.Get_UnknownOSPlatformExceptionMessage();

            var exception = new Exception(message);
            return exception;
        }
    }
}
