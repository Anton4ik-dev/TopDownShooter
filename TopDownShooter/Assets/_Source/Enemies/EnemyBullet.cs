using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float fireForce;
    [SerializeField] private LayerMask playerLayer;
    
    private int _damage;
    private int _enemyLayerMask;

    private void Awake()
    {
        rb.AddForce(transform.up * fireForce, ForceMode2D.Impulse);
        _enemyLayerMask = (int)Mathf.Log(playerLayer.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _enemyLayerMask)
            collision.GetComponent<PlayerController>().TakeDamage(_damage);

        Destroy(gameObject);
    }

    public void SetDamage(int damage) => _damage = damage;
}
