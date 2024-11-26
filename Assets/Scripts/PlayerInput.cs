using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerInput : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10.0f;

    [Header("Characters")]
    [SerializeField] private int defaultCharacter = 0;

    private CharacterController characterController;
    private Camera camera;
    private PlayerInput input;

    private Vector3 currentMovement;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        camera = Camera.main;
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();    
    }

    private void Move()
    {
        characterController.Move(currentMovement * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        var input = value.Get<Vector2>();

        Vector3 inputDirection = new Vector3(input.x, 0f, input.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        worldDirection.Normalize(); // Limited to correct speed when pressing multiple keys.

        currentMovement.x = worldDirection.x * speed;
        currentMovement.z = worldDirection.z * speed;
    }

    public void OnSwap()
    {
        Debug.Log("Swap");
    }
}
