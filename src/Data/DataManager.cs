using Microsoft.Xna.Framework;
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
    private static readonly string _characterFilePath = "xml/Character.xml";
    private static readonly string _enemiesFilePath = "xml/Enemies.xml";
    private static readonly string _skillsFilePath = "xml/Skills.xml";

    public static bool IsInitialized { get; private set; } = false;

    public static void Initialize(ContentManager contentManager)
    {
        _contentRootPath = contentManager.RootDirectory;
        IsInitialized = true;
    }

    public static Character LoadBaseCharacter()
    {
        CheckInitialized();
        return DeserializeData<Character>(_characterFilePath);
    }

    public static List<Enemy> LoadAllEnemies()
    {
        CheckInitialized();
        return DeserializeData<Enemies>(_enemiesFilePath).Enemy.ToList();
    }

    public static List<Skill> LoadAllSkills()
    {
        CheckInitialized();
        return DeserializeData<Skills>(_skillsFilePath).Skill.ToList();
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

    private static T DeserializeData<T>(string relativePath)
    {
        CheckInitialized();
        
        string fullPath = Path.Combine(_contentRootPath, relativePath);
        
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

    private static void CheckInitialized()
    {
        if (!IsInitialized)
            throw new System.InvalidOperationException("DataManager is not initialized. Call Initialize() before accessing its properties.");
    }
}