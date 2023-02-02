using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        playerController.Move(moveX, moveY);
        playerController.Rotate();

        if(Input.GetMouseButtonDown(0))
            playerController.Shoot();
    }
}