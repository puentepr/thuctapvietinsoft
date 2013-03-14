using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;

// Need these 2 assemblies for creating the assembly using Reflection.Emit
using System.Reflection;
using System.Reflection.Emit;

// Need these assemblies for the CodeDOM example
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;


namespace GeneratedControls
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button generateButton;
		private System.Windows.Forms.TextBox messageText;
		private System.Windows.Forms.Panel controlPanel;
		private System.Windows.Forms.Button generateCSharpButton;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.generateButton = new System.Windows.Forms.Button();
            this.messageText = new System.Windows.Forms.TextBox();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.generateCSharpButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(8, 32);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(88, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate IL";
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // messageText
            // 
            this.messageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageText.Location = new System.Drawing.Point(8, 8);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(488, 20);
            this.messageText.TabIndex = 1;
            this.messageText.Text = "[Enter a message]";
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.controlPanel.Location = new System.Drawing.Point(8, 64);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(488, 296);
            this.controlPanel.TabIndex = 2;
            // 
            // generateCSharpButton
            // 
            this.generateCSharpButton.Location = new System.Drawing.Point(104, 32);
            this.generateCSharpButton.Name = "generateCSharpButton";
            this.generateCSharpButton.Size = new System.Drawing.Size(88, 23);
            this.generateCSharpButton.TabIndex = 3;
            this.generateCSharpButton.Text = "Generate C#";
            this.generateCSharpButton.Click += new System.EventHandler(this.generateCSharpButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Assemblies";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(504, 367);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.generateCSharpButton);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.generateButton);
            this.Name = "Form1";
            this.Text = "Generated Controls";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		/// <summary>
		/// Generate an assembly in IL that creates controls, and display in the panel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void generateButton_Click(object sender, System.EventArgs e)
		{
			// Create the assembly name
			AssemblyName assemName = new AssemblyName ( ) ;
			assemName.Name = string.Format ( "MyControl{0}", DateTime.Now.Ticks ) ;

			// Create the assembly builder object
			AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly ( assemName, AssemblyBuilderAccess.RunAndSave ) ;

			// Then create the module builder
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule ( "MyAssembly.dll", "MyAssembly.dll" ) ;

			// Get the base class for our new control
			Type baseClass = typeof ( System.Windows.Forms.UserControl ) ;
			Type controlClass = typeof ( System.Windows.Forms.Control ) ;
			Type labelClass = typeof ( System.Windows.Forms.Label ) ;

			// Construct the type
			TypeBuilder typeBuilder = moduleBuilder.DefineType ( "MyControls.MyControl", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.BeforeFieldInit, baseClass ) ;

			// Create a private field for the label
			FieldBuilder labelField = typeBuilder.DefineField ( "_label", typeof ( System.Windows.Forms.Label ) , FieldAttributes.Private ) ;

			// Now generate the InitializeComponent method
			MethodBuilder initComponentBuilder = typeBuilder.DefineMethod ( "InitializeComponent" , MethodAttributes.Private | MethodAttributes.HideBySig, CallingConventions.Standard , typeof ( void ) , new System.Type[] { } ) ;

			// Get an IL generator for the InitializeComponent method
			ILGenerator initIL = initComponentBuilder.GetILGenerator ( ) ;

			// And write the method body
			initIL.BeginScope ( ) ;
			// Construct the label
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Newobj , typeof ( System.Windows.Forms.Label).GetConstructor ( new Type[] { } ) ) ;
			initIL.Emit ( OpCodes.Stfld , labelField ) ;
			// Then call Control.SuspendLayout
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Call , baseClass.GetMethod ( "SuspendLayout" ) ) ;
			// Anchor the control to the top left right
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldfld, labelField ) ;
			initIL.Emit ( OpCodes.Ldc_I4_S, (int) (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right ) ) ;
			initIL.Emit ( OpCodes.Callvirt , labelClass.GetProperty("Anchor",typeof(AnchorStyles)).GetSetMethod ( ) ) ;
			// Set the border style of the control
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldfld, labelField ) ;
			initIL.Emit ( OpCodes.Ldc_I4_2 ) ;
			initIL.Emit ( OpCodes.Callvirt , labelClass.GetProperty("BorderStyle",typeof(BorderStyle)).GetSetMethod()) ;// typeof(System.Windows.Forms.Label).GetProperty("BorderStyle",typeof(BorderStyle)).GetSetMethod ( ) ) ;
			// Set the top left of the label
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldfld, labelField ) ;
			initIL.Emit ( OpCodes.Ldc_I4_8 ) ;
			initIL.Emit ( OpCodes.Ldc_I4_8 ) ;
			initIL.Emit ( OpCodes.Newobj , typeof ( System.Drawing.Point ).GetConstructor ( new Type[] { typeof ( int ) , typeof ( int ) } ) ) ;
			initIL.Emit ( OpCodes.Callvirt , labelClass.GetProperty("Location",typeof(System.Drawing.Point)).GetSetMethod ( ) ) ;
			// Set the name of the control
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldfld, labelField ) ;
			initIL.Emit ( OpCodes.Ldstr , "mainLabel" ) ;
			initIL.Emit ( OpCodes.Callvirt , labelClass.GetProperty("Name",typeof(string)).GetSetMethod ( ) ) ;
			// Set the size of the control
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldfld, labelField ) ;
			initIL.Emit ( OpCodes.Ldc_I4, 312 ) ;
			initIL.Emit ( OpCodes.Ldc_I4_S, 23 ) ;
			initIL.Emit ( OpCodes.Newobj , typeof ( Size ).GetConstructor ( new Type[] { typeof ( int ) , typeof ( int ) } ) ) ;
			initIL.Emit ( OpCodes.Callvirt , labelClass.GetProperty("Size",typeof(Size)).GetSetMethod ( ) ) ;
			// Set the tab index of the label control
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldfld, labelField ) ;
			initIL.Emit ( OpCodes.Ldc_I4_0 ) ;
			initIL.Emit ( OpCodes.Callvirt , labelClass.GetProperty("TabIndex",typeof(int)).GetSetMethod ( ) ) ;
			// And set the text to that which the user typed in...
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldfld, labelField ) ;
			initIL.Emit ( OpCodes.Ldstr , messageText.Text ) ;
			initIL.Emit ( OpCodes.Callvirt , labelClass.GetProperty("Text",typeof(string)).GetSetMethod ( ) ) ;
			// Now add the label to the controls on the user control
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Call , controlClass.GetProperty("Controls").GetGetMethod ( ) ) ;
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldfld, labelField ) ;
			initIL.Emit ( OpCodes.Callvirt, typeof ( ControlCollection ).GetMethod ( "Add" ) ) ;
			// Now set the name of the main control
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldstr, "MyControl" ) ;
			initIL.Emit ( OpCodes.Call, controlClass.GetProperty("Name").GetSetMethod ( ) ) ;
			// Now emit the initial size of the control
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldc_I4, 328 ) ;
			initIL.Emit ( OpCodes.Ldc_I4, 200 ) ;
			initIL.Emit ( OpCodes.Newobj , typeof ( Size ).GetConstructor ( new Type[] { typeof ( int ) , typeof ( int ) } ) ) ;
			initIL.Emit ( OpCodes.Callvirt , controlClass.GetProperty("Size",typeof(Size)).GetSetMethod ( ) ) ;
			// Call Control.ResumeLayout
			initIL.Emit ( OpCodes.Ldarg_0 ) ;
			initIL.Emit ( OpCodes.Ldc_I4_0 ) ;
			initIL.Emit ( OpCodes.Call , baseClass.GetMethod ( "ResumeLayout" , new Type[] { typeof ( bool ) } ) ) ;
			// And emit the end of the function
			initIL.Emit ( OpCodes.Ret ) ;
			initIL.EndScope ( ) ;

			MethodBuilder dummyBuilder = typeBuilder.DefineMethod ( "Dummy" , MethodAttributes.Private | MethodAttributes.HideBySig, CallingConventions.Standard , typeof ( void ) , new System.Type[] { } ) ;

			// Get an IL generator 
			ILGenerator dummyIL = dummyBuilder.GetILGenerator ( ) ;

			dummyIL.BeginScope ( ) ;
			LocalBuilder lb = dummyIL.DeclareLocal ( typeof ( Exception ) ) ;
			dummyIL.Emit ( OpCodes.Ret ) ;
			dummyIL.EndScope ( ) ;

			// Then create the constructor which will call InitializeComponent
			ConstructorBuilder constructor = typeBuilder.DefineConstructor ( MethodAttributes.Public | MethodAttributes.HideBySig , CallingConventions.Standard , new System.Type[] { } ) ;

			// Get an IL generator so I can write some code
			ILGenerator constructorIL = constructor.GetILGenerator ( ) ;

			// Call the base class constructor and then InitializeComponent
			constructorIL.BeginScope ( ) ;
			constructorIL.Emit ( OpCodes.Ldarg_0 ) ;
			constructorIL.Emit ( OpCodes.Call, baseClass.GetConstructor ( new Type[] { } ) ) ;
			constructorIL.Emit ( OpCodes.Ldarg_0 ) ;
			constructorIL.Emit ( OpCodes.Call, initComponentBuilder ) ;
			constructorIL.Emit ( OpCodes.Ret ) ;
			constructorIL.EndScope ( ) ;

			// Now write the type to the assembly
			Type newControl = typeBuilder.CreateType ( ) ;

			assemblyBuilder.Save ( "MyAssembly.dll" ) ;

			// And construct it and place it on screen!
			Control c = Activator.CreateInstance ( newControl ) as Control ;

			c.Dock = DockStyle.Fill ;
			
			controlPanel.SuspendLayout ( ) ;
			controlPanel.Controls.Clear ( ) ;
			controlPanel.Controls.Add ( c ) ;
			controlPanel.ResumeLayout ( ) ;
		}

		/// <summary>
		/// Generate a C# assembly, compile it and load it up
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void generateCSharpButton_Click(object sender, System.EventArgs e)
		{
			CodeExpression[] emptyParams = new CodeExpression[] { } ;

			// Generate the C# for the control
			CodeCompileUnit ccu = new CodeCompileUnit ( ) ;

			// Create a namespace
			CodeNamespace ns = new CodeNamespace ( "MyControls" ) ;

			// Add some imports statements
			ns.Imports.Add ( new CodeNamespaceImport ( "System" ) ) ;
			ns.Imports.Add ( new CodeNamespaceImport ( "System.Drawing" ) ) ;
			ns.Imports.Add ( new CodeNamespaceImport ( "System.Windows.Forms" ) ) ;

			// Add the namespace to the code compile unit
			ccu.Namespaces.Add ( ns ) ;

			// Now create the class
			CodeTypeDeclaration ctd = new CodeTypeDeclaration ( "MyControl" ) ;

			ctd.BaseTypes.Add ( typeof ( System.Windows.Forms.UserControl ) ) ;

			// Add the type to the namespace
			ns.Types.Add ( ctd ) ;

			// Add the default constructor
			CodeConstructor constructor = new CodeConstructor ( ) ;

			constructor.Statements.Add ( new CodeMethodInvokeExpression ( new CodeThisReferenceExpression ( ) , "InitializeComponent", emptyParams ) ) ;

			constructor.Attributes = MemberAttributes.Public ;

			ctd.Members.Add ( constructor ) ;

			// Create the private member variable to hold the label
			CodeMemberField labelField = new CodeMemberField ( typeof ( System.Windows.Forms.Label ) , "_label" ) ;
			ctd.Members.Add ( labelField ) ;

			// Now add the InitializeComponent method
			CodeMemberMethod initializeComponent = new CodeMemberMethod ( ) ;
			initializeComponent.Name = "InitializeComponent" ;
			initializeComponent.ReturnType = new CodeTypeReference ( typeof ( void ) ) ;

			CodeAssignStatement labelNew = new CodeAssignStatement ( new CodeVariableReferenceExpression ( "_label" ), 
				new CodeObjectCreateExpression ( typeof ( System.Windows.Forms.Label ), emptyParams ) ) ;
			initializeComponent.Statements.Add ( labelNew ) ;

			// Add the SuspendLayout() call
			initializeComponent.Statements.Add ( new CodeMethodInvokeExpression ( new CodeThisReferenceExpression ( ) , "SuspendLayout", emptyParams ) ) ;

			CodeBinaryOperatorExpression leftAndRight = new CodeBinaryOperatorExpression (
				new CodeFieldReferenceExpression ( new CodeTypeReferenceExpression ( typeof ( System.Windows.Forms.AnchorStyles ) ), "Left" ) ,
				CodeBinaryOperatorType.BitwiseOr ,
				new CodeFieldReferenceExpression ( new CodeTypeReferenceExpression ( typeof ( System.Windows.Forms.AnchorStyles ) ), "Right" ) ) ;

			CodeBinaryOperatorExpression topToo = new CodeBinaryOperatorExpression (
				new CodeFieldReferenceExpression ( new CodeTypeReferenceExpression ( typeof ( System.Windows.Forms.AnchorStyles ) ), "Top" ) ,
				CodeBinaryOperatorType.BitwiseOr ,
				leftAndRight ) ;		

			// Setup the Anchor property of the label
			initializeComponent.Statements.Add ( new CodeAssignStatement (
				new CodePropertyReferenceExpression ( new CodeVariableReferenceExpression ( "_label" ), "Anchor" ),
				topToo ) ) ;

			// And setup the border style
			initializeComponent.Statements.Add ( new CodeAssignStatement (
				new CodePropertyReferenceExpression ( new CodeVariableReferenceExpression ( "_label" ), "BorderStyle" ),
				new CodeFieldReferenceExpression ( new CodeTypeReferenceExpression ( typeof ( System.Windows.Forms.BorderStyle ) ), "Fixed3D" ) ) ) ;

			// Set the location of the control
			initializeComponent.Statements.Add ( new CodeAssignStatement (
				new CodePropertyReferenceExpression ( new CodeVariableReferenceExpression ( "_label" ), "Location" ),
				new CodeObjectCreateExpression ( typeof ( System.Drawing.Point ) , 
					new CodeExpression[] { new CodePrimitiveExpression ( 8 ) , 
											new CodePrimitiveExpression ( 8 ) } ) ) ) ;

			// Set the name of the control
			initializeComponent.Statements.Add ( new CodeAssignStatement (
				new CodePropertyReferenceExpression ( new CodeVariableReferenceExpression ( "_label" ), "Name" ),
				new CodePrimitiveExpression ( "_label" ) ) ) ;

			// Set the size of the control
			initializeComponent.Statements.Add ( new CodeAssignStatement (
				new CodePropertyReferenceExpression ( new CodeVariableReferenceExpression ( "_label" ), "Size" ),
				new CodeObjectCreateExpression ( typeof ( System.Drawing.Size ) , 
				new CodeExpression[] { new CodePrimitiveExpression ( 312 ) , 
										new CodePrimitiveExpression ( 23 ) } ) ) ) ;

			// Set the tab index
			initializeComponent.Statements.Add ( new CodeAssignStatement (
				new CodePropertyReferenceExpression ( new CodeVariableReferenceExpression ( "_label" ), "TabIndex" ),
				new CodePrimitiveExpression ( 0 ) ) ) ;

			// And then the text!
			initializeComponent.Statements.Add ( new CodeAssignStatement (
				new CodePropertyReferenceExpression ( new CodeVariableReferenceExpression ( "_label" ), "Text" ),
				new CodePrimitiveExpression ( messageText.Text ) ) ) ;

			// Now add the label control to the controls collection
			initializeComponent.Statements.Add (
				new CodeMethodInvokeExpression ( new CodePropertyReferenceExpression ( new CodeThisReferenceExpression ( ) , "Controls" ), "Add", 
				new CodeExpression[] { new CodeVariableReferenceExpression ( "_label" ) } ) ) ;

			// And set the name of the control to MyControl
			initializeComponent.Statements.Add ( new CodeAssignStatement ( new CodePropertyReferenceExpression ( new CodeThisReferenceExpression ( ) , "Name" ) ,
				new CodePrimitiveExpression ( "MyControl" ) ) ) ;

			// And the size of the control
			initializeComponent.Statements.Add ( new CodeAssignStatement ( new CodePropertyReferenceExpression ( new CodeThisReferenceExpression ( ) , "Size" ) ,
				new CodeObjectCreateExpression ( typeof ( System.Drawing.Size ) , 
					new CodeExpression[] { new CodePrimitiveExpression ( 328 ) , 
											new CodePrimitiveExpression ( 100 ) } ) ) ) ;

			// Add the ResumeLayout ( false ) call
			initializeComponent.Statements.Add ( new CodeMethodInvokeExpression ( new CodeThisReferenceExpression ( ) , "ResumeLayout", new CodeExpression [] { new CodePrimitiveExpression ( false ) } ) ) ;

			// And finally add initializeComponent to the members for the class
			ctd.Members.Add ( initializeComponent ) ;

			// Finally create the C#
			CodeDomProvider provider = new Microsoft.CSharp.CSharpCodeProvider ( ) ;

#if DEBUG
			// Generate the source code on disk 
			ICodeGenerator generator = provider.CreateGenerator ( ) ;

			using ( StreamWriter sw = new StreamWriter ( "code.cs" , false ) )
			{
				CodeGeneratorOptions options = new CodeGeneratorOptions ( ) ;
				options.BracingStyle = "C" ;
				generator.GenerateCodeFromCompileUnit ( ccu, sw, options ) ;
			}
#endif 

			ICodeCompiler compiler = provider.CreateGenerator ( ) as ICodeCompiler ;

			CompilerParameters cp = new CompilerParameters ( new string[] { "System.dll", "System.Windows.Forms.dll", "System.Drawing.dll" } ) ;

			cp.GenerateInMemory = true ;
			cp.OutputAssembly = "AutoGenerated" ;

			CompilerResults results = compiler.CompileAssemblyFromDom ( cp, ccu ) ;

			if ( results.Errors.Count == 0 )
			{
				Type t = results.CompiledAssembly.GetType ( "MyControls.MyControl" ) ;

				Control c = Activator.CreateInstance ( t ) as Control ;

				c.Dock = DockStyle.Fill ;
			
				controlPanel.SuspendLayout ( ) ;
				controlPanel.Controls.Clear ( ) ;
				controlPanel.Controls.Add ( c ) ;
				controlPanel.ResumeLayout ( ) ;
			}
			else
			{
				CompilerError error = results.Errors[0] ;
				int i = 0 ;
				i++;
			}

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			StringBuilder	assemblies = null ;

			// Display a list of all assemblies loaded
			foreach ( Assembly assem in AppDomain.CurrentDomain.GetAssemblies ( ) )
			{
				if ( null == assemblies )
					assemblies = new StringBuilder ( assem.FullName ) ;
				else
					assemblies.AppendFormat ( "\r\n{0}", assem.FullName ) ;
			}

			MessageBox.Show ( assemblies.ToString ( ) , "LoadedAssemblies" ) ;
		}
	}
}