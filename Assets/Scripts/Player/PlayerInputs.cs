using UnityEngine;
using UnityEngine.Events;

public class PlayerInputs : MonoBehaviour
{
    public event UnityAction onAim; // for change Animation
    public event UnityAction onShoot; // for PlayerShoot 

    [SerializeField] private LayerMask _aimRayMask;

    private Camera _cam;
    public Vector3 MovementDirection { get; private set; }
    public Vector3 AimDirection { get; private set; }

    private void Start()
    {
        _cam = Camera.main;;
    }

    private void Update()
    {
        SetMoveDirection();
        AimShooting();
    }
    private void SetMoveDirection()
    {
        if (Input.GetAxis(GlobalConst.HorizontalAxis) != 0 || Input.GetAxis(GlobalConst.VericalAxis) != 0)
        {
            MovementDirection = new Vector3(Input.GetAxis(GlobalConst.HorizontalAxis), 0, Input.GetAxis(GlobalConst.VericalAxis)).normalized;
        }
        else
            MovementDirection = Vector3.zero;
    }
    private void AimShooting()
    {
        if (Input.GetMouseButton(GlobalConst.RMB))
        {

            Aim();

            onAim?.Invoke();

            if (Input.GetMouseButtonDown(GlobalConst.LMB))
            {
                onShoot?.Invoke();
            }
        }
        else AimDirection = Vector3.zero;
    }
    private void Aim()
    {
        var position = GetMousePosition();
        var direction = position - transform.position;
        direction.y = 0;
        AimDirection = direction;
    }

    private Vector3 GetMousePosition()
    {
        var ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity,_aimRayMask))
        {
            return hitInfo.point;
        }
        else
            return Vector3.zero;
    }

}

