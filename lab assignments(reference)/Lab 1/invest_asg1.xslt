<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  
  <!--JONATHAN PARRILLA and CESAR DOMINICI-->
  
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
      <html>
        <head>
          <title>Jonathan Parrilla and Cesar Dominici Assignment 1</title>
          <style type="text/css">
            .type1
            {
              table-layout:fixed;
              border: medium groove black;
              text-align:center;
	            width:40%;
	            padding:auto;
	            border-spacing: 1px;
              background-color:#5CB3FF;
            }
            
            .Iticker
            {
              text-align:left;
            }
            
            .investInfo
            {
              text-align:center;
              padding:auto;
              width:100%;
            }
            
          </style>
        </head>

        <body>
          <h1>Investment Account</h1>
          <xsl:apply-templates select="accounts/account"/>
       </body>
      </html> 
    </xsl:template>
    
  <!--ACCOUNT Template-->
    <xsl:template match="account">
      <table  class="type1" border="1">
        <tr>
          <th>ID</th>
          <th>Name</th>
        </tr>

        <tr>
          <td>
            <xsl:value-of select="id"/>
          </td>
          <td>
            <xsl:value-of select="name"/>
          </td>
        </tr>

        <!--Can become INVESTMENT Template-->
        <xsl:for-each select="investment">
          <tr>
            <td class="Iticker" colspan="2">
              <b>
                Investment Transaction for <xsl:value-of select="@ticker"/>:
              </b>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <table class="investInfo" border="0">
                <tr>
                  <th>Date</th>
                  <th>Price</th>
                  <th>Shares</th>
                  <th>Value</th>
                </tr>

                <!--Can become TRANSACTION Template-->
                <xsl:for-each select="transaction">
                  <tr>
                    <td>
                      <xsl:value-of select="date"/>
                    </td>
                    <td>
                      <xsl:value-of select="price"/>
                    </td>
                    <td>
                      <xsl:value-of select="numShares"/>
                    </td>
                    <td>
                      <xsl:value-of select='format-number(number(price) * number(numShares), "0,000.00")'/>
                    </td>
                  </tr>
                </xsl:for-each>
                <tr>
                  <td></td>
                  <td>
                    Total Shares Processed: <xsl:value-of select= "count(transaction/numShares)"/>
                  </td>
                  <td>
                    <xsl:value-of select="sum(transaction/numShares)"/>
                  </td>
                  <td></td>
                </tr>
              </table>
            </td>
          </tr>
          <p />
        </xsl:for-each>
    </table>
    </xsl:template>

</xsl:stylesheet>
