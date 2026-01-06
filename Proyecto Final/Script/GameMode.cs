using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using System;

public class GameMode : MonoBehaviour
{
    public  bool IsPlaying = false;
    public static event Action<bool> OnGameModeChanged;
    public CinemachineCamera editCamera;
    public CinemachineCamera playCamera;

    public void StartGame()
    {
        if (IsPlaying) return;

        IsPlaying = true;
        editCamera.Priority = 0;
        playCamera.Priority = 10;

        OnGameModeChanged?.Invoke(true);
        Debug.Log("Juego iniciado → Modo movimiento activado");
    }

    public void StopGame()
    {
        IsPlaying = false;
        editCamera.Priority = 10;
        playCamera.Priority = 0;

        OnGameModeChanged?.Invoke(false);
        Debug.Log("Modo edición activado");
    }
}
