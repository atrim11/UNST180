using System.Collections;
using System.Collections.Generic;


namespace Stornaway
{
    [System.Serializable]
    public class SaveData
    {
        public string currentVariant;
        public string[] variantHistory;

        public SaveData(string _currentVariant, string[] _variantHistory) 
        { 
            currentVariant = _currentVariant;
            variantHistory = _variantHistory;
        }
    }
}