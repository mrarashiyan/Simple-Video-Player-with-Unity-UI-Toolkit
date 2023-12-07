using System;
using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Functionality;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWindowInitializer : MonoBehaviour
{
    [SerializeField] private VideoController m_VideoController;
    [SerializeField] private UIDocument m_UiDocument;
    
    [Space(20)]
    [SerializeField] private HeaderSection m_UiHeader;
    [SerializeField] private VideoSection m_UiVideo;
    [SerializeField] private FooterSection m_UiFooter;
    
    private VisualElement m_Root;

    private void OnEnable()
    {
        m_Root = m_UiDocument.rootVisualElement;
        
        m_UiHeader.Initialize(m_Root,m_VideoController);
        m_UiVideo.Initialize(m_Root,m_VideoController);
        m_UiFooter.Initialize(m_Root,m_VideoController);
    }

    private void OnDisable()
    {
        m_UiVideo.Deinitialize();
    }
}
