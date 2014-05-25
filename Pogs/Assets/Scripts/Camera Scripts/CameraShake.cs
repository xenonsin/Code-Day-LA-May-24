using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
   // public float duration = 0.5f;
   // public float speed = 5.0f;
   // public float magnitude = 0.2f;

    void Update()
    {
        /*
        if (Input.GetKeyDown("f"))
        {
            PlayShake(0.5f,5.0f,0.2f);
        }*/
    }

    //This function is used outside (or inside) the script
    public void PlayShake(float duration, float speed, float magnitude)
    {
        StopAllCoroutines();
        StartCoroutine(Shake(duration, speed, magnitude));


    }

    private IEnumerator Shake(float duration, float speed, float magnitude)
    {
        float elapsed = 0.0f;

       

        float randomStart = Random.Range(-1000.0f, 1000.0f);

        while (elapsed < duration)
        {
            Vector3 originalCamPos = transform.position;

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;

            float damper = 1.0f - Mathf.Clamp(1.5f * percentComplete - 1.0f, 0.0f, 1.0f);
            float alpha = randomStart + speed * percentComplete;

            float x = Mathf.PerlinNoise(alpha, 0.0f) * 2.0f - 1.0f;
            float z = Mathf.PerlinNoise(0.0f, alpha) * 2.0f - 1.0f;

            x *= magnitude * damper;
            z *= magnitude * damper;

            x += originalCamPos.x;
            z += originalCamPos.z;


            transform.position = new Vector3(x, originalCamPos.y, z);

            yield return 0;
        }

       // transform.position = Vector3.Lerp(transform.position, originalCamPos, Time.deltaTime * 5f);
    }
}