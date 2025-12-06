using System;
using Microsoft.Xna.Framework;

namespace EchoReborn.Battle;

public class BattleSystem
{
    public static readonly TimeSpan TURN_DELAY = TimeSpan.FromSeconds(1.5);
    public BattleEtape State => state;
    public bool IsOver => state == BattleEtape.VICTORY || state == BattleEtape.DEFEAT;
    private Character _character;
    private Enemy enemy;

    private BattleEtape state;

    private BattleAction _pendingPlayerBattleAction = null;
    private TimeSpan _turnTimer = TimeSpan.Zero;

    public BattleSystem(Character p, Enemy e)
    {
        _character = p;
        enemy = e;
        StartBattle();
    }

    public void StartBattle()
    {
        state = BattleEtape.START;
    }

    public void Update(GameTime gameTime)
    {
        _turnTimer += gameTime.ElapsedGameTime;
        if (_turnTimer > TURN_DELAY)
        {
            switch (state)
            {
                case BattleEtape.ENEMY_ACTION_EXECUTION:
                    if (CheckEnd())
                        return;
                    state = BattleEtape.PENDING_PLAYER;
                    break;
                case BattleEtape.PLAYER_ACTION_EXECUTION:
                    if (CheckEnd())
                        return;
                    state = BattleEtape.PENDING_ENEMY;
                    break;
            }
        }
        switch (state)
        {
            case BattleEtape.START:
                StartPlayerTurn();
                break;

            case BattleEtape.PENDING_PLAYER:
                TryExecutePlayerAction();
                break;

            case BattleEtape.PENDING_ENEMY:
                EnemyTurn();
                break;
        }
    }

    public void AcceptPlayerAction(BattleAction action)
    {
        if (state != BattleEtape.PENDING_PLAYER)
        {
            return;
        }

        _pendingPlayerBattleAction = action;
    }

    private void StartPlayerTurn()
    {
        state = BattleEtape.PENDING_PLAYER;
    }

    private void TryExecutePlayerAction()
    {
        if (_pendingPlayerBattleAction == null) return;

        if (_pendingPlayerBattleAction.Target == BattleAction.TargetType.Enemy)
            _pendingPlayerBattleAction.Execute(_character, enemy);
        else
            _pendingPlayerBattleAction.Execute(_character, _character);
        _pendingPlayerBattleAction = null;
         _turnTimer = TimeSpan.Zero;
        state = BattleEtape.PLAYER_ACTION_EXECUTION;
    }
    private void EnemyTurn()
    {
        BattleAction battleAction = enemy.ChooseAction();// ici l'action est aléatoire ,on peut la changer si on veut 
        if (battleAction.Target == BattleAction.TargetType.Enemy)
            battleAction.Execute(enemy, _character);
        else
            battleAction.Execute(enemy, enemy);

        _turnTimer = TimeSpan.Zero;
        state = BattleEtape.ENEMY_ACTION_EXECUTION;
    }

    private bool CheckEnd()
    {
        if (!enemy.IsAlive)
        {
            enemy.Animations?.PlayDeath();
            state = BattleEtape.VICTORY;
            return true;
        }

        if (!_character.IsAlive)
        {
            _character.Animations?.PlayDeath();
            state = BattleEtape.DEFEAT;
            return true;
        }

        return false;
    }
}
