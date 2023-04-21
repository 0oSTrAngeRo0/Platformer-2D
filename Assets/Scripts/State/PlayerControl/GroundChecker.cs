using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.PlayerControl;
using Enviroment.Platform;

public class GroundChecker : MonoBehaviour
{
    private Paramaters _Paramaters;
    [SerializeField] private LayerMask ColliderMask;

    private void Start()
    {
        _Paramaters = GetComponentInParent<PlayerController>()._Paramaters;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1<<collision.gameObject.layer & ColliderMask.value) != 0)
        {
            //_controller._GroundPlatformEffecrtor = other.GetComponent<PlatformEffector2D>();
            _Paramaters.IsGround = true;
            if (collision.GetComponentInParent<BrokenPlatform>() != null && _Paramaters.Velocity.y<=0)
            {
                collision.GetComponentInParent<BrokenPlatform>().IsShake = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((1<<collision.gameObject.layer & ColliderMask.value) != 0)
        {
            //PlatformEffector2D effector = other.GetComponent<PlatformEffector2D>();
            //if(effector!=null)
            //{
            //    effector.colliderMask |= 1 << _controller._Layer;
            //}

            //_controller._GroundPlatformEffecrtor = null;
            _Paramaters.IsGround = false;
        }
    }
}
