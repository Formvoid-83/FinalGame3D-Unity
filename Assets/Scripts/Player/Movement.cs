using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController carController;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;
    private bool isGrounded;
    private float magnitude;
    [SerializeField]
    private float rotationSpeed;
    private float horizontalMove;
    private float verticalMove;
    private float ySpeed;
    private Vector3 moveDirection;
    private Vector3 vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
        carController = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        moveDirection= new Vector3(horizontalMove,0, verticalMove);
        moveDirection.Normalize();
        magnitude = Mathf.Clamp01(moveDirection.magnitude);
        //transform.Translate(moveDirection*speed*Time.deltaTime, Space.World);
        carController.SimpleMove(moveDirection * magnitude * speed);

        ySpeed += Physics.gravity.y * Time.deltaTime;
        
        vel= moveDirection * magnitude;
        vel.y = ySpeed;
        //transform.Translate(vel * Time.deltaTime);
        carController.Move(vel * Time.deltaTime);
        if(carController.isGrounded){
            ySpeed = -0.5f;
            isGrounded = true;
            if(Input.GetKeyDown(KeyCode.Space)){
                ySpeed = jumpSpeed;
                isGrounded = false;
            }
        }
        if(moveDirection != Vector3.zero){
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
            
        }
    }
}
