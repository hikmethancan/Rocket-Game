using System;
using System.Collections;
using UdemyProject.Abstracts.Controllers;
using UnityEngine;

public class MoverWallController : WallController
{
    [SerializeField] private Vector3 direction;
    [Range(0f, 1f)] [SerializeField] private float _factor;
    [SerializeField] private float speed;

    private Vector3 _startPos;


    private const float FULL_CIRCLE = Mathf.PI * 2f;

    private void Awake()
    {
        _startPos = transform.position;
    }

    private void Start()
    {
        StartCoroutine(MoverWallCycle());
    }

    IEnumerator MoverWallCycle()
    {
        while (true)
        {
            var cycle = Time.time / speed;
            var sinWave = Mathf.Sin(cycle * FULL_CIRCLE);
            _factor = Mathf.Abs(sinWave);
            var offset = direction * _factor;
            transform.position = offset + _startPos;
            yield return null;
        }
    }
}