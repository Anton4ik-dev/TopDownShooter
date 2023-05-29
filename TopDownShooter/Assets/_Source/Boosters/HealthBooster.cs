using CharacterSystem;

namespace Boosters
{
    public class HealthBooster : ABooster
    {
        protected override void AddBoost(CharacterView characterView)
        {
            characterView.MaxHealth += _scale;
            characterView.Health += _scale;
        }

        protected override void RemoveBoost(CharacterView characterView)
        {
            characterView.MaxHealth -= _scale;
            characterView.Health -= _scale;
            gameObject.SetActive(false);
        }
    }
}