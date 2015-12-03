using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlStockDataReader
{
	public class DailyPrices
	{
		DateTime date;
		double open;
		double high;
		double low;
		double close;
		double volume;

		public DailyPrices(DateTime pDate, double pOpen, double pHigh, double pLow, double pClose, double pVolume)
		{
			date = pDate;
			open = pOpen;
			high = pHigh;
			low = pLow;
			close = pClose;
			volume = pVolume;
		}

		public override String ToString()
		{
			return date.ToString("d") + ", " + open + ", " + high + ", " + low + ", " + close + ", v=" + volume;
		}

	}

	public class Program
	{
        public List<DailyPrices> dailyList = new List<DailyPrices>();
        /*
		static void Main(string[] args)
		{
			string path = "http://cis.fiu.edu/~irvinek/cop4814/data/ulti.xml";
			bool fileFound = Read(path);

			foreach (DailyPrices P in dailyList)
			{
				Console.Out.WriteLine(P);
			}
		}
        */
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

		public string nextValue(System.Xml.XmlTextReader reader)
		{
			while (reader.Read())
			{
				if (reader.NodeType == System.Xml.XmlNodeType.Text)
					return reader.Value;
			}
			return null;
		}

        public DailyPrices readDailyPrices(System.Xml.XmlTextReader reader)
		{
			// Excel dates are encoded as integers, where 1/1/1900 = 1. There is a bug
			// in their date calculations because they consider 1900 to be a leap year. This
			// bug was never corrected because it first appeared in Lotus 1-2-3 and Microsoft
			// wanted the two products to be compatible.

			int offset = 2;     
			int excelDays = Convert.ToInt32(nextValue(reader)) - offset;
			DateTime start = new DateTime(1900, 1, 1);
			TimeSpan ts = new TimeSpan(excelDays,0,0,0);
			DateTime D = start.Add(ts);

			double open = Convert.ToDouble(nextValue(reader));
			double high = Convert.ToDouble(nextValue(reader));
			double low = Convert.ToDouble(nextValue(reader));
			double close = Convert.ToDouble(nextValue(reader));
			double volume = Convert.ToDouble(nextValue(reader));

			DailyPrices S = new DailyPrices(D, open, high, low, close, volume);
			return S;
		}

        public DailyPrices[] getStocksArray()
        {
            return dailyList.ToArray();
        }

        public List<DailyPrices> getStocksList()
        {
            return dailyList;
        }

	}
}
