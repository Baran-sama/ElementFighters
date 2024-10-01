using System;

namespace ElementFighters
{
    class James : Character
    {
        public James()
        {
            Name = "James";
            MaxHP = HP = 20;
            NormalAttackDamage = 4;
            SpecialAttack1Damage = 14;
            SpecialAttack2Damage = 8;
            UltimateMoveDamage = 10;
        }

        public override void NormalAttack(Character opponent)
        {
            opponent.ReduceHP(NormalAttackDamage);
        }

        public override void SpecialAttack1(Character opponent)
        {
            opponent.ReduceHP(SpecialAttack1Damage);
        }

        public override void SpecialAttack2(Character opponent)
        {
            opponent.ReduceHP(SpecialAttack2Damage);
        }

        public override void UltimateMove(Character opponent)
        {
            if (!UltimateMoveUsed)
            {
                opponent.ReduceHP(UltimateMoveDamage);
                UltimateMoveUsed = true;
            }
        }

        public override void DisplayMoves()
        {
            Console.WriteLine($"(A) Normal Attack");
            Console.WriteLine($"(T) Lightning King: Deals {SpecialAttack1Damage} damage");
            Console.WriteLine($"(J) Storm Breath: Deals {SpecialAttack2Damage} damage");
            if (!UltimateMoveUsed) Console.WriteLine($"(U)  Thunderball: Deals {UltimateMoveDamage} damage (usable once)");
        }
    }
}
