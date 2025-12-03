using EchoReborn.Battle;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace EchoReborn.UI.Components;

public class SkillsList
{
    private List<BattleAction> _skills;
    private List<Button> _skillButtons;
    private Vector2 _position;
    private float _spacing = 8;

    public SkillsList(
      Vector2 position, 
      IEnumerable<BattleAction> skills, 
      Action<BattleAction> onSkillButtonClicked)
    {
        _position = position;
        _skills = new List<BattleAction>(skills);
        _skillButtons = new List<Button>();

        int ButtonHeight = 30;
        int ButtonWidth = 250;

        // Create buttons for each skill
        for (int i = 0; i < _skills.Count; i++)
        {
            BattleAction skill = _skills[i];
            Vector2 buttonPosition = new Vector2(
                _position.X,
                _position.Y + i * (ButtonHeight + _spacing));

            Button skillButton = new Button(
                new Rectangle((int)buttonPosition.X, (int)buttonPosition.Y, ButtonWidth, ButtonHeight),
                skill.Name,
                GameFonts.ButtonFont,
                () => onSkillButtonClicked(skill));

            _skillButtons.Add(skillButton);
        }
    }

    public void Update()
    {
        foreach (var button in _skillButtons)
        {
            button.Update();
        }
    }

    public void Draw()
    {
        foreach (var button in _skillButtons)
        {
            button.Draw();
        }
    }
}