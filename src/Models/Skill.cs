using System;
using System.Xml.Serialization;

namespace EchoReborn.Models
{
    [Serializable]
    [XmlRoot("skill", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn")]
    public class Skill
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("TargetType")]
        public string TargetType { get; set; }

        [XmlElement("ManaCost")]
        public int ManaCost { get; set; }

        [XmlElement("HealthCost")]
        public int HealthCost { get; set; }

        [XmlElement("Damage")]
        public int Damage { get; set; }

        [XmlElement("Heal")]
        public int Heal { get; set; }

        [XmlElement("AnimationClass")]
        public string AnimationClass { get; set; }

        [XmlElement("SkillClass")]
        public string SkillClass { get; set; }

        // XmlSerializer requires it
        public Skill() 
        { 
        }

        public Skill(
            string id,
            string type,
            string name,
            string description,
            string targetType,
            int manaCost,
            int healthCost,
            int damage,
            int heal,
            string animationClass,
            string skillClass)
        {
            Id = id;
            Type = type;
            Name = name;
            Description = description;
            TargetType = targetType;
            ManaCost = manaCost;
            HealthCost = healthCost;
            Damage = damage;
            Heal = heal;
            AnimationClass = animationClass;
            SkillClass = skillClass;
        }
    }
}