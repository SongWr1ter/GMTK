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

    // 动画参数哈希值（性能优化）
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int MovingHash = Animator.StringToHash("Moving");

    private float _currentSpeed;
    private float _targetDirection;

    private void Update()
    {
        HandleInput();
        UpdateAnimation();
        UpdateFacingDirection();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
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
    }

    private void ApplyMovement()
    {
        // 仅修改X轴速度，保留Y轴物理效果（重力等）
        rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
    }

    private void UpdateFacingDirection()
    {
        // 仅在输入时更新方向
        if (_targetDirection != 0)
        {
            spriteRenderer.flipX = _targetDirection < 0;
        }
    }

    private void UpdateAnimation()
    {
        // // 使用绝对速度值控制混合树
        // float absSpeed = Mathf.Abs(_currentSpeed);
        // animator.SetFloat(SpeedHash, absSpeed);
        //
        // // 设置布尔值用于动画过渡（可选）
        // animator.SetBool(MovingHash, absSpeed > 0.1f);
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
