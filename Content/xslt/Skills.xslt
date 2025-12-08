<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">

    <xsl:output method="xml"/>

    <xsl:template match="/">
        <skills>
            <xsl:apply-templates select="er:initialState/er:skills/er:skill"/>
        </skills>
    </xsl:template>

    <xsl:template match="er:skill">
        <skill>
            <id><xsl:value-of select="@id"/></id>
            <type><xsl:value-of select="er:type"/></type>
            <name><xsl:value-of select="er:name"/></name>
            <description><xsl:value-of select="er:description"/></description>
            <TargetType><xsl:value-of select="er:TargetType"/></TargetType>
            <ManaCost><xsl:value-of select="er:ManaCost"/></ManaCost>
            <HealthCost><xsl:value-of select="er:HealthCost"/></HealthCost>
            <Damage><xsl:value-of select="er:Damage"/></Damage>
            <Heal><xsl:value-of select="er:Heal"/></Heal>
            <AnimationClass><xsl:value-of select="er:AnimationClass"/></AnimationClass>
            <SkillClass><xsl:value-of select="er:SkillClass"/></SkillClass>
        </skill>
    </xsl:template>

</xsl:stylesheet>
