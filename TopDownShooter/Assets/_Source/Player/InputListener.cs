using UnityEngine;

public class InputListener : MonoBehaviour
{
    private PlayerController _playerController;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        _playerController.Move(moveX, moveY);
    }

    public void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }
}