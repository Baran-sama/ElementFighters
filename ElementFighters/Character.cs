using System;
using System.Collections.Generic;

namespace ElementFighters
{
    abstract class Character
    {
        public string Name { get; protected set; }
        public int HP { get; protected set; }
        public int MaxHP { get; protected set; }
        public int NormalAttackDamage { get; protected set; }
        public int SpecialAttack1Damage { get; protected set; }
        public int SpecialAttack2Damage { get; protected set; }
        public int UltimateMoveDamage { get; protected set; }
        public bool UltimateMoveUsed { get; set; } = false;
        public Dictionary<string, int> Cooldowns { get; protected set; } = new Dictionary<string, int>();
        public List<string> MoveNames { get; protected set; } = new List<string>();

        public Character()
        {
            MoveNames.Add("Normal Attack");
            MoveNames.Add("Special Attack 1");
            MoveNames.Add("Special Attack 2");
            MoveNames.Add("Ultimate Move");
        }

        public abstract void NormalAttack(Character opponent);
        public abstract void SpecialAttack1(Character opponent);
        public abstract void SpecialAttack2(Character opponent);
        public abstract void UltimateMove(Character opponent);

        public virtual void DisplayMoves()
        {
            Console.WriteLine($"{Name}'s Moves:");
            for (int i = 0; i < MoveNames.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)} - {MoveNames[i]}");
            }
        }

        public void ReduceHP(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
        }

        public void ReduceCooldowns()
        {
            var keys = new List<string>(Cooldowns.Keys);
            foreach (var key in keys)
            {
                if (Cooldowns[key] > 0)
                {
                    Cooldowns[key]--;
                }
            }
        }
    }
}
