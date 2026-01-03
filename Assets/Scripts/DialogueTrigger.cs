using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public string[] dialogueLines;

    private int currentLine = 0;
    private bool playerInRange = false;

    void Awake()
    {
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueUI.activeSelf)
            {
                dialogueUI.SetActive(true);
                currentLine = 0;
                dialogueText.text = dialogueLines[currentLine];
            }
            else
            {
                currentLine++;
                if (currentLine < dialogueLines.Length)
                    dialogueText.text = dialogueLines[currentLine];
                else
                    dialogueUI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueUI.SetActive(false);
            currentLine = 0;
        }
    }
}
