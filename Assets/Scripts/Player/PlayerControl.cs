using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float deceleration = 20f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [Header("Interaction Settings")]
    [SerializeField] private float interactiveRadius = 0.2f;
    [SerializeField] private LayerMask interactiveLayer;

    // 动画参数哈希值（性能优化）
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    //private static readonly int MovingHash = Animator.StringToHash("Moving");

    private float _currentSpeed;
    private float _targetDirection;
    private bool _filpXCache;
    private Transform _interactCache = null;

    private void Update()
    {
        HandleInput();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckInteractiveObject();
    }

    private void HandleInput()
    {
        // 获取原始输入（-1, 0, 1）
        float rawInput = Input.GetAxisRaw("Horizontal");
        
        // 设置目标方向（保留符号用于转身）
        _targetDirection = Mathf.Sign(rawInput);
        
        // 平滑加速度计算
        if (rawInput != 0)
        {
            _currentSpeed = Mathf.MoveTowards(
                _currentSpeed, 
                moveSpeed * _targetDirection, 
                acceleration * Time.fixedDeltaTime
            );
        }
        else
        {
            _currentSpeed = Mathf.MoveTowards(
                _currentSpeed, 
                0f, 
                deceleration * Time.fixedDeltaTime
            );
        }
        //脸朝向
        if (rawInput != 0)
        {
            spriteRenderer.flipX = _targetDirection < 0;
            _filpXCache = spriteRenderer.flipX;
        }
        else
        {
            spriteRenderer.flipX = _filpXCache;
        }
    }

    private void ApplyMovement()
    {
        // 仅修改X轴速度，保留Y轴物理效果（重力等）
        rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
    }

    private void UpdateAnimation()
    {
        // 使用绝对速度值控制混合树
        float absSpeed = Mathf.Abs(_currentSpeed);
        animator.SetFloat(SpeedHash, absSpeed);
        
        // 设置布尔值用于动画过渡（可选）
        //animator.SetBool(MovingHash, absSpeed > 0.1f);
    }

    private void CheckInteractiveObject()
    {
        // 获取当前交互范围内的碰撞体
        Collider2D col = Physics2D.OverlapCircle(rb.position, interactiveRadius, interactiveLayer);
    
        // 没有缓存对象时处理新交互对象
        if (_interactCache == null)
        {
            if (col != null && col.TryGetComponent(out Interactive interactive))
            {
                interactive.ShowInteract();
                _interactCache = col.transform;
            }
            return;
        }
    
        // 处理已有缓存对象的情况
        bool isStillInteracting = col != null && _interactCache == col.transform;
    
        if (!isStillInteracting)
        {
            if (_interactCache.TryGetComponent(out Interactive cachedInteractive))
            {
                cachedInteractive.HideInteract();
            }
            _interactCache = null;
        
            // 检查是否有新的可交互对象
            if (col != null && col.TryGetComponent(out Interactive newInteractive))
            {
                newInteractive.ShowInteract();
                _interactCache = col.transform;
            }
        }
    }

    private void Interact()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rb.position, interactiveRadius);
    }
#if UNITY_EDITOR
    // 编辑器自动获取组件引用
    private void OnValidate()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endif
}
