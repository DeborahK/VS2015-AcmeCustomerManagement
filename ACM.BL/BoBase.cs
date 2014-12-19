using System;
using System.ComponentModel;

namespace ACM.BL
{
	/// <summary>
	/// Provides standard functionality for all business objects
	/// </summary>
	public abstract class BoBase : 
			IDataErrorInfo, 
			INotifyPropertyChanged
	{
		#region Constants
		/// <summary>
		/// Defines the valid entity states
		/// </summary>
		protected internal enum EntityStateType
		{
			/// <summary>
			/// Entity has not been changed
			/// </summary>
			Unchanged,
			/// <summary>
			/// Entity was created
			/// </summary>
			Added,
			/// <summary>
			/// Entity was deleted
			/// </summary>
			Deleted,
			/// <summary>
			/// Entity was modified
			/// </summary>
			Modified
		}
		#endregion 

		#region Properties
		private EntityStateType _EntityState;
		/// <summary> 
		/// Defines the business object state 
		/// </summary> 
		/// <value>EntityStateEnum</value> 
		/// <returns>Value identifying the entity's state</returns> 
		/// <remarks></remarks> 
		protected EntityStateType EntityState
		{
			get { return _EntityState; }
			set { _EntityState = value; }
		}

		/// <summary> 
		/// Gets whether the business object has changes 
		/// </summary> 
		/// <value>Flag</value> 
		/// <returns>True if there are unsaved changes;False if there are not</returns> 
		/// <remarks></remarks> 
		[BrowsableAttribute(false)]
		[BindableAttribute(false)]
		public bool IsDirty
		{
			get { return this.EntityState != EntityStateType.Unchanged; }
		}

		/// <summary> 
		/// Gets whether the business object is valid 
		/// </summary> 
		/// <returns>True if it is valid;False if it is not valid</returns> 
		/// <remarks>This property should not be browsable in the Properties Window 
		/// or Data Sources window</remarks> 
		[BrowsableAttribute(false)]
		[BindableAttribute(false)]
		public virtual bool IsValid
		{
			get { return (ValidationInstance.Count == 0); }
		}

		private Validation _ValidationInstance;
		/// <summary> 
		/// Expose the validation instance for use by the business objects 
		/// </summary> 
		/// <value>Instance of the Validation class</value> 
		/// <returns>Instance of the Validation class</returns> 
		/// <remarks>By using one instance of the Validation class for 
		/// a business object, all validation errors/rules will be 
		/// managed as one unit</remarks> 
		protected Validation ValidationInstance
		{
			get { return _ValidationInstance; }
			private set { _ValidationInstance = value; }
		}

		#endregion 

		#region Constructor
		/// <summary>
		/// Constructs an instance of the base class.
		/// </summary>
		protected BoBase() 
		{ 
			// Create the instance of the validation class 
			ValidationInstance = new Validation(); 
		} 
		#endregion 
		
		#region IDataErrorInfo Members

		/// <summary>
		/// Provides the validation errors in a formatted string
		/// </summary>
		/// <remarks>
		/// This property should not be browsable in the Properties
		/// Window or Data Sources window
		/// </remarks>
		[BrowsableAttribute(false)]
		[BindableAttribute(false)]
		public string Error
		{
			get { return ValidationInstance.ToString(); }
		}

		/// <summary>
		/// Provides the validation errors for a particular property as a single string
		/// </summary>
		/// <param name="columnName">Name of the property</param>
		/// <returns></returns>
		/// <remarks>
		/// This property should not be browsable in the Properties
		/// Window or Data Sources window
		/// </remarks>
		[BrowsableAttribute(false)]
		[BindableAttribute(false)]
		public string this[string columnName]
		{
			get { return ValidationInstance[columnName]; }
		}

		#endregion

		#region INotifyPropertyChanged Members
		/// <summary>
		/// Defines the event raised when a property is changed
		/// </summary>
			public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Methods

		#region SaveItem
		/// <summary> 
		/// Saves an item 
		/// </summary> 
		/// <remarks>Must be overridden by the child class</remarks> 
		public abstract bool SaveItem();
		#endregion 

		#region SetEntityState
		/// <summary>
		/// Changes the set of the entity to modified or new depending on the flag
		/// </summary>
		/// <param name="isNew">True to set the state to New</param>
		/// <remarks>
		/// This is a simplified public method for use by RIA for Silverlight.
		/// </remarks>
		public void SetEntityState(bool isNew)
		{
			if (isNew)
			{
				this.EntityState = EntityStateType.Added;
			}
			else
			{
				this.EntityState = EntityStateType.Modified;
			}
		}

		/// <summary>
		/// Changes the state of the entity
		/// </summary>
		/// <param name="newEntityState">New entity state</param>
		/// <remarks></remarks>
		protected internal void SetEntityState(EntityStateType newEntityState)
		{
			switch (newEntityState)
			{
				case EntityStateType.Deleted:
				case EntityStateType.Unchanged:
				case EntityStateType.Added:
					// If the new state is deleted, mark it as deleted
					// If the new state is unchanged, mark it as unchanged
					// If the new state is added, mark it as added
					this.EntityState = newEntityState;
					break;

			default:
					// Only set other data states if the existing state is unchanged
					if (this.EntityState == EntityStateType.Unchanged) 
						this.EntityState = newEntityState;
					break;
			}
		}

		/// <summary>
		/// Changes the state of the entity and notifies the system that the property changed
		/// </summary>
		/// <param name="newEntityState">New entity state</param>
		/// <param name="propertyName">Name of the changed property</param>
		/// <remarks></remarks>
		protected internal void SetEntityState(EntityStateType newEntityState, string propertyName)
		{
			SetEntityState(newEntityState);
			
			if (PropertyChanged != null) 
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		#endregion

	}
}
