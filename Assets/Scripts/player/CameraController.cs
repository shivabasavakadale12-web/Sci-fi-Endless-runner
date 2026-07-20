using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFov = 40f;
    [SerializeField] float maxFov = 100f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeed = 5f;
    [SerializeField] ParticleSystem speedup;

    CinemachineCamera cinemachineCamera;

    private void Awake()
    {
        speedup.Pause();
        cinemachineCamera = GetComponent<CinemachineCamera>();

    }

    public void changecamerafov(float speedamout)
    {
        StartCoroutine(camerafov(speedamout));
    }

    IEnumerator camerafov(float speedamount)
    {
        float currentfov = cinemachineCamera.Lens.FieldOfView;
        float targetfov = Mathf.Clamp(currentfov + speedamount * zoomSpeed, minFov, maxFov);



        
        float elapsedTime = 0f;
        while (elapsedTime < zoomDuration)
        {
             elapsedTime += Time.deltaTime;
             float t = elapsedTime / zoomDuration;
             cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(currentfov, targetfov, t);
             yield return null;
            
            speedup.Play();
            cinemachineCamera.Lens.FieldOfView = targetfov;
        }

        yield return new WaitForSeconds(10f);

        elapsedTime = 0f;
        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / zoomDuration;
            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(targetfov, currentfov, t);
            yield return null;
            cinemachineCamera.Lens.FieldOfView = currentfov;
        }

    }


}
