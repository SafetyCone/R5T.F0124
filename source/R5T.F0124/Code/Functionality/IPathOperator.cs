using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0179.Extensions;
using R5T.T0180;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker
    {
        public string Get_DirectoryPath(
            string parentDirectoryPath,
            string childDirectoryName,
            bool ensureDirectoryPathIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
        {
            return this.Get_DirectoryPath(
                parentDirectoryPath,
                ensureDirectoryPathIsDirectoryIndicated,
                childDirectoryName);
        }

        public string Get_DirectoryPath(
            string parentDirectoryPath,
            bool ensureDirectoryPathIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated,
            params string[] childDirectoryNames)
        {
            return this.Get_DirectoryPath(
                parentDirectoryPath,
                childDirectoryNames.AsEnumerable(),
                ensureDirectoryPathIsDirectoryIndicated);
        }

        public string Get_DirectoryPath(
            string parentDirectoryPath,
            IEnumerable<string> childDirectoryNames,
            bool ensureDirectoryPathIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
        {
            var directoryPath = Instances.PathOperator.GetDirectoryPath(
                parentDirectoryPath,
                childDirectoryNames);

            var output = Instances.PathOperator_N000.Ensure_DirectoryPath_IsDirectoryIndicated_If(
                directoryPath,
                ensureDirectoryPathIsDirectoryIndicated);

            return output;
        }

        public TFilePath Get_DirectoryPath<TFilePath>(
            IDirectoryPath parentDirectoryPath,
            IDirectoryName childDirectoryName,
            Func<string, TFilePath> directoryPathConstructor,
            bool ensureDirectoryPathIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
            where TFilePath : IDirectoryPath
        {
            var directoryPath = this.Get_DirectoryPath(
                parentDirectoryPath.Value,
                childDirectoryName.Value,
                ensureDirectoryPathIsDirectoryIndicated);

            var output = directoryPathConstructor(directoryPath);
            return output;
        }

        public IDirectoryPath Get_DirectoryPath(
            IDirectoryPath parentDirectoryPath,
            IDirectoryName childFileName,
            bool ensureDirectoryPathIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
        {
            var output = this.Get_DirectoryPath(
                parentDirectoryPath,
                childFileName,
                T0180.StringOperator.Instance.ToDirectoryPath,
                ensureDirectoryPathIsDirectoryIndicated);

            return output;
        }

        public TDirectoryPath Get_DirectoryPath<TDirectoryPath>(
            IDirectoryPath parentDirectoryPath,
            Func<string, TDirectoryPath> directoryPathConstructor,
            bool ensureDirectoryPathIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated,
            params IDirectoryName[] childDirectoryNames)
            where TDirectoryPath : IDirectoryPath
        {
            return this.Get_DirectoryPath(
                parentDirectoryPath,
                childDirectoryNames.AsEnumerable(),
                directoryPathConstructor,
                ensureDirectoryPathIsDirectoryIndicated);
        }

        public TDirectoryPath Get_DirectoryPath<TDirectoryPath>(
            IDirectoryPath parentDirectoryPath,
            IEnumerable<IDirectoryName> childDirectoryNames,
            Func<string, TDirectoryPath> directoryPathConstructor,
            bool ensureDirectoryPathIsDirectoryIndicated = IValues.Default_EnsureDirectoryPathIsDirectoryIndicated)
            where TDirectoryPath : IDirectoryPath
        {
            var directoryPath = this.Get_DirectoryPath(
                parentDirectoryPath.Value,
                childDirectoryNames.Get_Values(),
                ensureDirectoryPathIsDirectoryIndicated);

            var output = directoryPathConstructor(directoryPath);
            return output;
        }

        public string Get_FilePath(
            string parentDirectoryPath,
            string childFileName)
        {
            var output = Instances.PathOperator.GetFilePath(
                parentDirectoryPath,
                childFileName);

            return output;
        }

        public TFilePath Get_FilePath<TFilePath>(
            IDirectoryPath parentDirectoryPath,
            IFileName childFileName,
            Func<string, TFilePath> directoryPathConstructor)
            where TFilePath : IFilePath
        {
            var directoryPath = this.Get_FilePath(
                parentDirectoryPath.Value,
                childFileName.Value);

            var output = directoryPathConstructor(directoryPath);
            return output;
        }

        public IFilePath Get_FilePath(
            IDirectoryPath parentDirectoryPath,
            IFileName childFileName)
        {
            var output = this.Get_FilePath(
                parentDirectoryPath,
                childFileName,
                T0180.StringOperator.Instance.ToFilePath);

            return output;
        }
    }
}
