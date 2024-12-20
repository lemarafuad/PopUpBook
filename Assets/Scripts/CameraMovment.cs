using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTransform; // The camera's transform
    public float moveSpeed = 1.0f; // Speed of movement

    private Vector3[] positions = new Vector3[]
    {
        new Vector3(-88, 140, -170),
        new Vector3(-237, 100, -70),
        new Vector3(-121, 83, -44) ,
        new Vector3(-84, 73, 3) ,
        new Vector3(-117, 78, -77),
        new Vector3(-136, 58, -46),
        new Vector3(-99, 65, -44),
        new Vector3(-183, 58, -45),
        new Vector3(-119, 63, -87)
    };

    private Quaternion[] rotations = new Quaternion[]
    {
        Quaternion.Euler(45, 0, 0),
        Quaternion.Euler(40, 70, 0),
        Quaternion.Euler(9, 76, 0),
        Quaternion.Euler(7, 83, 0),
        Quaternion.Euler(7, 83, 0),
        Quaternion.Euler(7, 83, 0),
        Quaternion.Euler(38, 76, -8),
        Quaternion.Euler(10, 83, 0),
        Quaternion.Euler(11, 56, 0)
    };

    private float moveDuration = 2.0f;

    void Start()
    {

        StartCoroutine(MoveAndRotateCameraSequence());
    }

    IEnumerator MoveAndRotateCameraSequence()
    {

        for (int i = 0; i < positions.Length; i++)
        {
            if (i == 0)
            {

                cameraTransform.position = positions[i];
                cameraTransform.rotation = rotations[i];
            }


            yield return StartCoroutine(SmoothMoveAndRotateCamera(positions[i], rotations[i]));


            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator SmoothMoveAndRotateCamera(Vector3 targetPosition, Quaternion targetRotation)
    {
        float elapsedTime = 0f;


        Vector3 initialPosition = cameraTransform.position;
        Quaternion initialRotation = cameraTransform.rotation;

        while (elapsedTime < moveDuration)
        {

            cameraTransform.position = Vector3.Lerp(initialPosition, targetPosition, (elapsedTime / moveDuration));

            cameraTransform.rotation = Quaternion.Lerp(initialRotation, targetRotation, (elapsedTime / moveDuration));

            elapsedTime += Time.deltaTime;
            yield return null;
        }


        cameraTransform.position = targetPosition;
        cameraTransform.rotation = targetRotation;
    }
}
