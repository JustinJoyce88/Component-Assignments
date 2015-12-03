// Team: Alberto Fortuny & Justin Joyce
package cop4814.asg3;

import java.text.DecimalFormat;

/**This class includes the following methods. Investment(String tick, int numSh, double shPrice),
 * equals(Object investObj), compareTo(Investment investObj), getTicker(), getNumShares(),
 * getPrice(), getSum(), toString()
 * 
 * 
 */
public class Investment implements Comparable<Investment>
{
    private final String ticker;
    private final int numShares;
    private final double price;
    /**Constructor method for Investment class
     * 
     * @param tick
     * @param numSh
     * @param shPrice 
     */
    public Investment(String tick, int numSh, double shPrice)
    {
        ticker = tick;
        numShares = numSh;
        price = shPrice;
    }
    /**Compares a passed object with the current class iteration by ticker and
     * returns true if param and current object are the same or false if not.
     * 
     * @param investObj
     * @return a boolean
     */
    @Override
    public boolean equals(Object investObj)
    {
    	Investment inv = (Investment)investObj;
        return this.getTicker().equals(inv.getTicker());
    }
    /**compareTo method to compare tickers.
     * 
     * @param investObj
     * @return boolean;
     */
    @Override
    public int compareTo(Investment investObj) 
    {
        return ticker.compareTo(investObj.getTicker());
    }
    /**getter for ticker
     * 
     * @return String;
     */
    public String getTicker() 
    {
        return ticker;
    }
    /**getter for numShares
     * 
     * @return numShares;
     */
    public int getNumShares() 
    {
        return numShares;
    }
    /**getter for price
     * 
     * @return price;
     */
    public double getPrice() 
    {
        double sum = price;
        DecimalFormat df = new DecimalFormat("##.##");      
        return Double.parseDouble(df.format(sum));
    }
    /**getter for the total cost of a specified stock
     * 
     * @return numShares * price;
     */
    public double getSum()
    {   
        return numShares * price;
    }
    /**toString method to format the output for all investments. Returns a string
     * in the correct format for output.
     * 
     * @return String.format("(%s, %d shares @ %.2f)", ticker, numShares, price);
     */
    @Override
    public String toString()
    {
        return String.format("(%s, %d shares @ %.2f)", ticker, numShares, price);
    }
}
