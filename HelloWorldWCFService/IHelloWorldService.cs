using System.ServiceModel;

namespace HelloWorldWCFService
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string GetMessage(string name);
    }
}
