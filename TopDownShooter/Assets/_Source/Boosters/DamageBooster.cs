using CharacterSystem;

namespace Boosters
{
    public class DamageBooster : ABooster
    {
        protected override void AddBoost(CharacterView characterView)
        {
            characterView.Damage += (int)_scale;
        }

        protected override void RemoveBoost(CharacterView characterView)
        {
            characterView.Damage -= (int)_scale;
        }
    }
}