// Team: Alberto Fortuny & Justin Joyce
package cop4814.asg3;

import java.util.Iterator;
import java.util.List;

/**This class includes the following methods. Account(String id, List<Portfolio> portfolio2),
 * addPortfolio(Portfolio pf), iterator(), compareTo(Account o), getId(), getPortfolios(),
 * getStockValues()
 * 
 * 
 */
public class Account implements Comparable<Account>, Iterable<Portfolio>
{   
    private final String accountId;
    private final List<Portfolio> portfolios;
    
    /**Constructor method for class Account
     * 
     * @param id
     * @param portfolio2 
     */
    public Account(String id, List<Portfolio> portfolio2)
    {
        accountId = id;
        portfolios = portfolio2;
    }
    /**Method for adding portfolios to the list.
     * 
     * @param pf 
     */
    void addPortfolio(Portfolio pf) 
    {
        portfolios.add(pf);
    }
    /**Iterates through the portfolios list and returns them.
     * 
     * @return portfolios.iterator();
     */
    @Override
    public Iterator<Portfolio> iterator() 
    {
        return portfolios.iterator();
    }
    /**Compares incoming account's id with current account's id. Returns a positive value
     * if param follows after current account, negative if param precedes current account,
     * and zero if equal.
     * 
     * @param act
     * @return int
     */
    @Override
    public int compareTo(Account act) 
    {
        return accountId.compareTo(act.getId());
    }
    /**A getter to return the accountId
     * 
     * @return accountId;
     */
    public String getId() 
    {
        return accountId;
    }
    /**A getter to return the list of portfolios
     * 
     * @return portfolios;
     */
    public List<Portfolio> getPortfolios() 
    {
        return portfolios;
    }
    /**A getter to return sum of stock values for each portfolio.
     * 
     * @return sum;
     */
    public double getStockValues()
    {
        double sum = 0;
        for(Portfolio pf : portfolios)
        {
            sum+=pf.getStockValues();
        }
        return sum;
    }
}
