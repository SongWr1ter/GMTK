using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmokeSignAbnormal : AbnormalObject
{
    private bool _activeFlag = false;
    private Transform _target;
    private bool _inRange = false;
    //
    private Rigidbody2D _rb;
    private Vector2 _currentVelocity;
    [SerializeField] private float followDistance = 5f; // 停止跟踪的距离
    [SerializeField] private float moveSpeed = 3f; // 移动速度
    [SerializeField] private float acceleration = 5f; // 加速度
    [SerializeField] private float stoppingDistance = 1f; // 完全停止的距离

    private void FixedUpdate()
    {
        if (!_activeFlag) return;
        if (_inRange)
        {
            HandleMovement();
        }
    }

    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType abnormalType = (AbnormalType)message.Mid;
        if (abnormalType == AbnormalType.Smoke_Sign_Follow_Abnormal)
        {
            _activeFlag = true;
            _rb = GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = true;
            _target = other.transform;
        }
    }
    
    private void HandleMovement()
    {
        if (_target == null) return;

        Vector2 directionToTarget = _target.position - transform.position;
        directionToTarget.y = 0;
        float distanceToTarget = directionToTarget.magnitude;

        // 检查是否应该移动的条件
        bool shouldMove = distanceToTarget > followDistance && !IsTargetLooking() && distanceToTarget < stoppingDistance;

        if (shouldMove)
        {
            // 平滑移动
            Vector2 targetVelocity = directionToTarget.normalized * moveSpeed;
            _currentVelocity = Vector2.Lerp(
                _currentVelocity, 
                targetVelocity, 
                acceleration * Time.fixedDeltaTime
            );

            // 接近目标时减速
            if (distanceToTarget < followDistance * 1.5f)
            {
                float slowdownFactor = Mathf.InverseLerp(followDistance, followDistance * 1.5f, distanceToTarget);
                _currentVelocity *= slowdownFactor;
            }
        }
        else
        {
            // 平滑停止
            _currentVelocity = Vector2.Lerp(
                _currentVelocity, 
                Vector2.zero, 
                acceleration * Time.fixedDeltaTime
            );
        }

        // 应用最终速度
        _rb.velocity = _currentVelocity;
    }

    private bool IsTargetLooking()
    {
        bool target2Left = !_target.GetComponent<SpriteRenderer>().flipX;
        bool targetOnLeft = _target.position.x < transform.position.x;
        return target2Left == targetOnLeft;
    }
}
