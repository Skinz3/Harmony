//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Skinz\Desktop\Harmony\Harmony.Antlr\HarmonyParser.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="HarmonyParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IHarmonyParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.compilationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompilationUnit([NotNull] HarmonyParser.CompilationUnitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.compilationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompilationUnit([NotNull] HarmonyParser.CompilationUnitContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.attributes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAttributes([NotNull] HarmonyParser.AttributesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.attributes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAttributes([NotNull] HarmonyParser.AttributesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.unitDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnitDeclaration([NotNull] HarmonyParser.UnitDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.unitDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnitDeclaration([NotNull] HarmonyParser.UnitDeclarationContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] HarmonyParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] HarmonyParser.BlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.blockStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockStatement([NotNull] HarmonyParser.BlockStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.blockStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockStatement([NotNull] HarmonyParser.BlockStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] HarmonyParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] HarmonyParser.StatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.unitStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnitStatement([NotNull] HarmonyParser.UnitStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.unitStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnitStatement([NotNull] HarmonyParser.UnitStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.noteStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNoteStatement([NotNull] HarmonyParser.NoteStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.noteStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNoteStatement([NotNull] HarmonyParser.NoteStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.chordStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChordStatement([NotNull] HarmonyParser.ChordStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.chordStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChordStatement([NotNull] HarmonyParser.ChordStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.stepStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStepStatement([NotNull] HarmonyParser.StepStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.stepStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStepStatement([NotNull] HarmonyParser.StepStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.blockFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockFunction([NotNull] HarmonyParser.BlockFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.blockFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockFunction([NotNull] HarmonyParser.BlockFunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction([NotNull] HarmonyParser.FunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction([NotNull] HarmonyParser.FunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.propagateFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropagateFunction([NotNull] HarmonyParser.PropagateFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.propagateFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropagateFunction([NotNull] HarmonyParser.PropagateFunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.transposeFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTransposeFunction([NotNull] HarmonyParser.TransposeFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.transposeFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTransposeFunction([NotNull] HarmonyParser.TransposeFunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.strumFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStrumFunction([NotNull] HarmonyParser.StrumFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.strumFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStrumFunction([NotNull] HarmonyParser.StrumFunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.timesFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTimesFunction([NotNull] HarmonyParser.TimesFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.timesFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTimesFunction([NotNull] HarmonyParser.TimesFunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.bassFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBassFunction([NotNull] HarmonyParser.BassFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.bassFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBassFunction([NotNull] HarmonyParser.BassFunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.addFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddFunction([NotNull] HarmonyParser.AddFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.addFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddFunction([NotNull] HarmonyParser.AddFunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.noteLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNoteLiteral([NotNull] HarmonyParser.NoteLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.noteLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNoteLiteral([NotNull] HarmonyParser.NoteLiteralContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.chordLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChordLiteral([NotNull] HarmonyParser.ChordLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.chordLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChordLiteral([NotNull] HarmonyParser.ChordLiteralContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="HarmonyParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] HarmonyParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="HarmonyParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] HarmonyParser.NumberContext context);
}
