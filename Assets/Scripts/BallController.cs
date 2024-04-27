using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private BoxCollider2D _collider;

    private float _duration = 5f;

    [SerializeField]
    private LayerMask _borderLayer;

    [HideInInspector]
    public UnityEvent IsBallHit;

    private void Awake()
    {
        IsBallHit = new UnityEvent();
    }

    private void Start()
    {
        //_rb.AddForce(Vector2.down * _duration);
        _rb.velocity = Vector2.down * _duration;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            if (_collider != null)
                _collider.enabled = false;

            _rb.isKinematic = true;
        }
    }

}
