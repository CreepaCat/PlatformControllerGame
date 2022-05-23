using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{


    //单例模式
    private static UIManager _instance;

    public Canvas _canvas;

    //字典储存UI信息
    public Dictionary<string, GameObject> dict_ui_objs;

    //栈模拟UI间叠加
    public Stack<BasePanel> stack_panels;

    public UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UIManger单例获取失败！");
                return _instance;
            }
            return _instance;
        }
    }
    //构造初始化
    public UIManager()
    {
        _instance = this;
        stack_panels = new Stack<BasePanel>();
        dict_ui_objs = new Dictionary<string, GameObject>();

        //  _canvas = canvas;

    }


    /// <summary>
    /// 获取字典里指定ui实体，如果没有就实例化

    public GameObject GetUIGameObject(UIType _uiType)
    {

        if (dict_ui_objs.ContainsKey(_uiType.Name))
        {
            dict_ui_objs[_uiType.Name].SetActive(true);
            return dict_ui_objs[_uiType.Name];
        }


        //  GameObject prefab = Resources.Load<GameObject>(_uiType.Path);

        GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(_uiType.Path), _canvas.transform);
        dict_ui_objs.Add(_uiType.Name, gameObject);

        return dict_ui_objs[_uiType.Name];
    }


    //入栈

    public void Push(BasePanel panel)
    {

        Debug.Log("UIManager Push");

        GameObject panel_obj = GetUIGameObject(panel._uiType);

        //绑定当前激活ui gameObject
        panel.SetActiveObj(panel_obj);


        if (stack_panels.Count > 0)
        {
            stack_panels.Peek().OnDisable();
        }

        //入栈
        if ((stack_panels.Count == 0) || (panel._uiType.Name != stack_panels.Peek()._uiType.Name))
        {
            // stack_panels.Peek().OnDisable();
            stack_panels.Push(panel);
        }

        //激发
        panel.OnStart();

        // dict_panels[uiType.Name].OnStart();

    }


    //出栈
    public void Pop()
    {

        // GameObject gameObject = dict_ui_obj[stack_panels.Peek()._uiType.Name];

        if (stack_panels.Count > 0)
        {
            BasePanel panel = stack_panels.Peek();
            panel.OnDisable();
            panel.OnDestroy();
            dict_ui_objs[panel._uiType.Name].SetActive(false);
            //panel
            stack_panels.Pop();
            if (stack_panels.Count > 0)
            {
                stack_panels.Peek().OnEnable();
            }


        }

    }

    public void PopAll()
    {
        while (stack_panels.Count > 0)
        {
            Pop();
        }
    }


}
