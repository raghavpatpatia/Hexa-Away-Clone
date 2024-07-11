using UnityEngine;

public class HexagonController
{
    private HexagonView hexagonView;
    private HexagonModel hexagonModel;
    private Quaternion initialRotation;
    private EventService eventService;
    public HexagonController(HexagonView hexagonView, EventService eventService)
    {
        this.hexagonView = hexagonView;
        this.hexagonView.Init(this);
        this.hexagonModel = new HexagonModel(hexagonView.HexagonType, hexagonView.transform.position);
        initialRotation = hexagonView.transform.rotation;
        this.eventService = eventService;
    }

    public void Update()
    {
        if (hexagonModel.IsMoving())
        {
            Vector3 direction = hexagonModel.GetDirection();
            Vector3 targetPosition = hexagonView.transform.position + direction * 2f;

            Ray ray = new Ray(hexagonView.transform.position, direction);
            if (Physics.Raycast(ray, out RaycastHit hit, 50f))
            {
                if (hit.collider.gameObject.GetComponent<HexagonView>() != null)
                {
                    hexagonModel.SetMoving(false);
                    hexagonView.transform.position = hexagonModel.GetStartPosition();
                    hexagonView.transform.rotation = initialRotation;
                    hexagonView.HexagonRigidbody.velocity = Vector3.zero;
                    hexagonView.HexagonRigidbody.angularVelocity = Vector3.zero;
                    return;
                }
            }

            hexagonView.transform.position = Vector3.Lerp(hexagonView.transform.position, targetPosition, Time.deltaTime * hexagonModel.MoveSpeed);

            Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction).normalized;
            hexagonView.HexagonRigidbody.AddTorque(rotationAxis * hexagonModel.RotationSpeed);
        }
    }

    public void OnClick()
    {
        eventService.OnMoveDone.Invoke();
        if (!hexagonModel.IsMoving())
        {
            hexagonModel.SetMoving(true);
        }
        else
        {
            hexagonModel.SetMoving(false);
            hexagonView.transform.position = hexagonModel.GetStartPosition();
            hexagonView.transform.rotation = initialRotation;
        }
    }
}
