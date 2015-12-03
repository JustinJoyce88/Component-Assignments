// Team: Alberto Fortuny & Justin Joyce
package cop4814.asg3;

import java.util.LinkedList;
import java.util.List;

/**This class includes the following methods. Portfolio(String portfolioId2, double cashBalance2, List<Investment> holdings2),
 * addInvestment(Investment inv), compareTo(Portfolio arg0), getId(), getCashBalance(),
 * getHoldings(), getStockValues()
 * 
 * 
 */
public class Portfolio implements Comparable<Portfolio>
{
    private final String portfolioId;
    private final double cashBalance;
    private List<Investment> holdings = new LinkedList<>();
    
    /**Constructor method for Portfolio class
     * 
     * @param portfolioId2
     * @param cashBalance2
     * @param holdings2 
     */
    public Portfolio(String portfolioId2, double cashBalance2, List<Investment> holdings2)
    {
        portfolioId = portfolioId2;
        cashBalance = cashBalance2;
        holdings = holdings2;
    }
    /**method used to add an investment to the list
     * 
     * @param inv 
     */
    void addInvestment(Investment inv) 
    {
        holdings.add(inv);
    }
    /**Compares incoming portfolio's id with current portfolio's id. Returns a positive value
     * if param follows after current portfolio, negative if param precedes current portfolio,
     * and zero if equal. 
     * 
     * @param arg0
     * @return int. 
     */
    @Override
    public int compareTo(Portfolio arg0) 
    {
    	return Double.compare(cashBalance, arg0.getCashBalance());
    }
    /**getter for porfolioId
     * 
     * @return portfolioId;
     */
    public String getId() 
    {
        return portfolioId;
    }
    /**getter for cashBalance
     * 
     * @return cashBalance;
     */
    public double getCashBalance() 
    {
        return cashBalance;
    }
    /**getter for investment list
     * 
     * @return holdings;
     */
    public List<Investment> getHoldings() 
    {
        return holdings;
    } 
    /**getter for the sum of stock values in an investment. Returns the sum as a
     * double.
     * 
     * @return sum;
     */
    public double getStockValues()
    {
        double sum =0.0;
        for (Investment inv : holdings)
        {
            sum+= inv.getSum();
        }
        return sum;        
    }
}
