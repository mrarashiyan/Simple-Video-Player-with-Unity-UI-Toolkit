using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [HideInInspector] public UnityEvent<VideoController> onVideoChanged;
    [HideInInspector] public UnityEvent<VideoController> onVideoFrameReady;

    private VideoPlayer m_VideoPlayer;

    #region Engine Functions

    private void Awake()
    {
        m_VideoPlayer = GetComponent<VideoPlayer>();
    }

    private void OnEnable()
    {
        m_VideoPlayer.prepareCompleted += OnVideoLoaded;
    }

    private void OnDisable()
    {
        m_VideoPlayer.prepareCompleted -= OnVideoLoaded;
        m_VideoPlayer.targetTexture.Release();
    }

    private void Update()
    {
        if (m_VideoPlayer.isPlaying)
        {
            OnFrameReady();
        }
    }

    #endregion

    #region Video Player Functions

    public void LoadVideo(string videoPath)
    {
        m_VideoPlayer.url = videoPath;
        m_VideoPlayer.Prepare();
    }

    public void PlayVideo()
    {
        m_VideoPlayer.Play();
    }

    public void PauseVideo()
    {
        m_VideoPlayer.Pause();
    }

    public void SetVolume(float volume)
    {
        m_VideoPlayer.GetTargetAudioSource(0).volume = volume;
    }

    public void SeekTime(double time)
    {
        m_VideoPlayer.time = time;
    }

    #endregion

    #region Data Fields

    public string videoName => Path.GetFileName(m_VideoPlayer.url);
    public double videoLength => m_VideoPlayer.length;
    public double currentVideoTime => m_VideoPlayer.time;

    public string videoLengthStr =>
        string.Format("{0:00}:{1:00}:{2:00}", videoLength / 3600, videoLength / 60, videoLength % 60);

    public RenderTexture renderTexture => m_VideoPlayer.targetTexture;

    #endregion

    #region Event Handlers

    private void OnVideoLoaded(VideoPlayer source)
    {
        PlayVideo();
        onVideoChanged?.Invoke(this);
    }


    private void OnFrameReady()
    {
        onVideoFrameReady?.Invoke(this);
    }

    #endregion
}