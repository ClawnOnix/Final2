using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Antlr4.Runtime;
using Final2.Content;
using DocumentFormat.OpenXml.Packaging;
using System.Text;
using Antlr4.Runtime.Tree;

namespace Final2
{
    public class DocumentVisitor : DocumentSpecBaseVisitor<object>
    {
        private WordprocessingDocument _document;
        private Body _body;

        public DocumentVisitor(WordprocessingDocument document, Body body)
        {
            _document = document;
            _body = body;
        }

        public override object VisitDocument(DocumentSpecParser.DocumentContext context)
        {
            foreach (var child in context.children)
            {
                Visit(child);
            }
            return null;
        }

        public override object VisitText(DocumentSpecParser.TextContext context)
        {
            _body.AppendChild(new Paragraph(new Run(new Text(context.GetText()))));
            return null;
        }

        public override object VisitBold(DocumentSpecParser.BoldContext context)
        {
            var text = context.GetText();
            text = text.Substring(1, text.Length - 2);
            Run run = new Run(new Text(text));
            var properties = new Bold();
            run.RunProperties = new RunProperties(properties);
            _body.AppendChild(new Paragraph(run));

            return null;
        }




        public override object VisitItalic(DocumentSpecParser.ItalicContext context)
        {
            var text = context.GetText();
            text = text.Substring(1, text.Length - 2);
            Run run = new Run(new Text(text));
            var properties = new Italic();
            run.RunProperties = new RunProperties(properties);
            _body.AppendChild(new Paragraph(run));

            return null;
        }

        public override object VisitUnderline(DocumentSpecParser.UnderlineContext context)
        {
            var text = context.GetText();
            text = text.Substring(2, text.Length - 4);
            Run run = new Run(new Text(text));
            var properties = new Underline { Val = UnderlineValues.Single };
            run.RunProperties = new RunProperties(properties);
            _body.AppendChild(new Paragraph(run));
            return null;
        }

        public override object VisitTitle(DocumentSpecParser.TitleContext context)
        {
            var text = context.GetText();
            text = text.Substring(1, text.Length - 2);
            var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Title" });
            _body.AppendChild(new Paragraph(new Run(new Text(text)), properties));

            return null;
        }

        public override object VisitHeading1(DocumentSpecParser.Heading1Context context)
        {
            var text = context.GetText();
            text = text.Substring(1);
            var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading1" });
            _body.AppendChild(new Paragraph(new Run(new Text(text)), properties));

            return null;
        }

        public override object VisitHeading2(DocumentSpecParser.Heading2Context context)
        {
            var text = context.GetText();
            text = text.Substring(2);
            var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading2" });
            _body.AppendChild(new Paragraph(new Run(new Text(text)), properties));

            return null;
        }

        public override object VisitHeading3(DocumentSpecParser.Heading3Context context)
        {
            var text = context.GetText();
            text = text.Substring(3);
            var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading3" });
            _body.AppendChild(new Paragraph(new Run(new Text(text)), properties));

            return null;
        }

        //public override object VisitListItem(DocumentSpecParser.List_itemContext context)
        //{
        //    var sb = new StringBuilder();
        //    foreach (var child in context.children)
        //    {
        //        var text = child.GetText();
        //        text = text.Substring(1, text.Length - 2);
        //        sb.Append(text);
        //    }
        //    var properties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference { Val = 0 }, new NumberingId { Val = 1 }));
        //    _body.AppendChild(new Paragraph(new Run(new Text(sb.ToString())), properties));

        //    return null;
        //}

        //public override object VisitListNumber(DocumentSpecParser.List_numberContext context)
        //{
        //    var sb = new StringBuilder();
        //    foreach (var child in context.children)
        //    {
        //        var text = child.GetText();
        //        text = text.Substring(1, text.Length - 2);
        //        sb.Append(text);
        //    }
        //    var properties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference { Val = 0 }, new NumberingId { Val = 2 }));
        //    _body.AppendChild(new Paragraph(new Run(new Text(sb.ToString())), properties));

        //    return null;
        //}

        public override object VisitNested(DocumentSpecParser.NestedContext context)
        {
            var run = new Run();
            var runProperties = new RunProperties();

            foreach (var child in context.children)
            {
                if (child is DocumentSpecParser.BoldContext bold)
                {
                    var text = bold.GetText();
                    text = text.Substring(1, text.Length - 2);
                    run.AppendChild(new Text(text));
                    runProperties.Bold = new Bold();
                }
                else if (child is DocumentSpecParser.ItalicContext italic)
                {
                    var text = italic.GetText();
                    text = text.Substring(1, text.Length - 2);
                    run.AppendChild(new Text(text));
                    runProperties.Italic = new Italic();
                }
                else if (child is DocumentSpecParser.UnderlineContext underline)
                {
                    var text = underline.GetText();
                    text = text.Substring(1, text.Length - 2);
                    run.AppendChild(new Text(text));
                    runProperties.Underline = new Underline();
                }
                else if (child is DocumentSpecParser.TitleContext title)
                {
                    var text = title.GetText();
                    text = text.Substring(1, text.Length - 1);
                    _body.AppendChild(new Paragraph(new Run(new Text(text)) { RunProperties = new RunProperties(new Bold()) }) { ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center }) });
                }
                else if (child is DocumentSpecParser.Heading1Context heading1)
                {
                    var text = heading1.GetText();
                    text = text.Substring(1, text.Length - 1);
                    _body.AppendChild(new Paragraph(new Run(new Text(text)) { RunProperties = new RunProperties(new Bold()) }) { ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center }) });
                }
                else if (child is DocumentSpecParser.Heading2Context heading2)
                {
                    var text = heading2.GetText();
                    text = text.Substring(2, text.Length - 2);
                    _body.AppendChild(new Paragraph(new Run(new Text(text)) { RunProperties = new RunProperties(new Bold()) }) { ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center }) });
                }
                else if (child is DocumentSpecParser.Heading3Context heading3)
                {
                    var text = heading3.GetText();
                    text = text.Substring(3, text.Length - 3);
                    _body.AppendChild(new Paragraph(new Run(new Text(text)) { RunProperties = new RunProperties(new Bold()) }) { ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center }) });
                }
                else if (child is DocumentSpecParser.List_itemContext list_item)
                {
                    var paragraph = new Paragraph();
                    foreach (var item in list_item.children)
                    {
                        if (item is TerminalNodeImpl terminalNode && terminalNode.Symbol.Type == DocumentSpecLexer.HYPHEN)
                        {
                            // Add bullet to the paragraph
                            var properties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 0 }));
                            paragraph.AppendChild(properties);
                            _body.AppendChild(paragraph);
                        }
                        else if (item is DocumentSpecParser.TextContext text)
                        {
                            run.AppendChild(new Text(text.GetText()));
                        }
                    }
                    paragraph.AppendChild(run);
                    return null;
                }
                else if (child is DocumentSpecParser.List_numberContext list_number)
                {
                    var paragraph = new Paragraph();
                    foreach (var item in list_number.children)
                    {
                        if (item is TerminalNodeImpl terminalNode && terminalNode.Symbol.Type == DocumentSpecLexer.HYPHEN)
                        {
                            // Add bullet to the paragraph
                            var properties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 1 }));
                            paragraph.AppendChild(properties);
                            _body.AppendChild(paragraph);
                        }
                        else if (item is DocumentSpecParser.TextContext text)
                        {
                            run.AppendChild(new Text(text.GetText()));
                        }
                    }
                    paragraph.AppendChild(run);
                    return null;
                }

                

            }
            return null;
        }
    }
}

