using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ReduxRxNET.Store.Tests.Reducers
{
  //reducer
  class RaceSensitiveIncrementReducer : Reducer<int>
  {
    public override int Reduce(int state, object action)
    {
      switch (action)
      {
        case IncrementAction incrementAction:
          {
            var temp = state;
            Thread.Sleep(200);
            temp += 1;
            return temp;
          }
        case DecrementAction decrementAction:
          {
            var temp = state;
            Thread.Sleep(200);
            temp -= 1;
            return temp;
          }
        default:
          return state;
      }
    }


    //actions
    internal class IncrementAction { }
    internal class DecrementAction { }
    internal class NonExistingAction { }
  }
}