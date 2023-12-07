using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Constants;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PlayerWindow.Modules
{
    public class PlayPauseModule : BaseUIModule
    {
        private VideoController m_VideoController;
        private Button m_PlayBtn;
        private Button m_PauseBtn;

        public void Initialzie(VisualElement root, VideoController videoController)
        {
            SetRoot(root);
            m_VideoController = videoController;

            LoadModule();
        }

        public override void LoadModule()
        {
            base.LoadModule();

            // Play Button
            m_PlayBtn = GetElement<Button>(PlayerWindowConsts.Buttons.PLAY_BUTTON);
            m_PlayBtn.clicked += DoMPlayFileClicked;

            // Pause Button
            m_PauseBtn = GetElement<Button>(PlayerWindowConsts.Buttons.PAUSE_BUTTON);
            m_PauseBtn.clicked += DoMPauseFileClicked;
        }

        private void DoMPlayFileClicked()
        {
            m_VideoController.PlayVideo();
            m_PlayBtn.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
            m_PauseBtn.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
        }

        private void DoMPauseFileClicked()
        {
            m_VideoController.PauseVideo();
            m_PlayBtn.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
            m_PauseBtn.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
        }

        public override void UnloadModule()
        {
            base.UnloadModule();
        }
    }
}