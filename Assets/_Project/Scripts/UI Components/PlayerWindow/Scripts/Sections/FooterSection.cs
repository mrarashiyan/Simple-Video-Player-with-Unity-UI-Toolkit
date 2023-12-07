using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Modules;
using UnityEngine;
using UnityEngine.UIElements;

public class FooterSection : BaseUISection
{
    private PlayPauseModule m_PlayPauseModule;
    private TimelineModule m_TimelineModule;
    private VolumeModule m_VolumeModule;
    private QualityModule m_QualityModule;
    private SubtitleModule m_SubtitleModule;
    private FullScreenModule m_FullScreenModule;

    public override void Initialize(VisualElement root, VideoController videoController)
    {
        base.Initialize(root, videoController);
        LoadModules();
    }

    protected override void LoadModules()
    {
        base.LoadModules();

        m_PlayPauseModule = AddModule<PlayPauseModule>();
        m_PlayPauseModule.Initialzie(m_Root, m_VideoController);

        m_TimelineModule = AddModule<TimelineModule>();
        m_TimelineModule.Initialzie(m_Root, m_VideoController);

        m_VolumeModule = AddModule<VolumeModule>();
        m_VolumeModule.Initialzie(m_Root,m_VideoController);

        m_QualityModule = AddModule<QualityModule>();
        m_QualityModule.Initialzie(m_Root);
        
        m_SubtitleModule = AddModule<SubtitleModule>();
        m_SubtitleModule.Initialzie(m_Root);
        
        m_FullScreenModule = AddModule<FullScreenModule>();
        m_FullScreenModule.Initialzie(m_Root);
    }

    public override void Deinitialize()
    {
        base.Deinitialize();
        
        m_PlayPauseModule.UnloadModule();
        m_TimelineModule.UnloadModule();
        m_VolumeModule.UnloadModule();
        m_QualityModule.UnloadModule();
        m_SubtitleModule.UnloadModule();
        m_FullScreenModule.UnloadModule();
    }
}