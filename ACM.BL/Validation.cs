using System;
using System.Collections.Generic;

namespace ACM.BL
{
    /// <summary>
    /// Provides routines for validation
    /// </summary>
    public class Validation
    {
        #region Properties
        /// <summary>
        /// Gets the number of validation errors
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public int Count
        {
            get
            {
                return ValidationList.Count;
            }
        }

        /// <summary>
        /// Gets the validation errors for the defined property.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string this [string propertyName]
        { 
            get 
            {
                if (ValidationList.ContainsKey(propertyName))
                    return ValidationList[propertyName];
                else
                    return null;
            } 
        }

        private Dictionary<String, String> _ValidationList;
        /// <summary>
        /// Gets or sets the list of validation errors
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        private Dictionary<String, String> ValidationList 
        {
            get { return _ValidationList; }
            set { _ValidationList = value; }
        }
        #endregion

        #region Constructors/Destructors
        /// <summary>
        /// Constructor executed when an instance of this class is created
        /// </summary>
        /// <remarks></remarks>
        public Validation()
        {
            // Create the list to contain the validation errors
            ValidationList = new Dictionary<String, String>();
        }
        #endregion

        #region Public Methods

        #region ToString
            /// <summary>
            /// Converts the collection of validation errors
            /// into a single string 
            /// </summary>
            /// <returns></returns>
            /// <remarks></remarks>
            public override string ToString()
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                foreach (string s in ValidationList.Values)
                    sb.AppendLine(s);

                return sb.ToString();
            }
        #endregion

        #region ValidateClear
            /// <summary>
            /// Clears the validation for a property
            /// </summary>
            /// <param name="propertyName">Name of the Property</param>
            /// <remarks>Should be called before any other validation 
            /// is called</remarks>
            public void ValidateClear(string propertyName)
            {
                // If the Property doesn't have any messages, this is done
                if (ValidationList.ContainsKey(propertyName))
                    // Otherwise, remove the entry
                    ValidationList.Remove(propertyName);
            }
        #endregion

        #region ValidateLength
            /// <summary>
            /// Validates the maximum length of a field
            /// </summary>
            /// <param name="propertyName">Name of the Property to validate</param>
            /// <param name="value">Value of the Property to validate</param>
            /// <param name="maxLength">Maximum length</param>
            /// <returns></returns>
            /// <remarks></remarks>
            public Boolean ValidateLength(string propertyName,
                                            string value, 
                                            int maxLength)
            {
                String newMessage   = String.Empty;

                if (!String.IsNullOrEmpty(value) && value.Length > maxLength )
                {
                    newMessage = String.Format("{0} has a maximum size of {1}",
                                             propertyName, maxLength);
                    // Add the message to the validation list
                    AddValidationError(propertyName, newMessage);
                    return false;
                }
                else
                    return true;
                
            }
        #endregion

        #region ValidateRequired
        /// <summary>
        /// Validates that there is a value in a property
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="value">Value of the property</param>
        /// <returns>True if the property has a value; 
        /// false if the property has no value</returns>
        /// <remarks></remarks>
        public Boolean ValidateRequired(string propertyName,
                                        string value)
        {
            string newMessage = String.Empty;

            if (String.IsNullOrWhiteSpace(value))
            {
                newMessage = String.Format("{0} is required, please enter a valid value", 
                                            propertyName);
                AddValidationError(propertyName, newMessage);
                return false;
            }
            else
                return true;
        }
        #endregion

        #endregion

        #region Private Methods

        #region AddValidationError
            /// <summary>
            /// Adds a validation error to the collection
            /// </summary>
            /// <param name="propertyName">Property with the error</param>
            /// <param name="message">Message displayed to the user</param>
            /// <remarks></remarks>
            private void AddValidationError(string propertyName, string message)
            {
                // If the property already has a message, add this message
                if (ValidationList.ContainsKey(propertyName)) 
                {
                    string existingMessage  =  ValidationList[propertyName];

                    if (!existingMessage.Contains(message))
                        // Append the new message to the existing message
                        ValidationList[propertyName] += "; " + message;
                }
                else
                    // Add the message to the validation list
                    ValidationList.Add(propertyName, message);
            }
        #endregion

        #endregion

    }
}
