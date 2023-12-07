using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseUIModule : MonoBehaviour
{
    protected VisualElement m_Root;

    public void SetRoot(VisualElement root)
    {
        m_Root = root;
    }
    public virtual void LoadModule() { }

    public virtual void UnloadModule() { }

    protected T GetElement<T>(string Path) where T : VisualElement
    {
        return m_Root.Q<T>(Path);
    }
}
