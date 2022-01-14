using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using DevComponents.AdvTree;

namespace WzComparerR2
{
    public partial class FrmAbout:DevComponents.DotNetBar.Office2007Form
    {
        public FrmAbout()
        {
            InitializeComponent();

            this.lblClrVer.Text = string.Format("{0} ({1})",Environment.Version,Environment.Is64BitProcess ? "x64" : "x86");
            this.lblAsmVer.Text = GetAsmVersion().ToString();
            this.lblFileVer.Text = GetFileVersion().ToString();
            this.lblCopyright.Text = GetAsmCopyright().ToString();
            GetPluginInfo();
        }

        private Version GetAsmVersion()
        {
            return this.GetType().Assembly.GetName().Version;
        }

        private string GetFileVersion()
        {
            return this.GetAsmAttr<AssemblyInformationalVersionAttribute>()?.InformationalVersion
                ?? this.GetAsmAttr<AssemblyFileVersionAttribute>()?.Version;
        }

        private string GetAsmCopyright()
        {
            return this.GetAsmAttr<AssemblyCopyrightAttribute>()?.Copyright;
        }

        private void GetPluginInfo()
        {
            this.advTree1.Nodes.Clear();

            this.advTree1.Nodes.Add(new Node("KMS <font color=\"#808080\">v4.1.0</font>"));

            foreach(var contribution in new[]
            {

                Tuple.Create("[KMS] 添加各種功能，最終翻譯", "박현민"),
                Tuple.Create("[KMS] 短句翻譯", "슈린냥"),
                Tuple.Create("[KMS] 語句錯誤舉報", "인소야닷컴 실버"),
                Tuple.Create("[KMS] 語句錯誤舉報", "jusir_@naver.com"),
                Tuple.Create("[KMS] 工具提示錯誤舉報", "@Sunaries"),
                Tuple.Create("[KMS] 無法重複佩戴的文字錯誤舉報", "인소야닷컴 진류"),
                Tuple.Create("[KMS] 新增頭像保存功能", "@craftingmod"),
                Tuple.Create("[KMS] 頭像加載錯誤報告", "인소야닷컴 일감"),
                Tuple.Create("[KMS] 保存檔案時提供名稱規則錯誤資訊", "@mabooky"),
                Tuple.Create("[KMS] Avatar Hiref 耳朵錯誤報告", "메이플인벤 누리신드롬"),
                Tuple.Create("[KMS] 各種錯誤報告，提供GMS信息", "@Sunaries"),
                Tuple.Create("[KMS] 可用職業語句錯誤舉報", "@tanyoucai"),
                Tuple.Create("[KMS] 任務狀態不適用party錯誤舉報", "메이플인벤 펄더"),
                Tuple.Create("[KMS] 頭像錯誤報告", "@giraffebin"),
                Tuple.Create("[KMS] 添加文字、工具提示位置錯誤修正和舉報、視窗大小存儲功能、Kain支持", "@OniOniOn-"),
                Tuple.Create("[KMS] 與補丁一起比較時提供錯誤資訊", "@lowrt"),
                Tuple.Create("[KMS] 所有頭象匯出錯誤舉報", "@pid011"),
                Tuple.Create("[KMS] 添加與工具提示相關的功能，錯誤修正和舉報", "@sh-cho"),

            })
            {
                string nodeTxt = string.Format("{0} <font color=\"#808080\">{1}</font>",
                        contribution.Item1,
                        contribution.Item2);
                Node node = new Node(nodeTxt);
                this.advTree1.Nodes.Add(node);
            }

            if(PluginBase.PluginManager.LoadedPlugins.Count > 0)
            {
                foreach(var plugin in PluginBase.PluginManager.LoadedPlugins)
                {
                    string nodeTxt = string.Format("{0} <font color=\"#808080\">{1} ({2})</font>",
                        plugin.Instance.Name,
                        plugin.Instance.Version,
                        plugin.Instance.FileVersion);
                    Node node = new Node(nodeTxt);
                    this.advTree1.Nodes.Add(node);
                }
            }
            else
            {
                string nodeTxt = "<font color=\"#808080\">沒有連接的挿件</font>";
                Node node = new Node(nodeTxt);
                this.advTree1.Nodes.Add(node);
            }
        }

        private T GetAsmAttr<T>()
        {
            object[] attr = this.GetType().Assembly.GetCustomAttributes(typeof(T),true);
            if(attr != null && attr.Length > 0)
            {
                return (T)attr[0];
            }
            return default(T);
        }
    }
}
