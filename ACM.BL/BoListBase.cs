using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ACM.BL
{
    /// <summary>
    /// Base class for any business object list that needs binding list support.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BoListBase<T> : 
        BindingList<T> where T: BoBase, new()
    {
        #region Properties
        private List<T> _DeletedItemsList = new List<T>();
        /// <summary> 
        /// Gets the set of deleted items. 
        /// </summary> 
        /// <remarks> 
        /// This is needed to keep the deleted items until the save operation 
        /// actually removes them from the table. 
        /// </remarks> 
        protected List<T> DeletedItemsList
        {
            get
            {
                if (_DeletedItemsList == null)
                {
                    _DeletedItemsList = new List<T>();
                }
                return _DeletedItemsList;
            }
        }

        /// <summary> 
        /// Gets whether the list contains any dirty item 
        /// </summary> 
        /// <value></value> 
        /// <remarks></remarks> 
        public bool IsDirty
        {
            get
            {
                // This list is dirty if any of the elements in the list are dirty 
                bool anyDirty = this.Any(item => item.IsDirty);

                // List is also dirty if there are deleted items 
                if (!anyDirty)
                {
                    anyDirty = DeletedItemsList.Count != 0;
                }
                return anyDirty;
            }
        }

        /// <summary> 
        /// Gets whether the list contains any dirty item 
        /// </summary> 
        /// <value></value> 
        /// <remarks></remarks> 
        public bool IsValid
        {
            get
            {
                // This list is valid only if all of the items in the list are valid 
                bool allValid = this.All(item => item.IsValid);
                return allValid;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs an instance of BoListBase.
        /// </summary>
        public BoListBase() : base()
        { }

        /// <summary>
        /// Constructs an instance of BoListBase from an existing list.
        /// </summary>
        /// <param name="list"></param>
        public BoListBase(IList<T> list) : base(list)
        { }
        #endregion

        #region Methods

        #region DeleteItem
        /// <summary>
        /// Deletes the defined item from the list.
        /// </summary>
        /// <param name="item">Item to delete.</param>
        public void DeleteItem(T item)
        {
            // Ensure the item is marked for deletion
            item.SetEntityState(BoBase.EntityStateType.Deleted);

            // Add it to the deleted items list
            this.DeletedItemsList.Add(item);

            // Remove the item from "this" list
            base.Remove(item);
        }
        #endregion

        #region Save
        /// <summary>
        /// Performs the save.
        /// </summary>
        public bool Save()
        {
            bool success = true;

            //Perform the deletions first
            //Process each deleted entry
            foreach (T item in DeletedItemsList)
                //"Save" the delete
                item.SaveItem();

            // Clear the deleted items list
            _DeletedItemsList = null;

            //Process each entry in the binding list
            foreach (T item in this)
            {
                if (item.IsDirty)
                {
                    // Save the item
                    success=item.SaveItem();

                    if (!success)
                    {
                        break;
                    }

                    // Clear the change state
                    item.SetEntityState(BoBase.EntityStateType.Unchanged);
                }
            }

            return success;
        }
        #endregion

        #endregion
    }
}
