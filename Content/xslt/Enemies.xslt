<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">


    <xsl:output method="xml" indent="yes"/>
    <xsl:template match="/">
        <enemies>
            <xsl:apply-templates select="er:initialState/er:enemies/er:enemy"/>
        </enemies>
    </xsl:template>

    <xsl:template match="er:enemy">
        <enemy>
            <id><xsl:value-of select="@id"/></id>
            <name><xsl:value-of select="er:name"/></name>
            <difficulty><xsl:value-of select="er:difficulty"/></difficulty>
            <maxHP><xsl:value-of select="er:maxHP"/></maxHP>
            <animationClass><xsl:value-of select="er:animationClass"/></animationClass>
            <rewardXP><xsl:value-of select="er:rewardXP"/></rewardXP>

            <skills>
                <xsl:apply-templates select="er:skills/er:skillRef"/>
            </skills>
        </enemy>
    </xsl:template>

    <xsl:template match="er:skillRef">
        <skillRef><xsl:value-of select="."/></skillRef>
    </xsl:template>

</xsl:stylesheet>
