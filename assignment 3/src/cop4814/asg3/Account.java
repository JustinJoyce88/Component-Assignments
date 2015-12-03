package cop4814.asg3;

import java.util.Iterator;
import java.util.List;

public class Account implements Comparable<Account>, Iterable<Portfolio> {
	
	private String accountId;
	private List<Portfolio> portfolios;

	void addPortfolio(Portfolio pf){
		portfolios.add(pf);
	}
	
	@Override
	public Iterator<Portfolio> iterator() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public int compareTo(Account o) {
		// TODO Auto-generated method stub
		return 0;
	}

}
