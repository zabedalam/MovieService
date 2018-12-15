<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:c="http://my.company.com">

  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    
    
      <xsl:apply-templates select="//c:commercial"/>
   
  </xsl:template>

  <xsl:template match="c:commercial">

    <div style=" display: flex;   margin:15px; padding-left:2%; box-shadow: 0 4px 15px 0 rgba(0, 0, 0, 0., 0 6px 6px 0 rgba(0, 0, 0, .3); padding-bottom:5px; background-color: lightgreen;  width:20%">

      <div >

        <p style="padding-top:15px; font-size:20px; font-weight:bold;">
          Company Name: <span style="color:#ff0000">
            <xsl:value-of select="@company"/>
          </span>
          <br />
        </p>

        <p>
          Website:
          <a style="text-decoration: none" href="">
            <span style="color:#ff0000">
              <xsl:value-of select="c:webpage"/>
            </span>
          </a>
          <br/>
        </p>

        <p>
          Address: <span style="color:#ff0000">
            <xsl:value-of select="c:address/c:streetandno"/>
            <br/>
            <xsl:value-of select="c:address/c:town"/>
            <span>, </span>
            <xsl:value-of select="c:address/c:country"/>
          </span>
          <br />
        </p>

        <p>
          Telephone: <span style="color:#ff0000">
            <xsl:value-of select="c:telephone"/>
          </span>
          <br />
        </p>
      </div>

      <div style="padding-top:40px">
        <p>
          Logo: <span style="color:#ff0000">

            <img width="100px" height="100px">
              <xsl:attribute name="src">
                /logo/<xsl:value-of select="c:logo"/>
              </xsl:attribute>
              
            </img>
           
          </span>
          <br />
        </p>
      </div>
    </div>

  </xsl:template>
</xsl:stylesheet>