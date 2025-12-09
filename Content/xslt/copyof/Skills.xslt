<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">

    <xsl:output method="xml"/>

    <xsl:template match="/">
        <xsl:copy-of select="er:initialState/er:skills" />
    </xsl:template>

</xsl:stylesheet>
