<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">




    <xsl:output method="xml" indent="yes"/>
    <xsl:template match="/">
        <Statistiques>

            <!--nombre total de fragments-->
            <fragments>
                <totalFragments>
                    <xsl:value-of
                            select="count(er:initialState/er:locations/er:location/er:fragment)"/>
                </totalFragments>
            </fragments>

            <!--compétence ennemis-->
            <enemySkills>
                <totalEnemySkills>
                    <xsl:value-of
                            select="count(er:initialState/er:enemies/er:enemy/er:skills/er:skillRef)"/>
                </totalEnemySkills>
            </enemySkills>

            <!--enemies faciles-->
            <enemyDifficulty>
                <enemiesFaciles>
                    <xsl:value-of
                            select="count(er:initialState/er:enemies/er:enemy[er:difficulty &lt;= 2])"/>
                </enemiesFaciles>
            </enemyDifficulty>

            <!--locations importantes -->
            <locationStats>
                <nombreStart>
                    <xsl:value-of
                            select="count(er:initialState/er:locations/er:location[er:isStartLocation='true'])"/>
                </nombreStart>
                <nombreFinal>
                    <xsl:value-of
                            select="count(er:initialState/er:locations/er:location[er:isFinalLocation='true'])"/>
                </nombreFinal>
            </locationStats>

            <!--repartition des types de skills -->
            <skillsStats>
                <nombreBasic>
                    <xsl:value-of
                            select="count(er:initialState/er:skills/er:skill[er:type='BASIC'])"/>
                </nombreBasic>
                <nombreComplex>
                    <xsl:value-of
                            select="count(er:initialState/er:skills/er:skill[er:type='COMPLEX'])"/>
                </nombreComplex>
            </skillsStats>

        </Statistiques>
    </xsl:template>

</xsl:stylesheet>