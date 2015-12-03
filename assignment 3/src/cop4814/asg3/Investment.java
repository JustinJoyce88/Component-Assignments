package cop4814.asg3;

public class Investment implements Comparable<Investment> {
	
	private String ticker;
	private int numShares;
	private double price;

	public Investment(String tick, int numSh, double shPrice){
		ticker = tick;
		numShares = numSh;
		price = shPrice;
	}
	
	public boolean equals(Object investObj){
		
		Investment invest = (Investment)investObj;
		if(ticker.equals(invest.getTicker()))
			return true;
		return false;
	}
	
	@Override
	public int compareTo(Investment investObj) {
		
		return ticker.compareTo(investObj.getTicker());
		
		/*
		int compareShares = ((Investment)investObj).getNumShares();
		
		//ascending order
		return this.numShares - compareShares;
		
		//descending order
		//return  compareShares - this.numShares;
		 */
	}

	public String getTicker() {
		return ticker;
	}

	public void setTicker(String ticker) {
		this.ticker = ticker;
	}

	public int getNumShares() {
		return numShares;
	}

	public void setNumShares(int numShares) {
		this.numShares = numShares;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	
}
