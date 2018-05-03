﻿using System;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml;
using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
using P15 = DocumentFormat.OpenXml.Office2013.PowerPoint;
using A = DocumentFormat.OpenXml.Drawing;
using Thm15 = DocumentFormat.OpenXml.Office2013.Theme;
using MDToPPTX.PPTX.DefaultParts.SlideLayouts;

namespace MDToPPTX.PPTX.DefaultParts
{
    public class DefaultPresentationPart
    {
        public static void CreatePresentationPart(PresentationPart part, string Title, string SubTitle)
        {
            var partCreator = new DefaultPresentationPart();
            partCreator._CreatePresentationPart(part);

            SlidePart slidePart1 = DefaultSlidePart.CreateSlidePart(part, "rId2", Title, SubTitle);

            var topLayoutPart = new DefaultSlideLayoutPart();
            SlideLayoutPart slideLayoutPart1 = topLayoutPart.CreateSlideLayoutPart(slidePart1, "rId1");
            SlideMasterPart slideMasterPart1 = DefaultSlideMasterPart.CreateSlideMasterPart(slideLayoutPart1, "rId1");
            ThemePart themePart1 = DefaultTheme.CreateTheme(slideMasterPart1);

            slideMasterPart1.AddPart(slideLayoutPart1, "rId1");
            part.AddPart(slideMasterPart1, "rId1");
            part.AddPart(themePart1, "rId5");

            // 残りのスライドレイアウトを追加
            for (int i = 2; i <= 11; ++i)
            {
                var otherLayoutPartType = Type.GetType($"MDToPPTX.PPTX.DefaultParts.SlideLayouts.SlideLayoutID{i}");
                if (otherLayoutPartType == null) continue;
                SlideLayoutPartBase otherLayoutPart = Activator.CreateInstance(otherLayoutPartType) as SlideLayoutPartBase;
                if (otherLayoutPart != null)
                {
                    SlideLayoutPart otherSlideLayoutPart = otherLayoutPart.CreateSlideLayoutPart(slideMasterPart1, $"rId{i}");

                    otherSlideLayoutPart.AddPart(slideMasterPart1, "rId1");
                }
            }

        }


        // Adds child parts and generates content of the specified part.
        public void _CreatePresentationPart(PresentationPart part)
        {
            PresentationPropertiesPart presentationPropertiesPart1 = part.AddNewPart<PresentationPropertiesPart>("rId3");
            GeneratePresentationPropertiesPart1Content(presentationPropertiesPart1);

            TableStylesPart tableStylesPart1 = part.AddNewPart<TableStylesPart>("rId6");
            GenerateTableStylesPart1Content(tableStylesPart1);

            ViewPropertiesPart viewPropertiesPart1 = part.AddNewPart<ViewPropertiesPart>("rId4");
            GenerateViewPropertiesPart1Content(viewPropertiesPart1);

            GeneratePartContent(part);
        }

        // Generates content of presentationPropertiesPart1.
        private void GeneratePresentationPropertiesPart1Content(PresentationPropertiesPart presentationPropertiesPart1)
        {
            PresentationProperties presentationProperties1 = new PresentationProperties();
            presentationProperties1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentationProperties1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentationProperties1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            PresentationPropertiesExtensionList presentationPropertiesExtensionList1 = new PresentationPropertiesExtensionList();

            PresentationPropertiesExtension presentationPropertiesExtension1 = new PresentationPropertiesExtension() { Uri = "{E76CE94A-603C-4142-B9EB-6D1370010A27}" };

            P14.DiscardImageEditData discardImageEditData1 = new P14.DiscardImageEditData() { Val = false };
            discardImageEditData1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            presentationPropertiesExtension1.Append(discardImageEditData1);

            PresentationPropertiesExtension presentationPropertiesExtension2 = new PresentationPropertiesExtension() { Uri = "{D31A062A-798A-4329-ABDD-BBA856620510}" };

            P14.DefaultImageDpi defaultImageDpi1 = new P14.DefaultImageDpi() { Val = (UInt32Value)32767U };
            defaultImageDpi1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            presentationPropertiesExtension2.Append(defaultImageDpi1);

            PresentationPropertiesExtension presentationPropertiesExtension3 = new PresentationPropertiesExtension() { Uri = "{FD5EFAAD-0ECE-453E-9831-46B23BE46B34}" };

            P15.ChartTrackingReferenceBased chartTrackingReferenceBased1 = new P15.ChartTrackingReferenceBased() { Val = true };
            chartTrackingReferenceBased1.AddNamespaceDeclaration("p15", "http://schemas.microsoft.com/office/powerpoint/2012/main");

            presentationPropertiesExtension3.Append(chartTrackingReferenceBased1);

            presentationPropertiesExtensionList1.Append(presentationPropertiesExtension1);
            presentationPropertiesExtensionList1.Append(presentationPropertiesExtension2);
            presentationPropertiesExtensionList1.Append(presentationPropertiesExtension3);

            presentationProperties1.Append(presentationPropertiesExtensionList1);

            presentationPropertiesPart1.PresentationProperties = presentationProperties1;
        }

