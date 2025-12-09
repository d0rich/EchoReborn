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
        SplitXmlData();
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
    
    private static void GenerateStatistiques(string inputXmlPath, string outputXmlPath)
    {
        CheckInitialized();

        DomUtiles dom = new DomUtiles(RessourcePath(inputXmlPath));
        dom.CreationStatistiques(RessourcePath(outputXmlPath));
    }

    private static T DeserializeData<T>(string relativePath)
    {
        CheckInitialized();
        
        string fullPath = RessourcePath(relativePath);
        
        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"Could not find XML file: {fullPath}");
        
        using (FileStream fileStream = new FileStream(fullPath, FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(fileStream);
        }
    }

    private static void SerializeData<T>(string assetName, T data)
    {
        CheckInitialized();
        // Note: XNA's ContentManager does not support saving data at runtime.
        // This method is a placeholder to indicate where serialization logic would go.
        throw new System.NotImplementedException("Serialization is not supported in XNA ContentManager.");
    }

    private static void SplitXmlData()
    {
        ApplyXsl(RessourcePath("xslt/copyof/Character.xslt"), RessourcePath(CharacterFilePath));
        ApplyXsl(RessourcePath("xslt/copyof/Enemies.xslt"), RessourcePath(EnemiesFilePath));
        ApplyXsl(RessourcePath("xslt/copyof/Skills.xslt"), RessourcePath(SkillsFilePath));
        ApplyXsl(RessourcePath("xslt/copyof/Locations.xslt"), RessourcePath(LocationsFilePath));
    }

    private static void ApplyXsl(string xslPath, string outputPath)
    {
        var xpathDoc = new XPathDocument(RessourcePath(GameDataFilePath));
        var xslt = new XslCompiledTransform();
        xslt.Load(xslPath);

        
        using var htmlWriter = new XmlTextWriter(outputPath, null);
        xslt.Transform(xpathDoc, null, htmlWriter);
    }
    
    private static string RessourcePath(string relativePath)
    {
        CheckInitialized();
        return Path.Combine(_contentRootPath, relativePath);
    }

    private static void CheckInitialized()
    {
        if (!IsInitialized)
            throw new System.InvalidOperationException("DataManager is not initialized. Call Initialize() before accessing its properties.");
    }
}