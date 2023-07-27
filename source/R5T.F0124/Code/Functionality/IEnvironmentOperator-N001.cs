using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0221;


namespace R5T.F0124.N001
{
    /// <summary>
    /// An C# base types-level operator.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IEnvironmentOperator : IFunctionalityMarker
    {
        public IEnvironmentVariable[] Get_EnvironmentVariables(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            var output = Instances.EnvironmentOperator_N000.Get_EnvironmentVariables(environmentVariableTarget)
                .Select(pair => new EnvironmentVariable
                {
                    Name = pair.Key,
                    Value = pair.Value,
                })
                .ToArray();

            return output;
        }

        public IDictionary<string, IEnvironmentVariable> Get_EnvironmentVariablesByName(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            var output = this.Get_EnvironmentVariables(environmentVariableTarget)
                .ToDictionary(
                    x => x.Name);

            return output;
        }
    }
}