        // Generates content of tableStylesPart1.
        private void GenerateTableStylesPart1Content(TableStylesPart tableStylesPart1)
        {
            A.TableStyleList tableStyleList1 = new A.TableStyleList() { Default = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}" };
            tableStyleList1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            tableStylesPart1.TableStyleList = tableStyleList1;
        }

        // Generates content of viewPropertiesPart1.
        private void GenerateViewPropertiesPart1Content(ViewPropertiesPart viewPropertiesPart1)
        {
            ViewProperties viewProperties1 = new ViewProperties();
            viewProperties1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            viewProperties1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            viewProperties1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            NormalViewProperties normalViewProperties1 = new NormalViewProperties() { HorizontalBarState = SplitterBarStateValues.Maximized };
            RestoredLeft restoredLeft1 = new RestoredLeft() { Size = 18024, AutoAdjust = false };
            RestoredTop restoredTop1 = new RestoredTop() { Size = 94660 };

            normalViewProperties1.Append(restoredLeft1);
            normalViewProperties1.Append(restoredTop1);

            SlideViewProperties slideViewProperties1 = new SlideViewProperties();

            CommonSlideViewProperties commonSlideViewProperties1 = new CommonSlideViewProperties() { SnapToGrid = false };

            CommonViewProperties commonViewProperties1 = new CommonViewProperties() { VariableScale = true };

            ScaleFactor scaleFactor1 = new ScaleFactor();
            A.ScaleX scaleX1 = new A.ScaleX() { Numerator = 112, Denominator = 100 };
            A.ScaleY scaleY1 = new A.ScaleY() { Numerator = 112, Denominator = 100 };

            scaleFactor1.Append(scaleX1);
            scaleFactor1.Append(scaleY1);
            Origin origin1 = new Origin() { X = 468L, Y = 96L };

            commonViewProperties1.Append(scaleFactor1);
            commonViewProperties1.Append(origin1);
            GuideList guideList1 = new GuideList();

            commonSlideViewProperties1.Append(commonViewProperties1);
            commonSlideViewProperties1.Append(guideList1);

            slideViewProperties1.Append(commonSlideViewProperties1);

            NotesTextViewProperties notesTextViewProperties1 = new NotesTextViewProperties();

            CommonViewProperties commonViewProperties2 = new CommonViewProperties();

            ScaleFactor scaleFactor2 = new ScaleFactor();
            A.ScaleX scaleX2 = new A.ScaleX() { Numerator = 1, Denominator = 1 };
            A.ScaleY scaleY2 = new A.ScaleY() { Numerator = 1, Denominator = 1 };

            scaleFactor2.Append(scaleX2);
            scaleFactor2.Append(scaleY2);
            Origin origin2 = new Origin() { X = 0L, Y = 0L };

            commonViewProperties2.Append(scaleFactor2);
            commonViewProperties2.Append(origin2);

            notesTextViewProperties1.Append(commonViewProperties2);
            GridSpacing gridSpacing1 = new GridSpacing() { Cx = 72008L, Cy = 72008L };

            viewProperties1.Append(normalViewProperties1);
            viewProperties1.Append(slideViewProperties1);
            viewProperties1.Append(notesTextViewProperties1);
            viewProperties1.Append(gridSpacing1);

            viewPropertiesPart1.ViewProperties = viewProperties1;
        }

