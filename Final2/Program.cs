using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Antlr4.Runtime;
using Final2.Content;
using Antlr4.Runtime.Tree;
using System.Text;

namespace Final2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "^hoola^";
            byte[] byteArray = Encoding.UTF8.GetBytes(input);

            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                using (WordprocessingDocument document = WordprocessingDocument.Create("output.docx", WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = document.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    AntlrInputStream antlrInput = new AntlrInputStream(stream);
                    DocumentSpecLexer lexer = new DocumentSpecLexer(antlrInput);
                    CommonTokenStream tokens = new CommonTokenStream(lexer);
                    DocumentSpecParser parser = new DocumentSpecParser(tokens);
                    IParseTree tree = parser.document();

                    DocumentVisitor visitor = new DocumentVisitor(document, body);
                    visitor.Visit(tree);

                    document.Save();
                }
            }
        }
    }
}
