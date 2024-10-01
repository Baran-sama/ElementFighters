using System;

namespace ElementFighters
{
    class Melkha : Character
    {
        public Melkha()
        {
            Name = "Melkha";
            MaxHP = HP = 30;
            NormalAttackDamage = 5;
            SpecialAttack1Damage = 6;
            SpecialAttack2Damage = 7;
            UltimateMoveDamage = 12;
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
            Console.WriteLine($"(T)  Blood Magic: Deals {SpecialAttack1Damage} damage");
            Console.WriteLine($"(J) Cursed Scream: Deals {SpecialAttack2Damage} damage");
            if (!UltimateMoveUsed) Console.WriteLine($"(U) Death Magic: Deals {UltimateMoveDamage} damage (usable once)");
        }
    }
}
