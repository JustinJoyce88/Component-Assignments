package cop4814.asg3;

import java.util.LinkedList;
import java.util.List;

public class Portfolio implements Comparable<Portfolio> {
	
	private String portfolioId;
	private double cashBalance;
	private List<Investment> holdings = new LinkedList<>();

	
	@Override
	public int compareTo(Portfolio portfolioObj) {

		int compareId = Integer.parseInt(portfolioObj.getPortfolioId());
		
		//ascending order
		return getPortfolioIdInt() - compareId;
		
		//descending order
		//return compareId - getPortfolioIdInt();
	}


	public String getPortfolioId() {
		return portfolioId;
	}
	
	public int getPortfolioIdInt() {
		int portIdInt = Integer.parseInt(getPortfolioId());
		return portIdInt;
	}

	
	public void setPortfolioId(String portfolioId) {
		this.portfolioId = portfolioId;
	}


	public double getCashBalance() {
		return cashBalance;
	}


	public void setCashBalance(double cashBalance) {
		this.cashBalance = cashBalance;
	}


	public List<Investment> getHoldings() {
		return holdings;
	}


	public void setHoldings(List<Investment> holdings) {
		this.holdings = holdings;
	}

}
