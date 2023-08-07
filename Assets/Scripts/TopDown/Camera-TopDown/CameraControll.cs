using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    
    [SerializeField]
    private Camera _camera = null;
    [SerializeField]
    private float moveSpeed = 50;
    [SerializeField]
    private float moveSmooth = 5;


    [SerializeField]
    private float zoomSpeed = 5f; 
    [SerializeField]
    private float zoomSmooth = 5f;

    private CameraControl inputs = null;
    private bool moving = false;
    private bool zooming = false;

    private Transform root;
    private Transform pivot;
    private Transform target;

    private Vector3 center = Vector3.zero;
    private float right = 10;
    private float left = 10;
    private float top = 10;
    private float down = 10;
    private float angle = 10;
    private float zoom = 10;
    private float maxZoom = 10;
    private float minZoom = 1;

    private Vector2 zoomPositionOnScreen = Vector2.zero;
    private Vector3 zoomPositionOnWorld = Vector3.zero;
    private float zoomBaseValue = 0;
    private float zoomBaseDistance = 0;

    private bool building = false; public bool isPlacingBuilding { get { return building; } set { building = value; } }
    private Vector3 buildBasePosition;
    private bool movingBuilding = false;

    private static CameraControll _instance;
    public static CameraControll Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this; 
        inputs = new CameraControl();
        root = new GameObject("CameraHelper").transform;
        pivot = new GameObject("CameraPivot").transform;
        target = new GameObject("CameraTarget").transform;
        _camera.orthographic = true;
        _camera.nearClipPlane = 0;
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Main.CameraMovement.started += _ => MoveStarted();
        inputs.Main.TouchZoom.started += _ => ZoomStarted();
        inputs.Main.CameraMovement.canceled += _ => MoveCanceled();       
        inputs.Main.TouchZoom.canceled += _ => ZoomCanceled();

    }
    private void OnDisable()
    {
        inputs.Main.CameraMovement.started -= _ => MoveStarted();
        inputs.Main.TouchZoom.started -= _ => ZoomStarted();
        inputs.Main.CameraMovement.canceled -= _ => MoveCanceled(); 
        inputs.Main.TouchZoom.canceled -= _ => ZoomCanceled();
        inputs.Disable();
    }
    private void Start()
    {
        Initialize(Vector3.zero, 140, 140, 140, 140, 45, 10, 5, 20);

    }

    private void Initialize(Vector3 _center, float _right, float _left, float _up, float _down, float _angle, float _zoom, float _minZoom, float _maxZoom)
    {
        center = _center;
        right = _right;
        left = _left;
        top = _up;
        down = _down;
        moving = false;
        zoom = _zoom;
        maxZoom = _maxZoom;
        minZoom = _minZoom;

        _camera.orthographicSize = zoom;
        zooming = false;
        pivot.SetParent(root);
        target.SetParent(pivot);

        root.position = _center;
        root.localEulerAngles = Vector3.zero;

        pivot.localPosition = Vector3.zero;
        pivot.localEulerAngles = new Vector3(_angle,0,0);

        target.localPosition = new Vector3(0,0,-10);
        target.localEulerAngles = Vector3.zero;

       
    }

    private void MoveStarted()
    {
        if (UIMain.Instance.isActive)
        {
            if (building)
            {
                buildBasePosition = CameraScreenPositionToPlanePosition( inputs.Main.PointerPosition.ReadValue<Vector2>());
                if (UIMain.Instance.grid.IsWorldPositionOrIsOnPlane(buildBasePosition, Building.instance._currentX, Building.instance._currentY, Building.instance.rows, Building.instance.cols))
                {
                    Building.instance.StartMovingOnGrid();
                    movingBuilding = true;
                }

                

            }            
            if (movingBuilding == false)
            {
                moving = true;
            }
        }
    }
    private void MoveCanceled()
    {
        moving= false;
        movingBuilding= false;
    }    
    private void ZoomStarted()
    {
        if (UIMain.Instance.isActive)
        {
            Vector2 touch0 = inputs.Main.TouchPosition0.ReadValue<Vector2>();
            Vector2 touch1 = inputs.Main.TouchPosition1.ReadValue<Vector2>();
            zoomPositionOnScreen = Vector2.Lerp(touch0, touch1, 0.5f);
            zoomPositionOnWorld = CameraScreenPositionToPlanePosition(zoomPositionOnScreen);
            zoomBaseValue = zoom;

            touch0.x /= Screen.width;
            touch1.x /= Screen.width;

            touch0.y /= Screen.height;
            touch1.y /= Screen.height;

            zoomBaseDistance = Vector2.Distance(touch0, touch1);

            zooming = true;
        }   
    }
    private void ZoomCanceled()
    {
        zooming= false;
    }

    private void Update()
    {
        if (Input.touchSupported == false)
        {
            float mouseScroll = inputs.Main.MouseScroll.ReadValue<float>();
            if (mouseScroll > 0)
            {
                zoom -= 3f * Time.deltaTime;
            }
            else if (mouseScroll < 0)
            {
                zoom += 3f * Time.deltaTime;
            }
        }
        if (zooming)
        {
            Vector2 touch0 = inputs.Main.TouchPosition0.ReadValue<Vector2>();
            Vector2 touch1 = inputs.Main.TouchPosition1.ReadValue<Vector2>();

            touch0.x /= Screen.width;
            touch1.x /= Screen.width;

            touch0.y /= Screen.height;
            touch1.y /= Screen.height;

            float currentDistance = Vector2.Distance(touch0, touch1);
            float deltaDistance = currentDistance - zoomBaseDistance;
            zoom = zoomBaseValue - (deltaDistance * zoomSpeed);

            Vector3 zoomCenter = CameraScreenPositionToPlanePosition(zoomPositionOnScreen);
            root.position += (zoomPositionOnWorld - zoomCenter);
        }
        
        else if (moving)
        {
            Vector2 move = inputs.Main.MoveDelta.ReadValue<Vector2>();
            if(move != Vector2.zero)
            {
                move.x /= Screen.width;
                move.y /= Screen.height;
                root.position -= root.right.normalized * move.x * moveSpeed; 
                root.position -= root.forward.normalized * move.y * moveSpeed; 
            }
        }
        AdjustBounds();

        if (_camera.orthographicSize != zoom)
        {
            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize,zoom,zoomSmooth * Time.deltaTime);
        }
        if (_camera.transform.position != target.position)
        {
            _camera.transform.position =  Vector3.Lerp(_camera.transform.position,target.position, moveSmooth * Time.deltaTime);
        }
        if (_camera.transform.rotation != target.rotation)
        {
            _camera.transform.rotation = target.rotation;
        }       
        if (building && movingBuilding)
        {
            Vector3 pos = CameraScreenPositionToPlanePosition(inputs.Main.PointerPosition.ReadValue<Vector2>());
            Building.instance.UpdateGridPosition(buildBasePosition, pos);
        }
    }

    private void AdjustBounds()
    {
        if (zoom < minZoom)
        {
            zoom = minZoom;
        }
        if (zoom > maxZoom)
        {
            zoom = maxZoom;
        }

        float h = PlaneOrtographicSize();
        float w = h * _camera.aspect;

        if (h > (top + down) / 2f)
        {
            float n = (top + down) / 2f;
            zoom = n * Mathf.Sin(angle * Mathf.Deg2Rad);
        }
        if (w > (left + right) / 2f)
        {
            float n = (left + right) / 2f;
            zoom = n * Mathf.Sin(angle * Mathf.Deg2Rad) / _camera.aspect;
        }

         h = PlaneOrtographicSize();
         w = h * _camera.aspect;
        Vector3 tr = root.position + root.right.normalized * w + root.forward.normalized * h;
        Vector3 tl = root.position - root.right.normalized * w + root.forward.normalized * h;        
        Vector3 dr = root.position + root.right.normalized * w - root.forward.normalized * h;
        Vector3 dl = root.position - root.right.normalized * w - root.forward.normalized * h;

        if (tr.x > center.x + right)
        {
            root.position += Vector3.left * Mathf.Abs(tr.x - (center.x + right));
        }
        if (tl.x < center.x - left)
        {

            root.position += Vector3.right * Mathf.Abs((center.x - left) - tl.x);
        }
        if (tr.z > center.z + top)
        {
            root.position += Vector3.back * Mathf.Abs(tr.z - (center.z + top));
        }
        if (dl.z < center.z - down)
        {
            root.position += Vector3.forward * Mathf.Abs((center.z - down) - dl.z);
        }
    }

    private float PlaneOrtographicSize()
    {
        float h = zoom * 2f;
        return h / Mathf.Sin(angle * Mathf.Deg2Rad) / 2;
    }

    private Vector3 CameraScreenPositionToWorldPosition(Vector2 position)
    {
        float h = _camera.orthographicSize * 2f;
        float w = _camera.aspect * h;
        Vector3 ancher = _camera.transform.position - (_camera.transform.right.normalized * w/2f) - (_camera.transform.forward * h /2f);
        return ancher + (_camera.transform.right.normalized * position.x/ Screen.width * w) + (_camera.transform.up.normalized * position.y / Screen.height * h);
    }

    private Vector3 CameraScreenPositionToPlanePosition(Vector2 position)
    {
        Vector3 point = CameraScreenPositionToWorldPosition(position);
        float h = point.y - root.position.y;
        float x = h / Mathf.Sin(angle * Mathf.Deg2Rad);

        return point + _camera.transform.forward * x;

    }

}
