using System;

public class MovesTrackerController : IDisposable
{
    private MovesTrackerView movesTrackerView;
    private EventService eventService;
    private int totalMoves;
    public MovesTrackerController(MovesTrackerView movesTrackerView, EventService eventService, int totalMoves)
    {
        this.movesTrackerView = movesTrackerView;
        this.movesTrackerView.Init(this);
        this.eventService = eventService;
        this.totalMoves = totalMoves;
        this.movesTrackerView.SetMovesText(totalMoves);
        Subscribeevents();
    }

    private void Subscribeevents()
    {
        eventService.OnMoveDone.AddListener(OnMoveDone);
    }

    private void OnMoveDone()
    {
        if (totalMoves > 1)
        {
            movesTrackerView.SetMovesText(--totalMoves);
        }
        else
        {
            eventService.OnLevelOver.Invoke(LevelOverStatus.LOST);
        }
    }

    private void UnsubscribeEvents()
    {
        eventService.OnMoveDone.RemoveListener(OnMoveDone);
    }

    public void Dispose() => UnsubscribeEvents();
}