using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EchoReborn.Data.Models
{
    [Serializable]
    [XmlRoot("enemyRefs", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn")]
    public class EnemyRefs
    {
        [XmlElement("enemyRefs")]
        public List<int> EnemyIds { get; set; }

        public EnemyRefs()
        {
            EnemyIds= new List<int>();
        }
    }
}
