using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float _speed;
    [SerializeField] Renderer _backgroundRenderer;
    void Update()
    {
        _backgroundRenderer.material.mainTextureOffset += new Vector2(_speed * Time.deltaTime,0);
    }
}
