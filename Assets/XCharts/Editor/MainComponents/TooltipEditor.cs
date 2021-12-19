/************************************************/
/*                                              */
/*     Copyright (c) 2018 - 2021 monitor1394    */
/*     https://github.com/monitor1394           */
/*                                              */
/************************************************/

using UnityEditor;
using UnityEngine;

namespace XCharts
{
    [ComponentEditor(typeof(Tooltip))]
    public class TooltipEditor : MainComponentEditor<Tooltip>
    {
        public override void OnInspectorGUI()
        {
            ++EditorGUI.indentLevel;
            PropertyField("m_Type");
            PropertyField("m_Trigger");
            PropertyField("m_AlwayShow");
            PropertyField("m_TitleFormatter");
            PropertyField("m_ItemFormatter");
            PropertyField("m_NumericFormatter");
            PropertyField("m_TitleHeight");
            PropertyField("m_ItemHeight");
            PropertyFiledMore(() =>
            {
                PropertyField("m_Marker");
                PropertyField("m_BorderWidth");
                PropertyField("m_BorderColor");
                PropertyField("m_PaddingLeftRight");
                PropertyField("m_PaddingTopBottom");
                PropertyField("m_BackgroundImage");
                PropertyField("m_BackgroundColor");
                PropertyField("m_FixedWidth");
                PropertyField("m_FixedHeight");
                PropertyField("m_MinWidth");
                PropertyField("m_MinHeight");
                PropertyField("m_IgnoreDataDefaultContent");
                PropertyField("m_Offset");
                PropertyField("m_FixedXEnable");
                PropertyField("m_FixedX");
                PropertyField("m_FixedYEnable");
                PropertyField("m_FixedY");
            });
            PropertyField("m_LineStyle");
            PropertyField("m_LabelTextStyle");
            PropertyField("m_TitleTextStyle");
            PropertyListField("m_ColumnsTextStyle");
            --EditorGUI.indentLevel;
        }
    }
}