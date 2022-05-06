using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
   private string _name;
   private string _path;

   public string Name =>_name;
   public string Path => _path;

/// <summary>
/// UI名称和文件夹地址
/// </summary>
/// <param name="ui_name"></param>
/// <param name="ui_path"></param>
   public UIType(string ui_name, string ui_path){

       _name = ui_name;
       _path = ui_path;

   }
}
