using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Resource = CharaSimResource.Resource;
using WzComparerR2.Common;
using WzComparerR2.CharaSim;
using WzComparerR2.WzLib;

namespace WzComparerR2.CharaSimControl
{
    public class SkillTooltipRender2:TooltipRender
    {
        public SkillTooltipRender2()
        {
        }

        public Skill Skill { get; set; }

        public override object TargetItem
        {
            get { return this.Skill; }
            set { this.Skill = value as Skill; }
        }

        public bool ShowProperties { get; set; } = true;
        public bool ShowDelay { get; set; }
        public bool ShowReqSkill { get; set; } = true;
        public bool DisplayCooltimeMSAsSec { get; set; } = true;
        public bool DisplayPermyriadAsPercent { get; set; } = true;
        public bool IsWideMode { get; set; } = true;

        public override Bitmap Render()
        {
            if(this.Skill == null)
            {
                return null;
            }

            CanvasRegion region = this.IsWideMode ? CanvasRegion.Wide : CanvasRegion.Original;

            int picHeight;
            List<int> splitterH;
            //Bitmap originBmp = RenderSkill(region,out picHeight);
            Bitmap originBmp = RenderSkill(region, out picHeight, out splitterH);
            Bitmap tooltip = new Bitmap(originBmp.Width,picHeight);
           
         
            Graphics g = Graphics.FromImage(tooltip);

            //绘制背景区域
            GearGraphics.DrawNewTooltipBack(g,0,0,tooltip.Width,tooltip.Height);
            if (splitterH != null && splitterH.Count > 0)
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                foreach (var y in splitterH)
                {
                    DrawV6SkillDotline(g, region.SplitterX1, region.SplitterX2, y);
                }
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            }


            //复制图像
            g.DrawImage(originBmp,0,0,new Rectangle(0,0,originBmp.Width,picHeight),GraphicsUnit.Pixel);

            //左上角
            g.DrawImage(Resource.UIToolTip_img_Skill_Frame_cover, 3, 3);

            if (this.ShowObjectID)
            {
                GearGraphics.DrawGearDetailNumber(g,3,3,Skill.SkillID.ToString("d7"),true);
            }

            if(originBmp != null)
                originBmp.Dispose();

            g.Dispose();
            return tooltip;
        }

