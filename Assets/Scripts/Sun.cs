using UnityEngine;

[RequireComponent(typeof(Light))]
public class Sun : MonoBehaviour
{
    public AnimationCurve intentistyCurve;
    private float Elapsed;
    private Quaternion originalRotation;
    private Light light;

    private void Awake()
    {
        originalRotation = transform.rotation;
        light = GetComponent<Light>();
    }

    void Update()
    {
        Elapsed += Time.deltaTime;
        if (Elapsed > 50)
        {
           light.color = Color.white;
           Elapsed += 9*Time.deltaTime; // 10 degrees per second during night
        }
        if (Elapsed > 100) // one degree per second during day
        {
            Elapsed = 0;
        }

        var steps = Elapsed/100;
        var rotation = Mathf.Lerp(0, 360, steps) ; // third is in percent

        // 0/360 = midnight
        // 45 = morning, sunrise
        // 90 = noon
        // 135 = afternoon
        // 180 = evening, sundown

        light.intensity = intentistyCurve.Evaluate(steps);
        if(rotation > 135)
            light.color = Color.Lerp(Color.white, Color.red, steps);

        Debug.Log($"Elasped: {Elapsed} Steps: {steps} Rotation: {rotation}");

        transform.rotation = Quaternion.Euler(180-rotation, originalRotation.eulerAngles.y, originalRotation.eulerAngles.z);
    }
}
