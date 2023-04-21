using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment.Platform
{
    public class PlatformEffectorAdjustor : MonoBehaviour
    {
        private PlatformEffector2D _Effector;
        private BoxCollider2D _Collider;
        void Start()
        {
            _Effector = GetComponent<PlatformEffector2D>();
            _Collider = GetComponent<BoxCollider2D>();
            AdjustEffector();
        }
        public static float GetOptimumAngle(float height, float width)
        {
            //tan(alpha/2) = (��/2)/(���ľ�)
            //��=�����ľ�=��/2
            //alpha = 2*arctan(��/��)
            return 2 * Mathf.Atan2(height, width);
        }
        public void AdjustEffector()
        {
            _Effector.surfaceArc = GetOptimumAngle(_Collider.size.x, _Collider.size.y);
        }
    }
}
