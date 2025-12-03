using System;
using EchoReborn.Battle;

namespace EchoReborn
{
    class BattleSystemTest
    {
        static void Main(string[] args)
        {
            // Create player and enemy
            Player player = new Player("Hero", 100);
            Enemy enemy = new Enemy("Goblin", 50);

            // Start battle
            BattleSystem battle = new BattleSystem(player, enemy);
            battle.StartBattle();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}