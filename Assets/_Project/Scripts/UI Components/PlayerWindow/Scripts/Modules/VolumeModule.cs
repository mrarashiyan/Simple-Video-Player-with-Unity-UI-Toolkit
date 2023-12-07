using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Constants;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PlayerWindow.Modules
{
    public class VolumeModule : BaseUIModule
    {
        private VideoController m_VideoController;
        private Button m_AudioBtn;
        private Slider m_VolumeSlider;
        private bool m_IsOnVolumeButton = false;
        private bool m_IsOnVolumePanel = false;

        public void Initialzie(VisualElement root, VideoController videoController)
        {
            SetRoot(root);
            m_VideoController = videoController;

            LoadModule();
        }

        public override void LoadModule()
        {
            base.LoadModule();

            // Volume bar
            m_AudioBtn = GetElement<Button>(PlayerWindowConsts.Buttons.AUDIO_BUTTON);
            m_VolumeSlider = GetElement<Slider>(PlayerWindowConsts.Sliders.AUDIO_VOLUME);
            m_AudioBtn.RegisterCallback<PointerEnterEvent>(evt =>
            {
                m_IsOnVolumeButton = true;
                CheckAudioPanelDisplay();
            });
            m_AudioBtn.RegisterCallback<PointerLeaveEvent>(evt =>
            {
                m_IsOnVolumeButton = false;
                CheckAudioPanelDisplay();
            });
            m_VolumeSlider.RegisterCallback<PointerEnterEvent>(evt =>
            {
                m_IsOnVolumePanel = true;
                CheckAudioPanelDisplay();
            });
            m_VolumeSlider.RegisterCallback<PointerLeaveEvent>(evt =>
            {
                m_IsOnVolumePanel = false;
                CheckAudioPanelDisplay();
            });
            m_VolumeSlider.RegisterValueChangedCallback(value => { m_VideoController.SetVolume(value.newValue); });
        }

        private void CheckAudioPanelDisplay()
        {
            if (m_IsOnVolumeButton || m_IsOnVolumePanel)
                m_VolumeSlider.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);

            if (!m_IsOnVolumeButton && !m_IsOnVolumePanel)
                m_VolumeSlider.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
        }

        public override void UnloadModule()
        {
            base.UnloadModule();
            //m_AudioBtn.UnregisterCallback<PointerEnterEvent>();   
        }
    }
}