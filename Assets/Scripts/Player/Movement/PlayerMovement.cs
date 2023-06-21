using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
//susing static UnityEditor.PlayerSettings;

public class PlayerMovement : MonoBehaviour
{

    public PlayerData Data;

    public bool canWallJump;

    #region COMPONENTS
    public Rigidbody2D RB { get; private set; }

    public PlayerAnimator AnimHandler { get; private set; }
    #endregion

    #region STATE PARAMETERS
    public bool IsFacingRight;
    public bool IsJumping { get; private set; }
    public bool IsWallJumping;
    public bool IsDashing { get; private set; }
    public bool IsSliding { get; private set; }   
    public float LastOnGroundTime { get; private set; }
    public float LastOnWallTime { get; private set; }
    public float LastOnWallRightTime { get; private set; }
    public float LastOnWallLeftTime { get; private set; }

    public bool canMove;

    private bool _isJumpCut;
    private bool _isJumpFalling;

    private float _wallJumpStartTime;
    private int _lastWallJumpDir;

    private int _dashesLeft;
    private bool _dashRefilling;
    private Vector2 _lastDashDir;
    private bool _isDashAttacking;

    private PlayerController playerController;

    private Animator anim;
    private bool canFX;

    private bool isTurning = false;
    private Quaternion targetRotation;
    public float turnSpeed = 5f;
    // GameObject obj; 

    #endregion

    #region INPUT PARAMETERS
    private Vector2 _moveInput;

    public float LastPressedJumpTime { get; private set; }
    public float LastPressedDashTime { get; private set; }
    #endregion

