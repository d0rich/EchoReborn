<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">


    <xsl:output method="xml" indent="yes"/>
    <xsl:template match="/">
        <character>
            <xsl:apply-templates select="er:initialState/er:character"/>
        </character>
    </xsl:template>

    <xsl:template match="er:character">
        <level><xsl:value-of select="er:level"/></level>
        <experience><xsl:value-of select="er:experience"/></experience>
        <currentHealth><xsl:value-of select="er:currentHealth"/></currentHealth>
        <maxHealth><xsl:value-of select="er:maxHealth"/></maxHealth>
        <currentMana><xsl:value-of select="er:currentMana"/></currentMana>
        <maxMana><xsl:value-of select="er:maxMana"/></maxMana>

        <skills>
            <xsl:apply-templates select="er:skills/er:skillRef"/>
        </skills>
    </xsl:template>

    <xsl:template match="er:skillRef">
        <skillRef><xsl:value-of select="."/></skillRef>
    </xsl:template>

</xsl:stylesheet>
