using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EchoReborn.Data.Models
{
    [Serializable]
    [XmlRoot("skills", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn")]
    public class Skills
    {
        [XmlElement("skill", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn")]
        public List<Skill> SkillsList { get; set; } = new();

        public Skills()
        {
        }

        public Skills(List<Skill> skills)
        {
            SkillsList = skills;
        }
    }
}