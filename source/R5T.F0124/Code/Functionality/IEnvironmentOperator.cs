using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using R5T.T0132;
using R5T.T0199;
using R5T.T0199.Extensions;
using R5T.T0220;


namespace R5T.F0124
{
    [FunctionalityMarker]
    public partial interface IEnvironmentOperator : IFunctionalityMarker
    {
        public IEnvironmentVariableName[] Get_EnvironmentVariableNames(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            var output = Instances.EnvironmentOperator_N000.Get_EnvironmentVariableNames(environmentVariableTarget)
                .Select(x => x.ToEnvironmentVariableName())
                .Now();

            return output;
        }

        public IEnvironmentVariable[] Get_EnvironmentVariables(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            var output = Instances.EnvironmentOperator_N000.Get_EnvironmentVariables(environmentVariableTarget)
                .Select(pair => new EnvironmentVariable
                {
                    Name = pair.Key.ToEnvironmentVariableName(),
                    Value = pair.Value.ToEnvironmentVariableValue(),
                })
                .ToArray();

            return output;
        }

        public Dictionary<IEnvironmentVariableName, IEnvironmentVariable> Get_EnvironmentVariablesByName(
            EnvironmentVariableTarget environmentVariableTarget = IValues.Default_EnvironmentVariableTarget_Constant)
        {
            var output = this.Get_EnvironmentVariables(environmentVariableTarget)
                .ToDictionary(
                    x => x.Name);

            return output;
        }
    }
}
