using UnityEngine;

public class HexagonModel
{
    private HexagonType type;
    private Vector3 direction;
    private Vector3 startPosition;
    private bool isMoving = false;
    public float MoveSpeed { get; private set; }
    public float RotationSpeed { get; private set; }

    public HexagonModel(HexagonType type, Vector3 startPosition)
    {
        this.type = type;
        this.startPosition = startPosition;
        CalculateDirection();
        this.MoveSpeed = 5f;
        this.RotationSpeed = 180f;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public void SetMoving(bool moving)
    {
        isMoving = moving;
    }

    public Vector3 GetStartPosition()
    {
        return startPosition;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    private void CalculateDirection()
    {
        switch (type)
        {
            case HexagonType.UP:
                direction = new Vector3(0f, 0f, 1f);
                break;
            case HexagonType.DOWN:
                direction = new Vector3(0f, 0f, -1f);
                break;
            case HexagonType.UPPERLEFT:
                direction = new Vector3(-1f, 0f, 1f);
                break;
            case HexagonType.UPPERRIGHT:
                direction = new Vector3(1f, 0f, 1f);
                break;
            case HexagonType.LOWERLEFT:
                direction = new Vector3(-1f, 0f, -1f);
                break;
            case HexagonType.LOWERRIGHT:
                direction = new Vector3(1f, 0f, -1f);
                break;
            default:
                direction = Vector3.zero;
                break;
        }
    }
}
