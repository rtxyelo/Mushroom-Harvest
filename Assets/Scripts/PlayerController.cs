using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private SpriteRenderer _spriteRenderer;

    private MoveDirection _moveDirection = MoveDirection.None;

    [SerializeField] private float _speed = 100f;

    [SerializeField]
    private ScoreCounter _scoreCounter;

    [SerializeField]
    private HitSoundBehaviour _playGameSounds;

    private Vector3 _beePosition;

    private bool _isCanMove = true;

    public Vector3 BeePosition { get => _beePosition; set => _beePosition = value; }

    [HideInInspector]
    public UnityEvent<GameObject> IsBallHit;

    private void Awake()
    {
        IsBallHit = new UnityEvent<GameObject>();

        if (TryGetComponent(out Rigidbody2D rb))
        {
            _rb = rb;
        }
        else
        {
            new NullReferenceException("Check Player RigidBody!");
        }

        if (TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            _spriteRenderer = spriteRenderer;
        }
        else
        {
            new NullReferenceException("Check Player Animator!");
        }
    }

    private void Start()
    {
        _beePosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (_moveDirection != MoveDirection.None && _isCanMove)
        {
            switch (_moveDirection)
            {
                case MoveDirection.Left:
                    MovePlayer(-1);
                    break;

                case MoveDirection.Right:
                    MovePlayer(1);
                    break;

                default:
                    break;
            }
        }
    }

    private void MovePlayer(int moveDir)
    {
        _rb.velocity = new Vector2(moveDir * Time.deltaTime * _speed, 0f);
    }

    public void ChangeMoveSide(int moveDirection)
    {
        _moveDirection = (MoveDirection)moveDirection;
        _rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Mushroom"))
            {
                _playGameSounds.PlayCoinSound();
                _scoreCounter.IncreaseScore();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Poison"))
            {
                _playGameSounds.PlayHitSound();
                _scoreCounter.DecreaseScore();
                Destroy(collision.gameObject);
            }
        }
    }
}
