<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <html>
      <head>
        <title>Investing Information</title>
      </head>
      <body>

        <h1>Investment Account</h1>
        <table bgcolor="#CCE6FF" border="1" cellpadding="1" cellspacing="0" width="910">
          <xsl:for-each select="accounts/account">
            <tr>
              <th>
                ID
              </th>
              <th>
                Name
              </th>
            </tr>
            <tr>
              <td align ="center">
                <xsl:value-of select="id"/>
              </td>
              <td align ="center">
                <xsl:value-of select="name"/>
              </td>
            </tr>
            <xsl:for-each select="investment">
              <tr>
                <td colspan="2">
                  <b>
                    Transactions for invesment <xsl:value-of select="@ticker"/>:
                  </b>
                </td>
              </tr>
              <tr align ="center">
                <td colspan="2">
                  <table width="100%" border="0">
                    <th>Date</th>
                    <th>Price</th>
                    <th>Shares</th>
                    <th>Value</th>
                    <xsl:for-each select="transaction">
                      <tr align="center">
                        <td width="300">
                          <xsl:value-of select="date"/>
                        </td>
                        <td width="200">
                          <xsl:value-of select="price"/>
                        </td>
                        <td width="150">
                          <xsl:value-of select="numShares"/>
                        </td>
                        <td width="200">
                          <xsl:value-of select="format-number(price * numShares, '#,###.00')"/>
                        </td>
                      </tr>
                    </xsl:for-each>
                    <tr>
                      <td></td>
                      <td align ="center">
                        <b>
                          Total Shares Processed: <xsl:value-of select= "count(transaction/numShares)"/> |
                        </b>
                      </td>
                      <td align ="center">
                        <b>
                          <xsl:value-of select="sum(transaction/numShares)"/>
                        </b>
                      </td>
                      <td ></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </xsl:for-each>
          </xsl:for-each>
        </table>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>