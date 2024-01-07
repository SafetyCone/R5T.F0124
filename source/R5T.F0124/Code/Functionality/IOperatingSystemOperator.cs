using System;
using System.Runtime.InteropServices;

using R5T.T0132;
using R5T.T0180;
using R5T.T0180.Extensions;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IOperatingSystemOperator : IFunctionalityMarker,
        L0066.IOperatingSystemOperator
    {
        private static N000.IOperatingSystemOperator N000 => F0124.N000.OperatingSystemOperator.Instance;


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

            throw _Internal.Get_UnknownOSPlatformException();
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
    }
}
