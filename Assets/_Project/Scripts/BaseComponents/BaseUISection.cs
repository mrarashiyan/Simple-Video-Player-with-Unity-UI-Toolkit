using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements;


public class BaseUISection : MonoBehaviour
{
    protected VisualElement m_Root;
    protected VideoController m_VideoController;


    public virtual void Initialize(VisualElement root, VideoController videoController)
    {
        SetRoot(root);
        SetVideoController(videoController);
    }

    public virtual void Deinitialize()
    {
    }   
    
    public void SetRoot(VisualElement root)
    {
        if (root == null)
        {
            Debug.LogError("[BaseUISection] SetRoot: Root is null!",this);
            return;
        }
        m_Root = root;
    }

    public void SetVideoController(VideoController videoController)
    {
        if (videoController == null)
        {
            Debug.LogError("[BaseUISection] SetVideoController: VideoController is null!",this);
            return;
        }
        m_VideoController = videoController;
    }


    protected virtual void LoadModules()
    {
    }

    protected T GetElement<T>(string Path) where T : VisualElement
    {
        return m_Root.Q<T>(Path);
    }

    protected T AddModule<T>() where T : Component
    {
        var component = gameObject.AddComponent<T>();
        return component;
    }

    protected T GetModule<T>() where T : Component
    {
        var component = gameObject.GetComponent<T>();
        return component;
    }
}