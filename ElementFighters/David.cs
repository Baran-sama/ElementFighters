using System;

namespace ElementFighters
{
    class David : Character
    {
        public David()
        {
            Name = "David";
            MaxHP = HP = 35;
            NormalAttackDamage = 4;
            SpecialAttack1Damage = 5;
            SpecialAttack2Damage = 6;
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
            Console.WriteLine($"(T) Stone Head: Deals {SpecialAttack1Damage} damage"); //arka sokaklardan esinlendim :D
            Console.WriteLine($"(J) Rock Spear: Deals {SpecialAttack2Damage} damage");
            if (!UltimateMoveUsed) Console.WriteLine($"(U)  Earthquake: Deals {UltimateMoveDamage} damage (usable once)");
        }
    }
}
