using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Renderer _backgroundRenderer;
    private Transform _camera;
    public Vector3 offset;
    public float _speed;
    void Update()
    {
        _camera= GameObject.FindGameObjectWithTag("MainCamera").transform;
        _backgroundRenderer.material.mainTextureOffset += new Vector2(_speed * Time.deltaTime,0);
        transform.position = new Vector3(_camera.transform.position.x,0f + offset.y,0f + offset.z);
    }
}
