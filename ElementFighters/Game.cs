using System;
using System.Collections.Generic;

namespace ElementFighters
{
    class Game
    {
        private bool IsPlayer1Human;
        private bool IsPlayer2Human;
        private Character Player1;
        private Character Player2;
        private List<string> CombatLog;

        public Game(bool isPlayer1Human, bool isPlayer2Human, Character player1, Character player2)
        {
            IsPlayer1Human = isPlayer1Human;
            IsPlayer2Human = isPlayer2Human;
            Player1 = player1;
            Player2 = player2;
            CombatLog = new List<string>();
        }

        public void Start()
        {
            while (Player1.HP > 0 && Player2.HP > 0)
            {
                DisplayStatus();
                DisplayCombatLog();

                PlayerTurn(Player1, Player2, IsPlayer1Human);
                if (Player2.HP <= 0) break;

                DisplayStatus();
                DisplayCombatLog();

                PlayerTurn(Player2, Player1, IsPlayer2Human);
                ReduceCooldowns(Player1);
                ReduceCooldowns(Player2);
            }

            DisplayStatus();
            DisplayCombatLog();

            Console.WriteLine("Game Over!");
            if (Player1.HP > 0)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else
            {
                Console.WriteLine("Player 2 wins!");
            }
            Console.ReadKey(true);
        }

        private void DisplayStatus()
        {
            Console.Clear();
            Console.WriteLine($"{Player1.Name}'s HP: {Player1.HP}/{Player1.MaxHP}");
            Console.WriteLine($"{Player2.Name}'s HP: {Player2.HP}/{Player2.MaxHP}");
            Console.WriteLine("--------------------------------------------------");
        }

        private void DisplayCombatLog()
        {
            foreach (var log in CombatLog)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine("--------------------------------------------------");
        }

        private void PlayerTurn(Character player, Character opponent, bool isHuman)
        {
            Console.WriteLine($"{player.Name}'s turn. Choose an action:");
            DisplayCharacterMoves(player);

            while (true)
            {
                var input = isHuman ? Console.ReadKey(true).KeyChar : GetAIAction(player, opponent);
                bool validAction = true;

                switch (input)
                {
                    case 'A':
                    case 'a':
                        player.NormalAttack(opponent);
                        LogCombatAction(player, opponent, "Normal Attack", "Swoosh!");
                        break;
                    case 'T':
                    case 't':
                        player.SpecialAttack1(opponent);
                        LogCombatAction(player, opponent, "Special Attack 1", "Boom!");
                        break;
                    case 'J':
                    case 'j':
                        if (player.Cooldowns.ContainsKey("SpecialAttack2") && player.Cooldowns["SpecialAttack2"] > 0)
                        {
                            Console.WriteLine($"Special Attack 2 is on cooldown for {player.Cooldowns["SpecialAttack2"]} more turns.");
                            validAction = false;
                        }
                        else
                        {
                            player.SpecialAttack2(opponent);
                            player.Cooldowns["SpecialAttack2"] = 3;
                            LogCombatAction(player, opponent, "Special Attack 2", "Crash!");
                        }
                        break;
                    case 'U':
                    case 'u':
                        if (!player.UltimateMoveUsed)
                        {
                            player.UltimateMove(opponent);
                            LogCombatAction(player, opponent, "Ultimate Move", "Kaboom!");
                        }
                        else
                        {
                            Console.WriteLine("You can use your ultimate once. Use another move.");
                            validAction = false;
                        }
                        break;
                    default:
                        if (isHuman)
                        {
                            Console.WriteLine("Invalid input. Please choose a valid action.");
                        }
                        validAction = false;
                        break;
                }

                if (validAction) break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        private char GetAIAction(Character player, Character opponent)
        {
           

 
            Random rand = new Random();
            if (rand.NextDouble() < 0.10) // 20% sans ile degisik hamleler heyacan ıcın
            {
                return rand.Next(0, 10) == 0 ? 'a' : 't';
            }

            return 'a';
        }

        private void DisplayCharacterMoves(Character player)
        {
            player.DisplayMoves();
        }

        private void ReduceCooldowns(Character player)
        {
            player.ReduceCooldowns();
        }

        private void LogCombatAction(Character attacker, Character defender, string attackType, string soundEffect) //feedback veriyor
        {
            var actionLog = $"{attacker.Name} used {attackType} on {defender.Name}. {soundEffect}";
            var hpLog = $"{defender.Name}'s remaining HP: {defender.HP}/{defender.MaxHP}";
            Console.WriteLine(actionLog);
            Console.WriteLine(hpLog);
        }
    }
}
// hocam objektif olucagım. bildiginiz gibi ai yapmayı bilmiyorum machine learning tecrübem yok oyuna basit bir computer player ekledim calisiyor ama tabiki hayatınızda gördügünüz en iyi ai degil hatta zekide degil sadece bazen rastgale haraket ediyor heyacan katsın diye ve benimde öyle bir iddam yoktu elimden geleni yaptıgımı dusunuyorum.