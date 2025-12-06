using System;
using EchoReborn.Battle;
using EchoReborn.UI.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EchoReborn.UI;
public class BattleUI
{
    public enum UiState
    {
        CharacterEnteringBattle,
        EnemyEnteringBattle,
        Battle,
        Victory,
        Defeat
    }
    private static TimeSpan ENTERING_DURATION = TimeSpan.FromSeconds(2);
    
    public UiState State { get; private set; } = UiState.CharacterEnteringBattle;
    public bool IsLastBattle {get; private set;} = false;
    private readonly Character _character;
    private Enemy _enemy;
    private BattleSystem _battleSystem;
    private SpriteFont _font = GameFonts.ButtonFont;

    private TimeSpan _enteringTimer = TimeSpan.Zero;
    private readonly LevelDiamond _charlevel;
    private LevelDiamond _enemylevel;
    private readonly HpBar _hpBar;
    private HpBar _enemyHpBar;
    private readonly EnergyBar _energyBar;
    private readonly XpBar _xpBar;
    private readonly Rectangle _frameRect = new Rectangle(0, 530, 1280, 300);

    private SkillsList _skillsList;

    public BattleUI(Character character)
    {
        if (character.Animations == null)
        {
            character.Animations = new UI.Characters.WandererMagicianAnimation();
            character.Animations.Position = new Vector2(200, 200);
            character.Animations.Scale = 3;
        }

        _character = character;

        // Layout
        int barSpacing = 8;

        _charlevel = new LevelDiamond(new Vector2(60, 580), character.Level);
        Vector2 barsPsn = new Vector2(160, 580);
        _hpBar = new HpBar(barsPsn, character);
        _energyBar = new EnergyBar(barsPsn + new Vector2(0, RessourceBar.Size.Y + barSpacing), character);
        _xpBar = new XpBar(barsPsn + new Vector2(0, 2 * (RessourceBar.Size.Y + barSpacing)), character);
        _skillsList = new SkillsList(
            position: new Vector2(400, 580),
            skills: character.Skills,
            onSkillButtonClicked: (skill) =>
            {
                if (_battleSystem?.State == BattleEtape.PENDING_PLAYER)
                    _battleSystem.AcceptPlayerAction(skill);
            });
        
        PlayCharacterEnteringAnimation();
    }

    public bool CanInitiateNewBattle => !IsLastBattle && (State == UiState.Victory || (State == UiState.Battle && _enemy == null));

    public void NewBattle(Enemy enemy, BattleSystem battleSystem, bool isLastBattle = false)
    {
        IsLastBattle = isLastBattle;
        if (!CanInitiateNewBattle)
            throw new InvalidOperationException("Cannot initiate a new battle at this time.");
        _enemy = enemy;
        _battleSystem = battleSystem;
        
        if (enemy.Animations == null)
        {
            enemy.Animations = new UI.Characters.PlantAnimation();
            enemy.Animations.FaceLeft();
            enemy.Animations.Position = new Vector2(900, 200);
            enemy.Animations.Scale = 3;
        }
        
        _enemylevel = new LevelDiamond(new Vector2(1260, 580), enemy.Level);
        _enemyHpBar = new HpBar(_hpBar.Position + new Vector2(800, 0), enemy);
        PlayEnemyEnteringAnimation();
    }

    public void Update(GameTime gameTime)
    {
        _enteringTimer += gameTime.ElapsedGameTime;
        _skillsList.Update();
        if (_enteringTimer > ENTERING_DURATION)
        {
            switch (State)
            {
                case UiState.CharacterEnteringBattle:
                    FinalizeCharacterEnteringAnimation();
                    break;
                case UiState.EnemyEnteringBattle:
                    FinalizeEnemyEnteringAnimation();
                    break;
            }
        }

        switch (_battleSystem?.State)
        {
            case BattleEtape.DEFEAT:
                State = UiState.Defeat;
                break;
            case BattleEtape.VICTORY:
                State = UiState.Victory;
                break;
        }
    }

    public void Draw(GameTime gameTime)
    {
        SpriteBatch spriteBatch = DrawingContext.SpriteBatch;

        spriteBatch.Draw(
            DrawingContext.CreateTexture(Color.LightGray * 0.5f),
            _frameRect,
            Color.Wheat);


        //  Niveau 
        _charlevel.Draw();

        //  Barres de stats
        _hpBar.Draw();
        _energyBar.Draw();
        _xpBar.Draw();

        //  Label "Character"
        spriteBatch.DrawString(
            GameFonts.ButtonFont,
            "Character",
            new Vector2(20, 680),
            Color.Black);

        _enemylevel?.Draw();
        _enemyHpBar?.Draw();

        spriteBatch.DrawString(
            GameFonts.ButtonFont,
            "Enemy",
            new Vector2(1200, 680),
            Color.Black);

        if (_battleSystem?.State == BattleEtape.PENDING_PLAYER)
        {
            //  Compétences
            _skillsList.Draw();
        }

        if (State == UiState.CharacterEnteringBattle)
        {
            float progress = (float)(_enteringTimer.TotalSeconds / ENTERING_DURATION.TotalSeconds);
            _character.Animations?.Draw(gameTime, _character.Animations.Position + new Vector2(-300, 0) * (1 - progress));
        }
        else
        {
            _character.Animations?.Draw(gameTime);
        }
        if (State == UiState.EnemyEnteringBattle)
        {
            float progress = (float)(_enteringTimer.TotalSeconds / ENTERING_DURATION.TotalSeconds);
            _enemy.Animations?.Draw(gameTime, _enemy.Animations.Position + new Vector2(300, 0) * (1 - progress));
        }
        else
        {
            _enemy?.Animations?.Draw(gameTime);
        }

        if (State == UiState.Defeat)
        {
            DrawFinalLabel("DEFEAT");
        }
        else if (State == UiState.Victory && IsLastBattle)
        {
            DrawFinalLabel("VICTORY");
        }
    }
    
    private void PlayCharacterEnteringAnimation()
    {
        _enteringTimer = TimeSpan.Zero;
        State = UiState.CharacterEnteringBattle;
        if (_character.Animations != null)
        {
            _character.Animations.PlayRun();
        }
    }
    
    private void FinalizeCharacterEnteringAnimation()
    {
        if (_character.Animations != null)
        {
            _character.Animations.PlayIdle();
        }
        State = UiState.Battle;
    }
    
    private void PlayEnemyEnteringAnimation()
    {
        _enteringTimer = TimeSpan.Zero;
        State = UiState.EnemyEnteringBattle;
        if (_enemy.Animations != null)
        {
            _enemy.Animations.PlayRun();
        }
    }
    
    private void FinalizeEnemyEnteringAnimation()
    {
        if (_enemy.Animations != null)
        {
            _enemy.Animations.PlayIdle();
        }
        State = UiState.Battle;
    }

    private void DrawFinalLabel(string label)
    {
        var font = GameFonts.TitleFont;
        SpriteBatch spriteBatch = DrawingContext.SpriteBatch;
        Vector2 size = font.MeasureString(label);
        Vector2 position = new Vector2(
            (1280 - size.X) / 2,
            (720 - size.Y) / 2);

        spriteBatch.DrawString(
            font,
            label,
            position,
            Color.Red);
    }
}