        private Bitmap RenderSkill(CanvasRegion region, out int picH, out List<int> splitterH)
        {
            Bitmap bitmap = new Bitmap(region.Width,DefaultPicHeight);
            Graphics g = Graphics.FromImage(bitmap);
            StringFormat format = (StringFormat)StringFormat.GenericDefault.Clone();
            picH = 0;
            splitterH = new List<int>();
            //获取文字
            StringResult sr;
            if(StringLinker == null || !StringLinker.StringSkill.TryGetValue(Skill.SkillID,out sr))
            {
                sr = new StringResultSkill();
                sr.Name = "(null)";
            }

            //绘制技能名称
            format.Alignment = StringAlignment.Center;
            TextRenderer.DrawText(g,sr.Name,GearGraphics.ItemNameFont2,new Point(bitmap.Width,10),Color.White,TextFormatFlags.HorizontalCenter | TextFormatFlags.NoPrefix);

            //绘制图标

            picH = 33;
            g.DrawImage(Resource.UIToolTip_img_Skill_Frame_iconBackgrnd, 13, picH - 2);
            if (Skill.Icon.Bitmap != null)
            {
                picH = 33;
                g.FillRectangle(GearGraphics.GearIconBackBrush2,14,picH,68,68);
                g.DrawImage(GearGraphics.EnlargeBitmap(Skill.Icon.Bitmap),
                15 + (1 - Skill.Icon.Origin.X) * 2,
                picH + (33 - Skill.Icon.Bitmap.Height) * 2);
            }

            // for 6th job skills
            if (Skill.Origin)
            {
                g.DrawImage(Resource.UIWindow2_img_Skill_skillTypeIcon_origin, 16, 11);
            }

            //绘制desc
            picH = 35;
            if(Skill.HyperStat)
                GearGraphics.DrawString(g,"[等級上限 : " + Skill.MaxLevel + "]",GearGraphics.ItemDetailFont2,region.LevelDescLeft,region.TextRight,ref picH,16);
            else if(!Skill.PreBBSkill)
                GearGraphics.DrawString(g,"[等級上限 : " + Skill.MaxLevel + "]",GearGraphics.ItemDetailFont2,region.SkillDescLeft,region.TextRight,ref picH,16);

            if(sr.Desc != null)
            {
                string hdesc = SummaryParser.GetSkillSummary(sr.Desc,Skill.Level,Skill.Common,SummaryParams.Default);
                //string hStr = SummaryParser.GetSkillSummary(skill, skill.Level, sr, SummaryParams.Default);
                GearGraphics.DrawString(g,hdesc,GearGraphics.ItemDetailFont2,Skill.Icon.Bitmap == null ? region.LevelDescLeft : region.SkillDescLeft,region.TextRight,ref picH,16);
            }
            if(Skill.TimeLimited)
            {
                DateTime time = DateTime.Now.AddDays(7d);
                string expireStr = time.ToString("到yyyy年 M月 d日 H時 m分可以用");
                GearGraphics.DrawString(g,"#c" + expireStr + "#",GearGraphics.ItemDetailFont2,Skill.Icon.Bitmap == null ? region.LevelDescLeft : region.SkillDescLeft,region.TextRight,ref picH,16);
            }
            if(Skill.RelationSkill != null)
            {
                StringResult sr2 = null;
                if(StringLinker == null || !StringLinker.StringSkill.TryGetValue(Skill.RelationSkill.Item1,out sr2))
                {
                    sr2 = new StringResultSkill();
                    sr2.Name = "(null)";
                }
                DateTime time = DateTime.Now.AddMinutes(Skill.RelationSkill.Item2);
                string expireStr = time.ToString("有效期 : yyyy年 M月 d日 H時 m分");
                GearGraphics.DrawString(g,"#c" + sr2.Name + "의 " + expireStr + "#",GearGraphics.ItemDetailFont2,Skill.Icon.Bitmap == null ? region.LevelDescLeft : region.SkillDescLeft,region.TextRight,ref picH,16);
            }
            if(Skill.IsPetAutoBuff)
            {
                GearGraphics.DrawString(g,"#c可登入寵物Buff自動技能#",GearGraphics.ItemDetailFont2,Skill.Icon.Bitmap == null ? region.LevelDescLeft : region.SkillDescLeft,region.TextRight,ref picH,16);
            }
            if (Skill.ReqLevel > 0)
            {
                GearGraphics.DrawString(g, "#c[要求等级：" + Skill.ReqLevel.ToString() + "]#", GearGraphics.ItemDetailFont2, region.SkillDescLeft, region.TextRight, ref picH, 16);
            }
            if (Skill.ReqAmount > 0)
            {
                GearGraphics.DrawString(g, "#c" + ItemStringHelper.GetSkillReqAmount(Skill.SkillID, Skill.ReqAmount) + "#", GearGraphics.ItemDetailFont2, region.SkillDescLeft, region.TextRight, ref picH, 16);
            }
            picH += 13;
            //分割线
            picH = Math.Max(picH,114);
            //g.DrawLine(Pens.White,region.SplitterX1,picH,region.SplitterX2,picH);
            //picH += 9;
            splitterH.Add(picH);
            picH += 15;

            if (Skill.Level > 0)
            {
                string hStr = SummaryParser.GetSkillSummary(Skill,Skill.Level,sr,SummaryParams.Default,new SkillSummaryOptions
                {
                    ConvertCooltimeMS = this.DisplayCooltimeMSAsSec,
                    ConvertPerM = this.DisplayPermyriadAsPercent
                });
                GearGraphics.DrawString(g,"[現在等級: " + Skill.Level + "]",GearGraphics.ItemDetailFont,region.LevelDescLeft,region.TextRight,ref picH,16);
                if(Skill.SkillID / 10000 / 1000 == 10 && Skill.Level == 1 && Skill.ReqLevel > 0)
                {
                    GearGraphics.DrawPlainText(g,"[所需等級: " + Skill.ReqLevel.ToString() + "等級以上]",GearGraphics.ItemDetailFont2,GearGraphics.skillYellowColor,region.LevelDescLeft,region.TextRight,ref picH,16);
                }
                if(hStr != null)
                {
                    GearGraphics.DrawString(g,hStr,GearGraphics.ItemDetailFont2,region.LevelDescLeft,region.TextRight,ref picH,16);
                }
            }

            if(Skill.Level < Skill.MaxLevel && !Skill.DisableNextLevelInfo)
            {
                string hStr = SummaryParser.GetSkillSummary(Skill,Skill.Level + 1,sr,SummaryParams.Default,new SkillSummaryOptions
                {
                    ConvertCooltimeMS = this.DisplayCooltimeMSAsSec,
                    ConvertPerM = this.DisplayPermyriadAsPercent
                });
                GearGraphics.DrawString(g,"[下次等级 " + (Skill.Level + 1) + "]",GearGraphics.ItemDetailFont,region.LevelDescLeft,region.TextRight,ref picH,16);
                if(Skill.SkillID / 10000 / 1000 == 10 && (Skill.Level + 1) == 1 && Skill.ReqLevel > 0)
                {
                    GearGraphics.DrawPlainText(g,"[所需等級: " + Skill.ReqLevel.ToString() + "等級以上]",GearGraphics.ItemDetailFont2,GearGraphics.skillYellowColor,region.LevelDescLeft,region.TextRight,ref picH,16);
                }
                if(hStr != null)
                {
                    GearGraphics.DrawString(g,hStr,GearGraphics.ItemDetailFont2,region.LevelDescLeft,region.TextRight,ref picH,16);
                }
            }
            picH += 3;

            if(Skill.AddAttackToolTipDescSkill != 0)
            {
                g.DrawLine(Pens.White,region.SplitterX1,picH,region.SplitterX2,picH);
                picH += 9;
                GearGraphics.DrawPlainText(g,"[組合技能]",GearGraphics.ItemDetailFont,Color.FromArgb(119,204,255),region.LevelDescLeft,region.TextRight,ref picH,16);
                BitmapOrigin icon = new BitmapOrigin();
                Wz_Node skillNode = PluginBase.PluginManager.FindWz(string.Format(@"Skill\{0}.img\skill\{1}",Skill.AddAttackToolTipDescSkill / 10000,Skill.AddAttackToolTipDescSkill));
                if(skillNode != null)
                {
                    Skill skill = Skill.CreateFromNode(skillNode,PluginBase.PluginManager.FindWz);
                    icon = skill.Icon;
                }
                if(icon.Bitmap != null)
                {
                    g.DrawImage(icon.Bitmap,10 - icon.Origin.X,picH + 32 - icon.Origin.Y);
                }
                string skillName;
                if(this.StringLinker != null && this.StringLinker.StringSkill.TryGetValue(Skill.AddAttackToolTipDescSkill,out sr))
                {
                    skillName = sr.Name;
                }
                else
                {
                    skillName = Skill.AddAttackToolTipDescSkill.ToString();
                }
                picH += 10;
                GearGraphics.DrawString(g,skillName,GearGraphics.ItemDetailFont,region.LinkedSkillNameLeft,region.TextRight,ref picH,16);
                picH += 6;
                picH += 8;
            }

            if(Skill.AssistSkillLink != 0)
            {
                g.DrawLine(Pens.White,region.SplitterX1,picH,region.SplitterX2,picH);
                picH += 9;
                GearGraphics.DrawPlainText(g,"[輔助技能]",GearGraphics.ItemDetailFont,((SolidBrush)GearGraphics.OrangeBrush).Color,region.LevelDescLeft,region.TextRight,ref picH,16);
                BitmapOrigin icon = new BitmapOrigin();
                Wz_Node skillNode = PluginBase.PluginManager.FindWz(string.Format(@"Skill\{0}.img\skill\{1}",Skill.AssistSkillLink / 10000,Skill.AssistSkillLink));
                if(skillNode != null)
                {
                    Skill skill = Skill.CreateFromNode(skillNode,PluginBase.PluginManager.FindWz);
                    icon = skill.Icon;
                }
                if(icon.Bitmap != null)
                {
                    g.DrawImage(icon.Bitmap,10 - icon.Origin.X,picH + 32 - icon.Origin.Y);
                }
                string skillName;
                if(this.StringLinker != null && this.StringLinker.StringSkill.TryGetValue(Skill.AssistSkillLink,out sr))
                {
                    skillName = sr.Name;
                }
                else
                {
                    skillName = Skill.AssistSkillLink.ToString();
                }
                picH += 10;
                GearGraphics.DrawString(g,skillName,GearGraphics.ItemDetailFont,region.LinkedSkillNameLeft,region.TextRight,ref picH,16);
                picH += 6;
                picH += 8;
            }

            List<string> skillDescEx = new List<string>();
            if(ShowProperties)
            {
                List<string> attr = new List<string>();
                if(Skill.ReqLevel > 0)
                {
                    attr.Add("所需等級: " + Skill.ReqLevel);
                }
                if(Skill.Invisible)
                {
                    attr.Add("隐藏技能");
                }
                if(Skill.Hyper != HyperSkillType.None)
                {
                    attr.Add("超級技能: " + Skill.Hyper);
                }
                if(Skill.CombatOrders)
                {
                    attr.Add("戰鬥命令加成");
                }
                if(Skill.NotRemoved)
                {
                    attr.Add("無法被移除");
                }
                if(Skill.MasterLevel > 0 && Skill.MasterLevel < Skill.MaxLevel)
                {
                    attr.Add("初始掌握: Lv." + Skill.MasterLevel);
                }

                if(attr.Count > 0)
                {
                    skillDescEx.Add("#c" + string.Join(", ",attr.ToArray()) + "#");
                }
            }

            if(ShowDelay && Skill.Action.Count > 0)
            {
                foreach(string action in Skill.Action)
                {
                    skillDescEx.Add("#c[技能延遲] " + action + ": " + CharaSimLoader.GetActionDelay(action) + " ms#");
                }
            }



            if(ShowReqSkill && Skill.ReqSkill.Count > 0)
            {
                foreach(var kv in Skill.ReqSkill)
                {
                    string skillName;
                    if(this.StringLinker != null && this.StringLinker.StringSkill.TryGetValue(kv.Key,out sr))
                    {
                        skillName = sr.Name;
                    }
                    else
                    {
                        skillName = kv.Key.ToString();
                    }
                    skillDescEx.Add("#c[前置技能] " + skillName + ": " + kv.Value + " 級#");
                }
            }

            if(Skill.LT.X != 0)
            {

                skillDescEx.Add("#c[範圍座標] LT(左上): (" + Skill.LT.X + "," + Skill.LT.Y + ")" + " / " +
                                            "RB(右下): (" + Skill.RB.X + "," + Skill.RB.Y + ")");
                int LT = Math.Abs(Skill.LT.X) + Skill.RB.X;
                int RB = Math.Abs(Skill.LT.Y) + Skill.RB.Y;
                skillDescEx.Add("#c[範圍] " + LT + " X " + RB);

            }

            if(skillDescEx.Count > 0)
            {
                //delay rendering v6 splitter
                splitterH.Add(picH);
                picH += 9;
                foreach (var descEx in skillDescEx)
                {
                    GearGraphics.DrawString(g, descEx, GearGraphics.ItemDetailFont, region.LevelDescLeft, region.TextRight, ref picH, 16);
                }
                picH += 9;
            }

            picH += 6;

            format.Dispose();
            g.Dispose();
            return bitmap;
        }


