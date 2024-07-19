using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PlayerMovements : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] float m_walkSpeed;
    [SerializeField] float m_runSpeed, m_jumpPower, m_midairSpeed, m_midairSpeedLimit;
    [SerializeField] string FSMPath;
    public bool canMove = true;
    public float walkSpeed { get { return m_walkSpeed * speedMultiplier; } }
    public float runSpeed { get { return m_runSpeed * speedMultiplier; } }
    public float jumpPower { get { return m_jumpPower; } }
    public float midairSpeed { get { return m_midairSpeed; } }
    public float midairSpeedLimit { get { return m_midairSpeedLimit; } }
    public float speedMultiplier = 1.0f;
    public Rigidbody2D rb { get; private set; }
    BoxCollider2D m_collider;

    [Header("Keybinds")]
    [SerializeField] KeyCode m_runKey = KeyCode.LeftShift;
    [SerializeField] KeyCode m_jumpKey = KeyCode.Space;

    [Header("Components")]
    [SerializeField] Collider2DStatus groundDetector;

    //FSM
    PlayerMovements_TopLayer topLayer; 
    public KeyCode runKey { get { return m_runKey; } }
    public KeyCode jumpKey { get { return m_jumpKey; } }
    private void Awake()
    {
        m_collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        topLayer = new PlayerMovements_TopLayer(this);
        topLayer.onFSMChange += () => { FSMPath = topLayer.GetCurrentFSM(); };
        topLayer.OnStateEnter();
        FSMPath = topLayer.GetCurrentFSM();
    }
    void Update()
    {
        topLayer.OnStateUpdate();
    }
    public bool GroundCheck()
    {
        return groundDetector.isTouching;
    }
}
