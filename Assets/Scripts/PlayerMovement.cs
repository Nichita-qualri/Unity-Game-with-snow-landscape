`using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float rotationSpeed = 10f;
    public float moveMultiplier = 1.5f;

    [Header("Camera Settings")]
    public Camera mainCamera;
    public Vector3 cameraOffset = new Vector3(0, 3, -5);
    public float cameraSmooth = 5f;
    public float mouseSensitivity = 3f;
    public float minPitch = -40f;
    public float maxPitch = 80f;

    private Animator anim;
    private CharacterController controller;

    private float yaw = 0f;
    private float pitch = 20f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        if (mainCamera == null)
            mainCamera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        Quaternion camRotation = Quaternion.Euler(pitch, yaw, 0);

        if (mainCamera != null)
        {
            Vector3 desiredCamPos = transform.position + camRotation * cameraOffset;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, desiredCamPos, cameraSmooth * Time.deltaTime);
            mainCamera.transform.LookAt(transform.position + Vector3.up * 1.5f);
        }

        float v = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(v) > 0.01f)
        {
            Vector3 camForward = mainCamera.transform.forward;
            camForward.y = 0;
            camForward.Normalize();

            Quaternion targetRot = Quaternion.LookRotation(camForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
        anim.SetFloat("Speed", Mathf.Abs(v));
    }

    void OnAnimatorMove()
    {
        float v = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(v) > 0.01f)
        {
            Vector3 delta = anim.deltaPosition * moveMultiplier;

            delta.y = -0.1f;

            controller.Move(delta);
        }
    }
}
