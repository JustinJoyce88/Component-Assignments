// Team: Alberto Fortuny & Justin Joyce
package cop4814.asg3;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

/**This class includes the following methods. readAccountsFile(String filename), 
 * getAccounts(), getStockValuation(String accountId), getCashBalances(), 
 * getStockOwners(String ticker), getPortfoliosByCashBalances(), getInvestmentList()
 * 
 * 
 */
public class AccountManager 
{
    private final Map<String, Account> accounts = new TreeMap<>();
    
    /**Read a text file containing several accounts, which store this information 
     * in the accounts Map and returns True if successful.
     * 
     * @param filename
     * @return a boolean that confirms the successful or unsuccessful reading of 
     * the file specified
     */
    public boolean readAccountsFile(String filename) 
    {    
        Scanner sc;
        try 
        {   
            sc = new Scanner(new File(filename));
        }     
        catch (FileNotFoundException fe) 
        {
             System.out.println("File not found! -- " + fe);
             return false;
        }
        int numAccounts = sc.nextInt();
        sc.nextLine();
        
        try
        {
            for(int i=0; i<numAccounts; i++)
            {
                String[] acctArray = sc.nextLine().replaceAll("\\s+","").split(",");
                String acctID = acctArray[0];
                int numPortfolios = Integer.parseInt(acctArray[1]);
                List<Portfolio> pfList = new LinkedList<>();
                for(int j = 0; j<numPortfolios; j++)
                {
                    String[] pfArray = sc.nextLine().replaceAll("\\s+","").split(",");
                    String pfID = pfArray[0];
                    Double pfCashBalance = Double.parseDouble(pfArray[1]);
                    int numInvestments = Integer.parseInt(pfArray[2]);
                    List<Investment> invList = new LinkedList<>(); 
                    Portfolio pf = new Portfolio(pfID, pfCashBalance, invList);
                    pfList.add(pf);
                    for(int k=0; k<numInvestments; k++)
                    {
                        String[] invArray = sc.nextLine().replaceAll("\\s+","").split(",");
                        String invTicker = invArray[0];
                        int invNumShares = Integer.parseInt(invArray[1]);
                        Double invPrice = Double.parseDouble(invArray[2]);
                        Investment invest = new Investment(invTicker, invNumShares, invPrice);
                        invList.add(invest);
                    }
                }      
                Account acct = new Account(acctID, pfList);
                accounts.put(acctID, acct);
            }
            sc.close();
            return true;
        }
        catch (NumberFormatException e)
        {
            System.out.println("File was not successfully read" + e);
            return false;
        }
    }

    /*Returns a list of all accounts 
     * 
     * @return a list of all accounts
     */
    public List<Account> getAccounts()
    {
        List<Account> accts = new ArrayList<>();
        for( Map.Entry<String, Account> entry : accounts.entrySet())
        {
            accts.add(entry.getValue());
        }
        return accts;
    }    
    
    /**If the account ID is found, this method returns the sum value of all stock 
     * holdings in a single account not counting cash balances. If the account 
     * is not found, return -1.0 
     * 
     * @param accountId specified in test class
     * @return a double which is the sum of the cost of stocks per account specified
     */
    public double getStockValuation(String accountId) 
    {
        double sum = 0;
        if(accounts.containsKey(accountId)){
            for(Account acct : accounts.values())
            {
                if(acct.getId().equals(accountId))
                {
                    sum+=acct.getStockValues();    
                }
            }
            return sum;
        }
        else
            return -1.0;
    }
    
    /** Returns a Map of all account ID's and their sum of cash balances ordered by 
     * account ID in ascending order.
     *  
     * @return a TreeMap with Strings as the key and a Double as a value. 
     * The key is the ID of an account and the value is the cash balance of a portfolio.
     */ 
    public TreeMap<String, Double> getCashBalances() 
    {
        TreeMap<String, Double> map = new TreeMap<>();
        for(Account acct : accounts.values())
        {
            double balance = 0;
            for(Portfolio pf : acct.getPortfolios())
            {
                balance += pf.getCashBalance();               
            }
            map.put(acct.getId(), balance);
        }
        return map;
    }
    
    /**Returns an Map of account IDs and number of shares for each 
     * account that owns the stock identified by the ticker parameter. 
     * 
     * @param ticker specified in test class.
     * @return a TreeMap with Strings as the key and an Integer as a value. The
     * key is an account ID and the value is the sum of shares per specified ticker.
     */
    public TreeMap<String, Integer> getStockOwners(String ticker) 
    {
        TreeMap<String, Integer> map = new TreeMap<>();
        for(Account acct : accounts.values())
        {
            int shares = 0;
            for(Portfolio pf : acct.getPortfolios())
            {
                for(Investment inv : pf.getHoldings())
                {
                    if(inv.getTicker().equals(ticker))
                        shares += inv.getNumShares();
                }
            }
            map.put(acct.getId(), shares);
        }
        return map;
    }
    
    /**Returns a list of all Portfolios sorted in descending order by their cash
     * balances
     * 
     * @return a list of Portfolios in descending order by their cash
     */
    public List<Portfolio> getPortfoliosByCashBalances() 
    {
        List<Portfolio> list = new LinkedList<>();
        for(Account acct : accounts.values())
        {
            for(Portfolio pf : acct.getPortfolios())
            {
                list.add(pf);
            }
        }
        Collections.sort(list);
        Collections.reverse(list);
        return list;
    }
    
    /**Returns a list of all investments, sorted in ascending order by ticker symbol.
     * 
     * @return a list of Investments sorted in ascending order by ticker symbol.
     */
    public List<Investment> getInvestmentList() 
    {
        List<Investment> invList = new LinkedList<>();
        for(Account acct : accounts.values())
        {
            for(Portfolio pf : acct.getPortfolios())
            {
                for(Investment inv : pf.getHoldings())
                {
                	invList.add(inv);
                }
            }
        }
        Collections.sort(invList);
        return invList;
    }
}

