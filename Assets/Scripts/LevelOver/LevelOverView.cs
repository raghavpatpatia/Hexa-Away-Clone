using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOverView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelOverText;
    [SerializeField] private Image levelOverImage;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;
    private LevelOverController levelOverController;
    private EventService eventService;
    public void Init(LevelOverController levelOverController, EventService eventService)
    {
        this.levelOverController = levelOverController;
        this.eventService = eventService;
    }

    private void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonClick);
        retryButton.onClick.AddListener(OnRetryButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    public void SetLevelOverText(string text) => levelOverText.text = text;
    public void SetLevelOverImage(Sprite image) => levelOverImage.sprite = image;
    private void OnContinueButtonClick()
    {
        eventService.OnContinueButtonClick.Invoke(SceneManager.GetActiveScene().buildIndex);
        this.gameObject.SetActive(false);
    }
    private void OnRetryButtonClick()
    {
        eventService.OnRetryButtonClick.Invoke(SceneManager.GetActiveScene().buildIndex);
        this.gameObject.SetActive(false);
    }
    private void OnQuitButtonClick()
    {
        eventService.OnQuitButtonClick.Invoke();
    }
    public void SetContinueButtonActive(bool isActive) => continueButton.gameObject.SetActive(isActive);
    public void SetRetryButtonActive(bool isActive) => retryButton.gameObject.SetActive(isActive);
    public void SetQuitButtonActive(bool isActive) => quitButton.gameObject.SetActive(isActive);
} 