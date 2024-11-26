using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private float swapSpeed = 50.0f;
    [SerializeField] private Vector3 desiredLocalPoint = new Vector3(0, -1, 0);

    [Header("Characters")]
    [SerializeField] private GameObject[] characters;
    [SerializeField] private int defaultCharacter = 0;
    [SerializeField] private int currentCharacter = 0;

    private CharacterController characterController;
    private Camera camera;
    private Character character;

    private Vector3 currentMovement;
    private float moveSpeed;

    private void Awake()
    {
        camera = Camera.main;

        currentCharacter = defaultCharacter;
        swap();
        getCharacterInfo();
    }

    private void Update()
    {
        Move();    
    }

    private void getCharacterInfo()
    {
        character = GetComponentInParent<Character>();
        moveSpeed = character.speed;
        characterController = GetComponentInParent<CharacterController>();
    }

    private void OnMove(InputValue value)
    {
        var input = value.Get<Vector2>();

        Vector3 inputDirection = new Vector3(input.x, 0f, input.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        worldDirection.Normalize(); // Limited to correct speed when pressing multiple keys.

        currentMovement.x = worldDirection.x * moveSpeed;
        currentMovement.z = worldDirection.z * moveSpeed;
    }

    private void Move()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, desiredLocalPoint, swapSpeed * Time.deltaTime);

        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void OnSwap()
    {
        currentCharacter++;
        if (currentCharacter >= characters.Length)
        {
            currentCharacter = 0;
        }

        swap();
    }

    private void swap()
    {
        transform.SetParent(characters[currentCharacter].transform, true);

        getCharacterInfo();
    }
}
