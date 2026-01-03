using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource forestAudio;
    public AudioSource christmasAudio;

    [Header("Sliders")]
    public Slider forestSlider;
    public Slider christmasSlider;

    [Header("Panels")]
    public CanvasGroup menuCanvasGroup;
    public CanvasGroup musicCanvasGroup;

    [Header("Player Control")]
    public MonoBehaviour playerController;

    private bool isMenuOpen = false;

    void Start()
    {
        forestAudio.volume = forestSlider.value;
        christmasAudio.volume = christmasSlider.value;

        HideCanvas(menuCanvasGroup);
        HideCanvas(musicCanvasGroup);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        forestAudio.volume = forestSlider.value;
        christmasAudio.volume = christmasSlider.value;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (musicCanvasGroup.alpha > 0.9f)
            {
                BackToMenu();
                return;
            }
            if (isMenuOpen)
            {
                ResumeGame();
            }
            else
            {
                OpenMenuPanel();
            }
        }
    }
    public void OpenMenuPanel()
    {
        ShowCanvas(menuCanvasGroup);
        HideCanvas(musicCanvasGroup);

        if (playerController != null)
            playerController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isMenuOpen = true;
    }
    public void OpenMusicPanel()
    {
        HideCanvas(menuCanvasGroup);
        ShowCanvas(musicCanvasGroup);

        if (playerController != null)
            playerController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isMenuOpen = true;
    }
    public void BackToMenu()
    {
        HideCanvas(musicCanvasGroup);
        ShowCanvas(menuCanvasGroup);

        if (playerController != null)
            playerController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isMenuOpen = true;
    }
    public void ResumeGame()
    {
        HideCanvas(menuCanvasGroup);
        HideCanvas(musicCanvasGroup);

        if (playerController != null)
            playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isMenuOpen = false;
    }
    private void ShowCanvas(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    private void HideCanvas(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
