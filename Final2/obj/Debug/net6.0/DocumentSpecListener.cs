//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Jorge\source\repos\Final2\Final2\Content\DocumentSpec.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Final2.Content {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="DocumentSpecParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IDocumentSpecListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.document"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDocument([NotNull] DocumentSpecParser.DocumentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.document"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDocument([NotNull] DocumentSpecParser.DocumentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.text"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterText([NotNull] DocumentSpecParser.TextContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.text"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitText([NotNull] DocumentSpecParser.TextContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.boldText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoldText([NotNull] DocumentSpecParser.BoldTextContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.boldText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoldText([NotNull] DocumentSpecParser.BoldTextContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.bold"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBold([NotNull] DocumentSpecParser.BoldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.bold"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBold([NotNull] DocumentSpecParser.BoldContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.italicText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterItalicText([NotNull] DocumentSpecParser.ItalicTextContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.italicText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitItalicText([NotNull] DocumentSpecParser.ItalicTextContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.italic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterItalic([NotNull] DocumentSpecParser.ItalicContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.italic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitItalic([NotNull] DocumentSpecParser.ItalicContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.underlineText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnderlineText([NotNull] DocumentSpecParser.UnderlineTextContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.underlineText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnderlineText([NotNull] DocumentSpecParser.UnderlineTextContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.underline"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnderline([NotNull] DocumentSpecParser.UnderlineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.underline"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnderline([NotNull] DocumentSpecParser.UnderlineContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.title"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTitle([NotNull] DocumentSpecParser.TitleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.title"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTitle([NotNull] DocumentSpecParser.TitleContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.heading1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHeading1([NotNull] DocumentSpecParser.Heading1Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.heading1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHeading1([NotNull] DocumentSpecParser.Heading1Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.heading2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHeading2([NotNull] DocumentSpecParser.Heading2Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.heading2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHeading2([NotNull] DocumentSpecParser.Heading2Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.heading3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHeading3([NotNull] DocumentSpecParser.Heading3Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.heading3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHeading3([NotNull] DocumentSpecParser.Heading3Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.nested"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNested([NotNull] DocumentSpecParser.NestedContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.nested"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNested([NotNull] DocumentSpecParser.NestedContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.list_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterList_item([NotNull] DocumentSpecParser.List_itemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.list_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitList_item([NotNull] DocumentSpecParser.List_itemContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="DocumentSpecParser.list_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterList_number([NotNull] DocumentSpecParser.List_numberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DocumentSpecParser.list_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitList_number([NotNull] DocumentSpecParser.List_numberContext context);
}
} // namespace Final2.Content