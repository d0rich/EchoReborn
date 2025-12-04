
using System;
using System.Xml.Serialization;

namespace EchoReborn.Data.Models
{
    [Serializable]
    [XmlRoot("enemy", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn")]
    public class Enemy
    {
        // Id
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;
      
        [XmlElement("difficulty")]
        public int Difficulty { get; set; }
        
        [XmlElement("maxHP")]
        public int MaxHP { get; set; }

    
        [XmlElement("animationClass")]
        public string AnimationClass { get; set; }
       
        [XmlElement("rewardXP")]
        public int RewardXP { get; set; }

    
        [XmlElement("skills")]
        public SkillRefs Skills { get; set; }

        public Enemy()
        {
            Skills = new SkillRefs();
        }

    }
}
