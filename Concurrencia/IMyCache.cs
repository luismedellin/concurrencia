using System.Collections.Generic;

namespace Concurrencia.Console
{
    public interface IMyCache
    {
        int Length();
        void Add(KeyValuePair<int, int> keyItem);
        int Get(int key);
    }
}