using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    private EventService eventService;
    private ButtonManager buttonManager;

    private void Start()
    {
        eventService = GameManager.Instance.EventService;
        buttonManager = new ButtonManager(eventService);
        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick() => eventService.OnContinueButtonClick.Invoke(SceneManager.GetActiveScene().buildIndex);
}