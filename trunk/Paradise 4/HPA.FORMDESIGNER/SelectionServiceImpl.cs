using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;

namespace HPA.FORMDESIGNER
{
	public class SelectionServiceImpl: ISelectionService 
	{
		IDesignerHost host;
		IList selectedComponents;
		
		public event EventHandler SelectionChanging;
		public event EventHandler SelectionChanged;
		
		public SelectionServiceImpl(IDesignerHost host)
		{
			this.host = host;

			selectedComponents = new ArrayList();

			// we need to know when components get aded and/or removed
			IComponentChangeService changeService = (IComponentChangeService)host.GetService(typeof(IComponentChangeService));
			changeService.ComponentAdded +=new ComponentEventHandler(OnComponentAdded);
			changeService.ComponentRemoved += new ComponentEventHandler(OnComponentRemoved);
		}
		
		public ICollection GetSelectedComponents() 
		{
			return selectedComponents;
		}

		private void OnSelectionChanging(EventArgs e)
		{
			// fire changing event
			if (SelectionChanging != null) 
			{
				try
				{
					SelectionChanging(this, e);
				}
				catch{}
			}
		}
		
		private void OnSelectionChanged(EventArgs e)
		{
			// fire changed event
			if (SelectionChanged != null) 
			{
				try
				{
					SelectionChanged(this, e);
				}
				catch{}
			}
		}

		public object PrimarySelection 
		{
			get 
			{
				return ((selectedComponents !=null && selectedComponents.Count > 0)?selectedComponents[0]:null);
			}
		}
		
		public int SelectionCount 
		{
			get 
			{
				return selectedComponents.Count;
			}
		}
		
		public bool GetComponentSelected(object component) 
		{
			// is the component in our selected list
			return selectedComponents.Contains(component);
		}
		
		public void SetSelectedComponents(ICollection components, SelectionTypes selectionType) 
		{
			// fire changing event
			if (SelectionChanging != null)
			{
				try
				{
					SelectionChanging(this, EventArgs.Empty);
				}
				catch{}
			}
			// dont allow an empty collection
			if (components == null || components.Count == 0) 
			{
				components = new ArrayList();
			}
			bool ctrlDown=false,shiftDown=false;
			// we need to know if shift or ctrl is down on clicks 
			if ((selectionType & SelectionTypes.Click) == SelectionTypes.Click)
			{
				ctrlDown = ((Control.ModifierKeys & Keys.Control) == Keys.Control);
				shiftDown = ((Control.ModifierKeys & Keys.Shift)   == Keys.Shift);
			}
			if (selectionType == SelectionTypes.Replace)
			{
				// discard the hold list and go with this one
				selectedComponents = new ArrayList(components);
			}
			else
			{
				if (!shiftDown && !ctrlDown && components.Count == 1 && !selectedComponents.Contains(components))
				{
					selectedComponents.Clear();
				}
				// something was either added to the selection
				// or removed
				IEnumerator ie = components.GetEnumerator();
				while(ie.MoveNext())
				{
					IComponent comp = ie.Current as IComponent;
					if(comp!=null)
					{
						if (ctrlDown || shiftDown)
						{
							if (selectedComponents.Contains(comp))
							{
								selectedComponents.Remove(comp);
							}
							else
							{
								// put it back into the front because it was
								// the last one selected
								selectedComponents.Insert(0,comp);
							}
						}
						else
						{
							if (!selectedComponents.Contains(comp))
							{
								selectedComponents.Add(comp);
							}
							else
							{
								selectedComponents.Remove(comp);
								selectedComponents.Insert(0,comp);
							}
						}
					}
				}
			}
			// fire changed event
			if (SelectionChanged != null)
			{
				try
				{
					SelectionChanged(this, EventArgs.Empty);
				}
				catch{}
			}
		}
		
		public void SetSelectedComponents(ICollection components) 
		{
			SetSelectedComponents(components, SelectionTypes.Replace);
		}
		
		private void OnComponentRemoved(object sender, ComponentEventArgs e)
		{
			if (selectedComponents.Contains(e.Component)) 
			{
				// fire changing event
				OnSelectionChanging(EventArgs.Empty);
				// discard component
				selectedComponents.Remove(e.Component);
				// fire changed event
				OnSelectionChanged(EventArgs.Empty);
			}
		}

		private void OnComponentAdded(object sender, ComponentEventArgs e)
		{
			// if its not already in the list
			if(!selectedComponents.Contains(e.Component))
			{
				// fire changing event
				OnSelectionChanging(EventArgs.Empty);
				// discard component
				selectedComponents.Add(e.Component);
				// fire changed event
				OnSelectionChanged(EventArgs.Empty);
			}
		}
	}
}

