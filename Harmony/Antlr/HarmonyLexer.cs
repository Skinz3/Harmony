//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Skinz\Desktop\Harmony\Harmony.Antlr\HarmonyLexer.g4 by ANTLR 4.6.6

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
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class HarmonyLexer : Lexer {
	public const int
		UNIT=1, ATR_NAME=2, ATR_TEMPO=3, ATR_AUTHOR=4, NOTE=5, CHORD=6, STEP=7, 
		NOTES=8, TRANSPOSE=9, PROPAGATE=10, STRUM=11, ARPEGGIO=12, TIMES=13, BASS=14, 
		ADD=15, LPAREN=16, RPAREN=17, LBRACE=18, RBRACE=19, COMMA=20, DOT=21, 
		SEMI=22, COLON=23, SHARP=24, LBRACKET=25, RBRACKET=26, COMMENT=27, LINE_COMMENT=28, 
		IDENTIFIER=29, WS=30, DECIMAL_LITERAL=31, FLOAT_LITERAL=32;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"UNIT", "ATR_NAME", "ATR_TEMPO", "ATR_AUTHOR", "NOTE", "CHORD", "STEP", 
		"NOTES", "TRANSPOSE", "PROPAGATE", "STRUM", "ARPEGGIO", "TIMES", "BASS", 
		"ADD", "LPAREN", "RPAREN", "LBRACE", "RBRACE", "COMMA", "DOT", "SEMI", 
		"COLON", "SHARP", "LBRACKET", "RBRACKET", "COMMENT", "LINE_COMMENT", "IDENTIFIER", 
		"WS", "DECIMAL_LITERAL", "FLOAT_LITERAL", "Digits", "LetterOrDigit", "Letter"
	};


	public HarmonyLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'unit'", "'name'", "'tempo'", "'author'", "'note'", "'chord'", 
		"'step'", "'notes'", "'transpose'", "'propagate'", "'strum'", "'arpeggio'", 
		"'times'", "'bass'", "'add'", "'('", "')'", "'{'", "'}'", "','", "'.'", 
		"';'", "':'", "'#'", "'['", "']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "UNIT", "ATR_NAME", "ATR_TEMPO", "ATR_AUTHOR", "NOTE", "CHORD", 
		"STEP", "NOTES", "TRANSPOSE", "PROPAGATE", "STRUM", "ARPEGGIO", "TIMES", 
		"BASS", "ADD", "LPAREN", "RPAREN", "LBRACE", "RBRACE", "COMMA", "DOT", 
		"SEMI", "COLON", "SHARP", "LBRACKET", "RBRACKET", "COMMENT", "LINE_COMMENT", 
		"IDENTIFIER", "WS", "DECIMAL_LITERAL", "FLOAT_LITERAL"
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

	public override string GrammarFileName { get { return "HarmonyLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\"\x11A\b\x1\x4"+
		"\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b"+
		"\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4"+
		"\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15"+
		"\t\x15\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A"+
		"\x4\x1B\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 "+
		"\t \x4!\t!\x4\"\t\"\x4#\t#\x4$\t$\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\b\x3\b\x3\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3"+
		"\t\x3\t\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\v\x3\v\x3"+
		"\v\x3\v\x3\v\x3\v\x3\v\x3\v\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3"+
		"\r\x3\r\x3\r\x3\r\x3\r\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xE\x3\xE\x3"+
		"\xE\x3\xE\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF\x3\x10\x3\x10\x3\x10\x3\x10\x3"+
		"\x11\x3\x11\x3\x12\x3\x12\x3\x13\x3\x13\x3\x14\x3\x14\x3\x15\x3\x15\x3"+
		"\x16\x3\x16\x3\x17\x3\x17\x3\x18\x3\x18\x3\x19\x3\x19\x3\x1A\x3\x1A\x3"+
		"\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1C\x3\x1C\a\x1C\xC3\n\x1C\f\x1C\xE\x1C\xC6"+
		"\v\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1D\x3\x1D\x3\x1D\x3\x1D"+
		"\a\x1D\xD1\n\x1D\f\x1D\xE\x1D\xD4\v\x1D\x3\x1D\x3\x1D\x3\x1E\x3\x1E\x5"+
		"\x1E\xDA\n\x1E\x3\x1E\a\x1E\xDD\n\x1E\f\x1E\xE\x1E\xE0\v\x1E\x3\x1F\x6"+
		"\x1F\xE3\n\x1F\r\x1F\xE\x1F\xE4\x3\x1F\x3\x1F\x3 \x5 \xEA\n \x3 \x3 \x3"+
		" \x5 \xEF\n \x3 \x6 \xF2\n \r \xE \xF3\x3 \x5 \xF7\n \x5 \xF9\n \x3 \x5"+
		" \xFC\n \x3!\x3!\x3!\x5!\x101\n!\x3!\x3!\x5!\x105\n!\x3\"\x3\"\a\"\x109"+
		"\n\"\f\"\xE\"\x10C\v\"\x3\"\x5\"\x10F\n\"\x3#\x3#\x5#\x113\n#\x3$\x3$"+
		"\x3$\x3$\x5$\x119\n$\x3\xC4\x2\x2%\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v"+
		"\x2\a\r\x2\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B"+
		"\x2\xF\x1D\x2\x10\x1F\x2\x11!\x2\x12#\x2\x13%\x2\x14\'\x2\x15)\x2\x16"+
		"+\x2\x17-\x2\x18/\x2\x19\x31\x2\x1A\x33\x2\x1B\x35\x2\x1C\x37\x2\x1D\x39"+
		"\x2\x1E;\x2\x1F=\x2 ?\x2!\x41\x2\"\x43\x2\x2\x45\x2\x2G\x2\x2\x3\x2\f"+
		"\x4\x2\f\f\xF\xF\x5\x2\v\f\xE\xF\"\"\x3\x2\x33;\x4\x2NNnn\x3\x2\x32;\x4"+
		"\x2\x32;\x61\x61\x6\x2&&\x43\\\x61\x61\x63|\x4\x2\x2\x81\xD802\xDC01\x3"+
		"\x2\xD802\xDC01\x3\x2\xDC02\xE001\x128\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2"+
		"\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2"+
		"\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2"+
		"\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D"+
		"\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3"+
		"\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2"+
		"\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3\x2\x2\x2\x2\x35\x3\x2"+
		"\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2;\x3\x2\x2\x2\x2=\x3\x2"+
		"\x2\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2\x3I\x3\x2\x2\x2\x5N\x3\x2\x2"+
		"\x2\aS\x3\x2\x2\x2\tY\x3\x2\x2\x2\v`\x3\x2\x2\x2\r\x65\x3\x2\x2\x2\xF"+
		"k\x3\x2\x2\x2\x11p\x3\x2\x2\x2\x13v\x3\x2\x2\x2\x15\x80\x3\x2\x2\x2\x17"+
		"\x8A\x3\x2\x2\x2\x19\x90\x3\x2\x2\x2\x1B\x99\x3\x2\x2\x2\x1D\x9F\x3\x2"+
		"\x2\x2\x1F\xA4\x3\x2\x2\x2!\xA8\x3\x2\x2\x2#\xAA\x3\x2\x2\x2%\xAC\x3\x2"+
		"\x2\x2\'\xAE\x3\x2\x2\x2)\xB0\x3\x2\x2\x2+\xB2\x3\x2\x2\x2-\xB4\x3\x2"+
		"\x2\x2/\xB6\x3\x2\x2\x2\x31\xB8\x3\x2\x2\x2\x33\xBA\x3\x2\x2\x2\x35\xBC"+
		"\x3\x2\x2\x2\x37\xBE\x3\x2\x2\x2\x39\xCC\x3\x2\x2\x2;\xD7\x3\x2\x2\x2"+
		"=\xE2\x3\x2\x2\x2?\xE9\x3\x2\x2\x2\x41\x104\x3\x2\x2\x2\x43\x106\x3\x2"+
		"\x2\x2\x45\x112\x3\x2\x2\x2G\x118\x3\x2\x2\x2IJ\aw\x2\x2JK\ap\x2\x2KL"+
		"\ak\x2\x2LM\av\x2\x2M\x4\x3\x2\x2\x2NO\ap\x2\x2OP\a\x63\x2\x2PQ\ao\x2"+
		"\x2QR\ag\x2\x2R\x6\x3\x2\x2\x2ST\av\x2\x2TU\ag\x2\x2UV\ao\x2\x2VW\ar\x2"+
		"\x2WX\aq\x2\x2X\b\x3\x2\x2\x2YZ\a\x63\x2\x2Z[\aw\x2\x2[\\\av\x2\x2\\]"+
		"\aj\x2\x2]^\aq\x2\x2^_\at\x2\x2_\n\x3\x2\x2\x2`\x61\ap\x2\x2\x61\x62\a"+
		"q\x2\x2\x62\x63\av\x2\x2\x63\x64\ag\x2\x2\x64\f\x3\x2\x2\x2\x65\x66\a"+
		"\x65\x2\x2\x66g\aj\x2\x2gh\aq\x2\x2hi\at\x2\x2ij\a\x66\x2\x2j\xE\x3\x2"+
		"\x2\x2kl\au\x2\x2lm\av\x2\x2mn\ag\x2\x2no\ar\x2\x2o\x10\x3\x2\x2\x2pq"+
		"\ap\x2\x2qr\aq\x2\x2rs\av\x2\x2st\ag\x2\x2tu\au\x2\x2u\x12\x3\x2\x2\x2"+
		"vw\av\x2\x2wx\at\x2\x2xy\a\x63\x2\x2yz\ap\x2\x2z{\au\x2\x2{|\ar\x2\x2"+
		"|}\aq\x2\x2}~\au\x2\x2~\x7F\ag\x2\x2\x7F\x14\x3\x2\x2\x2\x80\x81\ar\x2"+
		"\x2\x81\x82\at\x2\x2\x82\x83\aq\x2\x2\x83\x84\ar\x2\x2\x84\x85\a\x63\x2"+
		"\x2\x85\x86\ai\x2\x2\x86\x87\a\x63\x2\x2\x87\x88\av\x2\x2\x88\x89\ag\x2"+
		"\x2\x89\x16\x3\x2\x2\x2\x8A\x8B\au\x2\x2\x8B\x8C\av\x2\x2\x8C\x8D\at\x2"+
		"\x2\x8D\x8E\aw\x2\x2\x8E\x8F\ao\x2\x2\x8F\x18\x3\x2\x2\x2\x90\x91\a\x63"+
		"\x2\x2\x91\x92\at\x2\x2\x92\x93\ar\x2\x2\x93\x94\ag\x2\x2\x94\x95\ai\x2"+
		"\x2\x95\x96\ai\x2\x2\x96\x97\ak\x2\x2\x97\x98\aq\x2\x2\x98\x1A\x3\x2\x2"+
		"\x2\x99\x9A\av\x2\x2\x9A\x9B\ak\x2\x2\x9B\x9C\ao\x2\x2\x9C\x9D\ag\x2\x2"+
		"\x9D\x9E\au\x2\x2\x9E\x1C\x3\x2\x2\x2\x9F\xA0\a\x64\x2\x2\xA0\xA1\a\x63"+
		"\x2\x2\xA1\xA2\au\x2\x2\xA2\xA3\au\x2\x2\xA3\x1E\x3\x2\x2\x2\xA4\xA5\a"+
		"\x63\x2\x2\xA5\xA6\a\x66\x2\x2\xA6\xA7\a\x66\x2\x2\xA7 \x3\x2\x2\x2\xA8"+
		"\xA9\a*\x2\x2\xA9\"\x3\x2\x2\x2\xAA\xAB\a+\x2\x2\xAB$\x3\x2\x2\x2\xAC"+
		"\xAD\a}\x2\x2\xAD&\x3\x2\x2\x2\xAE\xAF\a\x7F\x2\x2\xAF(\x3\x2\x2\x2\xB0"+
		"\xB1\a.\x2\x2\xB1*\x3\x2\x2\x2\xB2\xB3\a\x30\x2\x2\xB3,\x3\x2\x2\x2\xB4"+
		"\xB5\a=\x2\x2\xB5.\x3\x2\x2\x2\xB6\xB7\a<\x2\x2\xB7\x30\x3\x2\x2\x2\xB8"+
		"\xB9\a%\x2\x2\xB9\x32\x3\x2\x2\x2\xBA\xBB\a]\x2\x2\xBB\x34\x3\x2\x2\x2"+
		"\xBC\xBD\a_\x2\x2\xBD\x36\x3\x2\x2\x2\xBE\xBF\a\x31\x2\x2\xBF\xC0\a,\x2"+
		"\x2\xC0\xC4\x3\x2\x2\x2\xC1\xC3\v\x2\x2\x2\xC2\xC1\x3\x2\x2\x2\xC3\xC6"+
		"\x3\x2\x2\x2\xC4\xC5\x3\x2\x2\x2\xC4\xC2\x3\x2\x2\x2\xC5\xC7\x3\x2\x2"+
		"\x2\xC6\xC4\x3\x2\x2\x2\xC7\xC8\a,\x2\x2\xC8\xC9\a\x31\x2\x2\xC9\xCA\x3"+
		"\x2\x2\x2\xCA\xCB\b\x1C\x2\x2\xCB\x38\x3\x2\x2\x2\xCC\xCD\a\x31\x2\x2"+
		"\xCD\xCE\a\x31\x2\x2\xCE\xD2\x3\x2\x2\x2\xCF\xD1\n\x2\x2\x2\xD0\xCF\x3"+
		"\x2\x2\x2\xD1\xD4\x3\x2\x2\x2\xD2\xD0\x3\x2\x2\x2\xD2\xD3\x3\x2\x2\x2"+
		"\xD3\xD5\x3\x2\x2\x2\xD4\xD2\x3\x2\x2\x2\xD5\xD6\b\x1D\x2\x2\xD6:\x3\x2"+
		"\x2\x2\xD7\xD9\x5G$\x2\xD8\xDA\x5\x31\x19\x2\xD9\xD8\x3\x2\x2\x2\xD9\xDA"+
		"\x3\x2\x2\x2\xDA\xDE\x3\x2\x2\x2\xDB\xDD\x5\x45#\x2\xDC\xDB\x3\x2\x2\x2"+
		"\xDD\xE0\x3\x2\x2\x2\xDE\xDC\x3\x2\x2\x2\xDE\xDF\x3\x2\x2\x2\xDF<\x3\x2"+
		"\x2\x2\xE0\xDE\x3\x2\x2\x2\xE1\xE3\t\x3\x2\x2\xE2\xE1\x3\x2\x2\x2\xE3"+
		"\xE4\x3\x2\x2\x2\xE4\xE2\x3\x2\x2\x2\xE4\xE5\x3\x2\x2\x2\xE5\xE6\x3\x2"+
		"\x2\x2\xE6\xE7\b\x1F\x2\x2\xE7>\x3\x2\x2\x2\xE8\xEA\a/\x2\x2\xE9\xE8\x3"+
		"\x2\x2\x2\xE9\xEA\x3\x2\x2\x2\xEA\xF8\x3\x2\x2\x2\xEB\xF9\a\x32\x2\x2"+
		"\xEC\xF6\t\x4\x2\x2\xED\xEF\x5\x43\"\x2\xEE\xED\x3\x2\x2\x2\xEE\xEF\x3"+
		"\x2\x2\x2\xEF\xF7\x3\x2\x2\x2\xF0\xF2\a\x61\x2\x2\xF1\xF0\x3\x2\x2\x2"+
		"\xF2\xF3\x3\x2\x2\x2\xF3\xF1\x3\x2\x2\x2\xF3\xF4\x3\x2\x2\x2\xF4\xF5\x3"+
		"\x2\x2\x2\xF5\xF7\x5\x43\"\x2\xF6\xEE\x3\x2\x2\x2\xF6\xF1\x3\x2\x2\x2"+
		"\xF7\xF9\x3\x2\x2\x2\xF8\xEB\x3\x2\x2\x2\xF8\xEC\x3\x2\x2\x2\xF9\xFB\x3"+
		"\x2\x2\x2\xFA\xFC\t\x5\x2\x2\xFB\xFA\x3\x2\x2\x2\xFB\xFC\x3\x2\x2\x2\xFC"+
		"@\x3\x2\x2\x2\xFD\xFE\x5\x43\"\x2\xFE\x100\a\x30\x2\x2\xFF\x101\x5\x43"+
		"\"\x2\x100\xFF\x3\x2\x2\x2\x100\x101\x3\x2\x2\x2\x101\x105\x3\x2\x2\x2"+
		"\x102\x103\a\x30\x2\x2\x103\x105\x5\x43\"\x2\x104\xFD\x3\x2\x2\x2\x104"+
		"\x102\x3\x2\x2\x2\x105\x42\x3\x2\x2\x2\x106\x10E\t\x6\x2\x2\x107\x109"+
		"\t\a\x2\x2\x108\x107\x3\x2\x2\x2\x109\x10C\x3\x2\x2\x2\x10A\x108\x3\x2"+
		"\x2\x2\x10A\x10B\x3\x2\x2\x2\x10B\x10D\x3\x2\x2\x2\x10C\x10A\x3\x2\x2"+
		"\x2\x10D\x10F\t\x6\x2\x2\x10E\x10A\x3\x2\x2\x2\x10E\x10F\x3\x2\x2\x2\x10F"+
		"\x44\x3\x2\x2\x2\x110\x113\x5G$\x2\x111\x113\t\x6\x2\x2\x112\x110\x3\x2"+
		"\x2\x2\x112\x111\x3\x2\x2\x2\x113\x46\x3\x2\x2\x2\x114\x119\t\b\x2\x2"+
		"\x115\x119\n\t\x2\x2\x116\x117\t\n\x2\x2\x117\x119\t\v\x2\x2\x118\x114"+
		"\x3\x2\x2\x2\x118\x115\x3\x2\x2\x2\x118\x116\x3\x2\x2\x2\x119H\x3\x2\x2"+
		"\x2\x14\x2\xC4\xD2\xD9\xDE\xE4\xE9\xEE\xF3\xF6\xF8\xFB\x100\x104\x10A"+
		"\x10E\x112\x118\x3\x2\x3\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
