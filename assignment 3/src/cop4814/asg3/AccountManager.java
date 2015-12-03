package cop4814.asg3;

//Group members: Alberto Fortuny, Justin Joyce

import java.util.List;
import java.util.Map;
import java.util.TreeMap;

public class AccountManager {

	private Map<String,Account> accounts;
	
	/* Read a text file containg several accounts, store this information
	in the accounts map. Return True if successful. */
	boolean readAccountsFile(String filename){
		
	}
	
	/* Returns a list all stocks (investments), sorted in ascending
	order by ticker symbol.*/
	List<Investment> getInvestmentList(){
		for(Investment inv : )
	}
	
	/* Returns the sum value of all stock holdings in a
	single account, not counting cash balances.*/
	double getStockValuation(String accountId){
		
	}
	
	/* Returns an ordered Map of all account ID's and their cash balances. */
	TreeMap<String,Double> getCashBalances(){
		
	}
	
	/* Returns an ordered Map of account IDs and number of shares for each
	account that owns the stock identified by the ticker parameter. */
	TreeMap<String,Integer> getStockOwners(String ticker){
		
	}
	
	/* Returns a list of all Portfolios, sorted in descending order
	by their cash balances */
	List<Portfolio> getPortfoliosByCashBalances(){
		
	}
	
	/* Returns a list all investments, sorted in ascending order by
	ticker symbols.*/
	List<Investment> getStocksByTicker(){
		
	}
}
