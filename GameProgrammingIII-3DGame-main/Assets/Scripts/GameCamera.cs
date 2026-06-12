using UnityEngine;
using UnityEngine.InputSystem;

public class GameCamera : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    [SerializeField] Transform lookTarget;

    [SerializeField] Vector3 offset;

    [SerializeField] float targetDistance = 5f;

    [SerializeField] float rotateSpeed = 180f;

    float pitch;
    float yaw;

    private void Start()
    {
        yaw = 90;
        pitch = 0;
    }

    private void Update()
    {
        var lookVec = playerInput.actions["Look"].ReadValue<Vector2>();

        yaw += lookVec.x * rotateSpeed * Time.deltaTime;
        pitch -= lookVec.y * rotateSpeed * Time.deltaTime;

        var target = lookTarget.position + offset;
        var rotation = Quaternion.Euler(pitch, yaw, 0);
        var position =
            rotation * new Vector3(0, 0, -targetDistance)
            + target;

        transform.rotation = rotation;
        transform.position = position;
    }
}