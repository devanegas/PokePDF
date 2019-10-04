using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PokePDF
{
    public abstract class BindableDataErrorInfoBase : BindableBase, IDataErrorInfo
    {
        #region IDataErrorInfo Members
        public Dictionary<string, string> ErrorDictionary = new Dictionary<string, string>();

        public string Error
        {
            get { return String.Join(",", ErrorDictionary.Values); }

        }


        public string this[string columnName]
        {
            get
            {
                if (ErrorDictionary.ContainsKey(columnName))
                    return ErrorDictionary[columnName];
                return null;
            }
        }
        #endregion
    }
}
