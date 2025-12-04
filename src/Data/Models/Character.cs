using System;

using System.Xml.Serialization;

namespace EchoReborn.Data.Models;
[Serializable]
[XmlRoot("character", Namespace="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn")]

public class Character
{
    [XmlElement("level")]
    public int Level { get; set; }

    [XmlElement("experience")]
    public int Experience { get; set; }

    [XmlElement("currentHealth")]
    public int CurrentHealth { get; set; }

    [XmlElement("maxHealth")]
    public int MaxHealth { get; set; }

    [XmlElement("currentMana")]
    public int CurrentMana { get; set; }

    [XmlElement("maxMana")]
    public int MaxMana { get; set; }

    [XmlElement("skills")]
    public SkillRefs Skills { get; set; }

    // Constructeur sans parametres
    public Character()
    {
        Level = 1;
        Experience = 0;
        CurrentHealth = 0;
        MaxHealth = 0;
        CurrentMana = 0;
        MaxMana = 0;
        Skills = new SkillRefs();


    }
}
