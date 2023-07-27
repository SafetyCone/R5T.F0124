using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0180;
using R5T.T0180.Extensions;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IOperatingSystemOperator : IFunctionalityMarker
    {
        private static Internal.IOperatingSystemOperator Internal => F0124.Internal.OperatingSystemOperator.Instance;
        private static N000.IOperatingSystemOperator N000 => F0124.N000.OperatingSystemOperator.Instance;


        /// <summary>
        /// Get the operating system platform on which code is currently running.
        /// </summary>
        // Prior work: R5T.D0024.Default.OSPlatformProvider
        public OSPlatform Get_OSPlatform()
        {
            // Implementation note: there is no RuntimeInformation.GetOSPlatform() method, so the only way to determine the OSPlatform is to test each one.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux;
            }

            throw Internal.Get_UnknownOSPlatformException();
        }

        public IDirectoryPath Get_SpecialDirectoryPath(
            Environment.SpecialFolder specialFolder,
            bool ensureIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
        {
            var output = N000.Get_SpecialDirectoryPath(specialFolder, ensureIsDirectoryIndicated)
                .ToDirectoryPath();

            return output;
        }

        public TDirectoryPath Get_SpecialDirectoryPath<TDirectoryPath>(
            Environment.SpecialFolder specialFolder,
            Func<string, TDirectoryPath> directoryPathTypeConstructor,
            bool ensureIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
            // Include type restriction facet, even though it is extraneous.
            where TDirectoryPath : IDirectoryPath
        {
            var directoryPath = N000.Get_SpecialDirectoryPath(specialFolder, ensureIsDirectoryIndicated);

            var output = directoryPathTypeConstructor(directoryPath);
            return output;
        }

        // Prior work: R5T.D0025.Default.OSPlatformSwitch and R5T.D0025.Base.IOSPlatformSwitchExtensions.
        public T SwitchOn_OSPlatform<T>(
            OSPlatform oSPlatform,
            T forWindows,
            T forOsx,
            T forLinux)
        {
            // Unable to use basic switch statement since OSPlatform values are not constant.
            // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                return forWindows;
            }

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                return forOsx;
            }

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                return forLinux;
            }

            throw Internal.Get_UnknownOSPlatformException();
        }

        public T SwitchOn_OSPlatform<T>(
            T forWindows,
            T forOsx,
            T forLinux)
        {
            var osPlatform = this.Get_OSPlatform();

            return this.SwitchOn_OSPlatform(
                osPlatform,
                forWindows,
                forOsx,
                forLinux);
        }

        public T SwitchOn_OSPlatform<T>(
            OSPlatform oSPlatform,
            T forWindows,
            T forNonWindows)
        {
            return this.SwitchOn_OSPlatform(
                oSPlatform,
                forWindows,
                forNonWindows,
                forNonWindows);
        }

        public T SwitchOn_OSPlatform<T>(
            T forWindows,
            T forNonWindows)
        {
            var osPlatform = this.Get_OSPlatform();

            return this.SwitchOn_OSPlatform(
                osPlatform,
                forWindows,
                forNonWindows);
        }

        public void SwitchOn_OSPlatform(
            OSPlatform oSPlatform,
            Action windowsAction,
            Action osxAction,
            Action linuxAction)
        {
            // Unable to use basic switch statement since OSPlatform values are not constant.
            // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                windowsAction();
            }

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                osxAction();
            }

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                linuxAction();
            }

            throw Internal.Get_UnknownOSPlatformException();
        }

        public void SwitchOn_OSPlatform(
            Action windowsAction,
            Action osxAction,
            Action linuxAction)
        {
            var osPlatform = this.Get_OSPlatform();

            this.SwitchOn_OSPlatform(
                osPlatform,
                windowsAction,
                osxAction,
                linuxAction);
        }

        //public Task SwitchOn_OSPlatform(
        //    OSPlatform oSPlatform,
        //    Func<Task> windowsAction,
        //    Func<Task> osxAction,
        //    Func<Task> linuxAction)
        //{
        //    // Unable to use basic switch statement since OSPlatform values are not constant.
        //    // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

        //    if (RuntimeInformation.IsOSPlatform(oSPlatform))
        //    {
        //        return windowsAction();
        //    }

        //    if (RuntimeInformation.IsOSPlatform(oSPlatform))
        //    {
        //        return osxAction();
        //    }

        //    if (RuntimeInformation.IsOSPlatform(oSPlatform))
        //    {
        //        return linuxAction();
        //    }

        //    throw Internal.Get_UnknownOSPlatformException();
        //}

        //public Task SwitchOn_OSPlatform(
        //    Func<Task> windowsAction,
        //    Func<Task> osxAction,
        //    Func<Task> linuxAction)
        //{
        //    var osPlatform = this.Get_OSPlatform();

        //    return this.SwitchOn_OSPlatform(
        //        osPlatform,
        //        windowsAction,
        //        osxAction,
        //        linuxAction);
        //}

        public T SwitchOn_OSPlatform<T>(
            OSPlatform oSPlatform,
            Func<T> windowsFunction,
            Func<T> osxFunction,
            Func<T> linuxFunction)
        {
            // Unable to use basic switch statement since OSPlatform values are not constant.
            // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                return windowsFunction();
            }

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                return osxFunction();
            }

            if (RuntimeInformation.IsOSPlatform(oSPlatform))
            {
                return linuxFunction();
            }

            throw Internal.Get_UnknownOSPlatformException();
        }

        public T SwitchOn_OSPlatform<T>(
            Func<T> windowsFunction,
            Func<T> osxFunction,
            Func<T> linuxFunction)
        {
            var osPlatform = this.Get_OSPlatform();

            return this.SwitchOn_OSPlatform(
                osPlatform,
                windowsFunction,
                osxFunction,
                linuxFunction);
        }

        //public Task<T> SwitchOn_OSPlatform<T>(
        //    OSPlatform oSPlatform,
        //    Func<Task<T>> windowsFunction,
        //    Func<Task<T>> osxFunction,
        //    Func<Task<T>> linuxFunction)
        //{
        //    // Unable to use basic switch statement since OSPlatform values are not constant.
        //    // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

        //    if (RuntimeInformation.IsOSPlatform(oSPlatform))
        //    {
        //        return windowsFunction();
        //    }

        //    if (RuntimeInformation.IsOSPlatform(oSPlatform))
        //    {
        //        return osxFunction();
        //    }

        //    if (RuntimeInformation.IsOSPlatform(oSPlatform))
        //    {
        //        return linuxFunction();
        //    }

        //    throw Internal.Get_UnknownOSPlatformException();
        //}
    }
}
