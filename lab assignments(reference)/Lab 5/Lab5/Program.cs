using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab5
{
    //==================================================
    //-------------PROGRAM CLASS------------------------
    class Program
    {
        //Global string list to hold the names of price data files pulled from the portfolio.xml file
        static List<string> priceDataFiles;

        /* Global "Transaction" list to hold the transactions pulled from the portfolio.xml file
         * Transaction is a class and a method I created to handle the transaction data.
         */ 
        static List<Transaction> transList = new List<Transaction>();

        /* Global Dictionary that will have a String as a Key and a Dictionary as a value.
         * The dictionary that will be the value will have a string as a key and a double as a value.
         */ 
        static Dictionary<string, Dictionary<string, double>> allStocks = new Dictionary<string,Dictionary<string,double>>();



        //-------------Main Method------------------------
        static void Main(string[] args)
        {
            //A string to hold the online location of the portfolio.xml file
            string portfolioLocation = "http://cis.fiu.edu/~irvinek/cop4814/data/portfolioLab5.xml";

            /* Call the read_portfolio method and pass it the string holding the location.
             * This method will populate our priceDataFiles list with file names.
             * These files hold data concerning dates and prices of particular stocks.
             * It will also populate our transList with Transactions from the portfolio.xml file.
             */
            read_portfolio(portfolioLocation);

            /* For each of the files in the priceDataFiles list call the read_data_fle method 
             * and send it that file Name. This will populate the allStocks dictionary with
             * a ticker for each stock and data conerning dates and adjusted closing prices.
             */ 
            foreach(string fileName in priceDataFiles)
            {
                read_data_file(fileName);
            }

            //Calls a method that will process and print out the transactions.
            processTransactions();
            
        }
        //----------------End of Main Method-----------------------
        
 
        //-------------Read Portfolio Method------------------------
        private static void read_portfolio(string portfolioLocation)
        {
            /* Create an instance of the XmlTextReader class named 'reader' 
             * and pass it the portfolio location. It will now read from
             * the online portfolio.xml file (so long as it exists)
             */ 
            XmlTextReader reader = new XmlTextReader(portfolioLocation);

            priceDataFiles = new List<string>();

            //Start reading the xml file
            reader.Read();

            //While reading, test for files and transactions
            while (reader.Read())
            {
                reader.MoveToContent();

                /* When it finds a file, move to the next attribute, 
                 * which would be its name and add it 
                 * to the priceDataFiles list.
                 */ 
                if (reader.Name == "file")
                {
                    reader.MoveToNextAttribute();
                    priceDataFiles.Add(reader.Value);
                }

                //When it finds a transaction, call the transactionListReader method and pass the reader.
                if (reader.Name == "transaction")
                {

                    transactionListReader(reader);
                    
                }
            }

            //Remove the NULL item from the transaction list
            transList.RemoveAt(11);

            //Close Reader
            reader.Close();

        }
        //-----------------End of Read Portfolio Method--------------


        //-------------Read Data Files Method------------------------
        private static void read_data_file(string fileName)
        {
            
            //Decalre a file location string that matches the online location
            string fileLocation = "http://cis.fiu.edu/~irvinek/cop4814/data/";

            //Open the reader and have it read the location + the file name
            XmlTextReader reader = new XmlTextReader(fileLocation+fileName);
            
            //This grabs the starting index number of the file name
            int startOfFileName = 0;

            //This grabs the index number of the dot right before XML
            int dotLocation = fileName.IndexOf(".");

            //This substring method will only give me the index from the start to the dot. Thus removing ".xml"
            string ticker = fileName.Substring(startOfFileName, dotLocation);

            //Create a new dictionary to put in the stock info I will get from the reader.
            Dictionary<string, double> oneStock = new Dictionary<string, double>();

            //Start reading
            reader.Read();

            while(reader.Read())
            {
                if (reader.Name == "Row")
                {
                    //Logic for converting Excel Date format to a usable date format
                    int ExcelDate = Convert.ToInt32(nextValue(reader)) - 2;
                    DateTime StartingDate = new DateTime(1900, 1, 1);
                    TimeSpan timeSpan = new TimeSpan(ExcelDate, 0, 0, 0);

                    //Obtain the date converted from Excel to a usable format
                    DateTime realDate = StartingDate.Add(timeSpan);

                    //Convert the date to the same format as the one in the portfolio XML file.
                    string realDateConverted = realDate.ToString("yyyyMMdd");
                    
                    //Assign un-needed sections to variables. *easier for me
                    string open = nextValue(reader);
                    string high = nextValue(reader);
                    string low = nextValue(reader);
                    string close = nextValue(reader);
                    string volume = nextValue(reader);

                    //Obtain Adjusted Closing Price and convert it to a double
                    double adjustedClosingPrice = Convert.ToDouble(nextValue(reader));

                    //Add the Key (the date) and the value(the price) to the stock's dictionary
                    oneStock.Add(realDateConverted, adjustedClosingPrice);
                }

            }

            //Close the reader
            reader.Close();

            /* Add the Key(the stock's ticker) 
             * and the value (the stock's dictionary that has the date and price) 
             * to the dictionary for ALL stocks. 
             * I convert the ticker to all UPPERCASE to match the ticker provided
             * by the portfolio.xml file.
             */
            allStocks.Add(ticker.ToUpper(), oneStock);
            
        }
        //--------------------End of read data file-----------------------------


        //-------------Read nextValue in XML file Method------------------------
        static string nextValue(XmlTextReader reader)
        {
            //While the reader can read, it tests to see if the nodetype has text. If it does..return the value.
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    return reader.Value;
                }
            }
            return null;
        }
        //------------------End of Next value Method----------------------------

        //-------------Transaction Method---------------------------------------
        private static void transactionListReader(XmlTextReader reader)
        {
            //The reader arrives and we grab the following from the XML file
            string ticker = nextValue(reader);
            string action = nextValue(reader);
            string date = nextValue(reader);
            string shares = nextValue(reader);

            //We create a new instance of the Transaction class..and send it the info we collected
            Transaction transactions = new Transaction(ticker, action, date, shares);

            //We add this instance to our transaction list named transList.
            transList.Add(transactions);

        }
        //--------------End of transaction method-------------------------------

        //-------------------Process Transaction Method-------------------------
        private static void processTransactions()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Portfolio Transactions:" );
            Console.WriteLine();

            //For every transaction in the transList do the following
            foreach (Transaction tr in transList)
            {
                /* Create a  NEW dictionary  named 'prices' that expects a string as a key and a double as a value.
                 * Since the value of allStocks is a dictionary that also is made up of a string and a double
                 * then we will assign the values from allStocks that match its key, which in this case
                 * will be the ticker from the current transaction.
                 */
                Dictionary<string, double> prices = allStocks[tr.ticker];

                //Assign the value (the adjusted price) from the prices dictionary using the transaction date as the key.
                double price_per_share = prices[tr.date];

                /* Use string builder class to format the date
                 * I create an instance of the StringBuilder class named formattedDate.
                 */ 
                StringBuilder formattedDate = new StringBuilder();

                //I append the transaction date to this instance
                formattedDate.Append(tr.date);

                //I insert dashes "-" at the 4th and 7th index of the transaction date
                formattedDate.Insert(4, "-");
                formattedDate.Insert(7, "-");

                //I create a string named DateFormatted and convert my 'formattedDate' to a string
                string DateFormatted = formattedDate.ToString();

                /* Write out the date, action, number of shares, the ticker, and the price per share.
                 * I convert price_per_share to a string and format it to show two float decimal places.
                 * Because I converted and appended the transaction date, 
                 * it will appear as YYY-MM-DD rather than YYYYMMDD, which is how it is in the XML file.
                 */ 
                Console.WriteLine(DateFormatted +" : " +tr.action +" " +tr.shares  +" shares of " +tr.ticker +" at $" +price_per_share.ToString("f2") +" per share.");
            }

            Console.WriteLine("-----------------------------------------------------");
        }
        //----------------------End of Process Transaction Method----------------------


    }
    //End of program class
    //==================================================

    
    //==================================================
    //-------------TRANSACTION CLASS--------------------
    public class Transaction
    {
        public string ticker { get; set; }
        public string action { get; set; }
        public string date { get; set; }
        public string shares { get; set; }

        public Transaction(string ticker, string action, string date, string shares)
        {
            this.ticker = ticker;
            this.action = action;
            this.date = date;
            this.shares = shares;
        }

    }// end of Transaction class
    //==================================================

}//End of namespace
