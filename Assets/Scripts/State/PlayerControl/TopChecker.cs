using State.PlayerControl;
using UnityEngine;

public class TopChecker : MonoBehaviour
{
    private Paramaters _Patamaters;
    [SerializeField] private LayerMask ColliderMask;

    void Start()
    {
        _Patamaters = GetComponentInParent<PlayerController>()._Paramaters;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & ColliderMask.value) != 0)
        {
            _Patamaters.IsTopBlocked = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & ColliderMask.value) != 0)
        {
            _Patamaters.IsTopBlocked = false;
        }
    }
}

