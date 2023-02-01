using UnityEngine;

public class InputListener : MonoBehaviour
{
    private PlayerController _playerController;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        _playerController.Move(moveX, moveY);
        _playerController.Rotate();

        if(Input.GetMouseButtonDown(0))
            _playerController.Shoot();
    }

    public void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }
}