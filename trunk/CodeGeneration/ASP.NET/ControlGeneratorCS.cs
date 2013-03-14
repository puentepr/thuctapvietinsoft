using System;

// Need these assemblies for the CodeDOM example
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace GeneratedControlsASP
{
	/// <summary>
	/// Summary description for ControlGeneratorCS.
	/// </summary>
	public class ControlGeneratorCS
	{
		public static Type GenerateControl ( )
		{
			// Generate the C# for the control
			CodeCompileUnit ccu = new CodeCompileUnit ( ) ;

			// Create a namespace
			CodeNamespace ns = new CodeNamespace ( "MyASPCSControls" ) ;

			// Add some imports statements
			ns.Imports.Add ( new CodeNamespaceImport ( "System" ) ) ;
			ns.Imports.Add ( new CodeNamespaceImport ( "System.ComponentModel" ) ) ;
			ns.Imports.Add ( new CodeNamespaceImport ( "System.Web.UI" ) ) ;
			ns.Imports.Add ( new CodeNamespaceImport ( "System.Web.UI.WebControls" ) ) ;

			// Add the namespace to the code compile unit
			ccu.Namespaces.Add ( ns ) ;

			// Now create the class
			CodeTypeDeclaration ctd = new CodeTypeDeclaration ( "MyASPCSControl" ) ;

			ctd.BaseTypes.Add ( typeof ( System.Web.UI.WebControls.WebControl ) ) ;

			// Add the type to the namespace
			ns.Types.Add ( ctd ) ;

			// Create the private member variable to hold the label
			CodeMemberField textField = new CodeMemberField ( typeof ( string ) , "_text" ) ;
			ctd.Members.Add ( textField ) ;

			// Next add the Text property
			CodeMemberProperty textProp = new CodeMemberProperty ( ) ;
			textProp.Name = "Text" ;
			textProp.Attributes = MemberAttributes.Public ;
			textProp.Type = new CodeTypeReference ( typeof ( string ) ) ;

			textProp.GetStatements.Add ( new CodeMethodReturnStatement ( new CodeFieldReferenceExpression ( new CodeThisReferenceExpression(), "_text" ) ) ) ;
			textProp.SetStatements.Add ( new CodeAssignStatement ( new CodeFieldReferenceExpression ( new CodeThisReferenceExpression(), "_text" ),
				new CodePropertySetValueReferenceExpression ( ) ) ) ;

			ctd.Members.Add ( textProp ) ;

			// Then override the Render() method
			CodeMemberMethod renderMeth = new CodeMemberMethod ( ) ;
			renderMeth.Name = "Render" ;
			renderMeth.Attributes = MemberAttributes.Family | MemberAttributes.Override ;

			CodeParameterDeclarationExpression writer = new CodeParameterDeclarationExpression ( typeof (System.Web.UI.HtmlTextWriter) , "writer" ) ;
			renderMeth.Parameters.Add ( writer ) ;

			renderMeth.Statements.Add ( new CodeMethodInvokeExpression ( new CodeArgumentReferenceExpression ( "writer" ) , "Write", new CodeExpression[] { new CodePropertyReferenceExpression ( new CodeThisReferenceExpression ( ) , "Text" ) } ) ) ;
			ctd.Members.Add ( renderMeth ) ;

			// Add the default constructor
			CodeConstructor constructor = new CodeConstructor ( ) ;
			constructor.Attributes = MemberAttributes.Public ;

			ctd.Members.Add ( constructor ) ;

			// Finally create the C#
			CodeDomProvider provider = new Microsoft.CSharp.CSharpCodeProvider ( ) ;

			ICodeCompiler compiler = provider.CreateGenerator ( ) as ICodeCompiler ;

			CompilerParameters cp = new CompilerParameters ( new string[] { "System.dll", "System.Web.dll" } ) ;

			cp.GenerateInMemory = true ;

			CompilerResults results = compiler.CompileAssemblyFromDom ( cp, ccu ) ;

			if ( results.Errors.Count == 0 )
				return results.CompiledAssembly.GetType ( "MyASPCSControls.MyASPCSControl" ) ;

			// Oops, something was wrong
			throw new Exception ( results.Errors[0].ErrorText ) ;
		}
	}
}
