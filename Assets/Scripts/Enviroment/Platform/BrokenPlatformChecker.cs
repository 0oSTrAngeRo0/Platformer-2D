using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment.Platform
{
    public class BrokenPlatformChecker : MonoBehaviour
    {
        private LayerMask _Mask;
        //private Collider2D _Collider;
        private BrokenPlatform _Platform;
        private void Start()
        {
            _Platform = GetComponentInParent<BrokenPlatform>();
            _Mask = _Platform.CheckerMask;
            //_Collider = GetComponent<Collider2D>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((1 << collision.gameObject.layer & _Mask.value) != 0)
            {
                _Platform.IsShake = true;                
            }
        }

    }
}
