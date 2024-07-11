public class EventService
{
    public EventController OnMoveDone;
    public EventController<LevelOverStatus> OnLevelOver;
    public EventController<int> OnContinueButtonClick;
    public EventController<int> OnRetryButtonClick;
    public EventController OnQuitButtonClick;
    public EventService()
    {
        OnMoveDone = new EventController();
        OnLevelOver = new EventController<LevelOverStatus>();
        OnContinueButtonClick = new EventController<int>();
        OnRetryButtonClick = new EventController<int>();
        OnQuitButtonClick = new EventController();
    }
}