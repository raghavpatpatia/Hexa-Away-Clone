using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [Header("Level Hexagons")]
    [SerializeField] private List<HexagonView> hexagonViews;
    
    [Header("Level Moves")]
    [SerializeField] private MovesTrackerView movesTrackerView;
    [SerializeField] private int totalLevelMoves;
    
    [Header("Boundary")]
    [SerializeField] private BoundaryView boundingBoxView;

    [Header("Level Over")]
    [SerializeField] private LevelOverView levelOverView;
    [SerializeField] private Sprite levelWonSprite;
    [SerializeField] private Sprite levelLostSprite;

    private EventService eventService;
    private List<HexagonController> hexagonControllers;
    private MovesTrackerController movesTrackerController;
    private LevelOverController levelOverController;
    private ButtonManager buttonManager;
    private void Start()
    {
        eventService = GameManager.Instance.EventService;
        Initialize();
    }

    private void Initialize()
    {
        InitializeControllers();
        movesTrackerController = new MovesTrackerController(movesTrackerView, eventService, totalLevelMoves);
        boundingBoxView.Init(hexagonViews, eventService);
        levelOverController = new LevelOverController(levelOverView, levelWonSprite, levelLostSprite, eventService);
        buttonManager = new ButtonManager(eventService);
    }

    private void InitializeControllers()
    {
        hexagonControllers = new List<HexagonController>();
        foreach (HexagonView hexagonView in hexagonViews)
        {
            hexagonControllers.Add(new HexagonController(hexagonView, eventService));
        }
    }

    private void OnDestroy()
    {
        if (movesTrackerController != null)
        {
            movesTrackerController.Dispose();
        }

        if (levelOverController != null)
        {
            levelOverController.Dispose();
        }
    }
}