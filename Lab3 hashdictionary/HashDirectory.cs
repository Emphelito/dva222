using System.Collections;


namespace Lab3
{
    public class HashDirectory<K, V> : IDictionary<K, V>
    {
        public K key; public V value;
        public bool IsReadOnly { get; } //No clue what this does
        public int Count { get { return _count; } } //Returns nr of elements in table

        private int _count = 0; //Used with Count to return nr of elements, incremented in add like functions, decrement in remove like functions
        private const int capacity = 32; //arbitrary size of list(amount of buckets)
        internal LinkedList<KeyValuePair<K, V>>[] _entries; //List for buckets
        public HashDirectory()
        {
            _entries = new LinkedList<KeyValuePair<K, V>>[capacity]; //initializing list
        }
        private int GetBucketIndex(K key)
        {
            int index = key.GetHashCode() % _entries.Length; // ex. 33(key) % 32(Length) = 1
            return index;
        }
        public ICollection<K> Keys
        {
            get
            {
                List<K> keys = new List<K>(_count);

                // iterate over all buckets and add all keys to the list
                for (int i = 0; i < _entries.Length; i++)
                {
                    if (_entries[i] != null)
                    {
                        foreach (KeyValuePair<K, V> pair in _entries[i])
                        {
                            keys.Add(pair.Key);
                        }
                    }
                }

                return keys; //Returns list of keys
            }
        }

        public ICollection<V> Values
        {
            get
            {
                List<V> values = new List<V>(_count);

                // iterate over all buckets and add all values to the list
                for (int i = 0; i < _entries.Length; i++)
                {
                    if (_entries[i] != null)
                    {
                        foreach (KeyValuePair<K, V> pair in _entries[i])
                        {
                            values.Add(pair.Value);
                        }
                    }
                }

                return values; //Returns list of values
            }
        }
        public V this[K key]
        {
            get
            {
                int index = GetBucketIndex(key);
                var entry = _entries[index];
                if (entry != null)
                {
                    foreach (var pair in entry)
                    {
                        if (pair.Key.Equals(key))
                        {
                            return pair.Value; //Returns the value of the key
                        }
                    }
                }
                throw new ArgumentException(key + " could not be located"); //Throws an exception if key does not exist
            }
            set
            {
                int index = GetBucketIndex(key);
                if (_entries[index] == null)
                {
                    _entries[index] = new LinkedList<KeyValuePair<K, V>>();
                }
                var entry = _entries[index];
                foreach (var pair in entry)
                {
                    if (pair.Key.Equals(key)) //Checks for equality
                    {
                        entry.Remove(pair); //Removes old value
                        entry.AddLast(new KeyValuePair<K, V>(key, value)); //Adds new value
                        return;
                    }
                }
                entry.AddLast(new KeyValuePair<K, V>(key, value));
                _count++; //Forgot to add this, took me hours to solve it........
            }
        }
        public void Add(K key, V value)
        {
            int index = GetBucketIndex(key); //Get index(hash) from function 
            if (_entries[index] == null)
            {
                _entries[index] = new LinkedList<KeyValuePair<K, V>>(); //If bucket is empty initalize new list in bucket
            }
            var entry = _entries[index];
            foreach (var pair in entry) //Loops through pairs in bucket
            {
                if (pair.Key.Equals(key)) //Check if provided Key equals an already existing key at given index
                {
                    throw new ArgumentException("Key already exists"); //Might be able to just return, looks fancier.
                }
            }
            entry.AddLast(new KeyValuePair<K, V>(key, value)); //Adds to last pos in linked list
            _count++;
        }
        public void Add(KeyValuePair<K, V> item)
        {
            Add(item.Key, item.Value); //Reusing other Add()
        }
        public bool Contains(KeyValuePair<K, V> item) //Could maybe reuse ContainsKey() for this function
        {
            int index = GetBucketIndex(item.Key); //Get index using hashing function
            var entry = _entries[index]; //assign bucket to var entry

            if (entry != null)
            {
                foreach (var pair in entry)
                {
                    if (pair.Equals(item)) return true; //If they equal each other return true
                }
            }
            return false;
        }
        public bool ContainsKey(K key)
        {
            int index = GetBucketIndex(key);
            var entry = _entries[index];

            if (entry != null)
            {
                foreach (var pair in entry)
                {
                    if (pair.Key.Equals(key)) return true;
                }
            }
            return false;
        }
        public bool TryGetValue(K key, out V value)
        {
            int index = GetBucketIndex(key);
            var entry = _entries[index];

            if (entry != null)
            {
                foreach (var pair in entry) //looping through bucket on "int index"
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }
            value = default(V); //Depends on what value is ex, string,int,double,object.
            return false;
        }
        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            lab3Enumerator<K, V> enumerator = new lab3Enumerator<K, V>(this); //Used to add all elements to the array
            if (array == null) throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("Starting array index has to 0 or greater"); //Index less then 0
            if (array.Length - arrayIndex < _count) throw new ArgumentException("Not enough room in array"); //if the space from index to the end of array is less then _count

            while (enumerator.MoveNext()) //Moves to next element
            {
                array[arrayIndex++] = enumerator.Current; //Copys to array
            }
        }

        public void Clear()
        {
            Array.Clear(_entries, 0, _entries.Length); //Using array.Clear to clear the entire list
            _count = 0; //Reset count
        }
        public bool Remove(K key)
        {
            int index = GetBucketIndex(key);
            var entry = _entries[index];

            if (entry != null)
            {
                foreach (var pair in entry)
                {
                    if (pair.Key.Equals(key))
                    {
                        entry.Remove(pair); //removes pair
                        _count--; //Removes 1 from count
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Remove(KeyValuePair<K, V> item)
        {
            return Remove(item.Key); //Reusing other remove, similar to what i did in Add()
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return new lab3Enumerator<K, V>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new lab3Enumerator<K, V>(this);
        }
    }
    public class lab3Enumerator<K, V> : IEnumerator<KeyValuePair<K, V>>
    {
        private readonly HashDirectory<K, V> _hd; //Used as a tmp placeholder for hashDirectory
        private readonly List<KeyValuePair<K, V>> kvp; //List to store all KeyValuePairs in
        private int _index = -1; //-1 because when MoveNext is called the index shifts 1 place to 0, not very elegant

        public lab3Enumerator(HashDirectory<K, V> hd)
        {
            _hd = hd; //hd = hashDirectory when called "this" is used
            kvp = new List<KeyValuePair<K, V>>();

            foreach (var entry in _hd._entries) //every bucket in hashdirectory
            {
                if (entry != null)
                {
                    foreach (var pair in entry) //every pair in bucket
                    {
                        kvp.Add(pair); //Add every pair in bucket to list
                    }
                }
            }
        }

        public KeyValuePair<K, V> Current
        {
            get { return kvp[_index]; }
        }

        object IEnumerator.Current
        {
            get { return Current; } //Current element
        }

        public void Dispose() { } //Did not need to add this

        public bool MoveNext()
        {
            _index++;
            return _index < kvp.Count; //True or false is returned depending on if _index is less then kvp.Count or more/equal
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}


