using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EchoReborn.Model
{
    /// <summary>
    /// Représente le personnage tel que défini dans le XSD.
    /// Utilisé dans InitialState / GameState.
    /// </summary>
    [Serializable]
    [XmlType("Character", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn")]
    public class Character
    {
        // <level>
        [XmlElement("level")]
        public int Level { get; set; }

        // <experience>
        [XmlElement("experience")]
        public int Experience { get; set; }

        // <currentHealth>
        [XmlElement("currentHealth")]
        public int CurrentHealth { get; set; }

        // <maxHealth>
        [XmlElement("maxHealth")]
        public int MaxHealth { get; set; }

        // <currentMana>
        [XmlElement("currentMana")]
        public int CurrentMana { get; set; }

        // <maxMana>
        [XmlElement("maxMana")]
        public int MaxMana { get; set; }

        // <skillsId>0..*  (liste d’int)
        [XmlElement("skillsId")]
        public List<int> SkillsId { get; set; } = new List<int>();

        // ----------------------------------------------------
        // Propriétés utilitaires NON définies dans le XSD
        // (donc ignorées par la sérialisation XML)
        // ----------------------------------------------------

        /// <summary>
        /// XP nécessaire pour passer au niveau suivant.
        /// Tu peux la calculer à partir du niveau si tu veux
        /// ou la mettre à jour en chargeant le GameState.
        /// </summary>
        [XmlIgnore]
        public int ExperienceToNextLevel { get; set; }

        [XmlIgnore]
        public float HealthRatio =>
            MaxHealth > 0 ? (float)CurrentHealth / MaxHealth : 0f;

        [XmlIgnore]
        public float ManaRatio =>
            MaxMana > 0 ? (float)CurrentMana / MaxMana : 0f;

        [XmlIgnore]
        public float ExperienceRatio =>
            ExperienceToNextLevel > 0 ? (float)Experience / ExperienceToNextLevel : 0f;
    }
}
