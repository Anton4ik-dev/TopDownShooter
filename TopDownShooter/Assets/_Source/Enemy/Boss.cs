using Clues;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Computer computer;

    private void OnDisable()
    {
        computer.IsBossDead = true;
    }
}
