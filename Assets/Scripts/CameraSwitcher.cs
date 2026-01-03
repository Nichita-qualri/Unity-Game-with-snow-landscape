using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera tppCamera;
    public Camera fppCamera;

    private bool isFirstPerson = false;

    void Start()
    {
        tppCamera.enabled = true;
        fppCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;

            tppCamera.enabled = !isFirstPerson;
            fppCamera.enabled = isFirstPerson;
        }
    }
}
