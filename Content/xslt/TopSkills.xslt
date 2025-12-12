<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:er="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"
        version="1.0">

    <xsl:output method="html" indent="yes" encoding="UTF-8"/>

   
    <xsl:template match="/">
        <html>
            <head>
                <title>Top Skills by Damage</title>

                <style>
                    body {
                    font-family: Arial, sans-serif;
                    padding: 30px;
                    background: #f5f5f5;
                    }
                    h1 {
                    text-align: center;
                    color: #2c3e50;
                    margin-bottom: 30px;
                    }
                    table {
                    width: 70%;
                    margin: auto;
                    border-collapse: collapse;
                    background: white;
                    border-radius: 8px;
                    overflow: hidden;
                    box-shadow: 0 3px 10px rgba(0,0,0,0.15);
                    }
                    th {
                    background: #34495e;
                    color: white;
                    padding: 12px;
                    text-transform: uppercase;
                    font-size: 15px;
                    }
                    td {
                    padding: 12px;
                    text-align: center;
                    border-bottom: 1px solid #eeeeee;
                    font-size: 15px;
                    }
                    tr:hover {
                    background: #ecf0f1;
                    }
                </style>

            </head>

            <body>
                <h1>Top Skills triés par Dégâts</h1>

                <table>
                    <tr>
                        <th>Nom du Skill</th>
                        <th>Type</th>
                        <th>Dégâts</th>
                    </tr>

                    <!-- tri des skills par damage décroissant -->
                    <xsl:apply-templates select="er:gameData/er:skills/er:skill">
                        <xsl:sort select="er:Damage" data-type="number" order="descending"/>
                    </xsl:apply-templates>

                </table>
            </body>
        </html>
    </xsl:template>

    
    <xsl:template match="er:skill">
        <tr>
            <td><xsl:value-of select="er:name"/></td>
            <td><xsl:value-of select="er:type"/></td>
            <td><xsl:value-of select="er:Damage"/></td>
        </tr>
    </xsl:template>

</xsl:stylesheet>
