using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace TicTacToeServer.Other
{
    public class GlobalThreading
    {
        public void StartThreads()
        {

            string @namespace = "TicTacToeServer.Other.Threads";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @namespace
                    select t;
            var list = q.ToList();

            foreach (var obj in list)
            {
                obj.GetConstructor(new Type[] {}).Invoke(new object[] {});
            }
        }
    }
}
