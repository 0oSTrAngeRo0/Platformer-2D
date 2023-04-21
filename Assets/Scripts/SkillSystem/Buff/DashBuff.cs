//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Numeric;

//public class DashBuff : IBuff
//{
//    public float DashSpeed { get; set; }

//    //private CharactorInformation information;
//    //private Animator animator;
//    private PlayerController _Controller;
//    private Rigidbody2D _Rigidbody;

//    private float _PrimarySpeed;

//    private readonly static int[] _IgnoreLayers =
//    {
//        //LayerMask.NameToLayer("Enemy"),
//        //LayerMask.NameToLayer("EnemyAttack"),
//        LayerMask.NameToLayer("OneWayPlatform")
//    };

//    private readonly static int _PlayerLayer = LayerMask.NameToLayer("Player");

//    public DashBuff(float duration = 0.12f, float dashDistance=10f)
//    {
//        Duration = duration;
//        DashSpeed = dashDistance/duration;
//    }

//    public override void Start()
//    {
//        //data initialize
//        //information = Manager.GetComponent<CharactorInformation>();
//        //animator = Manager.GetComponent<Animator>();
//        _Controller = Manager.GetComponent<PlayerController>();
//        _Rigidbody = Manager.GetComponent<Rigidbody2D>();
//        _Rigidbody.velocity.Set(0, 0);
//        _Controller._MoveSpeed = _Controller._Move * DashSpeed;
//        IgnoreLayerCollision(true);
//        _Controller._IsDash = true;


//        //primarySpeed = information.MoveSpeed;
//        //information.MoveSpeed = DashSpeed;
//    }

//    public override void Stop()
//    {
//        IgnoreLayerCollision(false);
//        _Controller._IsDash = false;
//        //rigidbody.velocity  = new Vector3()

//        //animator.SetBool("Dodge", false);
//    }

//    private static void IgnoreLayerCollision(bool ignore)
//    {
//        foreach(int layer in _IgnoreLayers)
//        {
//            Physics2D.IgnoreLayerCollision(_PlayerLayer, layer, ignore);
//        }
//    }
//}