        private void DrawV6SkillDotline(Graphics g, int x1, int x2, int y)
        {
            // here's a trick that we won't draw left and right part because it looks the same as background border.
            var picCenter = Resource.UIToolTip_img_Skill_Frame_dotline_c;
            using (var brush = new TextureBrush(picCenter))
            {
                brush.TranslateTransform(x1, y);
                g.FillRectangle(brush, new Rectangle(x1, y, x2 - x1, picCenter.Height));
            }
        }
        private class CanvasRegion
        {
            public int Width { get; private set; }
            public int TitleCenterX { get; private set; }
            public int SplitterX1 { get; private set; }
            public int SplitterX2 { get; private set; }
            public int SkillDescLeft { get; private set; }
            public int LinkedSkillNameLeft { get; private set; }
            public int LevelDescLeft { get; private set; }
            public int TextRight { get; private set; }

            public static CanvasRegion Original { get; } = new CanvasRegion()
            {
                Width = 290,
                TitleCenterX = 144,
                SplitterX1 = 4,
                SplitterX2 = 284,
                SkillDescLeft = 90,
                LinkedSkillNameLeft = 46,
                LevelDescLeft = 8,
                TextRight = 272,
            };

            public static CanvasRegion Wide { get; } = new CanvasRegion()
            {
                Width = 430,
                TitleCenterX = 215,
                SplitterX1 = 4,
                SplitterX2 = 424,
                SkillDescLeft = 92,
                LinkedSkillNameLeft = 46,
                LevelDescLeft = 10,
                TextRight = 411,
            };
        }
    }
}
