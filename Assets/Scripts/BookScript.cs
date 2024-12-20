
using UnityEngine;

public class RotateExample : MonoBehaviour
{
    public Transform element0;
    public Transform element1;
    public Transform flowers;
    public Transform[] papers;

    public Transform[] sennara;

    public Transform al7abel;

    public Transform fish;
    float speed = 20.0f;
    float currentRotation1 = 0.0f;
    float currentRotation2 = 0.0f;
    float flowersCurrentRotation = 90.0f;
    float sennaraCurrentRotation1 = 0.0f;
    float sennaraCurrentRotation2 = 0.0f;
    float targetRotation1 = -90.0f;
    float targetRotation2 = 90.0f;
    float flowersTargetRotation = 0.0f;
    float sennaraTargetRotation1 = 90.0f;
    float sennaraTargetRotation2 = -90.0f;



    Vector3 targetScale = new Vector3(1.0f, 3f, 1.0f);
    float scalingSpeed = 10.0f;

    float x1 = -5.0f;
    float x2 = 1.0f;
    float moveSpeed = 2.0f;

    private bool movingUp = true;

    private Vector3 FishTargetScale = new Vector3(2, 2, 2);

    private bool isRotatingAndScaling = false;


    private Vector3 initialFishPosition;

    void Start()
    {

    }


    void Update()
    {
        float rotationStep = speed * Time.deltaTime;

        if (currentRotation1 > targetRotation1)
        {
            element0.Rotate(0, 0, -rotationStep);
            element1.Rotate(0, 0, -rotationStep);
            currentRotation1 -= rotationStep;
        }

        if (flowersCurrentRotation > flowersTargetRotation)
        {
            flowers.Rotate(0, 0, -rotationStep);
            flowersCurrentRotation -= rotationStep;
        }


        if (currentRotation2 < targetRotation2)
        {
            papers[0].Rotate(0, 0, rotationStep);
            papers[1].Rotate(0, 0, rotationStep);
            papers[2].Rotate(0, 0, rotationStep);
            papers[3].Rotate(0, 0, rotationStep);
            currentRotation2 += rotationStep;
        }
        else
        {
            fish.localScale = Vector3.Lerp(fish.localScale, targetScale, Time.deltaTime * 2.0f);
            if (fish.localScale == targetScale)
            {
                Vector3 currentPosition = fish.position;
                if (movingUp)
                {
                    currentPosition.y += moveSpeed * Time.deltaTime;
                    if (currentPosition.y >= x2)
                    {
                        currentPosition.y = x2;
                        movingUp = false;
                    }
                }
                else
                {
                    currentPosition.y -= moveSpeed * Time.deltaTime;
                    if (currentPosition.y <= x1)
                    {
                        currentPosition.y = x1;
                        movingUp = true;
                    }
                }
                fish.position = currentPosition;
                initialFishPosition = currentPosition;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isRotatingAndScaling = true;  // Enable the rotation and scaling behavior when Enter is pressed
            }
            if (isRotatingAndScaling)
            {
                float rotationStepInside = speed * Time.deltaTime;
                if (sennaraCurrentRotation1 < sennaraTargetRotation1)
                {
                    sennara[0].Rotate(0, 0, rotationStepInside);
                    sennaraCurrentRotation1 += rotationStepInside;
                }
                if (sennaraCurrentRotation2 > sennaraTargetRotation2)
                {
                    sennara[1].Rotate(-rotationStepInside, 0, 0);
                    sennaraCurrentRotation2 -= rotationStepInside;
                }
                else
                {
                    if (al7abel.localScale != targetScale)
                    {
                        al7abel.localScale = Vector3.MoveTowards(al7abel.localScale, targetScale, scalingSpeed * Time.deltaTime);
                    }
                }

            }

        }

    }
}



