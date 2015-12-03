using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using XmlStockDataReader;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStockWebService" in both code and config file together.
[ServiceContract]
public interface IStockWebService
{
    //[OperationContract]
    //Stock[] getDateRange(DateTime startDate, DateTime endDate);

    [OperationContract]
    DateTime[] getDateRangeTest(DateTime startDate, DateTime endDate);
    /*
	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);
    */
	// TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class Stock
{
    [DataMember]
    public DateTime Date { get; set; }

    [DataMember]
    public Double Open { get; set; }

    [DataMember]
    public Double High { get; set; }

    [DataMember]
    public Double Low { get; set; }

    [DataMember]
    public Double Close { get; set; }

    [DataMember]
    public Double Volume { get; set; }

    public Stock(DateTime pDate, double pOpen, double pHigh, double pLow, double pClose, double pVolume)
	{
		Date = pDate;
		Open = pOpen;
		High = pHigh;
		Low = pLow;
		Close = pClose;
		Volume = pVolume;
	}

    /*
	bool boolValue = true;
	string stringValue = "Hello ";

    [DataMember]
    public bool BoolValue
    {
        get { return boolValue; }
        set { boolValue = value; }
    }

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
     * */
}
