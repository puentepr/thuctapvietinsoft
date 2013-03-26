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
	/// an implementation of dictionary service.
	/// </summary>
	public class DictionaryServiceImpl:IDictionaryService
	{
		private IDictionary table;
		public DictionaryServiceImpl()
		{
			table = new Hashtable();
		}
		#region IDictionaryService Members

		public object GetValue(object key)
		{
			return table[key];
		}

		public void SetValue(object key, object value)
		{
			table[key]=value;
		}

		public object GetKey(object value)
		{
			object key = null;
			foreach(DictionaryEntry de in table)
			{
				if(de.Value==value)
				{
					key=de.Key;
					break;
				}
			}
			return key;
		}

		#endregion
	}
}