<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  
  <!--JONATHAN PARRILLA and CESAR DOMINICI-->
  
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
      <html>
        <head>
          <title>Jonathan Parrilla Lab 3</title>
        </head>
        <body>
          <h1>Computer Science Majors</h1>
          <!--Calling the 1st template named 'student' but only to students whose major is CS:BS-->
          <xsl:apply-templates select="students/student[major='CS:BS']"/>
       </body>
      </html> 
    </xsl:template>
  
  <!--student Template-->
    <xsl:template match="student">
      ID:
      <!--Calling the 2nd template named 'id' that displays the id field--> 
      <xsl:apply-templates select="id"/>
      
      Name:
      <!--Calling the 3rd template named 'lastName' that displays the lastName field--> 
      <xsl:apply-templates select="lastName"/>,
      <!--Calling the 4th template named 'firstName' that displays the firstName field-->
      <xsl:apply-templates select="firstName"/>
      
      Date Enrolled:
      <!--Calling the 5th template named 'dateEnrolled' that displays the dateEnrolled field-->
      <xsl:apply-templates select="dateEnrolled"/>
      
      Major:
      <!--Calling the 6th template named 'major' that displays the major and catalogYear fields-->
      <xsl:apply-templates select="major"/>
      <!--An xsl if statement that will add a note in red if the catalogYear is greaterthan 2008-->
      <xsl:if test="major[@catalogYear > '2008']">
      <div style="color:red"> Must complete the Senior Project course</div>
      </xsl:if>
    <p />
    </xsl:template>
  
  <!--id Template-->
    <xsl:template match="id">
      <xsl:value-of select="."/><br />
    </xsl:template>
  
  <!--lastName Template-->
    <xsl:template match="lastName">
      <xsl:value-of select="."/>  
    </xsl:template>
  
  <!--firstName Template-->
    <xsl:template match="firstName">
      <xsl:value-of select="."/><br />
    </xsl:template>
  
  <!--dateEnrolled Template-->
    <xsl:template match="dateEnrolled">
      <xsl:value-of select="."/><br />  
    </xsl:template>
  
  <!--major Template-->
    <xsl:template match="major">
      <xsl:value-of select="."/>, Declared in <xsl:value-of select="./@catalogYear"/> 
    </xsl:template>

</xsl:stylesheet>