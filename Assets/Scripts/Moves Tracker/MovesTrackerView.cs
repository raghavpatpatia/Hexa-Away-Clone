using TMPro;
using UnityEngine;

public class MovesTrackerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI movesText;
    private MovesTrackerController movesTrackerController;
    public void Init(MovesTrackerController movesTrackerController)
    {
        this.movesTrackerController = movesTrackerController;
    }
    public void SetMovesText(int amount) => movesText.text = amount.ToString();
}