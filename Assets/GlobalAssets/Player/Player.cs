using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerMove), typeof(PlayerRotate))]
public class Player : MonoBehaviour
{
    private PlayerMove _move;
    private PlayerRotate _rotate;
    private PlayerRotate _rotateSmooth;
    private PlayerRotate _currentRotate;
    public static bool canMove;

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
        _rotate = GetComponents<PlayerRotate>()[0];
        Cursor.lockState = CursorLockMode.Locked;
        _currentRotate = _rotate;
    }

    private void Update()
    {
        if (canMove)
        {
            _move.Move();
            _currentRotate.Rotate();
        }
    }
}
