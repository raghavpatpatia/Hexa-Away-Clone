using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : IDisposable
{
    private LevelOverView levelOverView;
    private Sprite levelPassSprite;
    private Sprite levelFailSprite;
    private EventService eventService;

    public LevelOverController(LevelOverView levelOverView, Sprite levelPassSprite, Sprite levelFailSprite, EventService eventService)
    {
        this.levelOverView = levelOverView;
        this.levelOverView.Init(this, eventService);
        this.levelPassSprite = levelPassSprite;
        this.levelFailSprite = levelFailSprite;
        this.eventService = eventService;
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        eventService.OnLevelOver.AddListener(OnLevelComplete);
    }

    private void OnLevelComplete(LevelOverStatus status)
    {
        levelOverView.gameObject.SetActive(true);
        if (status == LevelOverStatus.WON)
        {
            levelOverView.SetLevelOverText("You Won");
            levelOverView.SetLevelOverImage(levelPassSprite);
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                levelOverView.SetQuitButtonActive(true);
                levelOverView.SetContinueButtonActive(false);
                levelOverView.SetRetryButtonActive(false);
            }
            else
            {
                levelOverView.SetQuitButtonActive(false);
                levelOverView.SetContinueButtonActive(true);
                levelOverView.SetRetryButtonActive(false);
            }
        }
        else if (status == LevelOverStatus.LOST)
        {
            levelOverView.SetLevelOverText("Not Enough Moves");
            levelOverView.SetLevelOverImage(levelFailSprite);
            levelOverView.SetContinueButtonActive(false);
            levelOverView.SetRetryButtonActive(true);
            levelOverView.SetQuitButtonActive(false);
        }
    }

    private void UnsubscribeEvents()
    {
        eventService.OnLevelOver.RemoveListener(OnLevelComplete);
    }

    public void Dispose() => UnsubscribeEvents();
}