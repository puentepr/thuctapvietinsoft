using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace HPA.FORMDESIGNER
{
	/// <summary>
	/// manages a single operation in a designer transaction.
	/// </summary>
	internal class DesignerTransactionImpl:DesignerTransaction
	{
		// the host
		private DesignerHostImpl host;
		public DesignerTransactionImpl(DesignerHostImpl host,string description) 
			: base(description)
		{
			this.host = host;
			description = (description==null)?"":description;
			// push this descriptions.
			host.Transactions.Push(description);
			// when we start the first transaction, we have fire
			// the opening and opened events
			if (host.Transactions.Count == 1)
			{
				// we can fire both back to back instread of 
				// pushing and opening and the firing opened
				host.OnTransactionOpening(EventArgs.Empty);
				host.OnTransactionOpened(EventArgs.Empty);
			}
		}

		protected override void OnCancel()
		{
			if (host != null)
			{
				host.Transactions.Pop();
				// if this is the last transaction, fire 
				// closing and closed events
				if (host.Transactions.Count == 0)
				{
					host.OnTransactionClosing(false);
					host.OnTransactionClosed(false);
				}
			}
		}

		protected override void OnCommit()
		{
			if (host != null)
			{
				// pop transaction
				host.Transactions.Pop();

				// if this is the last transaction to be closed, 
				// fire closing and closed event
				if (host.Transactions.Count==0) 
				{
					host.OnTransactionClosing(true);
					host.OnTransactionClosed(true);
				}
			}
		}
	}
}
