using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerFirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveMultiplier = 1.5f;
    public CharacterController controller;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f;
    public float minPitch = -90f;
    public float maxPitch = 90f;

    [Header("References")]
    public Transform cameraHolder;
    public Animator anim;

    private float xRotation = 0f;

    void Start()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
        if (anim == null) anim = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleAnimatorSpeed();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minPitch, maxPitch);
        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleAnimatorSpeed()
    {
        float v = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", Mathf.Abs(v));
    }

    void OnAnimatorMove()
    {
        float v = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(v) > 0.01f)
        {
            Vector3 delta = anim.deltaPosition * moveMultiplier;
            delta = transform.rotation * delta.normalized * delta.magnitude;
            delta.y = -0.1f;
            controller.Move(delta);
        }
    }
}
