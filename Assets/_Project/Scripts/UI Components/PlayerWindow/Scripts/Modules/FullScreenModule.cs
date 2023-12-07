using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Constants;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PlayerWindow.Modules
{
    public class FullScreenModule : BaseUIModule
    {
        private VisualElement m_VideoOutputImage;
        private Button m_FullScreenBtn;
        private bool m_IsFullScreen = false;
        private StyleLength m_StarterWidth;
        private StyleLength m_StarterHeight;

        public void Initialzie(VisualElement root)
        {
            SetRoot(root);
            LoadModule();
        }

        public override void LoadModule()
        {
            base.LoadModule();

            // video 
            m_VideoOutputImage = GetElement<VisualElement>(PlayerWindowConsts.Panels.VIDEO_OUTPUT);

            //Full Screen Btn
            m_FullScreenBtn = GetElement<Button>(PlayerWindowConsts.Buttons.FULLSCREEN_BUTTON);
            m_StarterWidth = m_VideoOutputImage.style.width;
            m_StarterHeight = m_VideoOutputImage.style.height;
            m_FullScreenBtn.clicked += ToggleFullScreen;
        }

        private void ToggleFullScreen()
        {
            m_IsFullScreen = !m_IsFullScreen;
            if (m_IsFullScreen)
            {
                m_VideoOutputImage.style.width = new StyleLength(Length.Percent(100));
                m_VideoOutputImage.style.height = new StyleLength(Length.Percent(100));
            }
            else
            {
                m_VideoOutputImage.style.width = m_StarterWidth;
                m_VideoOutputImage.style.height = m_StarterHeight;
            }
        }

        public override void UnloadModule()
        {
            base.UnloadModule();
            m_FullScreenBtn.clicked -= ToggleFullScreen;
        }
    }
}