        // Generates content of part.
        private void GeneratePartContent(PresentationPart part)
        {
            Presentation presentation1 = new Presentation() { SaveSubsetFonts = true };
            presentation1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentation1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentation1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            SlideMasterIdList slideMasterIdList1 = new SlideMasterIdList();
            SlideMasterId slideMasterId1 = new SlideMasterId() { Id = (UInt32Value)2147483660U, RelationshipId = "rId1" };

            slideMasterIdList1.Append(slideMasterId1);

            SlideIdList slideIdList1 = new SlideIdList();
            SlideId slideId1 = new SlideId() { Id = (UInt32Value)256U, RelationshipId = "rId2" };

            slideIdList1.Append(slideId1);
            SlideSize slideSize1 = new SlideSize() { Cx = 9144000, Cy = 6858000, Type = SlideSizeValues.Screen4x3 };
            NotesSize notesSize1 = new NotesSize() { Cx = 6858000L, Cy = 9144000L };

            DefaultTextStyle defaultTextStyle1 = new DefaultTextStyle();

            A.DefaultParagraphProperties defaultParagraphProperties2 = new A.DefaultParagraphProperties();
            A.DefaultRunProperties defaultRunProperties100 = new A.DefaultRunProperties() { Language = "en-US" };

            defaultParagraphProperties2.Append(defaultRunProperties100);

            A.Level1ParagraphProperties level1ParagraphProperties19 = new A.Level1ParagraphProperties() { LeftMargin = 0, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties101 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill38 = new A.SolidFill();
            A.SchemeColor schemeColor48 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill38.Append(schemeColor48);
            A.LatinFont latinFont22 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont22 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont22 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties101.Append(solidFill38);
            defaultRunProperties101.Append(latinFont22);
            defaultRunProperties101.Append(eastAsianFont22);
            defaultRunProperties101.Append(complexScriptFont22);

            level1ParagraphProperties19.Append(defaultRunProperties101);

            A.Level2ParagraphProperties level2ParagraphProperties11 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties102 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill39 = new A.SolidFill();
            A.SchemeColor schemeColor49 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill39.Append(schemeColor49);
            A.LatinFont latinFont23 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont23 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont23 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties102.Append(solidFill39);
            defaultRunProperties102.Append(latinFont23);
            defaultRunProperties102.Append(eastAsianFont23);
            defaultRunProperties102.Append(complexScriptFont23);

            level2ParagraphProperties11.Append(defaultRunProperties102);

            A.Level3ParagraphProperties level3ParagraphProperties11 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties103 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill40 = new A.SolidFill();
            A.SchemeColor schemeColor50 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill40.Append(schemeColor50);
            A.LatinFont latinFont24 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont24 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont24 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties103.Append(solidFill40);
            defaultRunProperties103.Append(latinFont24);
            defaultRunProperties103.Append(eastAsianFont24);
            defaultRunProperties103.Append(complexScriptFont24);

            level3ParagraphProperties11.Append(defaultRunProperties103);

            A.Level4ParagraphProperties level4ParagraphProperties11 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties104 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill41 = new A.SolidFill();
            A.SchemeColor schemeColor51 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill41.Append(schemeColor51);
            A.LatinFont latinFont25 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont25 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont25 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties104.Append(solidFill41);
            defaultRunProperties104.Append(latinFont25);
            defaultRunProperties104.Append(eastAsianFont25);
            defaultRunProperties104.Append(complexScriptFont25);

            level4ParagraphProperties11.Append(defaultRunProperties104);

            A.Level5ParagraphProperties level5ParagraphProperties11 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties105 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill42 = new A.SolidFill();
            A.SchemeColor schemeColor52 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill42.Append(schemeColor52);
            A.LatinFont latinFont26 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont26 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont26 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties105.Append(solidFill42);
            defaultRunProperties105.Append(latinFont26);
            defaultRunProperties105.Append(eastAsianFont26);
            defaultRunProperties105.Append(complexScriptFont26);

            level5ParagraphProperties11.Append(defaultRunProperties105);

            A.Level6ParagraphProperties level6ParagraphProperties11 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties106 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill43 = new A.SolidFill();
            A.SchemeColor schemeColor53 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill43.Append(schemeColor53);
            A.LatinFont latinFont27 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont27 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont27 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties106.Append(solidFill43);
            defaultRunProperties106.Append(latinFont27);
            defaultRunProperties106.Append(eastAsianFont27);
            defaultRunProperties106.Append(complexScriptFont27);

            level6ParagraphProperties11.Append(defaultRunProperties106);

            A.Level7ParagraphProperties level7ParagraphProperties11 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties107 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill44 = new A.SolidFill();
            A.SchemeColor schemeColor54 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill44.Append(schemeColor54);
            A.LatinFont latinFont28 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont28 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont28 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties107.Append(solidFill44);
            defaultRunProperties107.Append(latinFont28);
            defaultRunProperties107.Append(eastAsianFont28);
            defaultRunProperties107.Append(complexScriptFont28);

            level7ParagraphProperties11.Append(defaultRunProperties107);

            A.Level8ParagraphProperties level8ParagraphProperties11 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties108 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill45 = new A.SolidFill();
            A.SchemeColor schemeColor55 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill45.Append(schemeColor55);
            A.LatinFont latinFont29 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont29 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont29 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties108.Append(solidFill45);
            defaultRunProperties108.Append(latinFont29);
            defaultRunProperties108.Append(eastAsianFont29);
            defaultRunProperties108.Append(complexScriptFont29);

            level8ParagraphProperties11.Append(defaultRunProperties108);

            A.Level9ParagraphProperties level9ParagraphProperties11 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 457200, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = false, Height = true };

            A.DefaultRunProperties defaultRunProperties109 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill46 = new A.SolidFill();
            A.SchemeColor schemeColor56 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill46.Append(schemeColor56);
            A.LatinFont latinFont30 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont30 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont30 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties109.Append(solidFill46);
            defaultRunProperties109.Append(latinFont30);
            defaultRunProperties109.Append(eastAsianFont30);
            defaultRunProperties109.Append(complexScriptFont30);

            level9ParagraphProperties11.Append(defaultRunProperties109);

            defaultTextStyle1.Append(defaultParagraphProperties2);
            defaultTextStyle1.Append(level1ParagraphProperties19);
            defaultTextStyle1.Append(level2ParagraphProperties11);
            defaultTextStyle1.Append(level3ParagraphProperties11);
            defaultTextStyle1.Append(level4ParagraphProperties11);
            defaultTextStyle1.Append(level5ParagraphProperties11);
            defaultTextStyle1.Append(level6ParagraphProperties11);
            defaultTextStyle1.Append(level7ParagraphProperties11);
            defaultTextStyle1.Append(level8ParagraphProperties11);
            defaultTextStyle1.Append(level9ParagraphProperties11);

            PresentationExtensionList presentationExtensionList1 = new PresentationExtensionList();

            PresentationExtension presentationExtension1 = new PresentationExtension() { Uri = "{EFAFB233-063F-42B5-8137-9DF3F51BA10A}" };

            P15.SlideGuideList slideGuideList1 = new P15.SlideGuideList();
            slideGuideList1.AddNamespaceDeclaration("p15", "http://schemas.microsoft.com/office/powerpoint/2012/main");

            presentationExtension1.Append(slideGuideList1);

            presentationExtensionList1.Append(presentationExtension1);

            presentation1.Append(slideMasterIdList1);
            presentation1.Append(slideIdList1);
            presentation1.Append(slideSize1);
            presentation1.Append(notesSize1);
            presentation1.Append(defaultTextStyle1);
            presentation1.Append(presentationExtensionList1);

            part.Presentation = presentation1;
        }

    }
}
