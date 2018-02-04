using UnityEngine;
using Project.Player;

///<summary>Class to making a camera follow (and rotate) an object</summary>
[RequireComponent(typeof(Camera))]
public class CamFollow : MonoBehaviour
{
    /// <summary>
    /// Transform of the desired object
    /// </summary>
    public Transform objectToFollow = null;
    ///< summary>
    /// Tag of the object to find it with in case of not being attached manually
    /// </summary>
    public string objectsTag = null;
    /// <summary>
    /// Follow the object?
    /// </summary>
    public bool followObject = true;
    /// <summary>
    /// Rotate the object follow?
    /// </summary>
    public bool rotateObject = true;
    [Space]
    /// <summary>
    /// Camera's offset from the object's position
    /// </summary>
    public Vector3 offset = Vector3.zero;
    /// <summary>
    /// Use the current position as offset?
    /// </summary>
    public bool useCurrentPositionAsOffset = true;
    [Space]
    [Range(0, 1)]
    /// <summary>
    /// Float specifying the amount of camera smoothing (0 - 1)
    /// </summary>
    public float cameraSmoothAmount = 0.5f;

    private Vector3 _velocity = Vector3.zero;          // Private Vector storing the current velocity

    void Start()
    {
        if (!objectToFollow)                                                            // Assign the object's transform with the provided tag if not set manually
        {
            objectToFollow = GameObject.FindGameObjectWithTag(objectsTag).transform;
        }

        if (useCurrentPositionAsOffset)
            offset = transform.position;                                                // Set the offset equal to the current position if useCurrentPositionOffset set to true

        print(name + " now following: "                                                 // Print what camera is following what object with what offset
                + objectToFollow.name 
                + " | Offset: " + offset.ToString());

        Player.PlayerDied.AddListerner(StopFollowingAndRotatingObject, "Cam Stop Following and Rotating Player");       // Stop following and rotating player on death
    }

    void Update()
    {
        if (rotateObject)
            RotateObject(objectToFollow);                                               // Rotate the object if rotateObject is true
    }

    void LateUpdate()
    {
        if(followObject)
            FollowObject(objectToFollow);                                               // Follow the object
    }

    /// <summary>
    /// Follow a specified object
    /// </summary>
    /// <param name="objectToFollow">
    /// Transform of the object to follow
    /// </param>
    private void FollowObject(Transform objectToFollow)
    {
        transform.position = Vector3.SmoothDamp(transform.position,
                                                    objectToFollow.position + offset,
                                                    ref _velocity,
                                                    cameraSmoothAmount);
    }

    /// <summary>
    /// Rotate a specified object
    /// </summary>
    /// <param name="objectToRotate">
    /// Transform of the object to rotate
    /// </param>
    private void RotateObject(Transform objectToRotate)
    {
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayRange = float.MaxValue;
        Ray camRay = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(camRay, out rayRange))
        {
            Vector3 pointToLook = camRay.GetPoint(rayRange);                            // Store the position of where the camRay intersects with the plane

            objectToRotate.LookAt(new Vector3(pointToLook.x,                            // Make the specified object look at a specified point
                                                objectToRotate.transform.position.y,
                                                pointToLook.z));
        }

        Debug.DrawRay(camRay.origin, camRay.direction * rayRange, Color.blue);
    }

    /// <summary>
    /// Stop following and rotating the object
    /// </summary>
    private void StopFollowingAndRotatingObject()
    {
        if(followObject)
            followObject = false;

        if (rotateObject)
            rotateObject = false;

        Debug.LogWarningFormat("{0} stopped following and rotating | {1}", gameObject.name, objectToFollow.name);
    }
}
