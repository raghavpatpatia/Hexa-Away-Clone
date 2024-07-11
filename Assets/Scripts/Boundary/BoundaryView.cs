using UnityEngine;
using System.Collections.Generic;

public class BoundaryView : MonoBehaviour
{
    private List<HexagonView> hexagonViews;
    private EventService eventService;
    public void Init(List<HexagonView> hexagonViews, EventService eventService)
    {
        this.hexagonViews = hexagonViews;
        this.eventService = eventService;
    }

    private void OnCollisionEnter(Collision collision)
    {
        HexagonView hexagonView = collision.gameObject.GetComponent<HexagonView>();
        if (hexagonView != null)
        {
            hexagonViews.Remove(hexagonView);
            Destroy(hexagonView.gameObject);
            OnHexagonRemoved();
        }
    }

    private void OnHexagonRemoved()
    {
        if (hexagonViews.Count == 0)
        {
            eventService.OnLevelOver.Invoke(LevelOverStatus.WON);
        }
    }
}