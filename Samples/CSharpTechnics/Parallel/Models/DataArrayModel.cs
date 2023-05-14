using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel.Models
{

    public class DataArrayModel : IEnumerable, IEnumerator
    {
        ArrayList DataList = new ArrayList();
        public void AddData(SampleData data)
        {
            DataList.Add(data);
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        private int CurrPosition = -1;
        public bool MoveNext()
        {
            if (CurrPosition < DataList.Count - 1)
            {
                ++CurrPosition;
                return true;
            }
            return false;
        }

        // (2-2) bool MoveNext()メソッドの実装（★追記）
        public void Reset()
        {
            CurrPosition = -1;
        }

        // (2-3) object Current()メソッドの実装（★追記）
        public object Current
        {
            get
            {
                return DataList[CurrPosition];
            }
        }
    }
}
