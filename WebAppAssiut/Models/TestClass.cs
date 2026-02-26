using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net.Security;

namespace WebAppAssiut.Models
{
    public class TestClass
    {
        object _viewData;
        //Full Property
        public object ViewData
        {
            set { _viewData = value; }
            get { return _viewData; }
        }
        public dynamic ViewBag
        {
            set { _viewData = value; }
            get { return _viewData; }
        }



        public void Sum(int x, int y)
        {
            Parent<int> obj = new();//Close
            Parent<Student> obj2 = new();//Close
            Parent<string> obj3 = new();//Close
            Child1<Student> obj4 = new();
            Child2 obj5 = new();
            //
        }
        public void Test()
        {
            //dynamic datatype parmeter list - ReturnStatementSyntax type
            dynamic obj = new Student();
            obj.sdhskfhsdk = "skjsdkf";

            dynamic val = 10;
            dynamic msg = "hello";
            msg = obj + val; //detect type runtime





            int a = 10;
            int b = 20;
            int h = 10, n = 20;
            Sum(a, b);
            Sum(h, n);
        }
    }

    public class Parent<T>
    {
        public T Model { get; set; }
    }

    public class Child1<T> : Parent<T>
    {

    }

    public class Child2 : Parent<int>
    {
        public void MEthodd()
        {
            TestClass t = new TestClass();
            string str = t.ViewData.ToString();
            int x = t.ViewBag;
        }
    }

}
