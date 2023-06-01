using CharacterSystem;

namespace Boosters
{
    public class HealthBooster : ABooster
    {
        protected override void AddBoost(CharacterView characterView)
        {
            characterView.MaxHealth += (int)_scale;
            characterView.Health += (int)_scale;
        }

        protected override void RemoveBoost(CharacterView characterView)
        {
            characterView.MaxHealth -= (int)_scale;
            characterView.Health -= (int)_scale;
        }
    }
}