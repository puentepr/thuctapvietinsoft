using System;
using System.CodeDom;
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
	/// Summary description for NameCreationServiceImpl.
	/// </summary>
	public class NameCreationServiceImpl:INameCreationService
	{
		private IDesignerHost designerHost;
		public NameCreationServiceImpl(IDesignerHost host)
		{
			if(host==null)
			{
				throw new ArgumentException("designerHost");
			}
			designerHost=host;
		}
		#region INameCreationService Members
		/// <summary>
		/// creates a unique name from the given container and dataType
		/// </summary>
		/// <param name="container"></param>
		/// <param name="dataType"></param>
		/// <returns></returns>
		public string CreateName(IContainer container, Type dataType)
		{
			if(container==null)
			{
				throw new ArgumentException("container");
			}
			if(dataType==null)
			{
				throw new ArgumentException("dataType");
			}
			// look to see if the container already has this type
			// of component, if it does, then iterate until you
			// find a unique name
			int count = 1;
			string compName = dataType.Name + count.ToString();
			if(container.Components[compName]!=null)
			{
				for(int i=1; i<container.Components.Count; i++)
				{
					compName = dataType.Name + (i+1).ToString();
					if(container.Components[compName]==null)
					{
						break;
					}
				}
			}
			return compName;
		}

		public bool IsValidName(string name)
		{
			ValidateName(name);
			return true;
		}

		public void ValidateName(string name)
		{
			// iterate the comps in the component container and 
			// make sure that the name is not used already
			if(designerHost.Container==null)
			{
				throw new Exception("Null container.");
			}
			// if we have some components
			if(designerHost.Container.Components!=null &&
				designerHost.Container.Components.Count>0)
			{
				foreach(IComponent comp in designerHost.Container.Components)
				{
					if(string.Compare(name,comp.Site.Name)==0)
					{
						throw new Exception("Name alreay in use.");
					}
				}
			}
		}

		#endregion
	}
}
