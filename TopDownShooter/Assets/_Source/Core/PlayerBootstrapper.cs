using UnityEngine;

public class PlayerBootstrapper : MonoBehaviour
{
    [Header("PlayerSettings")]
    [SerializeField] private InputListener inputListener;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;

    private void Awake()
    {
        inputListener.Construct(new PlayerController(playerSpeed, playerRb, mainCamera, bullet, shootPoint));
    }
}