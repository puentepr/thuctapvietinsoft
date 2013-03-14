using System;
using System.ComponentModel;

// Need these 2 assemblies for creating the assembly using Reflection.Emit
using System.Reflection;
using System.Reflection.Emit;

namespace GeneratedControlsASP
{
	/// <summary>
	/// Summary description for ControlGeneratorIL.
	/// </summary>
	public class ControlGeneratorIL
	{
		public static Type GenerateControl ( )
		{
			// Create the assembly name
			AssemblyName assemName = new AssemblyName ( ) ;
			assemName.Name = string.Format ( "MyASPILControl{0}", DateTime.Now.Ticks ) ;

			// Create the assembly builder object
			AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly ( assemName, AssemblyBuilderAccess.RunAndSave ) ;

			// Then create the module builder
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule ( "MyASPILAssembly.dll", "MyASPILAssembly.dll" ) ;

			// Get the base class for our new control
			Type baseClass = typeof ( System.Web.UI.WebControls.WebControl ) ;

			// Construct the type
			TypeBuilder typeBuilder = moduleBuilder.DefineType ( "MyASPILControls.MyASPILControl", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.BeforeFieldInit, baseClass ) ;

			// Create a private field for the text
			FieldBuilder labelField = typeBuilder.DefineField ( "_text", typeof ( string ) , FieldAttributes.Private ) ;

			// Define an array for parameter types
			Type[] nullParams = new Type[] { } ;

			// Then define the Text property of the control
			PropertyBuilder pb = typeBuilder.DefineProperty ( "Text", PropertyAttributes.None, typeof ( string ) , nullParams ) ;

			// And add the Bindable(true) attribute
			ConstructorInfo cons = typeof ( BindableAttribute ).GetConstructor ( new Type[] { typeof ( bool ) } ) ;
			CustomAttributeBuilder bindable = new CustomAttributeBuilder ( cons, new object[] { true } ) ;
			pb.SetCustomAttribute ( bindable ) ;

			// Define the Get method
			MethodBuilder getMethod = typeBuilder.DefineMethod ( "get_Text", MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.SpecialName, typeof ( string ), nullParams ) ;

			// Get an IL generator for the get method
			ILGenerator getIL = getMethod.GetILGenerator ( ) ;

			getIL.Emit ( OpCodes.Ldarg_0 ) ;
			getIL.Emit ( OpCodes.Ldfld, labelField ) ;
			getIL.Emit ( OpCodes.Ret ) ;

			pb.SetGetMethod ( getMethod ) ;

			// And define the Set method
			MethodBuilder setMethod = typeBuilder.DefineMethod ( "set_Text", MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.SpecialName, typeof ( void ) , new Type[] { typeof ( string ) } ) ;
			ILGenerator setIL = setMethod.GetILGenerator ( ) ;

			setIL.Emit ( OpCodes.Ldarg_0 ) ;
			setIL.Emit ( OpCodes.Ldarg_1 ) ;
			setIL.Emit ( OpCodes.Stfld, labelField ) ;
			setIL.Emit ( OpCodes.Ret ) ;

			pb.SetSetMethod ( setMethod ) ;

			// Next define the Render method
			MethodBuilder renderMethod = typeBuilder.DefineMethod ( "Render", MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual , typeof ( void ) , new Type[] { typeof ( System.Web.UI.HtmlTextWriter ) } ) ;

			ILGenerator renderIL = renderMethod.GetILGenerator ( ) ;

			renderIL.Emit ( OpCodes.Ldarg_1 ) ;
			renderIL.Emit ( OpCodes.Ldarg_0 ) ;
			renderIL.Emit ( OpCodes.Call, getMethod ) ;

			MethodInfo textWriterWrite = typeof(System.IO.TextWriter).GetMethod("Write",new Type[] { typeof ( string ) } ) ;
			renderIL.Emit ( OpCodes.Callvirt, textWriterWrite ) ;
			renderIL.Emit ( OpCodes.Ret ) ;

			// And finally create the constructor
			ConstructorBuilder cb = typeBuilder.DefineConstructor ( MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.Public, CallingConventions.Standard, nullParams ) ;
			ILGenerator consIL = cb.GetILGenerator ( ) ;

			consIL.Emit ( OpCodes.Ldarg_0 ) ;
			consIL.Emit ( OpCodes.Call, baseClass.GetConstructor ( BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, new ParameterModifier[] { } ) ) ;
			consIL.Emit ( OpCodes.Ret ) ;

			return typeBuilder.CreateType ( ) ;
		}
	}
}
