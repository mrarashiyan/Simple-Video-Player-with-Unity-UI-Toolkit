using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Constants;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PlayerWindow.Modules
{
    public class TimelineModule : BaseUIModule
    {
        private VideoController m_VideoController;
        private Slider m_TimelineSlider;
        private bool m_IsTimelineDragging = false;
        private Label m_TimeLabel;


        public void Initialzie(VisualElement root, VideoController videoController)
        {
            SetRoot(root);
            m_VideoController = videoController;

            m_VideoController.onVideoChanged.AddListener(DoOnVideoChanged);
            LoadModule();
        }

        public override void LoadModule()
        {
            base.LoadModule();

            //Time Label
            m_TimeLabel = GetElement<Label>(PlayerWindowConsts.Labels.TIME_LABEL);

            //Timeline
            m_TimelineSlider = GetElement<Slider>(PlayerWindowConsts.Sliders.TIMELINE);
            m_TimelineSlider.RegisterCallback<PointerCaptureOutEvent>(value => { m_IsTimelineDragging = false; });
            m_TimelineSlider.RegisterCallback<PointerCaptureEvent>(evt => { m_IsTimelineDragging = true; });
            m_TimelineSlider.RegisterValueChangedCallback(value =>
            {
                if (m_IsTimelineDragging)
                    m_VideoController.SeekTime(value.newValue);
            });
        }

        private void DoOnVideoChanged(VideoController videoController)
        {
            m_TimeLabel.text = videoController.videoLengthStr;
        }

        public override void UnloadModule()
        {
            base.UnloadModule();

            m_VideoController.onVideoChanged.RemoveListener(DoOnVideoChanged);

        }
    }
}