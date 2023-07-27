using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.F0124.N000
{
    /// <summary>
    /// An C# intrinsic types-level operator.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IEnvironmentOperator : IFunctionalityMarker
    {
        public string Describe_EnvironmentVariable(string name, string value)
        {
            var output = $"{name}: {value}";
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Write_EnvironmentVariables(IDictionary{string, string}, TextWriter, bool)"/>.
        /// </summary>
        public void Display_EnvironmentVariables(
            IDictionary<string, string> variables,
            TextWriter writer,
            bool alphabetize = IValues.Default_Alphabetization_Constant)
        {
            this.Write_EnvironmentVariables(
                variables,
                writer,
                alphabetize);
        }

        public string Display_EnvironmentVariables(
            IDictionary<string, string> variables)
        {
            var output = Instances.StringOperator.In_WriterContext(
                writer => this.Display_EnvironmentVariables(
                    variables,
                    writer));

            return output;
        }

        public void Display_EnvironmentVariables(
            TextWriter writer,
            bool alphabetize = IValues.Default_Alphabetization_Constant)
        {
            var variables = this.Get_EnvironmentVariables();

            this.Display_EnvironmentVariables(
                variables,
                writer,
                alphabetize);
        }

        public string Display_EnvironmentVariables()
        {
            var variables = this.Get_EnvironmentVariables();

            var output = this.Display_EnvironmentVariables(variables);
            return output;
        }

        public string[] Get_EnvironmentVariableNames(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            var raw = this.Get_EnvironmentVariables_Raw(environmentVariableTarget);

            var output = Instances.CollectionsOperator.Convert_Keys<string>(raw)
                .Now();

            return output;
        }

        public IDictionary Get_EnvironmentVariables_Raw(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            var output = Environment.GetEnvironmentVariables(environmentVariableTarget);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_EnvironmentVariableValuesByName(EnvironmentVariableTarget)"/>.
        /// </summary>
        public Dictionary<string, string> Get_EnvironmentVariables(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            return this.Get_EnvironmentVariableValuesByName(environmentVariableTarget);
        }

        public Dictionary<string, string> Get_EnvironmentVariableValuesByName(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            var raw = this.Get_EnvironmentVariables_Raw(environmentVariableTarget);

            var output = Instances.CollectionsOperator.Convert_NonGenericToGeneric<string, string>(raw);
            return output;
        }

        public void Write_EnvironmentVariables(
            IDictionary<string, string> variables,
            TextWriter writer,
            Func<string, string, string> descriptor,
            bool alphabetize = IValues.Default_Alphabetization_Constant)
        {
            var orderedVariables = variables.OrderAlphabetically_If(
                x => x.Key,
                alphabetize);

            orderedVariables.ForEach(pair =>
            {
                var description = descriptor(pair.Key, pair.Value);

                writer.WriteLine(description);
            });
        }

        public void Write_EnvironmentVariables(
            IDictionary<string, string> variables,
            TextWriter writer,
            bool alphabetize = IValues.Default_Alphabetization_Constant)
        {
            this.Write_EnvironmentVariables(
                variables,
                writer,
                this.Describe_EnvironmentVariable,
                alphabetize);
        }
    }
}
