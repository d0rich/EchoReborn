using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Content;

using EchoReborn.Data.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace EchoReborn.Data;

public static class DataManager
{
    private static string _contentRootPath;
    private static readonly string GameDataFilePath = "xml/GameData.xml";
    private static readonly string CharacterFilePath = "xml/Character.xml";
    private static readonly string EnemiesFilePath = "xml/Enemies.xml";
    private static readonly string SkillsFilePath = "xml/Skills.xml";
    private static readonly string LocationsFilePath = "xml/Locations.xml";
    private static readonly string StatistiquesFilePath = "xml/Statistiques.xml";

    public static bool IsInitialized { get; private set; } = false;

    public static void Initialize(ContentManager contentManager)
    {
        _contentRootPath = contentManager.RootDirectory;
        IsInitialized = true;
        SplitXmlDataWithDom();
        GenerateStatistiques(GameDataFilePath, StatistiquesFilePath);
    }

    public static Character LoadBaseCharacter()
    {
        CheckInitialized();
        return DeserializeData<Character>(CharacterFilePath);
    }

    public static List<Enemy> LoadAllEnemies()
    {
        CheckInitialized();
        return DeserializeData<Enemies>(EnemiesFilePath).Enemy.ToList();
    }
    
    public static Enemy LoadEnemyById(int enemyId)
    {
        return LoadAllEnemies().FirstOrDefault(e => e.Id == enemyId);
    }

    public static List<Skill> LoadAllSkills()
    {
        CheckInitialized();
        return DeserializeData<Skills>(SkillsFilePath).Skill.ToList();
    }

    public static List<Skill> LoadSkillsByIds(SkillRefs skillRefs)
    {
        return LoadSkillsByIds(skillRefs.SkillRef);
    }

    public static List<Skill> LoadSkillsByIds(Collection<int> skillIds)
    {
        CheckInitialized();
        var allSkills = LoadAllSkills();
        List<Skill> selectedSkills = new List<Skill>();

        foreach (int id in skillIds)
        {
            Skill skill = allSkills.Find(s => s.Id == id);
            if (skill != null)
            {
                selectedSkills.Add(skill);
            }
        }

        return selectedSkills;
    }
    
    public static List<Location> LoadAllLocations()
    {
        CheckInitialized();
        return DeserializeData<Locations>(LocationsFilePath).Location.ToList();
    }

    public static Location LoadLocationById(int locationId)
    {
        return LoadAllLocations().FirstOrDefault(l => l.Id == locationId);
    }
    
    private static void GenerateStatistiques(string inputXmlPath, string outputXmlPath)
    {
        CheckInitialized();

        DomUtiles dom = new DomUtiles(RessourcePath(inputXmlPath));
        dom.CreationStatistiques(RessourcePath(outputXmlPath));
    }

    private static T DeserializeData<T>(string relativePath)
    {
        CheckInitialized();
        
        using (FileStream fileStream = new FileStream(RessourcePath(relativePath, true), FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(fileStream);
        }
    }

    private static void SerializeData<T>(string assetName, T data, XmlSerializerNamespaces ns)
    {
        CheckInitialized();
        using (TextWriter writer = new StreamWriter(RessourcePath(assetName)))
        {
            var xml = new XmlSerializer(typeof(T));
            xml.Serialize(writer, data, ns);
        }
    }

    private static void SplitXmlDataWithXslt()
    {
        ApplyXsl(RessourcePath("xslt/copyof/Character.xslt", true), RessourcePath(CharacterFilePath));
        ApplyXsl(RessourcePath("xslt/copyof/Enemies.xslt", true), RessourcePath(EnemiesFilePath));
        ApplyXsl(RessourcePath("xslt/copyof/Skills.xslt", true), RessourcePath(SkillsFilePath));
        ApplyXsl(RessourcePath("xslt/copyof/Locations.xslt", true), RessourcePath(LocationsFilePath));
    }
    
    private static void SplitXmlDataWithDom()
    {
        var doc = new XmlDocument();
        doc.Load(RessourcePath(GameDataFilePath, true));

        void SaveSmallXml(string tagName, string outputPath)
        {
            XmlDocument smallXml = new XmlDocument();
            XmlDeclaration xmlDeclaration = smallXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            smallXml.AppendChild(xmlDeclaration);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
            nsManager.AddNamespace("er", "http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn");
            var sourceNode = doc.SelectSingleNode($"//er:gameData/er:{tagName}", nsManager);
            // TODO remarquer dans rapporte 
            var smallRoot = smallXml.ImportNode(sourceNode, true);
            ((XmlElement)smallRoot).SetAttribute("xmlns", "http://www.univ-grenoble-alpes.fr/l3miage/EchoReborn");
            smallXml.AppendChild(smallRoot);
            smallXml.Save(outputPath);
        }
        
        SaveSmallXml("character", RessourcePath(CharacterFilePath));
        SaveSmallXml("enemies", RessourcePath(EnemiesFilePath));
        SaveSmallXml("skills", RessourcePath(SkillsFilePath));
        SaveSmallXml("locations", RessourcePath(LocationsFilePath));
    }

    private static void ApplyXsl(string xslPath, string outputPath)
    {
        var xpathDoc = new XPathDocument(RessourcePath(GameDataFilePath));
        var xslt = new XslCompiledTransform();
        xslt.Load(xslPath);

        
        using var writer = new XmlTextWriter(outputPath, null);
        xslt.Transform(xpathDoc, null, writer);
    }
    
    private static string RessourcePath(string relativePath, bool ensureExists = false)
    {
        CheckInitialized();
        var path = Path.Combine(_contentRootPath, relativePath);
        
        if (ensureExists && !File.Exists(path))
            throw new FileNotFoundException($"Could not find file: {path}");

        return path;
    }

    private static void CheckInitialized()
    {
        if (!IsInitialized)
            throw new System.InvalidOperationException("DataManager is not initialized. Call Initialize() before accessing its properties.");
    }
}