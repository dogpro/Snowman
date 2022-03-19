using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public Vector3 MovementDirection { get; private set; }

    private void Start()
    {
        MovementDirection = Vector3.zero;
    }

    private void Update()
    {
        SetMoveDirection();
    }
    private void SetMoveDirection()
    {
        if (Input.GetAxis(GlobalConst.HorizontalAxis) !=0 || Input.GetAxis(GlobalConst.VericalAxis) !=0)
        {
            MovementDirection = new Vector3(Input.GetAxis(GlobalConst.HorizontalAxis), 0, Input.GetAxis(GlobalConst.VericalAxis)).normalized;
        }
        else
        {
            MovementDirection = Vector3.zero;
        }
    }


}
