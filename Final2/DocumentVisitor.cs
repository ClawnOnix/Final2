using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Antlr4.Runtime;
using Final2.Content;
using DocumentFormat.OpenXml.Packaging;
using System.Text;
using Antlr4.Runtime.Tree;
using DocumentFormat.OpenXml.Bibliography;
using System.Text.RegularExpressions;
using System.Xml;

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
            text = text.Substring(1, text.Length - 1).TrimStart('>').TrimEnd('<');
            var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Title" });
            var run = new Run(new Text(text));
            run.RunProperties = new RunProperties(new Bold(), new FontSize { Val = "36" });
            _body.AppendChild(new Paragraph(run, properties));

            return null;

        }





        public override object VisitHeading1(DocumentSpecParser.Heading1Context context)
        {
            var text = context.GetText();
            text = text.Substring(1, text.Length - 1).TrimStart('^').TrimEnd('^');
            var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading1" });
            var run = new Run(new Text(text));
            run.RunProperties = new RunProperties(new Bold(), new Color { Val = "FF0000" });
            _body.AppendChild(new Paragraph(run, properties));

            return null;
        }


        public override object VisitHeading2(DocumentSpecParser.Heading2Context context)
        {
            var text = context.GetText();
            text = text.Substring(2, text.Length - 2).TrimStart('^').TrimEnd('^');
            var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading2" });
            var run = new Run(new Text(text));
            run.RunProperties = new RunProperties(new Bold(), new Color { Val = "0000FF" });
            _body.AppendChild(new Paragraph(run, properties));

            return null;
        }


        public override object VisitHeading3(DocumentSpecParser.Heading3Context context)
        {
            var text = context.GetText();
            text = text.Substring(3, text.Length - 3).TrimStart('^').TrimEnd('^');
            var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading3" });
            var run = new Run(new Text(text));
            run.RunProperties = new RunProperties(new Bold(), new Color { Val = "008000" });
            _body.AppendChild(new Paragraph(run, properties));

            return null;
        }

        public override object VisitNested(DocumentSpecParser.NestedContext context)
        {
            var normalTextRegex = new Regex(@"(?<=^|[\s\S])(?:(?<![\*_~\^>])[\s\S])+?(?=$|[\s\S](?=[*_~\^>]))");
            var text = context.GetText();
            var boldRegex = new Regex(@"\$.*?\$");
            var italicRegex = new Regex(@"\~.*?\~");
            var underlineRegex = new Regex(@"\+\+.*?\+\+");
            var titleRegex = new Regex(@">\s*Title\s*<");
            var heading1Regex = new Regex(@"\^\s*Heading1\s*\^");
            var heading2Regex = new Regex(@"\^\^\s*Heading2\s*\^\^");
            var heading3Regex = new Regex(@"\^\^\^\s*Heading3\s*\^\^\^");

            while (true)
            {
                var normalTextMatch = normalTextRegex.Match(text);
                if (normalTextMatch.Success)
                {
                    var before = text.Substring(0, normalTextMatch.Index);
                    var after = text.Substring(normalTextMatch.Index + normalTextMatch.Length);
                    var normalText = normalTextMatch.Value;
                    _body.AppendChild(new Paragraph(before));
                    text = after;
                    continue;
                }

                var boldMatch = boldRegex.Match(text);
                if (boldMatch.Success)
                {
                    var before = text.Substring(0, boldMatch.Index);
                    var after = text.Substring(boldMatch.Index + boldMatch.Length);
                    var boldText = boldMatch.Value.Substring(1, text.Length - 2);
                    var run = new Run(new Text(boldText));
                    var properties = new Bold();
                    run.RunProperties = new RunProperties(properties);
                    _body.AppendChild(new Paragraph(before));
                    text = after;
                    continue;
                }

                var italicMatch = italicRegex.Match(text);
                if (italicMatch.Success)
                {
                    var before = text.Substring(0, italicMatch.Index);
                    var after = text.Substring(italicMatch.Index + italicMatch.Length);
                    var italicText = italicMatch.Value.Substring(1, text.Length - 2);
                    var run = new Run(new Text(italicText));
                    var properties = new Italic();
                    run.RunProperties = new RunProperties(properties);
                    _body.AppendChild(new Paragraph(before));
                    text = after;
                    continue;
                }

                var underlineMatch = underlineRegex.Match(text);
                if (underlineMatch.Success)
                {
                    var before = text.Substring(0, underlineMatch.Index);
                    var after = text.Substring(underlineMatch.Index + underlineMatch.Length);
                    var underlineText = underlineMatch.Value.Substring(2, text.Length - 4);
                    var run = new Run(new Text(underlineText));
                    var properties = new Underline { Val = UnderlineValues.Single };
                    run.RunProperties = new RunProperties(properties);
                    _body.AppendChild(new Paragraph(before));
                    text = after;
                    continue;
                }

                var titleMatch = titleRegex.Match(text);
                if (titleMatch.Success)
                {
                    var before = text.Substring(0, titleMatch.Index);
                    var after = text.Substring(titleMatch.Index + titleMatch.Length);
                    var titleText = titleMatch.Value.Substring(1, text.Length - 1).TrimStart('>').TrimEnd('<');
                    var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Title" });
                    var run = new Run(new Text(titleText));
                    run.RunProperties = new RunProperties(new Bold(), new FontSize { Val = "36" });
                    _body.AppendChild(new Paragraph(before));
                    _body.AppendChild(new Paragraph(run, properties));
                    _body.AppendChild(new Break());
                    text = after;
                    continue;
                }

                var heading1Match = heading1Regex.Match(text);
                if (heading1Match.Success)
                {
                    var before = text.Substring(0, heading1Match.Index);
                    var after = text.Substring(heading1Match.Index + heading1Match.Length);
                    var heading1text = heading1Match.Value.Substring(1, text.Length - 1).TrimStart('^').TrimEnd('^'); 
                    var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading1" });
                    var run = new Run(new Text(heading1text));
                    run.RunProperties = new RunProperties(new Bold(), new Color { Val = "FF0000" });
                    _body.AppendChild(new Paragraph(before));
                    _body.AppendChild(new Paragraph(run, properties));
                    _body.AppendChild(new Break());
                    text = after;
                    continue;
                }

                var heading2Match = heading2Regex.Match(text);
                if (heading2Match.Success)
                {
                    var before = text.Substring(0, heading2Match.Index);
                    var after = text.Substring(heading2Match.Index + heading2Match.Length);
                    var heading2text = heading2Match.Value.Substring(2, text.Length - 2).TrimStart('^').TrimEnd('^');
                    var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading2" });
                    var run = new Run(new Text(heading2text));
                    run.RunProperties = new RunProperties(new Bold(), new Color { Val = "0000FF" });
                    _body.AppendChild(new Paragraph(before));
                    _body.AppendChild(new Paragraph(run, properties));
                    _body.AppendChild(new Break());
                    text = after;
                    continue;
                }

                var heading3Match = heading3Regex.Match(text);
                if (heading3Match.Success)
                {
                    var before = text.Substring(0, heading3Match.Index);
                    var after = text.Substring(heading3Match.Index + heading3Match.Length);
                    var heading3text = heading3Match.Value.Substring(2, text.Length - 2).TrimStart('^').TrimEnd('^');
                    var properties = new ParagraphProperties(new ParagraphStyleId { Val = "Heading3" });
                    var run = new Run(new Text(heading3text));
                    run.RunProperties = new RunProperties(new Bold(), new Color { Val = "0000FF" });
                    _body.AppendChild(new Paragraph(before));
                    _body.AppendChild(new Paragraph(run, properties));
                    _body.AppendChild(new Break());
                    text = after;
                    continue;
                }

                return null;
            }
        }
    }
}

