public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance 
    { 
        get 
        { 
            if (instance == null)
                instance = new GameManager();

            return instance;
        }
    }
    public EventService EventService { get; private set; }
    public GameManager()
    {
        EventService = new EventService();
    }
}