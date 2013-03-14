<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="GeneratedControlsASP._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Runtime Control Generation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<h1>Runtime Control Generation</h1>
			<P>Please enter some text in the following control, then click on either of the 
				Generate IL or Generate C# buttons. This will generate an ASP.NET control 
				(using Reflection.Emit or System.CodeDom), and then display a page into which 
				this generated control is loaded.</P>
			<P>
				<asp:TextBox id="TextBox1" runat="server" Width="50%"></asp:TextBox>&nbsp;
				<asp:Button id="generateIL" runat="server" Text="Generate IL"></asp:Button>&nbsp;
				<asp:Button id="generateCsharp" runat="server" Text="Generate C#"></asp:Button></P>
		</form>
	</body>
</HTML>
