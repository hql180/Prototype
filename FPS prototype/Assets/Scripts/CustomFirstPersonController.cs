using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;


public class CustomFirstPersonController : MonoBehaviour
{
    [Tooltip("Walking Speed")]
    public float walkSpeed = 6f;

    [Tooltip("Running Speed")]
    public float runSpeed = 12f;

    [Tooltip("Jump Height")]
    public float jumpHeight = 10f;

    public float gravity = 20f;

    // Standard FPS mouseLook class used to rotate camera
    [SerializeField] private MouseLook mouseLook;

    [SerializeField] private HeadBobber headBob = new HeadBobber();

    // Boolean to check whether player is running or walking
    private bool isRunning = false;

    // Direction of character movement
    private Vector3 moveDirection = Vector3.zero;

    // Character controller component
    private CharacterController controller;

    // Reference to first person camera
    private Camera FPCamera;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        FPCamera = Camera.main;
        mouseLook.Init(transform, FPCamera.transform);
        headBob.SetUp(FPCamera);
	}
	
	// Update is called once per frame
	void Update ()
    {
        mouseLook.LookRotation(transform, FPCamera.transform);
	    if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKey("left shift"))
            {
                moveDirection *= runSpeed;
            }
            else
                moveDirection *= walkSpeed;

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
            }
        }
        
        headBob.BobHead();

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

       
	}

    void OnGUI()
    {

    }
}
