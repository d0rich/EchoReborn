using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EchoReborn.Data.Models;

[Serializable]
public class SkillRefs
{
    [XmlElement("SkillRefs")]
    public List<int> SkillIds { get; set; }

    public SkillRefs()
    {
        SkillIds = new List<int>();
    }
}
