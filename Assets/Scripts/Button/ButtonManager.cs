using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : IDisposable
{
    private EventService eventService;
    public ButtonManager(EventService eventService)
    {
        this.eventService = eventService;
        SubscribeEvents();
    }
    private void SubscribeEvents()
    {
        eventService.OnContinueButtonClick.AddListener(OnContinueButtonClick);
        eventService.OnRetryButtonClick.AddListener(OnRetryButtonClick);
        eventService.OnQuitButtonClick.AddListener(OnQuitButtonClick);
    }
    private void OnContinueButtonClick(int scene)
    {
        SceneManager.LoadScene(scene + 1);
    }

    private void OnRetryButtonClick(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    private void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void UnsubscribeEvents()
    {
        eventService.OnContinueButtonClick.RemoveListener(OnContinueButtonClick);
        eventService.OnRetryButtonClick.RemoveListener(OnRetryButtonClick);
        eventService.OnQuitButtonClick.RemoveListener(OnQuitButtonClick);
    }

    public void Dispose() => UnsubscribeEvents();
}