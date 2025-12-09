<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">

    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <locations>
            <xsl:apply-templates select="er:initialState/er:locations/er:location"/>
        </locations>
    </xsl:template>

    <xsl:template match="er:location">
        <location>
            <id><xsl:value-of select="@id"/></id>
            <name><xsl:value-of select="er:name"/></name>
            <difficulty><xsl:value-of select="er:difficulty"/></difficulty>
            <isStartLocation><xsl:value-of select="er:isStartLocation"/></isStartLocation>
            <isFinalLocation><xsl:value-of select="er:isFinalLocation"/></isFinalLocation>

            <connectedLocationId>
                <xsl:value-of select="er:connectedLocationId"/>
            </connectedLocationId>

            <enemyEncounterId>
                <xsl:apply-templates select="er:enemyEncounterId/er:enemyRefs"/>
            </enemyEncounterId>

            <fragment>
                <id><xsl:value-of select="er:fragment/@id"/></id>
                <name><xsl:value-of select="er:fragment/er:name"/></name>
                <image><xsl:value-of select="er:fragment/er:image"/></image>
            </fragment>
        </location>
    </xsl:template>

    <xsl:template match="er:enemyRefs">
        <enemyRefs><xsl:value-of select="."/></enemyRefs>
    </xsl:template>

</xsl:stylesheet>
