using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Character;
using Microsoft.Xna.Framework;

namespace Attack
{
    public class AttackController
    {
        public static bool TryAttack(
            CharacterModel attacker,
            CharacterModel target,
            bool attackerIsFacingRight,
            float deltaTime)
        {
            if(attacker.AttackTimer > 0)
            {
                attacker.AttackTimer -= deltaTime;
                return false;
            }

            var attackBounds = attacker.GetAttackBounds(attackerIsFacingRight);

            if (!attackBounds.Intersects(target.Bounds))
                return false;

            target.CurrentHealth -= attacker.AttackForce;
            target.CurrentHealth = MathHelper.Clamp(target.CurrentHealth, 0, target.MaxHealth);

            attacker.AttackTimer = attacker.AttackCooldown;
            
            return true;
        }    
    }
}