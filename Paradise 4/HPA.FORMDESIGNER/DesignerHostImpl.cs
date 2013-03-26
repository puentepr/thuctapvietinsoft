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
	/// the host implementation
	/// </summary>
	public class DesignerHostImpl:IDesignerHost,IContainer,IServiceContainer,IComponentChangeService,IExtenderProviderService,IDesignerEventService
	{
		// root component
		private IComponent						rootComponent;
		// service container
		private IServiceContainer               serviceContainer;
		// site-name to site mapping
		private IDictionary						sites;
		// component to designer mapping
		private IDictionary						designers;
		// extender provider list
		private IList							extenderProviders;
		// transaction list
		private Stack					        transactions;
		public DesignerHostImpl(IServiceProvider parentProvider)
		{
			// append to the parentProvider...
			serviceContainer = new ServiceContainer(parentProvider);
			// site name to ISite mapping
			sites = new Hashtable();
			// component to designer mapping
			designers = new Hashtable();
			// list of extender providers
			extenderProviders = new ArrayList();
			// create transaction stack
			transactions = new Stack();
			// services
			serviceContainer.AddService(typeof(IDesignerHost), this);
			serviceContainer.AddService(typeof(IContainer), this);
			serviceContainer.AddService(typeof(IComponentChangeService), this);
			serviceContainer.AddService(typeof(IExtenderProviderService), this);
			serviceContainer.AddService(typeof(IDesignerEventService), this);
			serviceContainer.AddService(typeof(INameCreationService), new NameCreationServiceImpl(this));
			serviceContainer.AddService(typeof(ISelectionService), new SelectionServiceImpl(this));
			serviceContainer.AddService(typeof(IMenuCommandService), new MenuCommandServiceImpl(this));
		}
		#region IDesignerHost Members

		public IContainer Container
		{
			get
			{
				return this;
			}
		}

		public event System.EventHandler TransactionOpening;

		public event System.EventHandler TransactionOpened;

		public event System.EventHandler LoadComplete;

		public IDesigner GetDesigner(IComponent component)
		{
			return designers[component] as IDesigner;
		}

		public event System.EventHandler Activated;

		public event System.EventHandler Deactivated;

		public event System.ComponentModel.Design.DesignerTransactionCloseEventHandler TransactionClosed;

		public bool Loading
		{
			get
			{
				return false;
			}
		}

		public IComponent CreateComponent(Type componentClass, string name)
		{
			IComponent newComponent = Activator.CreateInstance(componentClass)as IComponent;
			Add(newComponent,name);
			return newComponent;
		}
        public IComponent CreateComponent(string systemType, string name)
		{
            Type type = Type.GetType(systemType);
            if (type == null)
                throw new Exception() { HelpLink = systemType };
            return CreateComponent(type, name);
		}

		IComponent System.ComponentModel.Design.IDesignerHost.CreateComponent(Type componentClass)
		{
			return CreateComponent(componentClass,null);
		}

		public bool InTransaction
		{
			get
			{
				// we are in a transaction if the stack has something in it
				return (transactions.Count>0);
			}
		}

		public string TransactionDescription
		{
			get
			{
				DesignerTransaction designerTran = null;
				if (InTransaction)
				{
					designerTran = (DesignerTransaction)transactions.Peek();
				}
				return (designerTran==null)?null:designerTran.Description;
			}
		}
		public DesignerTransaction CreateTransaction(string description)
		{
			return new DesignerTransactionImpl(this,description);
		}

		DesignerTransaction System.ComponentModel.Design.IDesignerHost.CreateTransaction()
		{
			return CreateTransaction("");
		}
		internal Stack Transactions
		{
			get
			{
				return transactions;
			}
		}
		internal void OnTransactionOpened(EventArgs e) 
		{
			if (TransactionOpened != null)
			{
				try
				{
					TransactionOpened(this, e);
				}
				catch{}
			}
		}
        
		internal void OnTransactionOpening(EventArgs e) 
		{
			if (TransactionOpening != null)
			{
				try
				{
					TransactionOpening(this, e);
				}
				catch{}
			}
		}

		internal void OnTransactionClosed(bool commit) 
		{
			if (TransactionClosed != null)
			{
				DesignerTransactionCloseEventArgs e = new DesignerTransactionCloseEventArgs(commit);
				try
				{
					TransactionClosed(this, e);
				}
				catch{}
			}
		}
        
		internal void OnTransactionClosing(bool commit) 
		{

			if (TransactionClosing != null)
			{
				DesignerTransactionCloseEventArgs e = new DesignerTransactionCloseEventArgs(commit);
				try
				{
					TransactionClosing(this,e);
				}
				catch{}
			}
		}
		public void DestroyComponent(IComponent component)
		{
			DesignerTransaction designerTransaction = CreateTransaction("Destroying Component ");
			try
			{
				Remove(component);
			}
			finally
			{
				if(designerTransaction!=null)
				{
					designerTransaction.Commit();
				}
			}
		}

		public void Activate()
		{
			try
			{
				if (Activated != null)
				{
					Activated(this,EventArgs.Empty);
				}
			}
			catch{}
		}

		public string RootComponentClassName
		{
			get
			{
				return rootComponent.GetType().Name;
			}
		}
		public Type GetType(string typeName)
		{
			Type type = null;
			ITypeResolutionService typeResolverService = (ITypeResolutionService)GetService(typeof(ITypeResolutionService));
			
			if (typeResolverService != null)
			{
				type = typeResolverService.GetType(typeName);
			}
			else
			{
				type = Type.GetType(typeName);
			}
			return type;
		}

		public event System.ComponentModel.Design.DesignerTransactionCloseEventHandler TransactionClosing;

		public IComponent RootComponent
		{
			get
			{
				return rootComponent;
			}
		}

		#endregion

		#region IServiceContainer Members

		public void RemoveService(Type serviceType, bool promote)
		{
			serviceContainer.RemoveService(serviceType,promote);
		}

		void System.ComponentModel.Design.IServiceContainer.RemoveService(Type serviceType)
		{
			serviceContainer.RemoveService(serviceType);
		}

		public void AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback, bool promote)
		{
			serviceContainer.AddService(serviceType,callback,promote);
		}

		void System.ComponentModel.Design.IServiceContainer.AddService(Type serviceType, System.ComponentModel.Design.ServiceCreatorCallback callback)
		{
			serviceContainer.AddService(serviceType,callback);
		}

		void System.ComponentModel.Design.IServiceContainer.AddService(Type serviceType, object serviceInstance, bool promote)
		{
			serviceContainer.AddService(serviceType,serviceInstance,promote);
		}

		void System.ComponentModel.Design.IServiceContainer.AddService(Type serviceType, object serviceInstance)
		{
			serviceContainer.AddService(serviceType,serviceInstance);
		}

		#endregion

		#region IServiceProvider Members

		public object GetService(Type serviceType)
		{
			//			if(serviceContainer.GetService(serviceType)!=null)
			//			{
			//				Console.WriteLine("service requested "+serviceType.Name);
			//			}
			return serviceContainer.GetService(serviceType);
		}

		#endregion

		#region IContainer Members

		public ComponentCollection Components
		{
			get
			{
				return new ComponentCollection(GetAllComponents());
			}
		}

		public void Remove(IComponent component)
		{
			if(component==null)
			{
				throw new ArgumentException("component");
			}
			// fire off changing and removing event
			ComponentEventArgs ce = new ComponentEventArgs(component);
			OnComponentChanging(component,null);
			try
			{
				if(ComponentRemoving!=null)
				{
					ComponentRemoving(this, ce);
				}
			}
			catch
			{
				// dont throw here
			}
			// make sure we own the component
			if(component.Site!=null && component.Site.Container==this)
			{
				// remove from extender provider list
				if (component is IExtenderProvider)
				{
					IExtenderProviderService extenderProvider = (IExtenderProviderService)GetService(typeof(IExtenderProviderService));
					if(extenderProvider!=null)
					{
						extenderProvider.RemoveExtenderProvider((IExtenderProvider)component);
					}
				}
				// remove the site
				sites.Remove(component.Site.Name);
				// dispose the designer
				IDesigner designer = designers[component] as IDesigner;
				if(designer!=null)
				{
					designer.Dispose();
					// get rid of the designer from the list
					designers.Remove(component);
				}

				// fire off removed event
				try
				{
					if(ComponentRemoved!=null)
					{
						ComponentRemoved(this, ce);
					}
					this.OnComponentChanged(component,null,null,null);
				}
				catch
				{
					// dont throw here
				}

				// breakdown component, container, and site relationship
				component.Site=null;

				// now dispose the of the component too
				component.Dispose();
			}
		}
		public void Add(IComponent component, string name)
		{
			// we have to have a component
			if(component==null)
			{
				throw new ArgumentException("component");
			}
			
			// if we dont have a name, create one
			if(name==null || name.Trim().Length==0)
			{
				// we need the naming service
				INameCreationService nameCreationService = GetService(typeof(INameCreationService))as INameCreationService;
				if(nameCreationService==null)
				{
					throw new Exception("Failed to get INameCreationService.");
				}
				name = nameCreationService.CreateName(this,component.GetType());
			}

			// if we own the component and the name has changed
			// we just rename the component
			if (component.Site != null && component.Site.Container == this &&
				name!=null && string.Compare(name,component.Site.Name,true)!=0) 
			{
				// name validation and component changing/changed events
				// are fired in the Site.Name property so we don't have 
				// to do it here...
				component.Site.Name=name;
				// bail out
				return;
			}
			// create a site for the component
			ISite site = new SiteImpl(component,name,this);
			// create component-site association
			component.Site=site;
			// the container-component association was established when 
			// we created the site through site.host.
			// we need to fire adding/added events. create a component event args 
			// for the component we are adding.

			ComponentEventArgs evtArgs = new ComponentEventArgs(component);

			// fire off adding event
			if(ComponentAdding!=null)
			{
				try
				{
					ComponentAdding(this,evtArgs);
				}
				catch{}
			}
			
			// if this is the root component
			IDesigner designer = null;
			if(rootComponent==null)
			{
				// set the root component
				rootComponent=component;
				// create the root designer
				designer = (IRootDesigner)TypeDescriptor.CreateDesigner(component,typeof(IRootDesigner));
			}
			else
			{
				designer = TypeDescriptor.CreateDesigner(component,typeof(IDesigner)); 
			}
			if(designer!=null)
			{
				// add the designer to the list
				designers.Add(component,designer);
				// initialize the designer
				designer.Initialize(component);
			}
			// add to container component list
			sites.Add(site.Name,site);
			// now fire off added event
			if(ComponentAdded!=null)
			{
				try
				{
					ComponentAdded(this,evtArgs);
				}
				catch{}
			}
		}

		void System.ComponentModel.IContainer.Add(IComponent component)
		{
			Add(component,null);
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			// dispose all designers
			if(designers!=null && designers.Count>0)
			{
				foreach(IDesigner designer in designers.Values)
				{
					try
					{
						designer.Dispose();
					}
					catch{}
				}
			}
			// dispose all components
			foreach(IComponent icomp in sites.Values)
			{
				try
				{
					icomp.Dispose();
				}
				catch{}
			}

			rootComponent = null;
			serviceContainer = null;
			sites = null;
			designers = null;
			extenderProviders = null;
			transactions = null;
		}

		#endregion

		#region IComponentChangeService Members

		public event System.ComponentModel.Design.ComponentEventHandler ComponentRemoving;

		public void OnComponentChanged(object component, MemberDescriptor member, object oldValue, object newValue)
		{
			if (ComponentChanged != null) 
			{
				ComponentChangedEventArgs ce = new ComponentChangedEventArgs(component, member, oldValue, newValue);
				try
				{
					ComponentChanged(this, ce);
				}
				catch{}
			}
		}

		public void OnComponentChanging(object component, MemberDescriptor member)
		{
			if (ComponentChanging != null) 
			{
				ComponentChangingEventArgs ce = new ComponentChangingEventArgs(component, member);
				try
				{
					ComponentChanging(this, ce);
				}
				catch{}
			}
		}

		internal void OnComponentRename(object component, string oldName, string newName)
		{
			if (ComponentRename != null)
			{
				try
				{
					ComponentRename(this, new ComponentRenameEventArgs(component, oldName, newName));
				}
				catch{}
			}
		}
		public event System.ComponentModel.Design.ComponentEventHandler ComponentAdded;

		public event System.ComponentModel.Design.ComponentRenameEventHandler ComponentRename;

		public event System.ComponentModel.Design.ComponentEventHandler ComponentAdding;

		public event System.ComponentModel.Design.ComponentEventHandler ComponentRemoved;

		public event System.ComponentModel.Design.ComponentChangingEventHandler ComponentChanging;

		public event System.ComponentModel.Design.ComponentChangedEventHandler ComponentChanged;

		#endregion


		#region Private Helper Methods

		private IComponent[] GetAllComponents()
		{
			IComponent[] components = new IComponent[sites.Count];
			// loop over the sites and get all the components
			IEnumerator ie = sites.Values.GetEnumerator();
			int count = 0;
			while(ie.MoveNext())
			{
				ISite site = ie.Current as ISite;
				components[count++]=site.Component;
			}
			return components;
		}
		#endregion

		#region IExtenderProviderService Members

		public void RemoveExtenderProvider(IExtenderProvider provider)
		{
			extenderProviders.Remove(provider);
		}

		public void AddExtenderProvider(IExtenderProvider provider)
		{
			extenderProviders.Add(provider);
		}

		#endregion

		#region IDesignerEventService Members

		public DesignerCollection Designers
		{
			get
			{
				// we just have one designer
				IDesignerHost[] designers = new IDesignerHost[]{this};
				return new DesignerCollection(designers);
			}
		}

		public event System.ComponentModel.Design.DesignerEventHandler DesignerDisposed;

		public IDesignerHost ActiveDesigner
		{
			get
			{
				// always this designer
				return this;
			}
		}

		public event System.ComponentModel.Design.DesignerEventHandler DesignerCreated;

		public event System.ComponentModel.Design.ActiveDesignerEventHandler ActiveDesignerChanged;

		public event System.EventHandler SelectionChanged;

		#endregion
	}
}
