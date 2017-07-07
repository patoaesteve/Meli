using System.Runtime.Serialization;
using System.ServiceModel;

namespace Pato.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IClimaWS
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        ClimaResponse Clima(int dia);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class ClimaResponse
    {
        int dia = 0;
        string clima = string.Empty;

        [DataMember]
        public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        [DataMember]
        public string Clima
        {
            get { return clima; }
            set { clima = value; }
        }
    }
}
