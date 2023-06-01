using UnityEngine;

public class EnemyAnimationSystem : MonoBehaviour
{
    private int WALK_HASH = Animator.StringToHash("Walk");
    private int ATTACK_HASH = Animator.StringToHash("Attack");
    private int DEATH_HASH = Animator.StringToHash("Death");

    [SerializeField] private Animator animator;

    public void Walk(bool isWalk)=>
        animator.SetBool(WALK_HASH, isWalk);

    public void Attack() =>
        animator.SetTrigger(ATTACK_HASH);

    public void Death() =>
        animator.SetBool(DEATH_HASH,true);
}