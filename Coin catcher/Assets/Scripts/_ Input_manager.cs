using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public class _Input_manager : _Singletone<_Input_manager>
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    private _Touch_control touch_control;

    private void Awake()
    {
        touch_control = new _Touch_control();
    }
    private void OnEnable()
    {
        touch_control.Enable();
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();

        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }
    private void OnDisable()
    {
        touch_control.Disable();
        TouchSimulation.Disable();
        EnhancedTouchSupport.Disable();

        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void Start()
    {
        touch_control.Touch.TouchPress.started  += context => StartTouch(context);
        touch_control.Touch.TouchPress.canceled += context => EndTouch(context);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        // Debug.Log("Touch started " + touch_control.Touch.TouchPosition.ReadValue<Vector2>());
        Debug.Log("Touch started");

        if (OnStartTouch != null)
            OnStartTouch(touch_control.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended");

        if (OnEndTouch != null)
            OnEndTouch(touch_control.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }

    private void FingerDown(Finger finger)
    {
        if (OnStartTouch != null) OnStartTouch(finger.screenPosition, Time.time);
    }

    private void Update()
    {
        Debug.Log(EnhancedTouch.Touch.activeTouches);

        foreach (EnhancedTouch.Touch touch in EnhancedTouch.Touch.activeTouches)
        {
            Debug.Log(touch.phase == UnityEngine.InputSystem.TouchPhase.Began);
        }
    }
}
