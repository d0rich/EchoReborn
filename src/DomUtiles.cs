using System.Xml;
using System;

namespace EchoReborn;

public class DomUtiles
{
    private  XmlDocument doc;
    private XmlNode root;
    private string filename;
    
    public DomUtiles(string filename)
    {
        this.filename = filename;
        doc = new XmlDocument();
        doc.Load(filename);
        root = doc.DocumentElement;

    }
    // compteur le nombre de fois que le paramétre instnaceName: string à été déclaré 
    public int CompteurInstances(string instanceName)
    {
        
        return doc.GetElementsByTagName(instanceName).Count;

    }

    public void CreationStatistiques(String filename)
    {
        XmlDocument statsXml = new XmlDocument();
        XmlDeclaration xmlDeclaration = statsXml.CreateXmlDeclaration("1.0", "UTF-8", null);
        statsXml.AppendChild(xmlDeclaration);

        
        string ns ="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn"; 
        XmlElement root = statsXml.CreateElement("Statistiques");
       
        statsXml.AppendChild(root);
        
        root.AppendChild(this.CreerSkillStats(statsXml));
        root.AppendChild(this.CreerEnemyStats(statsXml));
        root.AppendChild(this.CreerLocationStats(statsXml));
        statsXml.Save("/home/ahcene/EchoReborn/Content/xml/Statistiques.xml");


    }

    public XmlNode CreerSkillStats(XmlDocument document)
    {
        
        XmlNode skillStats = document.CreateElement("statistiqueSkills");
        
        

        // recherche du skill avec le plus de damage 
        int max = 0;
        string maxSkillNom = "";
        XmlNodeList skills = doc.GetElementsByTagName("skill");

        foreach (XmlNode skill in skills)
        {
            string skillName = "";
            int skillDamage = 0;
            foreach (XmlNode skillFils in skill.ChildNodes)
            {
                if (skillFils.Name == "name")
                {
                    skillName = skillFils.InnerText;
                    
                }
                else if (skillFils.Name == "Damage")
                {
                    skillDamage = int.Parse(skillFils.InnerText);
                }

                
                }
            if (skillDamage > max)
            {
                max = skillDamage;
                maxSkillNom = skillName;
            }
            }
        //création du noeud nombreskills
        int skillstat = this.CompteurInstances("skill");
        XmlNode numberSkillsXml = document.CreateElement("nombreskills");
        XmlNode textenumber = document.CreateTextNode(skillstat.ToString());
        numberSkillsXml.AppendChild(textenumber);
        //création du noeud maxdamageskill
        XmlNode maxSkillDamage = document.CreateElement("maxdamageskill");
        XmlNode maxDamageSkillText = document.CreateTextNode(maxSkillNom);
        maxSkillDamage.AppendChild(maxDamageSkillText);
        
       //ajoute des noeud dans le document xml
        skillStats.AppendChild(numberSkillsXml);
        skillStats.AppendChild(maxSkillDamage);
       
        return skillStats;
    }

    public XmlNode CreerEnemyStats(XmlDocument document)
    {
        XmlNode enemyStats = document.CreateElement("enemyStatistics");

        int enemyCountValue = this.CompteurInstances("enemy");
        XmlNode enemyCountNode = document.CreateElement("nombreEnemies");
        XmlNode enemyCountText = document.CreateTextNode(enemyCountValue.ToString());
        enemyCountNode.AppendChild(enemyCountText);

        enemyStats.AppendChild(enemyCountNode);
        return enemyStats;
    }

    public XmlNode CreerLocationStats(XmlDocument document)
    {
        XmlNode locationStats = document.CreateElement("locationStatistics");

        int locationCountValue = this.CompteurInstances("location");
        XmlNode locationCountNode = document.CreateElement("nombreLocations");
        XmlNode locationCountText = document.CreateTextNode(locationCountValue.ToString());
        locationCountNode.AppendChild(locationCountText);

        locationStats.AppendChild(locationCountNode);
        return locationStats;
    }

    }
    
    
