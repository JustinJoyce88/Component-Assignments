using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
    GraphData[] GetDateRange(DateTime first, DateTime last);

	[OperationContract]
    GraphData[] CalcMovingAverages(DateTime firstDate, DateTime lastDate, int numDays);

	// TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class GraphData
{
	public GraphData(DateTime date, double value)
	{
		this.Date = date;
		this.Value = value;
	}

	[DataMember]
	public DateTime Date { get; set; }

	[DataMember]
	public double Value { get; set; }
}

