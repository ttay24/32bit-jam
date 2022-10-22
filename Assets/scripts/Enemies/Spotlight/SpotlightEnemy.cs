using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightEnemy : MonoBehaviour
{

    [SerializeField]
    public float SearchAngle = 90.0f;

    [SerializeField]
    public float RotateSpeed = 10.0f;

    // starting vals
    private Quaternion StartQuaternion;
    private Vector3 StartAngle;
    private Quaternion MinimumRotation;
    private Quaternion MaximumRotation;
    private float CurrentRotateDirection = 1.0f;

    private void Awake()
    {
        StartQuaternion = this.transform.localRotation;
        StartAngle = StartQuaternion.eulerAngles;
        Debug.Log(string.Format("StartAngle: {0}", StartAngle.ToString()));

        MinimumRotation = StartQuaternion * Quaternion.Euler(Vector3.up * (SearchAngle / -2.0f));
        MaximumRotation = StartQuaternion * Quaternion.Euler(Vector3.up * (SearchAngle / 2.0f));

        Debug.Log(string.Format("MinimumRotation: {0}", MinimumRotation));
        Debug.Log(string.Format("MaximumRotation: {0}", MaximumRotation));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, CurrentRotateDirection * RotateSpeed * Time.deltaTime);

        var currentRotation = this.transform.localRotation.eulerAngles;

        // normalize the y rotation
        var currentYRotation = currentRotation.y;
        //if (IsMaxAbove360 && )

        //Debug.Log(string.Format("currentYRotation : {0}", currentYRotation));

        var rotatedFromOG = Quaternion.Angle(transform.localRotation, StartQuaternion);
        Debug.Log(string.Format("angle: {0}", Quaternion.Angle(transform.localRotation, StartQuaternion)));

        if (rotatedFromOG > (SearchAngle / 2.0f))
        {
            // clamp to max if we are rotating that way
            if (CurrentRotateDirection == 1.0f)
                this.transform.localRotation = MaximumRotation;
            // otherwise clamp to min
            else
                this.transform.localRotation = MinimumRotation;

            CurrentRotateDirection *= -1.0f;
        }
        /*else if (rotatedFromOG < (SearchAngle / -2.0f))
        {
            CurrentRotateDirection *= -1.0f;
            // clamp to min
            this.transform.localRotation = MinimumRotation;
        }*/
    }
}
