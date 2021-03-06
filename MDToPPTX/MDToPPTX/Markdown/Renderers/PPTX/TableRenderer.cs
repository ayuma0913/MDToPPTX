// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Extensions.Tables;
using MDToPPTX.PPTX;
using MDToPPTX.PPTX.OpenXML;

namespace MDToPPTX.Markdown.Renderers.PPTX
{
    /// <summary>
    /// A HTML renderer for a <see cref="Table"/>
    /// </summary>
    public class TableRenderer : PPTXObjectRenderer<Table>
    {
        protected override void Write(PPTXRenderer renderer, Table table)
        {
            var tableObj = new PPTXTable();

            foreach (var tableColumnDefinition in table.ColumnDefinitions)
            {
                var pptxTableColObj = new PPTXTableColumn();
                
                var alignment = tableColumnDefinition.Alignment;
                if (alignment.HasValue)
                {
                    switch (alignment)
                    {
                        case TableColumnAlign.Center:
                            pptxTableColObj.Alignment = PPTXTableColumnAlign.Center;
                            break;
                        case TableColumnAlign.Right:
                            pptxTableColObj.Alignment = PPTXTableColumnAlign.Right;
                            break;
                        case TableColumnAlign.Left:
                            pptxTableColObj.Alignment = PPTXTableColumnAlign.Left;
                            break;
                    }

                    tableObj.Columns.Add(pptxTableColObj);
                }
            }

            renderer.PushBlockSetting(renderer.Options.Table);
            renderer.AddTable(tableObj);

            foreach (var rowObj in table)
            {
                renderer.AddTableRow();

                var row = (TableRow)rowObj;

                for (int i = 0; i < row.Count; i++)
                {
                    renderer.NextTableCell();

                    renderer.WriteChildren((TableCell)row[i]);
                }

                renderer.EndTableRow();
            }

            renderer.PopBlockSetting();
            renderer.AddTableEnd();
        }
    }
}