using UnityEngine;

public class Door : MonoBehaviour
{
    public string keyName = "HouseKey";
    public Transform doorRoot;
    public float openAngle = 90f;
    public float openSpeed = 3f;

    [Header("Door Sounds")]
    public AudioSource audioSource;
    public AudioClip doorSound;

    private bool isOpen = false;
    private bool playerNear = false;
    private bool unlocked = false;

    private Quaternion closedRot;
    private Quaternion openRot;

    void Start()
    {
        closedRot = doorRoot.localRotation;
        openRot = closedRot * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!unlocked)
            {
                PlayerInventory inv = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();

                if (inv.HasKey(keyName))
                {
                    unlocked = true;
                    ToggleDoor();
                }
                else
                {
                    Debug.Log("Нужен ключ: " + keyName);
                }
            }
            else
            {
                ToggleDoor();
            }
        }

        if (isOpen)
            doorRoot.localRotation = Quaternion.Lerp(doorRoot.localRotation, openRot, openSpeed * Time.deltaTime);
        else
            doorRoot.localRotation = Quaternion.Lerp(doorRoot.localRotation, closedRot, openSpeed * Time.deltaTime);
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;

        if (audioSource && doorSound)
        {
            audioSource.PlayOneShot(doorSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}
