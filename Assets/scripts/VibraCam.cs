using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class VibraCam : MonoBehaviour
{   
    public static VibraCam Instance;
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private CinemachineBasicMultiChannelPerlin cineMachineBasicMultiChannelPerlin;

    private float tiempoMov;
    private float tiempoTotal;
    private float intensidadInicial;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cineMachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        
    }

    // Update is called once per frame
    public void Sacudir(float intensidad, float frecuencia, float tiempo)
    {
        cineMachineBasicMultiChannelPerlin.m_AmplitudeGain = intensidad;
        cineMachineBasicMultiChannelPerlin.m_FrequencyGain = frecuencia;
        intensidadInicial = intensidad;
        tiempoTotal = tiempo;
        tiempoMov = tiempo;
    }

    private void Update(){
        if (tiempoMov > 0)
        {
            tiempoMov -= Time.deltaTime;
            cineMachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intensidadInicial,0, 1 -(tiempoMov/tiempoTotal));
        }

    }
}
