using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EchoReborn.Data.Models
{
    [Serializable]
    [XmlRoot("enemies", Namespace="http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn")]
    public class Enemies
    {
        [XmlElement("enemy")]
        public List<Enemy> Items { get; set; } = new List<Enemy>();
    }
}
