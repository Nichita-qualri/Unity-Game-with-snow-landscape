using UnityEngine;

public class PickupLog : MonoBehaviour
{
    public Transform holdPoint;
    public float pickupRange = 3f;

    private bool isHeld = false;
    private Rigidbody rb;
    private Collider logCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        logCollider = GetComponent<Collider>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, holdPoint.position);

        if (Input.GetKeyDown(KeyCode.E) && distance < pickupRange)
        {
            isHeld = !isHeld;

            if (isHeld)
                Pickup();
            else
                Drop();
        }

        if (isHeld)
        {
            transform.position = holdPoint.position;
            transform.rotation = holdPoint.rotation;
        }
    }

    private void Pickup()
    {
        rb.isKinematic = true;
        logCollider.enabled = false;
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    private void Drop()
    {
        rb.isKinematic = false;
        logCollider.enabled = true;
        transform.SetParent(null);
    }
}
