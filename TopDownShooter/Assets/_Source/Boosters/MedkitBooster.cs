using CharacterSystem;

namespace Boosters
{
    public class MedkitBooster : ABooster
    {
        protected override void AddBoost(CharacterView characterView)
        {
            characterView.Health += (int)_scale;
        }

        protected override void RemoveBoost(CharacterView characterView) { }
    }
}