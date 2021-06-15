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

using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class HarmonyParser : Parser {
	public const int
		UNIT=1, NOTE=2, CHORD=3, ATR_NAME=4, ATR_TEMPO=5, ATR_DURATION=6, ATR_AUTHOR=7, 
		TRANSPOSE=8, PROPAGATE=9, ARPEGGIATE=10, LPAREN=11, RPAREN=12, LBRACE=13, 
		RBRACE=14, COMMA=15, DOT=16, SEMI=17, COLON=18, SHARP=19, FUNC=20, WS=21, 
		IDENTIFIER=22, DECIMAL_LITERAL=23, FLOAT_LITERAL=24;
	public const int
		RULE_compilationUnit = 0, RULE_attributes = 1, RULE_unitDeclaration = 2, 
		RULE_block = 3, RULE_blockStatement = 4, RULE_statement = 5, RULE_noteStatement = 6, 
		RULE_chordStatement = 7, RULE_function = 8, RULE_propagateFunction = 9, 
		RULE_transposeFunction = 10, RULE_arpeggiateFunction = 11, RULE_noteLiteral = 12, 
		RULE_chordLiteral = 13, RULE_number = 14;
	public static readonly string[] ruleNames = {
		"compilationUnit", "attributes", "unitDeclaration", "block", "blockStatement", 
		"statement", "noteStatement", "chordStatement", "function", "propagateFunction", 
		"transposeFunction", "arpeggiateFunction", "noteLiteral", "chordLiteral", 
		"number"
	};

	private static readonly string[] _LiteralNames = {
		null, "'unit'", "'note'", "'chord'", "'name'", "'tempo'", "'duration'", 
		"'author'", "'transpose'", "'propagate'", "'arpeggiate'", "'('", "')'", 
		"'{'", "'}'", "','", "'.'", "';'", "':'", "'#'", "'->'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "UNIT", "NOTE", "CHORD", "ATR_NAME", "ATR_TEMPO", "ATR_DURATION", 
		"ATR_AUTHOR", "TRANSPOSE", "PROPAGATE", "ARPEGGIATE", "LPAREN", "RPAREN", 
		"LBRACE", "RBRACE", "COMMA", "DOT", "SEMI", "COLON", "SHARP", "FUNC", 
		"WS", "IDENTIFIER", "DECIMAL_LITERAL", "FLOAT_LITERAL"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "HarmonyParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public HarmonyParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class CompilationUnitContext : ParserRuleContext {
		public AttributesContext attributes() {
			return GetRuleContext<AttributesContext>(0);
		}
		public ITerminalNode Eof() { return GetToken(HarmonyParser.Eof, 0); }
		public UnitDeclarationContext[] unitDeclaration() {
			return GetRuleContexts<UnitDeclarationContext>();
		}
		public UnitDeclarationContext unitDeclaration(int i) {
			return GetRuleContext<UnitDeclarationContext>(i);
		}
		public CompilationUnitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_compilationUnit; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterCompilationUnit(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitCompilationUnit(this);
		}
	}

	[RuleVersion(0)]
	public CompilationUnitContext compilationUnit() {
		CompilationUnitContext _localctx = new CompilationUnitContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_compilationUnit);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 30; attributes();
			State = 34;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==UNIT) {
				{
				{
				State = 31; unitDeclaration();
				}
				}
				State = 36;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 37; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AttributesContext : ParserRuleContext {
		public IToken name;
		public IToken author;
		public NumberContext duration;
		public IToken tempo;
		public ITerminalNode[] IDENTIFIER() { return GetTokens(HarmonyParser.IDENTIFIER); }
		public ITerminalNode IDENTIFIER(int i) {
			return GetToken(HarmonyParser.IDENTIFIER, i);
		}
		public NumberContext number() {
			return GetRuleContext<NumberContext>(0);
		}
		public ITerminalNode DECIMAL_LITERAL() { return GetToken(HarmonyParser.DECIMAL_LITERAL, 0); }
		public AttributesContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_attributes; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterAttributes(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitAttributes(this);
		}
	}

	[RuleVersion(0)]
	public AttributesContext attributes() {
		AttributesContext _localctx = new AttributesContext(_ctx, State);
		EnterRule(_localctx, 2, RULE_attributes);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			{
			State = 39; Match(ATR_NAME);
			State = 40; Match(COLON);
			State = 41; _localctx.name = Match(IDENTIFIER);
			}
			{
			State = 43; Match(ATR_AUTHOR);
			State = 44; Match(COLON);
			State = 45; _localctx.author = Match(IDENTIFIER);
			}
			{
			State = 47; Match(ATR_DURATION);
			State = 48; Match(COLON);
			State = 49; _localctx.duration = number();
			}
			{
			State = 51; Match(ATR_TEMPO);
			State = 52; Match(COLON);
			State = 53; _localctx.tempo = Match(DECIMAL_LITERAL);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class UnitDeclarationContext : ParserRuleContext {
		public ITerminalNode UNIT() { return GetToken(HarmonyParser.UNIT, 0); }
		public ITerminalNode IDENTIFIER() { return GetToken(HarmonyParser.IDENTIFIER, 0); }
		public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
		public UnitDeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_unitDeclaration; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterUnitDeclaration(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitUnitDeclaration(this);
		}
	}

	[RuleVersion(0)]
	public UnitDeclarationContext unitDeclaration() {
		UnitDeclarationContext _localctx = new UnitDeclarationContext(_ctx, State);
		EnterRule(_localctx, 4, RULE_unitDeclaration);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 55; Match(UNIT);
			State = 56; Match(IDENTIFIER);
			State = 57; block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockContext : ParserRuleContext {
		public BlockStatementContext[] blockStatement() {
			return GetRuleContexts<BlockStatementContext>();
		}
		public BlockStatementContext blockStatement(int i) {
			return GetRuleContext<BlockStatementContext>(i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_block; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterBlock(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitBlock(this);
		}
	}

	[RuleVersion(0)]
	public BlockContext block() {
		BlockContext _localctx = new BlockContext(_ctx, State);
		EnterRule(_localctx, 6, RULE_block);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 59; Match(LBRACE);
			State = 63;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==NOTE || _la==CHORD) {
				{
				{
				State = 60; blockStatement();
				}
				}
				State = 65;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 66; Match(RBRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockStatementContext : ParserRuleContext {
		public StatementContext statement() {
			return GetRuleContext<StatementContext>(0);
		}
		public FunctionContext[] function() {
			return GetRuleContexts<FunctionContext>();
		}
		public FunctionContext function(int i) {
			return GetRuleContext<FunctionContext>(i);
		}
		public BlockStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_blockStatement; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterBlockStatement(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitBlockStatement(this);
		}
	}

	[RuleVersion(0)]
	public BlockStatementContext blockStatement() {
		BlockStatementContext _localctx = new BlockStatementContext(_ctx, State);
		EnterRule(_localctx, 8, RULE_blockStatement);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 68; statement();
			State = 73;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==FUNC) {
				{
				{
				State = 69; Match(FUNC);
				State = 70; function();
				}
				}
				State = 75;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementContext : ParserRuleContext {
		public NoteStatementContext noteStatement() {
			return GetRuleContext<NoteStatementContext>(0);
		}
		public ChordStatementContext chordStatement() {
			return GetRuleContext<ChordStatementContext>(0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_statement; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterStatement(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitStatement(this);
		}
	}

	[RuleVersion(0)]
	public StatementContext statement() {
		StatementContext _localctx = new StatementContext(_ctx, State);
		EnterRule(_localctx, 10, RULE_statement);
		try {
			State = 78;
			_errHandler.Sync(this);
			switch (_input.La(1)) {
			case NOTE:
				EnterOuterAlt(_localctx, 1);
				{
				State = 76; noteStatement();
				}
				break;
			case CHORD:
				EnterOuterAlt(_localctx, 2);
				{
				State = 77; chordStatement();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NoteStatementContext : ParserRuleContext {
		public NumberContext startTime;
		public NumberContext duration;
		public NumberContext velocity;
		public ITerminalNode NOTE() { return GetToken(HarmonyParser.NOTE, 0); }
		public NoteLiteralContext noteLiteral() {
			return GetRuleContext<NoteLiteralContext>(0);
		}
		public NumberContext[] number() {
			return GetRuleContexts<NumberContext>();
		}
		public NumberContext number(int i) {
			return GetRuleContext<NumberContext>(i);
		}
		public NoteStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_noteStatement; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterNoteStatement(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitNoteStatement(this);
		}
	}

	[RuleVersion(0)]
	public NoteStatementContext noteStatement() {
		NoteStatementContext _localctx = new NoteStatementContext(_ctx, State);
		EnterRule(_localctx, 12, RULE_noteStatement);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			{
			State = 80; Match(NOTE);
			State = 81; noteLiteral();
			State = 82; Match(LPAREN);
			State = 83; _localctx.startTime = number();
			State = 84; Match(COMMA);
			State = 85; _localctx.duration = number();
			State = 86; Match(COMMA);
			State = 87; _localctx.velocity = number();
			State = 88; Match(RPAREN);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ChordStatementContext : ParserRuleContext {
		public NumberContext startTime;
		public NumberContext duration;
		public NumberContext velocity;
		public IToken octave;
		public ITerminalNode CHORD() { return GetToken(HarmonyParser.CHORD, 0); }
		public ChordLiteralContext chordLiteral() {
			return GetRuleContext<ChordLiteralContext>(0);
		}
		public NumberContext[] number() {
			return GetRuleContexts<NumberContext>();
		}
		public NumberContext number(int i) {
			return GetRuleContext<NumberContext>(i);
		}
		public ITerminalNode DECIMAL_LITERAL() { return GetToken(HarmonyParser.DECIMAL_LITERAL, 0); }
		public ChordStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_chordStatement; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterChordStatement(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitChordStatement(this);
		}
	}

	[RuleVersion(0)]
	public ChordStatementContext chordStatement() {
		ChordStatementContext _localctx = new ChordStatementContext(_ctx, State);
		EnterRule(_localctx, 14, RULE_chordStatement);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			{
			State = 90; Match(CHORD);
			State = 91; chordLiteral();
			State = 92; Match(LPAREN);
			State = 93; _localctx.startTime = number();
			State = 94; Match(COMMA);
			State = 95; _localctx.duration = number();
			State = 96; Match(COMMA);
			State = 97; _localctx.velocity = number();
			State = 98; Match(COMMA);
			State = 99; _localctx.octave = Match(DECIMAL_LITERAL);
			State = 100; Match(RPAREN);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FunctionContext : ParserRuleContext {
		public TransposeFunctionContext transposeFunction() {
			return GetRuleContext<TransposeFunctionContext>(0);
		}
		public PropagateFunctionContext propagateFunction() {
			return GetRuleContext<PropagateFunctionContext>(0);
		}
		public ArpeggiateFunctionContext arpeggiateFunction() {
			return GetRuleContext<ArpeggiateFunctionContext>(0);
		}
		public FunctionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_function; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterFunction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitFunction(this);
		}
	}

	[RuleVersion(0)]
	public FunctionContext function() {
		FunctionContext _localctx = new FunctionContext(_ctx, State);
		EnterRule(_localctx, 16, RULE_function);
		try {
			State = 105;
			_errHandler.Sync(this);
			switch (_input.La(1)) {
			case TRANSPOSE:
				EnterOuterAlt(_localctx, 1);
				{
				State = 102; transposeFunction();
				}
				break;
			case PROPAGATE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 103; propagateFunction();
				}
				break;
			case ARPEGGIATE:
				EnterOuterAlt(_localctx, 3);
				{
				State = 104; arpeggiateFunction();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PropagateFunctionContext : ParserRuleContext {
		public IToken amount;
		public ITerminalNode PROPAGATE() { return GetToken(HarmonyParser.PROPAGATE, 0); }
		public ITerminalNode DECIMAL_LITERAL() { return GetToken(HarmonyParser.DECIMAL_LITERAL, 0); }
		public PropagateFunctionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_propagateFunction; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterPropagateFunction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitPropagateFunction(this);
		}
	}

	[RuleVersion(0)]
	public PropagateFunctionContext propagateFunction() {
		PropagateFunctionContext _localctx = new PropagateFunctionContext(_ctx, State);
		EnterRule(_localctx, 18, RULE_propagateFunction);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 107; Match(PROPAGATE);
			State = 108; Match(LPAREN);
			State = 109; _localctx.amount = Match(DECIMAL_LITERAL);
			State = 110; Match(RPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TransposeFunctionContext : ParserRuleContext {
		public IToken value;
		public ITerminalNode TRANSPOSE() { return GetToken(HarmonyParser.TRANSPOSE, 0); }
		public ITerminalNode DECIMAL_LITERAL() { return GetToken(HarmonyParser.DECIMAL_LITERAL, 0); }
		public TransposeFunctionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_transposeFunction; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterTransposeFunction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitTransposeFunction(this);
		}
	}

	[RuleVersion(0)]
	public TransposeFunctionContext transposeFunction() {
		TransposeFunctionContext _localctx = new TransposeFunctionContext(_ctx, State);
		EnterRule(_localctx, 20, RULE_transposeFunction);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 112; Match(TRANSPOSE);
			State = 113; Match(LPAREN);
			State = 114; _localctx.value = Match(DECIMAL_LITERAL);
			State = 115; Match(RPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ArpeggiateFunctionContext : ParserRuleContext {
		public NumberContext offset;
		public ITerminalNode ARPEGGIATE() { return GetToken(HarmonyParser.ARPEGGIATE, 0); }
		public NumberContext number() {
			return GetRuleContext<NumberContext>(0);
		}
		public ArpeggiateFunctionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_arpeggiateFunction; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterArpeggiateFunction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitArpeggiateFunction(this);
		}
	}

	[RuleVersion(0)]
	public ArpeggiateFunctionContext arpeggiateFunction() {
		ArpeggiateFunctionContext _localctx = new ArpeggiateFunctionContext(_ctx, State);
		EnterRule(_localctx, 22, RULE_arpeggiateFunction);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 117; Match(ARPEGGIATE);
			State = 118; Match(LPAREN);
			State = 119; _localctx.offset = number();
			State = 120; Match(RPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NoteLiteralContext : ParserRuleContext {
		public ITerminalNode IDENTIFIER() { return GetToken(HarmonyParser.IDENTIFIER, 0); }
		public NoteLiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_noteLiteral; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterNoteLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitNoteLiteral(this);
		}
	}

	[RuleVersion(0)]
	public NoteLiteralContext noteLiteral() {
		NoteLiteralContext _localctx = new NoteLiteralContext(_ctx, State);
		EnterRule(_localctx, 24, RULE_noteLiteral);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 122; Match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ChordLiteralContext : ParserRuleContext {
		public ITerminalNode IDENTIFIER() { return GetToken(HarmonyParser.IDENTIFIER, 0); }
		public ChordLiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_chordLiteral; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterChordLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitChordLiteral(this);
		}
	}

	[RuleVersion(0)]
	public ChordLiteralContext chordLiteral() {
		ChordLiteralContext _localctx = new ChordLiteralContext(_ctx, State);
		EnterRule(_localctx, 26, RULE_chordLiteral);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 124; Match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NumberContext : ParserRuleContext {
		public ITerminalNode DECIMAL_LITERAL() { return GetToken(HarmonyParser.DECIMAL_LITERAL, 0); }
		public ITerminalNode FLOAT_LITERAL() { return GetToken(HarmonyParser.FLOAT_LITERAL, 0); }
		public NumberContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_number; } }
		public override void EnterRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.EnterNumber(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IHarmonyParserListener typedListener = listener as IHarmonyParserListener;
			if (typedListener != null) typedListener.ExitNumber(this);
		}
	}

	[RuleVersion(0)]
	public NumberContext number() {
		NumberContext _localctx = new NumberContext(_ctx, State);
		EnterRule(_localctx, 28, RULE_number);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 126;
			_la = _input.La(1);
			if ( !(_la==DECIMAL_LITERAL || _la==FLOAT_LITERAL) ) {
			_errHandler.RecoverInline(this);
			} else {
				if (_input.La(1) == TokenConstants.Eof) {
					matchedEOF = true;
				}

				_errHandler.ReportMatch(this);
				Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x3\x1A\x83\x4\x2\t"+
		"\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4\t"+
		"\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x3\x2\x3\x2\a\x2#\n\x2\f\x2\xE\x2&\v\x2\x3\x2\x3\x2\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\a\x5@\n\x5\f\x5\xE"+
		"\x5\x43\v\x5\x3\x5\x3\x5\x3\x6\x3\x6\x3\x6\a\x6J\n\x6\f\x6\xE\x6M\v\x6"+
		"\x3\a\x3\a\x5\aQ\n\a\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b"+
		"\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\n\x3\n"+
		"\x3\n\x5\nl\n\n\x3\v\x3\v\x3\v\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\r"+
		"\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x10\x2\x2"+
		"\x2\x11\x2\x2\x4\x2\x6\x2\b\x2\n\x2\f\x2\xE\x2\x10\x2\x12\x2\x14\x2\x16"+
		"\x2\x18\x2\x1A\x2\x1C\x2\x1E\x2\x2\x3\x3\x2\x19\x1Ay\x2 \x3\x2\x2\x2\x4"+
		")\x3\x2\x2\x2\x6\x39\x3\x2\x2\x2\b=\x3\x2\x2\x2\n\x46\x3\x2\x2\x2\fP\x3"+
		"\x2\x2\x2\xER\x3\x2\x2\x2\x10\\\x3\x2\x2\x2\x12k\x3\x2\x2\x2\x14m\x3\x2"+
		"\x2\x2\x16r\x3\x2\x2\x2\x18w\x3\x2\x2\x2\x1A|\x3\x2\x2\x2\x1C~\x3\x2\x2"+
		"\x2\x1E\x80\x3\x2\x2\x2 $\x5\x4\x3\x2!#\x5\x6\x4\x2\"!\x3\x2\x2\x2#&\x3"+
		"\x2\x2\x2$\"\x3\x2\x2\x2$%\x3\x2\x2\x2%\'\x3\x2\x2\x2&$\x3\x2\x2\x2\'"+
		"(\a\x2\x2\x3(\x3\x3\x2\x2\x2)*\a\x6\x2\x2*+\a\x14\x2\x2+,\a\x18\x2\x2"+
		",-\x3\x2\x2\x2-.\a\t\x2\x2./\a\x14\x2\x2/\x30\a\x18\x2\x2\x30\x31\x3\x2"+
		"\x2\x2\x31\x32\a\b\x2\x2\x32\x33\a\x14\x2\x2\x33\x34\x5\x1E\x10\x2\x34"+
		"\x35\x3\x2\x2\x2\x35\x36\a\a\x2\x2\x36\x37\a\x14\x2\x2\x37\x38\a\x19\x2"+
		"\x2\x38\x5\x3\x2\x2\x2\x39:\a\x3\x2\x2:;\a\x18\x2\x2;<\x5\b\x5\x2<\a\x3"+
		"\x2\x2\x2=\x41\a\xF\x2\x2>@\x5\n\x6\x2?>\x3\x2\x2\x2@\x43\x3\x2\x2\x2"+
		"\x41?\x3\x2\x2\x2\x41\x42\x3\x2\x2\x2\x42\x44\x3\x2\x2\x2\x43\x41\x3\x2"+
		"\x2\x2\x44\x45\a\x10\x2\x2\x45\t\x3\x2\x2\x2\x46K\x5\f\a\x2GH\a\x16\x2"+
		"\x2HJ\x5\x12\n\x2IG\x3\x2\x2\x2JM\x3\x2\x2\x2KI\x3\x2\x2\x2KL\x3\x2\x2"+
		"\x2L\v\x3\x2\x2\x2MK\x3\x2\x2\x2NQ\x5\xE\b\x2OQ\x5\x10\t\x2PN\x3\x2\x2"+
		"\x2PO\x3\x2\x2\x2Q\r\x3\x2\x2\x2RS\a\x4\x2\x2ST\x5\x1A\xE\x2TU\a\r\x2"+
		"\x2UV\x5\x1E\x10\x2VW\a\x11\x2\x2WX\x5\x1E\x10\x2XY\a\x11\x2\x2YZ\x5\x1E"+
		"\x10\x2Z[\a\xE\x2\x2[\xF\x3\x2\x2\x2\\]\a\x5\x2\x2]^\x5\x1C\xF\x2^_\a"+
		"\r\x2\x2_`\x5\x1E\x10\x2`\x61\a\x11\x2\x2\x61\x62\x5\x1E\x10\x2\x62\x63"+
		"\a\x11\x2\x2\x63\x64\x5\x1E\x10\x2\x64\x65\a\x11\x2\x2\x65\x66\a\x19\x2"+
		"\x2\x66g\a\xE\x2\x2g\x11\x3\x2\x2\x2hl\x5\x16\f\x2il\x5\x14\v\x2jl\x5"+
		"\x18\r\x2kh\x3\x2\x2\x2ki\x3\x2\x2\x2kj\x3\x2\x2\x2l\x13\x3\x2\x2\x2m"+
		"n\a\v\x2\x2no\a\r\x2\x2op\a\x19\x2\x2pq\a\xE\x2\x2q\x15\x3\x2\x2\x2rs"+
		"\a\n\x2\x2st\a\r\x2\x2tu\a\x19\x2\x2uv\a\xE\x2\x2v\x17\x3\x2\x2\x2wx\a"+
		"\f\x2\x2xy\a\r\x2\x2yz\x5\x1E\x10\x2z{\a\xE\x2\x2{\x19\x3\x2\x2\x2|}\a"+
		"\x18\x2\x2}\x1B\x3\x2\x2\x2~\x7F\a\x18\x2\x2\x7F\x1D\x3\x2\x2\x2\x80\x81"+
		"\t\x2\x2\x2\x81\x1F\x3\x2\x2\x2\a$\x41KPk";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
