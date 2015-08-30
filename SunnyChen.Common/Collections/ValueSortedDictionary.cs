using System;
using System.Collections;
using System.Collections.Generic;

using SunnyChen.Common.Enumerations;
using SunnyChen.Common.Properties;

namespace SunnyChen.Common.Collections
{
    /// <summary>
    /// Data dictionary with the Value-Sorted algorithm.
    /// </summary>
    /// <typeparam name="TKey">Type of the dictionary key.</typeparam>
    /// <typeparam name="TValue">Type of the dictionary value. This type should be comparable. For more information
    /// about comparable types please refer to <see cref="System.IComparable"/> interface.</typeparam>
    public class ValueSortedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        where TValue : IComparable
    {
        #region Private Fields

        private IList<KeyValuePair<TKey, TValue>> collection__ = new List<KeyValuePair<TKey, TValue>>();
        private SortOrder sortOrder__ = SortOrder.Ascending;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor, creates the instance with the default value (sorting the values ascending).
        /// </summary>
        public ValueSortedDictionary()
        {
            Resources.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        /// <summary>
        /// Constructor, specifies the sorting order of the values.
        /// </summary>
        /// <param name="_sortOrder">The sorting order. Please see <see cref="SunnyChen.Common.Enumerations.SortOrder"/> enumeration.</param>
        public ValueSortedDictionary(SortOrder _sortOrder)
        {
            sortOrder__ = _sortOrder;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the key-value-pair that has the maximum value in the dictionary.
        /// </summary>
        /// <exception cref="System.IndexOutOfRangeException">Throws when there is nothing in the dictionary.</exception>
        public KeyValuePair<TKey, TValue> MaxValuePair
        {
            get
            {
                if (collection__.Count > 0)
                {
                    switch (sortOrder__)
                    {
                        case SortOrder.Descending:
                            return collection__[0];
                        default:
                            return collection__[collection__.Count - 1];
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException(Resources.EMPTY_DICTIONARY);
                }
            }
        }

        /// <summary>
        /// Gets the key-value-pair that has the minimal value in the dictionary.
        /// </summary>
        /// <exception cref="System.IndexOutOfRangeException">Throws when there is nothing in the dictionary.</exception>
        public KeyValuePair<TKey, TValue> MinValuePair
        {
            get
            {
                if (collection__.Count > 0)
                {
                    switch (sortOrder__)
                    {
                        case SortOrder.Descending:
                            return collection__[collection__.Count - 1];
                        default:
                            return collection__[0];
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException(Resources.EMPTY_DICTIONARY);
                }
            }
        }

        #endregion

        #region IDictionary<TKey,TValue> Members

        /// <summary>
        /// Adds a key-value-pair to the dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(TKey key, TValue value)
        {
            KeyValuePair<TKey, TValue> kvp = new KeyValuePair<TKey, TValue>(key, value);
            this.Add(kvp);
        }

        /// <summary>
        /// Determines if the key exists in the dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>True if the key exists, otherwise false.</returns>
        public bool ContainsKey(TKey key)
        {
            foreach (KeyValuePair<TKey, TValue> kvp in collection__)
            {
                if (kvp.Key.Equals(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the collection of keys.
        /// </summary>
        public ICollection<TKey> Keys
        {
            get
            {
                if (collection__.Count == 0)
                    return null;

                ICollection<TKey> keys = new List<TKey>();
                foreach (KeyValuePair<TKey, TValue> kvp in collection__)
                {
                    keys.Add(kvp.Key);
                }
                return keys;
            }
        }

        /// <summary>
        /// Removes the key-value-pair with a specified key from the dictionary.
        /// </summary>
        /// <param name="key">The key for which the key-value-pair should be removed.</param>
        /// <returns>True if the key-value-pair has been successfully removed, otherwise false.</returns>
        public bool Remove(TKey key)
        {
            foreach (KeyValuePair<TKey, TValue> kvp in collection__)
            {
                if (kvp.Key.Equals(key))
                {
                    collection__.Remove(kvp);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Trying to get the value for a specified key.
        /// </summary>
        /// <param name="key">The specified key.</param>
        /// <param name="value">The value.</param>
        /// <returns>True if successfully get the value, otherwise false.</returns>
        /// <example>
        /// <code>
        /// public void TestValueSortedDictionary()
        /// {
        ///     ValueSortedDictionary&lt;string, int&gt; dictionary = new ValueSortedDictionary&lt;string, int&gt;();
        ///     dictionary.Add("a", 10);
        ///     dictionary.Add("b", 20);
        ///     int val;
        ///     bool ret = dictionary.TryGetValue("a", out val);
        ///     if (ret)
        ///         Console.WriteLine(string.Format("a={0}", val));
        ///     else
        ///         Console.WriteLine("Cannot get the value for key a");
        /// }
        /// </code>
        /// </example>
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            try
            {
                foreach (KeyValuePair<TKey, TValue> kvp in collection__)
                {
                    if (kvp.Key.Equals(key))
                    {
                        value = kvp.Value;
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the collection of values.
        /// </summary>
        public ICollection<TValue> Values
        {
            get
            {
                if (collection__.Count == 0)
                    return null;

                ICollection<TValue> values = new List<TValue>();
                foreach (KeyValuePair<TKey, TValue> item in collection__)
                {
                    values.Add(item.Value);
                }
                return values;
            }
        }

        /// <summary>
        /// Gets or sets the value to the specific key.
        /// </summary>
        /// <param name="key">Name of the key.</param>
        /// <returns>The value of the key-value-pair.</returns>
        /// <exception cref="System.ArgumentException">Throws when trying to get the value of a key but the key doesn't exist.</exception>
        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (this.TryGetValue(key, out value))
                {
                    return value;
                }

                throw new ArgumentException (Resources.VALUE_NOT_FOUND);
            }
            set
            {
                TValue oldValue;
                try
                {
                    oldValue = this[key];
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }

                TValue newValue = value;

                if (newValue.Equals(oldValue))
                    return;

                int oldIndex = collection__.IndexOf(new KeyValuePair<TKey, TValue>(key, oldValue));

                collection__.RemoveAt(oldIndex);
                int i;

                if (collection__.Count == 0)
                {
                    collection__.Insert(0, new KeyValuePair<TKey, TValue>(key, newValue));
                    return;
                }
                switch (sortOrder__)
                {
                    case SortOrder.Ascending:
                        if (newValue.CompareTo(oldValue) < 0)
                        {
                            if (collection__[0].Value.CompareTo(newValue) >= 0)
                            {
                                collection__.Insert(0, new KeyValuePair<TKey, TValue>(key, newValue));
                                //collection__.RemoveAt(oldIndex);
                                return;
                            }
                            for (i = oldIndex; i >= 1; i--)
                            {
                                if (collection__[i].Value.CompareTo(newValue) >= 0 &&
                                    collection__[i - 1].Value.CompareTo(newValue) <= 0)
                                {
                                    collection__.Insert(i, new KeyValuePair<TKey, TValue>(key, newValue));
                                    //collection__.RemoveAt(oldIndex);
                                    return;
                                }
                            }
                        }
                        else 
                        {
                            if (collection__[collection__.Count - 1].Value.CompareTo(newValue) <= 0)
                            {
                                collection__.Insert(collection__.Count, new KeyValuePair<TKey, TValue>(key, newValue));
                                //collection__.RemoveAt(oldIndex);
                                return;
                            }
                            for (i = oldIndex - 1; i <= collection__.Count - 1; i++)
                            {
                                if (collection__[i].Value.CompareTo(newValue) <= 0 &&
                                    collection__[i + 1].Value.CompareTo(newValue) >= 0)
                                {
                                    collection__.Insert(i + 1, new KeyValuePair<TKey, TValue>(key, newValue));
                                    //collection__.RemoveAt(oldIndex);
                                    return;
                                }
                            }
                        }
                        break;
                    case SortOrder.Descending:
                        if (newValue.CompareTo(oldValue) > 0)
                        {
                            if (collection__[0].Value.CompareTo(newValue) <= 0)
                            {
                                collection__.Insert(0, new KeyValuePair<TKey, TValue>(key, newValue));
                                //collection__.RemoveAt(oldIndex);
                                return;
                            }
                            for (i = oldIndex; i >= 1; i--)
                            {
                                if (collection__[i].Value.CompareTo(newValue) <= 0 &&
                                    collection__[i - 1].Value.CompareTo(newValue) >= 0)
                                {
                                    collection__.Insert(i, new KeyValuePair<TKey, TValue>(key, newValue));
                                    //collection__.RemoveAt(oldIndex);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (collection__[collection__.Count - 1].Value.CompareTo(newValue) >= 0)
                            {
                                collection__.Insert(collection__.Count, new KeyValuePair<TKey, TValue>(key, newValue));
                                //collection__.RemoveAt(oldIndex);
                                return;
                            }
                            for (i = oldIndex; i <= collection__.Count - 1; i++)
                            {
                                if (collection__[i].Value.CompareTo(newValue) >= 0 &&
                                    collection__[i + 1].Value.CompareTo(newValue) <= 0)
                                {
                                    collection__.Insert(i + 1, new KeyValuePair<TKey, TValue>(key, newValue));
                                    //collection__.RemoveAt(oldIndex);
                                    return;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        /// <summary>
        /// Adds a key-value-pair to the dictionary.
        /// </summary>
        /// <param name="item">The key-value-pair that is going to be added.</param>
        /// <example>
        /// <code>
        /// public void TestAddKeyValuePair()
        /// {
        ///     ValueSortedDictionary&lt;string, int&gt; dictionary = new ValueSortedDictionary&lt;string, int&gt;();
        ///     KeyValuePair&lt;string, int&gt; item = new KeyValuePair&lt;string, int&gt;("a", 10);
        ///     dictionary.Add(item);
        /// }
        /// </code>
        /// </example>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (this.ContainsKey(item.Key))
            {
                throw new ArgumentException(Resources.KEY_ALREADY_EXISTS);
            }

            if (collection__.Count == 0)
            {
                collection__.Add(item);
                return;
            }

            switch (sortOrder__)
            {
                case SortOrder.Ascending:
                    if (item.Value.CompareTo(collection__[0].Value) <= 0)
                    {
                        collection__.Insert(0, item);
                    }
                    else if (item.Value.CompareTo(collection__[collection__.Count - 1].Value) >= 0)
                    {
                        collection__.Insert(collection__.Count, item);
                    }
                    else
                    {
                        for (int i = 0; i < collection__.Count - 1; i++)
                        {
                            if (item.Value.CompareTo(collection__[i].Value) >= 0 &&
                                item.Value.CompareTo(collection__[i + 1].Value) <= 0)
                            {
                                collection__.Insert(i + 1, item);
                                return;
                            }
                        }
                    }
                    break;
                case SortOrder.Descending:
                    if (item.Value.CompareTo(collection__[0].Value) >=0)
                    {
                        collection__.Insert(0, item);
                    }
                    else if (item.Value.CompareTo(collection__[collection__.Count - 1].Value) <= 0)
                    {
                        collection__.Insert(collection__.Count, item);
                    }
                    else
                    {
                        for (int i = 0; i < collection__.Count - 1; i++)
                        {
                            if (item.Value.CompareTo(collection__[i].Value) <= 0 &&
                                item.Value.CompareTo(collection__[i + 1].Value) >= 0)
                            {
                                collection__.Insert(i + 1, item);
                                return;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Clears all the key-value-pairs in the dictionary.
        /// </summary>
        public void Clear()
        {
            collection__.Clear();
        }

        /// <summary>
        /// Determines if the specified key-value-pair exists in the dictionary.
        /// </summary>
        /// <param name="item">The key-value-pair that needs to be determined.</param>
        /// <returns>True if it exists, otherwise false.</returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            foreach (KeyValuePair<TKey, TValue> kvp in collection__)
            {
                if (kvp.Equals(item))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Copies the key-value-pair to the specific position in the dictionary.
        /// </summary>
        /// <param name="array">The array to which the key-value-pair is copied.</param>
        /// <param name="arrayIndex">The position in the dictionary that is being filled.</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            collection__.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the count of the key-value-pair in the dictionary.
        /// </summary>
        public int Count
        {
            get { return collection__.Count; }
        }

        /// <summary>
        /// Checks if the dictionary is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes a specific key-value-pair from the dictionary.
        /// </summary>
        /// <param name="item">The key-value-pair that is going to be removed.</param>
        /// <returns>True if successfully removed, otherwise false.</returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            foreach (KeyValuePair<TKey, TValue> kvp in collection__)
            {
                if (kvp.Equals(item))
                {
                    collection__.Remove(kvp);
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>The enumerator that iterates through the collection.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return collection__.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return collection__.GetEnumerator();
        }

        #endregion
    }
}
