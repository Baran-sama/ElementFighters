using System;

namespace ElementFighters
{
    class Jon : Character
    {
        public Jon()
        {
            Name = "Jon";
            MaxHP = HP = 25;
            NormalAttackDamage = 5;
            SpecialAttack1Damage = 8;
            SpecialAttack2Damage = 12;
            UltimateMoveDamage = 11;
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
            // Jon can use his Ice Age once in 3 rounds because it deals more than other spa2 and his hp is good so it would be unfair.
            Console.WriteLine($"(A) Normal Attack");
            Console.WriteLine($"(T)  Ice Bite: Deals {SpecialAttack1Damage} damage");
            Console.WriteLine($"(J) Ice Age: Deals {SpecialAttack2Damage} damage");
            if (!UltimateMoveUsed) Console.WriteLine($"(U)  Ice Storm: Deals {UltimateMoveDamage} damage (usable once)");
        }
    }
}
