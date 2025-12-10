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
    private Button _nextPageButton;
    private Button _previousPageButton;
    private int _currentPage = 0;
    private int _maxSkillsPerPage = 3;
    private bool NextPageAvailable => (_currentPage + 1) * _maxSkillsPerPage < _skills.Count;
    private bool PreviousPageAvailable => _currentPage > 0;
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
        for (int i = 0; i < _maxSkillsPerPage; i++)
        {
            int skillIndex = i + _currentPage * _maxSkillsPerPage;

            Vector2 buttonPosition = new Vector2(
                _position.X,
                _position.Y + i * (ButtonHeight + _spacing));

            Button skillButton = new Button(
                new Rectangle((int)buttonPosition.X, (int)buttonPosition.Y, ButtonWidth, ButtonHeight),
                skillIndex < _skills.Count ? _skills[skillIndex].Name : "",
                GameFonts.ButtonFont,
                () => onSkillButtonClicked(_skills[skillIndex]));

            _skillButtons.Add(skillButton);
        }

        _nextPageButton = new Button(
            new Rectangle((int)(_position.X + ButtonWidth + 10), (int)_position.Y, 100, ButtonHeight),
            "Next",
            GameFonts.ButtonFont,
            () =>
            {
                if (NextPageAvailable)
                {
                    _currentPage++;
                }
            });
        _previousPageButton = new Button(
            new Rectangle((int)(_position.X + ButtonWidth + 10), (int)(_position.Y + ButtonHeight + _spacing), 100, ButtonHeight),
            "Prev",
            GameFonts.ButtonFont,
            () =>
            {
                if (PreviousPageAvailable)
                {
                    _currentPage--;
                }
            });
    }

    public void Update()
    {
        for (int i = 0; i < _maxSkillsPerPage; i++)
        {
            int skillIndex = i + _currentPage * _maxSkillsPerPage;
            if (skillIndex >= _skills.Count)
                break;
            var button = _skillButtons[i];
            BattleAction skill = _skills[skillIndex];
            button.Update();
            button.Text = skill.Name;
        }
        _nextPageButton.Update();
        _previousPageButton.Update();
    }

    public void Draw()
    {
        for (int i = 0; i < _maxSkillsPerPage; i++)
        {
            int skillIndex = i + _currentPage * _maxSkillsPerPage;
            if (skillIndex >= _skills.Count)
                break;
            _skillButtons[i].Draw();
        }
        if (NextPageAvailable)
            _nextPageButton.Draw();
        if (PreviousPageAvailable)
            _previousPageButton.Draw();
    }
}