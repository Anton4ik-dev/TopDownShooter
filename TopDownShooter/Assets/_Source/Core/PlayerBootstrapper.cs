using UnityEngine;

public class PlayerBootstrapper : MonoBehaviour
{
    [Header("PlayerSettings")]
    [SerializeField] private InputListener inputListener;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float playerSpeed;

    private void Awake()
    {
        inputListener.Construct(new PlayerController(playerSpeed, playerRb));
    }
}