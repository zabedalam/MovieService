<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:c="http://my.company.com">

  <xsl:output method="xml" indent="yes"/>
  <xsl:template match="c:commercials">

    <!--<xsl:template match="/collection">-->
    <html>
      <body>
        <table border="1">
          <tr bgcolor ="#9abc30">
            <th>Company Name</th>
            <th>Webpage</th>
            <th>Address</th>
            <th>Director</th>
            <th>Telephone</th>

          </tr>
          <xsl:for-each select="c:commercial">
            <tr bgcolor ="#9abc66">

              <td>
                <xsl:value-of select="@company"/>
              </td>
              <td>
                <xsl:value-of select="c:webpage"/>
              </td>
              <td>
                <xsl:value-of select="c:address"/>
              </td>
              <td>
                <xsl:value-of select="c:director"/>
              </td>
              <td>
                <xsl:value-of select="c:telephones"/>
                <xsl:value-of select="c:telephone"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>