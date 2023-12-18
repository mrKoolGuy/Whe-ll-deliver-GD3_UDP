using UnityEngine;

public class Movement_Audio : MonoBehaviour
{
    [SerializeField]
    private float rotationTorque;
    [SerializeField]
    private float movementForce; // force in newton
    [SerializeField]
    private float maxSpeed; // maximum Speed in m/s
    [SerializeField]
    private float sidewaysFriction;
    [SerializeField]
    private float breakingForce;

    public AudioClip grassSound;
    public AudioClip stoneSound;
    public AudioClip dirtSound;

    private AudioSource audioSource;
    private Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // limit the maximum reachable speed of the player
    void LimitMaxSpeed()
    {
        Vector3 xzSpeed = rbody.velocity;
        // ignore the y, we alone want the speed along the flat speed
        xzSpeed.y = 0;

        xzSpeed = Vector3.ClampMagnitude(xzSpeed, maxSpeed);
        rbody.velocity = new Vector3(xzSpeed.x, rbody.velocity.y, xzSpeed.z);
    }

    // This simulates the sideways friction on the wheels off the wheelchair,
    // and applies brakes to the wheels when the player is not controlling the speed
    private void ApplyBreakingAndSidewaysFriction()
    {
        // objectVelocity is the current velocity viewed from the direction of the player
        Vector3 objectVelocity = transform.InverseTransformDirection(rbody.velocity);
        float sidewaysSpeed = objectVelocity.x;
        float forwardSpeed = objectVelocity.z;

        // apply the sideways friction as force proportional to sideways speed
        rbody.AddForce(transform.TransformDirection(sidewaysFriction * sidewaysSpeed * Vector3.left));

        // if the player is not actively going forward or backward, apply a braking force
        if (Mathf.Approximately(Input.GetAxis("Vertical"), 0))
        {
            rbody.AddForce(transform.TransformDirection(breakingForce * forwardSpeed * Vector3.back));
            PlayTerrainSound();
        }
    }

    // Play the sound effect based on the terrain tag
    private void PlayTerrainSound()
    {
        string terrainTag = GetTerrainTag(); // Implement this function to get the terrain tag

        if (terrainTag != null)
        {
            switch (terrainTag)
            {
                case "Grass":
                    PlaySound(grassSound);
                    break;
                case "Stone":
                    PlaySound(stoneSound);
                    break;
                case "Dirt":
                    PlaySound(dirtSound);
                    break;
                    // Add more cases for other terrains as needed
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private string GetTerrainTag()
    {
        // Implement this function to get the terrain tag based on the player's position
        // You might use raycasting, collision detection, or other methods
        // For simplicity, let's assume you have a function that returns the terrain tag
        // based on the player's position.

        // Example:
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            if (hit.collider != null)
            {
                return hit.collider.gameObject.tag;
            }
        }

        return null;
    }

    private void FixedUpdate()
    {
        // get vertical user input and apply a force to create back and forth movement
        rbody.AddForce(rbody.transform.forward * (Input.GetAxis("Vertical") * movementForce));
        // get horizontal user input and apply a force to rotate the player
        rbody.angularVelocity = Vector3.up * (Input.GetAxis("Horizontal") * rotationTorque);

        ApplyBreakingAndSidewaysFriction();
        LimitMaxSpeed();
    }
}