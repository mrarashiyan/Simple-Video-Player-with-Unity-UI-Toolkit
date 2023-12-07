using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Constants;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PlayerWindow.Modules
{
    public class SubtitleModule : BaseUIModule
    {
        private Button m_SubtitleBtn;
        private Toggle m_SubtitleToggle;

        public void Initialzie(VisualElement root)
        {
            SetRoot(root);

            LoadModule();
        }

        public override void LoadModule()
        {
            base.LoadModule();
            
            //Subtitle Btn
            m_SubtitleBtn = GetElement<Button>(PlayerWindowConsts.Buttons.SUBTITLE_BUTTON);
            m_SubtitleToggle = GetElement<Toggle>(PlayerWindowConsts.Toggles.SUBTITILE_TOGGLE);
            /*m_SubtitleToggle.RegisterValueChangedCallback(value =>
            {
                //todo show/hide caption box
            });*/
        }

        public override void UnloadModule()
        {
            base.UnloadModule();
        }
    }
}