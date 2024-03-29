using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float fireForce;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int damage;

    private int _enemyLayerMask;
    
    private void Awake()
    {
        rb.AddForce(transform.up * fireForce, ForceMode2D.Impulse);
        _enemyLayerMask = (int)Mathf.Log(enemyLayer.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _enemyLayerMask)
            collision.GetComponent<IEnemy>().GetDamage(damage);

        Destroy(gameObject);
    }
}