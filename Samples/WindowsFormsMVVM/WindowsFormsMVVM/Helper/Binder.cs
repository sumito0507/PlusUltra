using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVVM
{
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows.Forms;
    /// <summary>
    /// コントロールとデータとのバインドを容易にします。
    /// </summary>
    public static class Binder
    {
        public static void Bind<T, U>(Expression<Func<T>> item1, Expression<Func<U>> item2)
        {
            Tuple<object, string> ResolveLambda<V>(Expression<Func<V>> expression)
            {
                var lambda = expression as LambdaExpression;
                if (lambda == null) throw new ArgumentException();
                var property = lambda.Body as MemberExpression;
                if (property == null) throw new ArgumentException();
                var members = new List<MemberInfo>();
                var parent = property.Expression;
                return new Tuple<object, string>(Expression.Lambda(parent).Compile().DynamicInvoke(), property.Member.Name);
            }
            var tuple1 = ResolveLambda(item1);
            var tuple2 = ResolveLambda(item2);
            var control = tuple1.Item1 as Control;
            if (control == null) throw new ArgumentException();
            control.DataBindings.Add(new Binding(tuple1.Item2, tuple2.Item1, tuple2.Item2));
        }

        public static void Bind(this Button button, Command command)
        {
            Bind(() => button.Enabled, () => command.CanExecute);
            button.Click += (sender, args) => command.Execute();
        }

        public static void Bind<T>(this Label label, Expression<Func<T>> expression)
        {
            Bind(() => label.Text, expression);
        }
    }
}
