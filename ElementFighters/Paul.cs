using System;

namespace ElementFighters
{
    class Paul : Character
    {
        public Paul()
        {
            Name = "Paul";
            MaxHP = HP = 28;
            NormalAttackDamage = 4;
            SpecialAttack1Damage = 6;
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
            Console.WriteLine($"(T) Wind Sword: Deals {SpecialAttack1Damage} damage");
            Console.WriteLine($"(J) Speed Attack: Deals {SpecialAttack2Damage} damage");
            if (!UltimateMoveUsed) Console.WriteLine($"(U)  Twister Winds: Deals {UltimateMoveDamage} damage (usable once)");
        }
    }
}
