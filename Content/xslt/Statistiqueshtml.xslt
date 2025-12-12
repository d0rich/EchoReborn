<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">

    <xsl:output method="html" encoding="UTF-8"/>

    <xsl:template match="/">
        <html>
            <head>
                <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
                <title>Statistiques EchoReborn</title>

                <style type="text/css">
                    body { font-family: Arial; background:#f5f5f5; padding:20px; }
                    h1 { text-align:center; color:#2c3e50; }
                    h2 { color:#34495e; border-bottom:1px solid #ccc; }
                    .card { background:white; padding:15px; margin:10px 0;
                    border-radius:6px; box-shadow:0 1px 4px rgba(0,0,0,0.1); }
                    .value { font-weight:bold; color:#2980b9; }
                </style>
            </head>

            <body>
                <h1>Statistiques EchoReborn</h1>

                <div class="card">
                    <h2>Fragments</h2>
                    <p>
                        Nombre total de fragments :
                        <span class="value">
                            <xsl:value-of
                                    select="count(er:gameData/er:locations/er:location/er:fragment)"/>
                        </span>
                    </p>
                </div>

                <div class="card">
                    <h2>Compétences des ennemis</h2>
                    <p>
                        Nombre total de compétences utilisées par les ennemis :
                        <span class="value">
                            <xsl:value-of
                                    select="count(er:gameData/er:enemies/er:enemy/er:skills/er:skillRef)"/>
                        </span>
                    </p>
                </div>

                <div class="card">
                    <h2>Ennemis faciles</h2>
                    <p>
                        Nombre d'ennemis faciles :
                        <span class="value">
                            <xsl:value-of
                                    select="count(er:gameData/er:enemies/er:enemy[er:difficulty &lt;= 2])"/>
                        </span>
                    </p>
                </div>

                <!--nombre total locations -->
                <div class="card">
                    <h2>Locations</h2>
                    <p>
                        Nombre total de locations :
                        <span class="value">
                            <xsl:value-of
                                    select="count(er:gameData/er:locations/er:location)"/>
                        </span>
                    </p>
                </div>

                <div class="card">
                    <h2>Compétences (skills)</h2>
                    <p>
                        BASIC SKILLS :
                        <span class="value">
                            <xsl:value-of
                                    select="count(er:gameData/er:skills/er:skill[er:type='BASIC'])"/>
                        </span>
                        <br/>
                        COMPLEX SKILLS :
                        <span class="value">
                            <xsl:value-of
                                    select="count(er:gameData/er:skills/er:skill[er:type='COMPLEX'])"/>
                        </span>
                    </p>
                </div>

            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
