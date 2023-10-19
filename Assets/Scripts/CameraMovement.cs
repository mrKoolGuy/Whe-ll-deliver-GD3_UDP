using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject target;

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, Time.deltaTime * speed * (-Input.GetAxis("Horizontal Camera")));
        transform.RotateAround(target.transform.position, transform.right, Time.deltaTime * speed * (-Input.GetAxis("Vertical Camera")));
        //transform.RotateAround()
    }
}