using System;

namespace ElementFighters
{
    class Luke : Character
    {
        public Luke()
        {
            Name = "Luke";
            MaxHP = HP = 30;
            NormalAttackDamage = 3;
            SpecialAttack1Damage = 5;
            SpecialAttack2Damage = 10;
            UltimateMoveDamage = 10;
            Cooldowns["SpecialAttack2"] = 0;
            MoveNames[1] = "Fire Punch";
            MoveNames[2] = "Fire Breath (usable once every 3 turns)";
            MoveNames[3] = "Fireball (usable once)";
        }

        public override void NormalAttack(Character opponent)
        {
            opponent.ReduceHP(NormalAttackDamage);
            Console.WriteLine($"{Name} dealt {NormalAttackDamage} damage to {opponent.Name} with Normal Attack.");
        }

        public override void SpecialAttack1(Character opponent)
        {
            opponent.ReduceHP(SpecialAttack1Damage);
            Console.WriteLine($"{Name} dealt {SpecialAttack1Damage} damage to {opponent.Name} with Fire Punch.");
        }

        public override void SpecialAttack2(Character opponent)
        {
            if (Cooldowns["SpecialAttack2"] == 0)
            {
                opponent.ReduceHP(SpecialAttack2Damage);
                Cooldowns["SpecialAttack2"] = 3; // Cooldown for 3 turns
                Console.WriteLine($"{Name} dealt {SpecialAttack2Damage} damage to {opponent.Name} with Fire Breath.");
            }
            else
            {
                Console.WriteLine($"Fire Breath is on cooldown for {Cooldowns["SpecialAttack2"]} more turns.");
            }
        }

        public override void UltimateMove(Character opponent)
        {
            if (!UltimateMoveUsed)
            {
                opponent.ReduceHP(UltimateMoveDamage);
                UltimateMoveUsed = true;
                Console.WriteLine($"{Name} dealt {UltimateMoveDamage} damage to {opponent.Name} with Fireball.");
            }
            else
            {
                Console.WriteLine("Fireball has already been used.");
            }
        }

        public override void DisplayMoves()
        {
            // Luke can use his Fire Breath once in 3 rounds because it deals more than other spa2 and his hp is good so it would be unfair.
            Console.WriteLine($"(A) Normal Attack");
            Console.WriteLine($"(T) Fire Punch: Deals {SpecialAttack1Damage} damage");
            Console.WriteLine($"(J) Fire Breath: Deals {SpecialAttack2Damage} damage");
            if (!UltimateMoveUsed) Console.WriteLine($"(U) Fireball: Deals {UltimateMoveDamage} damage (usable once)");
        }
    }
}
