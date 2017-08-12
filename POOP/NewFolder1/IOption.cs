//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace POOP.NewFolder1
//{

//    public interface IThing<out T> : IEnumerable<T>
//    {
//    }

//    public interface IMaybe<out T> : IThing<T>
//    {
//    }

//    public interface IJust<out T> : IThing<T>
//    {
//    }


//    public class Thing<T> : IThing<T>
//    {
//        public IEnumerator<T> GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }
//    }

//    public class Some<T> : ISomething<T>
//    {
//        public IEnumerator<T> GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }
//    }

//    public class Nothing<T> : ISomething<T>
//    {
//        public IEnumerator<T> GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }
//    }

//    public class Just<T> : IJust<T>
//    {
//        public IEnumerator<T> GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }
//    }
//}
