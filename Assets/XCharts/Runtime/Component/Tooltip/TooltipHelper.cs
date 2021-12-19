/************************************************/
/*                                              */
/*     Copyright (c) 2018 - 2021 monitor1394    */
/*     https://github.com/monitor1394           */
/*                                              */
/************************************************/

using System;
using System.Text;
using UnityEngine;

namespace XCharts
{
    public static class TooltipHelper
    {
        internal static void ResetTooltipParamsByItemFormatter(Tooltip tooltip, BaseChart chart)
        {
            if (!string.IsNullOrEmpty(tooltip.titleFormatter))
            {
                if (tooltip.titleFormatter.Equals("{i}", StringComparison.CurrentCultureIgnoreCase))
                {
                    tooltip.context.data.title = string.Empty;
                }
                else
                {
                    tooltip.context.data.title = tooltip.titleFormatter;
                    FormatterHelper.ReplaceContent(ref tooltip.context.data.title, 0,
                        tooltip.numericFormatter, null, chart);
                }
            }
            foreach (var param in tooltip.context.data.param)
            {
                if (!string.IsNullOrEmpty(param.itemFormatter))
                {
                    var content = param.itemFormatter;
                    FormatterHelper.ReplaceSerieLabelContent(ref content,
                        param.numericFormatter,
                        param.value,
                        param.total,
                        param.serieName,
                        param.category,
                        param.serieData.name,
                        param.color);

                    param.columns.Clear();

                    foreach (var item in content.Split('|'))
                    {
                        param.columns.Add(item);
                    }
                }
            }
        }

        public static void LimitInRect(Tooltip tooltip, Rect chartRect)
        {
            if (tooltip.view == null)
                return;

            var pos = tooltip.view.GetTargetPos();
            if (pos.x + tooltip.context.width > chartRect.x + chartRect.width)
            {
                //pos.x = chartRect.x + chartRect.width - tooltip.context.width;
                pos.x = pos.x - tooltip.context.width - tooltip.offset.x;
            }
            if (pos.y - tooltip.context.height < chartRect.y)
            {
                pos.y = chartRect.y + tooltip.context.height;
            }
            tooltip.UpdateContentPos(pos);
        }

        public static string GetItemNumericFormatter(Tooltip tooltip, Serie serie, SerieData serieData)
        {
            var itemStyle = SerieHelper.GetItemStyle(serie, serieData);
            if (!string.IsNullOrEmpty(itemStyle.numericFormatter)) return itemStyle.numericFormatter;
            else return tooltip.numericFormatter;
        }

        public static Color32 GetLineColor(Tooltip tooltip, ThemeStyle theme)
        {
            var lineStyle = tooltip.lineStyle;
            if (!ChartHelper.IsClearColor(lineStyle.color))
            {
                return lineStyle.GetColor();
            }
            else
            {
                var color = theme.tooltip.lineColor;
                ChartHelper.SetColorOpacity(ref color, lineStyle.opacity);
                return color;
            }
        }
    }
}