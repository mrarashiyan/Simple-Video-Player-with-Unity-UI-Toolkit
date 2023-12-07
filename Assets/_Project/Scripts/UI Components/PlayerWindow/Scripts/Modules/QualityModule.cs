using System.Collections;
using System.Collections.Generic;
using UI.PlayerWindow.Constants;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PlayerWindow.Modules
{
    public class QualityModule : BaseUIModule
    {
        private Button m_QualityBtn;
        private VisualElement m_QualityPanel;
        private bool m_IsOnQualityButton = false;
        private bool m_IsOnQualityPanel = false;
        
        public void Initialzie(VisualElement root)
        {
            SetRoot(root);

            LoadModule();
        }

        public override void LoadModule()
        {
            base.LoadModule();
            
            //Quality Panel
            m_QualityBtn = GetElement<Button>(PlayerWindowConsts.Buttons.QUALITY_BUTTON);
            m_QualityPanel = GetElement<VisualElement>(PlayerWindowConsts.Panels.QUALITY_DROPDOWN);
            m_QualityBtn.RegisterCallback<PointerEnterEvent>(evt=>
            {
                m_IsOnQualityButton = true;
                CheckQualityPanelDisplay();
            });
            m_QualityBtn.RegisterCallback<PointerLeaveEvent>(evt=>
            {
                m_IsOnQualityButton = false;
                CheckQualityPanelDisplay();
            });
            m_QualityPanel.RegisterCallback<PointerEnterEvent>(evt=>
            {
                m_IsOnQualityPanel = true;
                CheckQualityPanelDisplay();
            });
            m_QualityPanel.RegisterCallback<PointerLeaveEvent>(evt=>
            {
                m_IsOnQualityPanel = false;
                CheckQualityPanelDisplay();
            });
            foreach (var qualityButton in m_QualityPanel.Children())
            {
                ((Button)qualityButton).clicked += () =>
                {
                    var currentBtn = (Button)qualityButton;
                    m_QualityBtn.text = currentBtn.text;
                };
            }
        }

        private void CheckQualityPanelDisplay()
        {
            if(m_IsOnQualityButton || m_IsOnQualityPanel)
                m_QualityPanel.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);

            if(!m_IsOnQualityButton && !m_IsOnQualityPanel)
                m_QualityPanel.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
        }
        
        public override void UnloadModule()
        {
            base.UnloadModule();
        }
    }
}