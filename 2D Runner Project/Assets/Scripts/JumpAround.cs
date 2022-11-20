using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpAround : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(0.5f,2f).SetLoops(-1,LoopType.Yoyo);
    }
}
