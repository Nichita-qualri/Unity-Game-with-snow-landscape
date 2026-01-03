using UnityEngine;

public class Campfire : MonoBehaviour
{
    public ParticleSystem fire;
    public float intensityIncrement = 0.2f;

    private ParticleSystem.MainModule fireMain;

    void Start()
    {
        fireMain = fire.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Log"))
        {
            Destroy(other.gameObject);
            fireMain.startSizeMultiplier += intensityIncrement;
            fireMain.startSpeedMultiplier += intensityIncrement;
        }
    }
}
