using UnityEngine;

public class HexagonView : MonoBehaviour
{
    [SerializeField] private HexagonType hexagonType;
    [SerializeField] private Rigidbody rb;
    public Rigidbody HexagonRigidbody { get { return rb; } }
    public HexagonType HexagonType { get { return hexagonType; } }
    private HexagonController hexagonController;

    public void Init(HexagonController hexagonController)
    {
        this.hexagonController = hexagonController;
    }

    private void Update()
    {
        hexagonController.Update();
    }

    private void OnMouseDown()
    {
        hexagonController.OnClick();
    }
}
