using CharacterSystem;

namespace Boosters
{
    public class SpeedBooster : ABooster
    {
        protected override void AddBoost(CharacterView characterView)
        {
            characterView.MoveSpeed *= _scale;
        }

        protected override void RemoveBoost(CharacterView characterView)
        {
            characterView.MoveSpeed /= _scale;
            gameObject.SetActive(false);
        }
    }
}