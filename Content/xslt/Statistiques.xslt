<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">

    <xsl:output method="xml" indent="yes" />

    <xsl:template match="/">
        <Statistiques>
           <!-- nombre fragment -->
            <fragments>
                <totalFragments>
                    <xsl:value-of
                            select="count(er:gameData/er:locations/er:location/er:fragment)"/>
                </totalFragments>
            </fragments>
             <!-- skills d'enemies -->
            <enemySkillsStats>
                <totalEnemySkills>
                    <xsl:value-of
                            select="count(er:gameData/er:enemies/er:enemy/er:skills/er:skillRef)"/>
                </totalEnemySkills>
            </enemySkillsStats>
           <!--les enemies -->
            <enemyDifficulty>
                <enemiesFaciles>
                    <xsl:value-of
                            select="count(er:gameData/er:enemies/er:enemy[er:difficulty &lt;= 2])"/>
                </enemiesFaciles>
            </enemyDifficulty>

            <!--nbr total locations -->
            <locationStats>
                <nombreLocations>
                    <xsl:value-of
                            select="count(er:gameData/er:locations/er:location)"/>
                </nombreLocations>
            </locationStats>

            <skillsStats>
                <nombreBasic>
                    <xsl:value-of
                            select="count(er:gameData/er:skills/er:skill[er:type='BASIC'])"/>
                </nombreBasic>

                <nombreComplex>
                    <xsl:value-of
                            select="count(er:gameData/er:skills/er:skill[er:type='COMPLEX'])"/>
                </nombreComplex>
            </skillsStats>

        </Statistiques>
    </xsl:template>

</xsl:stylesheet>
