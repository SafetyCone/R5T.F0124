using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using R5T.T0132;
using R5T.T0180;


namespace R5T.F0124
{
    // Prior work: R5T.NetStandard.IO.Serialization
    [FunctionalityMarker]
    public partial interface IBinaryFileSerializer : IFunctionalityMarker
    {
        public T Deserialize<T>(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            var output = (T)formatter.Deserialize(stream);
            return output;
        }

        public T Deserialize<T>(IFilePath filePath)
        {
            var stream = Instances.FileStreamOperator.NewRead(filePath.Value);

            return this.Deserialize<T>(stream);
        }

        public void Serialize<T>(Stream stream, T obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
        }

        public void Serialize<T>(IFilePath filePath, T obj)
        {
            var stream = Instances.FileStreamOperator.NewWrite(filePath.Value);

            this.Serialize<T>(stream, obj);
        }
    }
}
