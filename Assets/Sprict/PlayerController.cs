﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>移動する時にかける力</summary>
    [SerializeField] float _speed = 3f;

    Rigidbody2D _rb = default;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h, v);
        _rb.velocity = dir.normalized * _speed;
    }

}