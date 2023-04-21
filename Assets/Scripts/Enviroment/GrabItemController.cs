using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemController : MonoBehaviour
{
    public enum GrabState
    {
        Defalut,
        Selected,
        Active
    }

    [SerializeField, ReadOnly] private GrabState grabState;
    [SerializeField, ReadOnly] private Material material;

    [SerializeField] private Color _DefaultColor = Color.green;
    [SerializeField] private Color _SelectedColor = Color.blue;
    [SerializeField] private Color _ActiveColor = Color.red;

    public GrabState _GrabState
    {
        get
        {
            return grabState;
        }
        set
        {
            if (value != grabState)
            {
                grabState = value;
                switch (value)
                {
                    case GrabState.Defalut:
                        material.color = _DefaultColor;
                        break;
                    case GrabState.Selected:
                        material.color = _SelectedColor;
                        break;
                    case GrabState.Active:
                        material.color = _ActiveColor;
                        break;
                }
            }
        }
    }

    private void Start()
    {
        material = transform.Find("Mesh").GetComponent<MeshRenderer>().material;
        _GrabState = GrabState.Defalut;
        material.color = _DefaultColor;
    }

}