    #region CHECK PARAMETERS
    [Header("Checks")]
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);
    [Space(5)]
    [SerializeField] private Transform _frontWallCheckPoint;
    [SerializeField] private Transform _backWallCheckPoint;
    [SerializeField] private Vector2 _wallCheckSize = new Vector2(0.5f, 1f);
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _groundLayer;
    #endregion
  
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        AnimHandler = GetComponent<PlayerAnimator>();

    }

    private void Start()
    {
        SetGravityScale(Data.gravityScale);
       // IsFacingRight = true;

    }
    public bool isFLoating;
    private void Update()

    {
        if (canMove && Time.deltaTime > 0)
        {
            _moveInput.x = UserInput.instance.moveInput.x;
            _moveInput.y = UserInput.instance.moveInput.y;
        }
        else
        {
            _moveInput.x = 0;
            _moveInput.y = 0;

        }
        
        if (CanJump())
        {
            if (_moveInput.x > 0 && canFX)
            {
                canFX = false;

                    GameObject obj = Instantiate(AnimHandler.turnFX, AnimHandler.pos.transform.position, Quaternion.Euler(-25, -90, 90));
                    Destroy(obj, 1);
                

            }   
            else if(_moveInput.x < 0 && canFX)
            {
                GameObject obj = Instantiate(AnimHandler.turnFX, AnimHandler.pos.transform.position, Quaternion.Euler(-150, -90, 90));
                Destroy(obj, 1);
                canFX = false;
            }
        }
        if(_moveInput.x == 0)
        {
            canFX = true;
        }

        #region TIMERS
        LastOnGroundTime -= Time.deltaTime;
        LastOnWallTime -= Time.deltaTime;
        LastOnWallRightTime -= Time.deltaTime;
        LastOnWallLeftTime -= Time.deltaTime;

        LastPressedJumpTime -= Time.deltaTime;
        LastPressedDashTime -= Time.deltaTime;
        #endregion

        #region INPUT HANDLER

        if (!IsWallJumping)
        {
            if (_moveInput.x != 0)
                CheckDirectionToFace(_moveInput.x > 0);
        }
        

        if (UserInput.instance.playerController.InGame.Jump.triggered && Time.deltaTime > 0)
        {
            OnJumpInput();
        }

        if (IsJumping && !UserInput.instance.playerController.InGame.Jump.ReadValue<float>().Equals(1f))
        {
            OnJumpUpInput();
        }

        if (UserInput.instance.playerController.InGame.Debug_Z.triggered)
        {
            OnDashInput();
        }
        #endregion

        #region COLLISION CHECKS
        
            
        if (!IsDashing && !IsJumping)
        {

            if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer))
            {
                if (LastOnGroundTime < -0.1f)
                {
                    AnimHandler.justLanded = true;
                }
                LastOnGroundTime = Data.coyoteTime;
                isFLoating = false;
            }
            else
            {
                isFLoating = true;
                AnimHandler.anim.SetBool("IsJumping", true);
            }

            if (((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && IsFacingRight)
                    || (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && !IsFacingRight)) && !IsWallJumping)
                LastOnWallRightTime = Data.coyoteTime;

            if (((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && !IsFacingRight)
                || (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && IsFacingRight)) && !IsWallJumping)
                LastOnWallLeftTime = Data.coyoteTime;

            LastOnWallTime = Mathf.Max(LastOnWallLeftTime, LastOnWallRightTime);
        }
        #endregion

        #region JUMP CHECKS
        if (IsJumping && RB.velocity.y < 0)
        {
            IsJumping = false;

            _isJumpFalling = true;
        }

        if (IsWallJumping && Time.time - _wallJumpStartTime > Data.wallJumpTime)
        {
            IsWallJumping = false;
        }

        if (LastOnGroundTime > 0 && !IsJumping && !IsWallJumping)
        {
            _isJumpCut = false;

            _isJumpFalling = false;
        }
        if (canMove)
        {
            if (!IsDashing)
            {

                if (CanJump() && LastPressedJumpTime > 0)
                {
                    IsJumping = true;
                    IsWallJumping = false;
                    _isJumpCut = false;
                    _isJumpFalling = false;
                    Jump();

                    AnimHandler.startedJumping = true;
                }
                else if (CanWallJump() && LastPressedJumpTime > 0 && canWallJump)
                {
                   //AnimHandler.anim.SetBool("WallJump", true);
                    
                    IsWallJumping = true;
                    IsJumping = false;
                    _isJumpCut = false;
                    _isJumpFalling = false;

                    _wallJumpStartTime = Time.time;
                    _lastWallJumpDir = (LastOnWallRightTime > 0) ? -1 : 1;
                    

                    WallJump(_lastWallJumpDir);
                }
            }
            #endregion

            #region DASH CHECKS
            if (CanDash() && LastPressedDashTime > 0)
            {
                Sleep(Data.dashSleepTime);

                if (_moveInput != Vector2.zero)
                    _lastDashDir = _moveInput;
                else
                    _lastDashDir = IsFacingRight ? Vector2.right : Vector2.left;



                IsDashing = true;
                IsJumping = false;
                IsWallJumping = false;
                _isJumpCut = false;

                StartCoroutine(nameof(StartDash), _lastDashDir);
            }
        }
        #endregion


        #region SLIDE CHECKS
        if (CanSlide() && ((LastOnWallLeftTime > 0 && _moveInput.x < 0) || (LastOnWallRightTime > 0 && _moveInput.x > 0)))
        {
            if (!IsSliding)
            {
                IsSliding = true;
                StartCoroutine(StartSlidingCoroutine());
            }
        }
        else
        {
            IsSliding = false;
        }

        #endregion

        #region GRAVITY
        if (!_isDashAttacking)
        {
            if (IsSliding)
            {
                SetGravityScale(0);
            }
            else if (RB.velocity.y < 0 && _moveInput.y < 0)
            {
                SetGravityScale(Data.gravityScale * Data.fastFallGravityMult);
                RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFastFallSpeed));
            }
            else if (_isJumpCut)
            {
                SetGravityScale(Data.gravityScale * Data.jumpCutGravityMult);
                RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFallSpeed));
            }
            else if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
            {
                SetGravityScale(Data.gravityScale * Data.jumpHangGravityMult);
            }
            else if (RB.velocity.y < 0)
            {

                SetGravityScale(Data.gravityScale * Data.fallGravityMult);                
                RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFallSpeed));
            }
            else
            {
                SetGravityScale(Data.gravityScale);
            }
        }
        else
        {
            SetGravityScale(0);
        }
        #endregion
    }
    public float particleInterval = 0.1f;
    private IEnumerator StartSlidingCoroutine()
    {
        float timer = 0f;

        while (IsSliding)
        {
            timer += Time.deltaTime;

            if (timer >= particleInterval)
            {
                GameObject obj = Instantiate(AnimHandler.slideFX, AnimHandler.slidePos.transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(obj, 1);
                timer = 0f;
            }

            yield return null;
        }
    }
    private IEnumerator StartPushingCoroutine()
    {
        float timer = 0f;
        float randomMargin = Random.Range(0.3f, 0.7f);

        while (isPushing)
        {
            timer += Time.deltaTime;

            if (timer >= randomMargin)
            {
                if (IsFacingRight)
                {
                    GameObject obj = Instantiate(AnimHandler.boxFX, AnimHandler.boxPos.transform.position, Quaternion.Euler(-180, 90, 80));
                    Destroy(obj, 1);
                }
                else
                {
                    GameObject obj = Instantiate(AnimHandler.boxFX, AnimHandler.boxPos.transform.position, Quaternion.Euler(-180, -90, 80));
                    Destroy(obj, 1);
                }

                timer = 0f;
                randomMargin = Random.Range(0.2f, 0.5f);
            }

            yield return null;
        }
    }
    bool isPushing;
    private void FixedUpdate()
    {
        if (AnimHandler.anim.GetBool("IsPushing") && Mathf.Abs(RB.velocity.x) > 0.4)
        {
            if (!isPushing)
            {
                isPushing = true;
                StartCoroutine(StartPushingCoroutine());
            }
        }
        else
        {
            isPushing = false;
        }


        if (Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer))
        {
            if (Physics2D.OverlapBox(_groundCheckPoint.position, _wallCheckSize, 0, _groundLayer))
            {
                AnimHandler.anim.SetBool("IsSliding", false);

            }
            else
            {
                AnimHandler.anim.SetBool("IsSliding", true);
            }
            
        }
        else
        {
            AnimHandler.anim.SetBool("IsSliding", false);
        }

        

        if (IsSliding)
        {
            if (canFxSlide)
            {

               // obj = Instantiate(AnimHandler.slideFX, AnimHandler.pos.transform.position, Quaternion.Euler(-90, 0, 0));
              //  canFxSlide = false;
            }
        }
        else
        {
           // Destroy(obj);
           // canFxSlide = true;
        }

        if (isTurning)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isTurning = false;
            }
        }

        if (!IsDashing)
        {
            if (IsWallJumping)
                Run(Data.wallJumpRunLerp);
            else
                Run(1);
        }
        else if (_isDashAttacking)
        {
            Run(Data.dashEndRunLerp);
        }

        if (IsSliding)
            Slide();

    }

    #region INPUT CALLBACKS
    public void OnJumpInput()
    {
        LastPressedJumpTime = Data.jumpInputBufferTime;
    }

    public void OnJumpUpInput()
    {
        if (CanJumpCut() || CanWallJumpCut())
            _isJumpCut = true;
    }

    public void OnDashInput()
    {
        LastPressedDashTime = Data.dashInputBufferTime;
    }
    #endregion

    #region GENERAL METHODS
    public void SetGravityScale(float scale)
    {
        RB.gravityScale = scale;
    }

    private void Sleep(float duration)
    {
        StartCoroutine(nameof(PerformSleep), duration);
    }

    private IEnumerator PerformSleep(float duration)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
    #endregion

    #region RUN METHODS
    private void Run(float lerpAmount)
    {

        float targetSpeed = _moveInput.x * Data.runMaxSpeed;
        targetSpeed = Mathf.Lerp(RB.velocity.x, targetSpeed, lerpAmount);

        #region Calculate AccelRate
        float accelRate;

        if (LastOnGroundTime > 0)
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        else
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount * Data.accelInAir : Data.runDeccelAmount * Data.deccelInAir;
        #endregion

        #region Add Bonus Jump Apex Acceleration
        if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
        {
            accelRate *= Data.jumpHangAccelerationMult;
            targetSpeed *= Data.jumpHangMaxSpeedMult;
        }
        #endregion

        #region Conserve Momentum
        
        if (Data.doConserveMomentum && Mathf.Abs(RB.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(RB.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0)
        {           
            accelRate = 0;
        }
        #endregion


        float speedDif = targetSpeed - RB.velocity.x;


        float movement = speedDif * accelRate;


        RB.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }
    private void Turn()
    {
        
        if (isTurning) return;
        
        isTurning = true;
        IsFacingRight = !IsFacingRight;

        if (IsFacingRight)
        {
            targetRotation = Quaternion.Euler(0f, 0f, 0f);
            if (CanJump())
            {
                GameObject obj = Instantiate(AnimHandler.turnFX, AnimHandler.pos.transform.position, Quaternion.Euler(-25, -90, 90));
                Destroy(obj, 1);
            }

        }
        else
        {
            targetRotation = Quaternion.Euler(0f, 180f, 0f);
            if (CanJump())
            {
                GameObject obj = Instantiate(AnimHandler.turnFX, AnimHandler.pos.transform.position, Quaternion.Euler(-150, -90, 90));
                Destroy(obj, 1);
            }

        }
    }
    private void TurnWallJump()
    {
        if (isTurning) return;

        isTurning = true;
        

        if (Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && !IsFacingRight)
        {
            
            targetRotation = Quaternion.Euler(0f, 0f, 0f);
            IsFacingRight = !IsFacingRight;
        }
        else if (Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && IsFacingRight)
        {
            targetRotation = Quaternion.Euler(0f, 180f, 0f);
            IsFacingRight = !IsFacingRight;
        }
    }
    #endregion

    #region JUMP METHODS
    private void Jump()
    {
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;

        #region Perform Jump

        float force = Data.jumpForce;
        if (RB.velocity.y < 0)
            force -= RB.velocity.y;

        RB.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        #endregion
    }

    private void WallJump(int dir)
    {
        AnimHandler.anim.SetBool("WallJump", true);
        if(dir > 0)
        {
            GameObject obj = Instantiate(AnimHandler.WallJumpFX, AnimHandler.pos.transform.position, Quaternion.Euler(-35, 90, 90));
            Destroy(obj, 1);
        }
        else
        {
            GameObject obj = Instantiate(AnimHandler.WallJumpFX, AnimHandler.pos.transform.position, Quaternion.Euler(-135, 90, 90));
            Destroy(obj, 1);
        }
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;
        LastOnWallRightTime = 0;
        LastOnWallLeftTime = 0;

        #region Perform Wall Jump
        Vector2 force = new Vector2(Data.wallJumpForce.x, Data.wallJumpForce.y);
        force.x *= dir;

        if (Mathf.Sign(RB.velocity.x) != Mathf.Sign(force.x))
            force.x -= RB.velocity.x;

        if (RB.velocity.y < 0)
            force.y -= RB.velocity.y;

        RB.AddForce(force, ForceMode2D.Impulse);
        TurnWallJump();
        StartCoroutine(wallJumpFalse());
        #endregion
    }

    IEnumerator wallJumpFalse()
    {
        yield return new WaitForSeconds(1f);
        AnimHandler.anim.SetBool("WallJump", false);
    }
    #endregion

    #region DASH METHODS
    private IEnumerator StartDash(Vector2 dir)
    {

        LastOnGroundTime = 0;
        LastPressedDashTime = 0;

        float startTime = Time.time;

        _dashesLeft--;
        _isDashAttacking = true;

        SetGravityScale(0);

        while (Time.time - startTime <= Data.dashAttackTime)
        {
            RB.velocity = dir.normalized * Data.dashSpeed;
            yield return null;
        }

        startTime = Time.time;

        _isDashAttacking = false;

        SetGravityScale(Data.gravityScale);
        RB.velocity = Data.dashEndSpeed * dir.normalized;

        while (Time.time - startTime <= Data.dashEndTime)
        {
            yield return null;
        }

        IsDashing = false;
    }

    private IEnumerator RefillDash(int amount)
    {

        _dashRefilling = true;
        yield return new WaitForSeconds(Data.dashRefillTime);
        _dashRefilling = false;
        _dashesLeft = Mathf.Min(Data.dashAmount, _dashesLeft + 1);
    }
    #endregion

    #region OTHER MOVEMENT METHODS
    bool canFxSlide;
    private void Slide()
    {
        if (RB.velocity.y > 0)
        {
            RB.AddForce(-RB.velocity.y * Vector2.up, ForceMode2D.Impulse);
            
        }

        float speedDif = Data.slideSpeed - RB.velocity.y;
        float movement = speedDif * Data.slideAccel;
        movement = Mathf.Clamp(movement, -Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime), Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime));

        RB.AddForce(movement * Vector2.up);
        
        
    }
    #endregion

    #region CHECK METHODS
    public void CheckDirectionToFace(bool isMovingRight)
    {
        
        if (isMovingRight != IsFacingRight)
            Turn();
    }

    public bool CanJump()
    {
        return LastOnGroundTime > 0 && !IsJumping;
    }

    public bool CanWallJump()
    {
        return LastPressedJumpTime > 0 && LastOnWallTime > 0 && LastOnGroundTime <= 0 && (!IsWallJumping ||
             (LastOnWallRightTime > 0 && _lastWallJumpDir == 1) || (LastOnWallLeftTime > 0 && _lastWallJumpDir == -1));
    }

    private bool CanJumpCut()
    {
        return IsJumping && RB.velocity.y > 0;
    }

    private bool CanWallJumpCut()
    {
        return IsWallJumping && RB.velocity.y > 0;
    }

    private bool CanDash()
    {
        if (!IsDashing && _dashesLeft < Data.dashAmount && LastOnGroundTime > 0 && !_dashRefilling)
        {
            StartCoroutine(nameof(RefillDash), 1);
        }

        return _dashesLeft > 0;
    }

    public bool CanSlide()
    {
        if (LastOnWallTime > 0 && !IsJumping && !IsWallJumping && !IsDashing && LastOnGroundTime <= 0)
            return true;
        else
            return false;
    }
    #endregion

    #region EDITOR METHODS
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_frontWallCheckPoint.position, _wallCheckSize);
        Gizmos.DrawWireCube(_backWallCheckPoint.position, _wallCheckSize);
    }
    #endregion
}
