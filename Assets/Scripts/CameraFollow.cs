using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;          
    [SerializeField] private Vector3 _offset = new Vector3(0, 2, -10); 
    [SerializeField] private float _smoothSpeed = 5f; 

    [Header("Giới hạn vùng camera")]
    [SerializeField] private Vector2 _minBounds; 
    [SerializeField] private Vector2 _maxBounds;

    [SerializeField] private Vector3[] roomPositions;
    [SerializeField] private float[] switchX;

    private int currentRoom = 0;
    public bool change = true;

    private float _halfHeight;
    private float _halfWidth;
    private Camera _cam;

    private void Start()
    {
        Camera cam = GetComponent<Camera>();
        _halfHeight = cam.orthographicSize;
        _halfWidth = _halfHeight * cam.aspect;
    }

    private void LateUpdate()
    {
        if (_player == null)
        {
            FindPlayer();
            return;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            change = !change;

            if (switchX == null || roomPositions == null) change = true;
        }

        SwitchTarget();
    }

    private void SwitchTarget()
    {
        if (change)
        {
            TargetPlayer();
        }
        else
        {
            SwitchRoom();
        }
    }
    private void TargetPlayer()
    {
        Vector3 targetPos = _player.position + _offset;

        float clampedX = Mathf.Clamp(targetPos.x, _minBounds.x + _halfWidth, _maxBounds.x - _halfWidth);
        float clampedY = Mathf.Clamp(targetPos.y, _minBounds.y + _halfHeight, _maxBounds.y - _halfHeight);

        Vector3 boundedPos = new Vector3(clampedX, clampedY, targetPos.z);

        transform.position = Vector3.Lerp(transform.position, boundedPos, _smoothSpeed * Time.deltaTime);
    }
    private void SwitchRoom()
    {
        // Kiểm tra nếu player vượt qua ngưỡng X thì đổi phòng
        for (int i = 0; i < switchX.Length; i++)
        {
            if (_player.position.x > switchX[i])
                currentRoom = i + 1;
        }
        currentRoom = Mathf.Clamp(currentRoom, 0, roomPositions.Length - 1);
        // Lấy vị trí mục tiêu của camera (theo phòng hiện tại)
        Vector3 targetPos = new Vector3(
            roomPositions[currentRoom].x,
            roomPositions[currentRoom].y,
            transform.position.z);

        // Di chuyển mượt mà
        transform.position = Vector3.Lerp(transform.position, targetPos, _smoothSpeed * Time.deltaTime);
    }
    private void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            _player = playerObj.transform;
            Debug.Log("📷 Camera đã tìm thấy Player mới!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 size = new Vector3(_maxBounds.x - _minBounds.x, _maxBounds.y - _minBounds.y, 1);
        Vector3 center = new Vector3((_maxBounds.x + _minBounds.x) / 2, (_maxBounds.y + _minBounds.y) / 2, 0);
        Gizmos.DrawWireCube(center, size);
    }
}
