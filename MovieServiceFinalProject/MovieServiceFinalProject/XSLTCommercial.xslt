<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:c="http://my.company.com">

  <xsl:output method="xml" indent="yes"/>
  <xsl:template match="c:commercials">

    <companyInfo>
      <xsl:apply-templates select="//c:commercial"/>
    </companyInfo>
  </xsl:template>

  <xsl:template match="c:commercial">

    <xsl:variable name="count" select="position()" />
    <commercial class="ComId" id="{$count}">


      <CompanyName>
        <xsl:value-of select="@company"/>
      </CompanyName>

      <Website>
        <xsl:value-of select="c:webpage"/>
      </Website>

      <Address>
        <xsl:value-of select="c:address/c:streetandno"/>
        <!--<br/>-->
        <xsl:value-of select="c:address/c:town"/>
        <xsl:value-of select="c:address/c:country"/>
      </Address>

      <Telephone>
        <xsl:value-of select="c:telephone"/>
      </Telephone>

      <CompanyLogo>
        <xsl:value-of select="c:logo"/>
      </CompanyLogo>
    </commercial>


  </xsl:template>
</xsl:stylesheet>