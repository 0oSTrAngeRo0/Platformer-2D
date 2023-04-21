using UnityEngine;
using State.PlayerControl;
using UnityEngine.InputSystem;

public class GrabCircleController : MonoBehaviour
{
    [Header("Information")]
    [SerializeField, ReadOnly] private Paramaters _Patamaters;
    [SerializeField, ReadOnly] private GameObject _Circle;
    [SerializeField, ReadOnly] private GameObject _Direction;
    [SerializeField, ReadOnly] private GrabItemController _GrabItem;

    [Header("Inspect Information")]
    [SerializeField, ReadOnly] private bool isCircleShow;
    [SerializeField, ReadOnly] private Vector2 _GrabDirection;

    [Header("Config")]
    public float Radius;
    public LayerMask GrabMask;
    public float CentralAngle;
    public int CastCount;

    private bool IsCircleShow
    {
        get { return isCircleShow; }
        set
        {
            if (value != isCircleShow)
            {
                isCircleShow = value;
                _Circle.SetActive(value);
                _Direction.SetActive(value);
            }
        }
    }
    private void Start()
    {
        _Patamaters = GetComponentInParent<PlayerController>()._Paramaters;
        _Circle = transform.Find("Circle").gameObject;
        _Direction = transform.Find("Direction").gameObject;
    }
    private void GrabUpdate()
    {
        //Update Direction
        //可能会引起GC
        _Direction.transform.eulerAngles = new(0, 0, Mathf.Rad2Deg * Mathf.Atan2(_GrabDirection.y, _GrabDirection.x));

        //Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _GrabDirection, Radius, GrabMask.value);
        if (hit)
        {
            GrabItemController tempItem = hit.collider.GetComponent<GrabItemController>();
            if (_GrabItem != tempItem)
            {
                //Recover Last Item
                if (_GrabItem != null)
                {
                    _GrabItem._GrabState = GrabItemController.GrabState.Defalut;
                }

                //Select Current Items
                _GrabItem = hit.collider.GetComponent<GrabItemController>();
                _GrabItem._GrabState = GrabItemController.GrabState.Selected;
                _Patamaters.GrabTarget = _GrabItem.transform.position;
            }
        }
        else if (_GrabItem != null)
        {
            //Recover Last Item
            _GrabItem._GrabState = GrabItemController.GrabState.Defalut;
            _GrabItem = null;
            _Patamaters.GrabTarget.Set(0, 0);
        }
    }
    private void DoGrab()
    {
        if (_GrabItem != null)
        {
            _GrabItem._GrabState = GrabItemController.GrabState.Active;
            _Patamaters.IsGrab = true;
            //_Player.transform.position = _GrabItem.transform.position;
            //_GrabItem._GrabState = GrabItemController.GrabState.Defalut;
            _GrabItem = null;
        }
    }
    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsCircleShow = true;
            _GrabDirection = context.ReadValue<Vector2>();
            GrabUpdate();
        }
        else if (context.performed)
        {
            _GrabDirection = context.ReadValue<Vector2>();
            GrabUpdate();
        }
        else if (context.canceled)
        {
            IsCircleShow = false;
            DoGrab();
        }
    }
}
