using UnityEngine;

public class camMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;   // Prêdkoœæ poruszania siê kamery
    [SerializeField] private float minX = -360f;    // Minimalny obrót kamery w osi X
    [SerializeField] private float maxX = 360f;     // Maksymalny obrót kamery w osi X
    [SerializeField] private float minY = -45f;     // Minimalny obrót kamery w osi Y
    [SerializeField] private float maxY = 45f;      // Maksymalny obrót kamery w osi Y
    [SerializeField] private bool lockCursor = true;// Zablokuj kursor myszy
    

    private float _rotationX = 0f;  // Aktualny obrót kamery w osi X
    private float _rotationY = 0f;  // Aktualny obrót kamery w osi Y

    void Start()
    {
        // Zablokuj kursor myszy
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        // Poruszanie kamery po osiach X i Y
        _rotationX += Input.GetAxis("Mouse X");
        _rotationY += Input.GetAxis("Mouse Y");
        _rotationY = Mathf.Clamp(_rotationY, minY, maxY);
        _rotationX = Mathf.Clamp(_rotationX, minX, maxX);

        transform.eulerAngles = new Vector3(-_rotationY, _rotationX, 0);

        // Poruszanie kamery wzd³u¿ osi X, Y i Z
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.position += transform.right * x * moveSpeed * Time.deltaTime;
        transform.position += transform.forward * z * moveSpeed * Time.deltaTime;

        //if (GameObject.Find("playerPrefab") !=null )
        //{
        //    Debug.Log("Player prefab existance detected");
        //} else
        //{
        //    Debug.Log("No player prefab found on the scene");
        //}
    }
}