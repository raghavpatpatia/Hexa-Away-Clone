using UnityEngine;

public class SwitchView : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform point3;
    [SerializeField] private Transform point4;
    [SerializeField] private HexagonView hexagonViewA;
    [SerializeField] private HexagonView hexagonViewB;
    private Vector3 startA;
    private Vector3 startB;
    private float interpolateAmount;
    private bool isSwapping;
    private Rigidbody rbA;
    private Rigidbody rbB;
    private EventService eventService;

    private void Start()
    {
        eventService = GameManager.Instance.EventService;
        startA = hexagonViewA.transform.position;
        startB = hexagonViewB.transform.position;
        rbA = hexagonViewA.GetComponent<Rigidbody>();
        rbB = hexagonViewB.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isSwapping)
        {
            interpolateAmount += Time.deltaTime;
            float t = Mathf.PingPong(interpolateAmount, 1f);

            Vector3 posA = GetInterpolatedPosition(t, point4.position, point1.position, point2.position, point3.position);
            Vector3 posB = GetInterpolatedPosition(t, point2.position, point3.position, point4.position, point1.position);

            hexagonViewA.transform.position = posA;
            hexagonViewB.transform.position = posB;

            if (interpolateAmount >= 1f)
            {
                Vector3 tempPos = startA;
                startA = startB;
                startB = tempPos;
                hexagonViewA.transform.position = startA;
                hexagonViewB.transform.position = startB;
                isSwapping = false;
                interpolateAmount = 0f;
                rbA.useGravity = true;
                rbB.useGravity = true;
                rbA.constraints = RigidbodyConstraints.None;
                rbB.constraints = RigidbodyConstraints.None;
            }

        }
    }

    private Vector3 GetInterpolatedPosition(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);
        Vector3 d = Vector3.Lerp(a, b, t);
        Vector3 e = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(d, e, t);
    }

    private void OnMouseDown()
    {
        eventService.OnMoveDone.Invoke();
        if (!isSwapping)
        {
            isSwapping = true;
            rbA.useGravity = false;
            rbB.useGravity = false;
            rbA.constraints = RigidbodyConstraints.FreezePosition;
            rbB.constraints = RigidbodyConstraints.FreezePosition;
            rbA.constraints = RigidbodyConstraints.FreezeRotation;
            rbB.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

}
