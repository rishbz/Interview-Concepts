using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // Windows Communication Foundation (WCF) is a framework for building service-oriented applications. 
    //Using WCF, you can send data as asynchronous messages from one service endpoint to another. 
    //A service endpoint can be part of a continuously available service hosted by IIS, or it can be a service hosted in an application.
    //ASP.NET web service is designed to exchange SOAP messages over HTTP only while WCF Service can exchange message 
    ///using any format (SOAP is default) over any transport protocol i.e. HTTP, TCP, MSMQ or NamedPipes etc. 
    //Web Services use XmlSerializer but WCF uses DataContractSerializer.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract(IsOneWay=true)]
        void NotTheBodyNotTheMind();

        int MyProperty { get; set; }

        // TODO: Add your service operations here
    }

    public abstract class abstest
    {
        public int MyProperty { get; set; }

        Enum a;

        public void me()
        {

        }

        public abstract void test();
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
}
