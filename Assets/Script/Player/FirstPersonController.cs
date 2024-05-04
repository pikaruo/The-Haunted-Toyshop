using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private bool Sneaking = false;
    private float xRotation;

    [Header("Komponen Yang Dibutuhkan")]
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController Controller;
    [SerializeField] private Transform Player;
    [Space]

    [Header("Parameter Gerakan")]
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Sensetivity;
    [SerializeField] private float Gravity = 20f;
    [Space]

    [Header("Menyelinap")]
    [SerializeField] private bool Sneak = true;
    [SerializeField] private float SneakSpeed;

    public bool ActivityDevice = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {

        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if(ActivityDevice == false){

        MovePlayer();
        MoveCamera();

        }


        if (Input.GetKey(KeyCode.LeftControl) && Sneak)
        {
            Player.localScale = new Vector3(1f, 0.5f, 1f);
            Sneaking = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Player.localScale = new Vector3(1f, 1f, 1f);
            Sneaking = false;
        }

        if (Input.GetKey(KeyCode.LeftAlt)){
            Cursor.lockState = CursorLockMode.Confined; 
        }else{
            if(ActivityDevice == true){
                Cursor.lockState = CursorLockMode.Confined; 
            }else{
                Cursor.lockState = CursorLockMode.Locked; 
            }
        }
       
    }
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);


        if (Controller.isGrounded)
        {
            Velocity.y = -1f;

            if (Input.GetKeyDown(KeyCode.Space) && Sneaking == false)
            {
                Velocity.y = JumpForce;
            }
        }
        else
        {
            Velocity.y -= -Gravity * -2f * Time.deltaTime;
        }
        if (Sneaking)
        {
            Controller.Move(MoveVector * SneakSpeed * Time.deltaTime);
        }
        else
        {
            Controller.Move(MoveVector * Speed * Time.deltaTime);
        }
        Controller.Move(Velocity * Time.deltaTime);

    }
    private void MoveCamera()
    {
        xRotation -= PlayerMouseInput.y * Sensetivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensetivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
