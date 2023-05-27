using UnityEngine;

namespace CharacterSystem
{
    public class CharacterAnimator
    {
        private readonly int _speedHash = Animator.StringToHash("Speed");
        private readonly int _shootHash = Animator.StringToHash("IsShooting");
        private readonly int _deadHash = Animator.StringToHash("IsDead");

        private readonly Animator _characterAnimator;

        public CharacterAnimator(Animator characterAnimator)
        {
            _characterAnimator = characterAnimator;
        }

        public void SetWalk(float x)
        {
            _characterAnimator.SetFloat(_speedHash, x);
        }

        public void SetShoot(bool isShooting)
        {
            _characterAnimator.SetBool(_shootHash, isShooting);
        }

        public void SetDead()
        {
            _characterAnimator.SetTrigger(_deadHash);
        }
    }
}