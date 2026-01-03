using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("TakeItem");
        }
    }
}
