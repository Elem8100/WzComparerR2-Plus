using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using WzComparerR2.CharaSim;
using WzComparerR2.WzLib;
using System.Text.RegularExpressions;

namespace WzComparerR2.Avatar
{
    public class AvatarPart
    {
        public AvatarPart(Wz_Node node)
        {
            this.Node = node;
            this.Visible = true;
            this.LoadInfo();
        }

        public Wz_Node Node { get; private set; }
        public string ISlot { get; private set; }
        public BitmapOrigin Icon { get; private set; }
        public bool Visible { get; set; }
        public int? ID { get; private set; }

        private void LoadInfo()
        {
            var m = Regex.Match(Node.Text, @"^(\d+)\.img$");
            if (m.Success)
            {
                this.ID = Convert.ToInt32(m.Result("$1"));
                GearType type = Gear.GetGearType(this.ID.Value);
                if (type == GearType.face || type == GearType.face2)
                {
                    Icon = BitmapOrigin.CreateFromNode(PluginBase.PluginManager.FindWz(@"Item\Install\0380.img\03801284\info\icon"), PluginBase.PluginManager.FindWz);
                }
                if (type == GearType.hair || type == GearType.hair2 || type == GearType.hair3)
                {
                    Icon = BitmapOrigin.CreateFromNode(PluginBase.PluginManager.FindWz(@"Item\Install\0380.img\03801283\info\icon"), PluginBase.PluginManager.FindWz);
                }
                if (type == GearType.head)
                {
                    Icon = BitmapOrigin.CreateFromNode(PluginBase.PluginManager.FindWz(@"Item\Install\0380.img\03801577\info\icon"), PluginBase.PluginManager.FindWz);
                }
            }

            Wz_Node infoNode = this.Node.FindNodeByPath("info");
            if (infoNode == null)
            {
                return;
            }

            foreach (var node in infoNode.Nodes)
            {
                switch (node.Text)
                {
                    case "islot":
                        this.ISlot = node.GetValue<string>();
                        break;

                    case "icon":
                        this.Icon = BitmapOrigin.CreateFromNode(node, PluginBase.PluginManager.FindWz);
                        break;
                }
            }
        }
    }
}
