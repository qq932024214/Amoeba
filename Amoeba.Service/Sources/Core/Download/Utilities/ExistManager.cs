using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Amoeba.Messages;
using Omnius.Base;
using Omnius.Utilities;

namespace Amoeba.Service
{
    sealed class ExistManager
    {
        private Dictionary<Group, GroupManager> _table = new Dictionary<Group, GroupManager>(new ReferenceEqualityComparer());

        private readonly object _lockObject = new object();

        public ExistManager()
        {

        }

        public void Add(Group group)
        {
            lock (_lockObject)
            {
                _table[group] = new GroupManager(group);
            }
        }

        public void Remove(Group group)
        {
            lock (_lockObject)
            {
                _table.Remove(group);
            }
        }

        public void Set(IEnumerable<Hash> hashes, bool state)
        {
            lock (_lockObject)
            {
                foreach (var groupManager in _table.Values)
                {
                    foreach (var hash in hashes)
                    {
                        groupManager.Set(hash, state);
                    }
                }
            }
        }

        public IEnumerable<Hash> GetHashes(Group group, bool state)
        {
            lock (_lockObject)
            {
                if (_table.TryGetValue(group, out var groupManager))
                {
                    return groupManager.GetHashes(state);
                }
                else
                {
                    if (state)
                    {
                        return Enumerable.Empty<Hash>();
                    }
                    else
                    {
                        return group.Hashes;
                    }
                }
            }
        }

        public int GetCount(Group group, bool state)
        {
            lock (_lockObject)
            {
                if (_table.TryGetValue(group, out var groupManager))
                {
                    return groupManager.GetCount(state);
                }
                else
                {
                    if (state)
                    {
                        return 0;
                    }
                    else
                    {
                        return group.Hashes.Count();
                    }
                }
            }
        }

        private class GroupManager
        {
            private BitArray _bitmap;
            private Dictionary<Hash, State> _dic;

            private class State
            {
                public bool IsEnabled { get; set; }
                public int Count { get; set; }
            }

            private const int BitmapSize = 2048;

            public GroupManager(Group group)
            {
                _bitmap = new BitArray(GroupManager.BitmapSize);

                foreach (var key in group.Hashes)
                {
                    _bitmap.Set((key.GetHashCode() & 0x7FFFFFFF) % GroupManager.BitmapSize, true);
                }

                _dic = new Dictionary<Hash, State>();

                foreach (var key in group.Hashes)
                {
                    State info;

                    if (!_dic.TryGetValue(key, out info))
                    {
                        info = new State();
                        info.IsEnabled = false;
                        info.Count = 0;

                        _dic.Add(key, info);
                    }

                    info.Count++;
                }
            }

            public void Set(Hash key, bool state)
            {
                if (!_bitmap.Get((key.GetHashCode() & 0x7FFFFFFF) % GroupManager.BitmapSize)) return;

                State info;
                if (!_dic.TryGetValue(key, out info)) return;

                info.IsEnabled = state;
            }

            public IEnumerable<Hash> GetHashes(bool state)
            {
                var list = new List<Hash>();

                foreach (var (hash, info) in _dic)
                {
                    if (info.IsEnabled == state)
                    {
                        for (int i = 0; i < info.Count; i++)
                        {
                            list.Add(hash);
                        }
                    }
                }

                return list;
            }

            public int GetCount(bool state)
            {
                int sum = 0;

                foreach (var info in _dic.Values)
                {
                    if (info.IsEnabled == state)
                    {
                        sum += info.Count;
                    }
                }

                return sum;
            }
        }
    }
}
