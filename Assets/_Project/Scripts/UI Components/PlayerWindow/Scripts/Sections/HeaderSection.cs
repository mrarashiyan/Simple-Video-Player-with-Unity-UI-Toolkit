using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Constants;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PlayerWindow.Functionality
{
    public class HeaderSection : BaseUISection
    {
        
        private Button m_OpenFileBtn;
        private Label m_TrackNameLabel;

        public override void Initialize(VisualElement root, VideoController videoController)
        {
            base.Initialize(root, videoController);
            
            m_VideoController.onVideoChanged.AddListener(DoOnVideoChanged);
            LoadModules();
        }
        
        protected override void LoadModules()
        {
            base.LoadModules();
            
            // Open Video Button
            m_OpenFileBtn = GetElement<Button>(PlayerWindowConsts.Buttons.OPEN_FILE_BUTTON);
            m_OpenFileBtn.clicked += DoMOpenFileBtnClicked;

            // File Name Label
            m_TrackNameLabel = GetElement<Label>(PlayerWindowConsts.Labels.FILE_NAME);

        }

        private void DoOnVideoChanged(VideoController videoController)
        {
            m_TrackNameLabel.text = videoController.videoName;   
        }
        
        private void DoMOpenFileBtnClicked()
        {
#if UNITY_EDITOR
            var filePath = EditorUtility.OpenFilePanel("Choose Your Video", Application.dataPath, "mp4");
            if (filePath != null)
            {
                m_VideoController.LoadVideo(filePath);
            }
#endif
        }
    }
}