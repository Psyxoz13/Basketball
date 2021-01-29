using UnityEngine;

public class Volume
{
    public static float GetVolumeScaleFromSpeed(Rigidbody rigidbody, float audioVolumeMultiplier)
    {
        var speed = GetSpeed(rigidbody);

        return Mathf.Clamp(speed * audioVolumeMultiplier, 0f, 10f);
    }

    public static float GetVolumeScaleFromSpeed(Rigidbody rigidbody, float audioVolumeMultiplier, float minSpeed)
    {
        var speed = GetSpeed(rigidbody);

        if (speed < minSpeed)
            return 0f;

        return Mathf.Clamp(speed * audioVolumeMultiplier, 0f, 10f);
    }

    public static float GetSpeed(Rigidbody rigidbody)
    {
        return rigidbody.velocity.magnitude;
    }
}
