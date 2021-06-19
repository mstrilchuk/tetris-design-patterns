using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Observer
public class PopLineAudioPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();
    private void OnEnable() => TetrisBlock.OnAnyLineDeletion += PlayPopAudio;
    private void OnDisable() => TetrisBlock.OnAnyLineDeletion -= PlayPopAudio;
    private void PlayPopAudio() => _audioSource.Play();
}
