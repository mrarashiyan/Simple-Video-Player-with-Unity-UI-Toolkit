using System;
using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Constants;
using UnityEngine;
using UnityEngine.UIElements;

public class VideoSection : BaseUISection
{
    private VisualElement m_BackgroundPreviewImage;
    private VisualElement m_VideoOutputImage;

    public override void Initialize(VisualElement root, VideoController videoController)
    {
        base.Initialize(root, videoController);
        LoadModules();

        m_VideoController.onVideoChanged.AddListener(DoOnVideoChanged);
    }

    protected override void LoadModules()
    {
        base.LoadModules();

        m_BackgroundPreviewImage = GetElement<VisualElement>(PlayerWindowConsts.Panels.BACKGROUND_PREVIEW_IMAGE);
        m_VideoOutputImage = GetElement<VisualElement>(PlayerWindowConsts.Panels.VIDEO_OUTPUT);
        
        m_VideoOutputImage.AddToClassList("VideoOutput--Up");
        Invoke(nameof(PlayIntroAnim),0.5f);
    }

    [ContextMenu("Play")]
    private void PlayIntroAnim()
    {
        m_VideoOutputImage.RemoveFromClassList("VideoOutput--Up");
    }

    private void DoOnVideoChanged(VideoController videoController)
    {
        m_BackgroundPreviewImage.style.backgroundImage =
            new StyleBackground(Background.FromRenderTexture(m_VideoController.renderTexture));

        m_VideoOutputImage.style.backgroundImage =
            new StyleBackground(Background.FromRenderTexture(m_VideoController.renderTexture));
    }

    [ContextMenu("Reset Anim")]
    public override void Deinitialize()
    {
        m_VideoController.onVideoChanged.RemoveListener(DoOnVideoChanged);
        m_VideoOutputImage.AddToClassList("VideoOutput--Up");
    }
}