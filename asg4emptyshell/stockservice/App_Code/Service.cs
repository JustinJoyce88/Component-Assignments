
//by: Alberto Fortuny and Justin Joyce

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

public class StockService : IStockService
{
    List<DailyPrices> dailyList = new List<DailyPrices>();
    static double smallest = 2100000000;
    static double largest = 0;

    public GraphData[] GetDateRange(DateTime firstDate, DateTime lastDate)
	{
        Read("http://cis.fiu.edu/~irvinek/cop4814/data/ulti.xml");
        GraphData[] allData = new GraphData[dailyList.Count];
        int counter = dailyList.Count-1;


        foreach (DailyPrices dp in dailyList)
        {
            allData[counter] = new GraphData(dp.getDate(), dp.getClose());
            counter--;
        }

        counter = 0;
        GraphData[] returnData = new GraphData[allData.Length];
        DateTime tempDate = firstDate;

        foreach (GraphData gd in allData)
        {
            if (gd.Date >= firstDate && gd.Date <= lastDate)
            {
                returnData[counter] = new GraphData(gd.Date, gd.Value);
                
                if (gd.Value < smallest)
                {
                    smallest = gd.Value;
                }
                if (gd.Value > largest)
                {
                    largest = gd.Value;
                }
            }
            counter++;
        }
        return returnData; 
	}


    public double getSmallest()
    {
        return smallest;
    }
    public double setSmallest(double smallest1)
    {
        return smallest = smallest1;
    }
    public double setLargest(double largest1)
    {
        return largest = largest1;
    }
    public double getLargest()
    {
        return largest;
    }

    public GraphData[] CalcMovingAverages(DateTime firstDate, DateTime lastDate, int numDays)
    {
        GraphData[] allData = GetDateRange(firstDate, lastDate);
        List<GraphData> simpleList = allData.ToList();
        simpleList.RemoveAll(gd => gd == null);
        GraphData[] returnData = new GraphData[simpleList.Count];
        int counter = 0;

        foreach (GraphData gd in simpleList)
        {
            returnData[counter] = new GraphData(gd.Date, gd.Value);
            counter++;
        }

        double sum = 0;
        double avg = 0;

        for (int i = 0; i < returnData.Length - numDays; i++)
        {
            sum = 0;
            for (int j = i; j < i + numDays -1; j++)
            {
                    sum += returnData[j].Value;
                    returnData[i].Date = returnData[j].Date;
            }
            avg = sum / numDays;
            returnData[i].Value = avg;

            if (returnData[i].Value < smallest)
            {
                smallest = returnData[i].Value;
            }
            if (returnData[i].Value > largest)
            {
                largest = returnData[i].Value;
            }
        }
        return returnData;
	}

    void Main(string[] args)
    {
        string path = "http://cis.fiu.edu/~irvinek/cop4814/data/ulti.xml";
        bool fileFound = Read(path);

        foreach (DailyPrices P in dailyList)
        {
            Console.Out.WriteLine(P);
        }
    }

    public bool Read(string path)
    {
        try
        {
            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(path);
            reader.Read();
            while (reader.Read())
            {
                reader.MoveToContent();
                if (reader.NodeType == System.Xml.XmlNodeType.Element)
                {
                    if (reader.Name == "Row")
                    {
                        DailyPrices S = readDailyPrices(reader);
                        dailyList.Add(S);
                    }
                }
            }
            return true;
        }
        catch (System.IO.FileNotFoundException)
        {
            return false;
        }
    }

    string nextValue(System.Xml.XmlTextReader reader)
    {
        while (reader.Read())
        {
            if (reader.NodeType == System.Xml.XmlNodeType.Text)
                return reader.Value;
        }
        return null;
    }

    DailyPrices readDailyPrices(System.Xml.XmlTextReader reader)
    {
        // Excel dates are encoded as integers, where 1/1/1900 = 1. There is a bug
        // in their date calculations because they consider 1900 to be a leap year. This
        // bug was never corrected because it first appeared in Lotus 1-2-3 and Microsoft
        // wanted the two products to be compatible.

        int offset = 2;
        int excelDays = Convert.ToInt32(nextValue(reader)) - offset;
        DateTime start = new DateTime(1900, 1, 1);
        TimeSpan ts = new TimeSpan(excelDays, 0, 0, 0);
        DateTime D = start.Add(ts);

        double open = Convert.ToDouble(nextValue(reader));
        double high = Convert.ToDouble(nextValue(reader));
        double low = Convert.ToDouble(nextValue(reader));
        double close = Convert.ToDouble(nextValue(reader));
        double volume = Convert.ToDouble(nextValue(reader));
        double adjClose = Convert.ToDouble(nextValue(reader));

        DailyPrices S = new DailyPrices(D, open, high, low, close, volume, adjClose);
        return S;
    }
}

class DailyPrices
{
    DateTime date;
    double open;
    double high;
    double low;
    double close;
    double volume;
    double adjClose;

    public DailyPrices(DateTime pDate, double pClose, double pOpen, double pHigh, double pLow, double pVolume, double pAdjClose)
    {
        date = pDate;
        open = pOpen;
        high = pHigh;
        low = pLow;
        close = pClose;
        volume = pVolume;
        adjClose = pAdjClose;
    }

    public DateTime getDate()
    {
        return date;
    }

    public double getClose()
    {
        return close;
    }

    public override String ToString()
    {
        return date.ToString("d") + ", adjClose=" + adjClose;
    }

}