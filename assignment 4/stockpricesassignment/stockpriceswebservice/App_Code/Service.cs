using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using XmlStockDataReader;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StockWebService" in code, svc and config file together.
public class StockWebService : IStockWebService
{
    private List<DailyPrices> stocks = new List<DailyPrices>();
    private Program xmlReader = new Program();
    private string path = "http://cis.fiu.edu/~irvinek/cop4814/data/ulti.xml";
    
    public StockWebService()
    {
        xmlReader.Read(path);
        stocks = xmlReader.getStocksList();
    }
    /*
    public DailyPrices[] getDateRange(DateTime startDate, DateTime endDate)
    {
        
    }
    */
    public DateTime[] getDateRangeTest(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
        {
            return null;
        }
        List<DateTime> rv = new List<DateTime>();
        DateTime tmpDate = startDate;
        do
        {
            rv.Add(tmpDate);
            tmpDate = tmpDate.AddDays(1);
        } while (tmpDate <= endDate);
        return rv.ToArray();
        /*
        List<DateTime> allDates = new List<DateTime>();
        for (DateTime date = startDate; date < endDate; date.AddDays(1))
        {
            allDates.Add(date);
        }
         return allDates.ToArray();
         * */
        
    }
    /*
    public DailyPrices[] StockList(DateTime startDate, DateTime endDate)
	{  
        List<DailyPrices> rangeStocks = Program.;
        while(startDate <= endDate)
        {
            rangeStocks.Add(DailyPrices.
        return stocks.ToArray();
	}
     * */
    /*
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
     * */
}
