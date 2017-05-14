using System;
using System.Collections.Generic;
using System.Text;

namespace ReduxRxNET.Store.Tests.Reducers
{
  //reducer
  class IncrementObjectReducer : Reducer<IncrementObjectReducer.Counter>
  {
    public override Counter Reduce(Counter state, object action)
    {
      switch (action)
      {
        case IncrementAction incrementAction:
          return new Counter(state.Value + 1);
        case DecrementAction decrementAction:
          return new Counter(state.Value - 1);
        default:
          return state;
      }
    }

    //actions
    internal class IncrementAction { }
    internal class DecrementAction { }
    internal class NonExistingAction { }

    //object
    internal class Counter
    {
      public int Value { get; private set; }

      public Counter(int value)
      {
        Value = value;
      }
    }

  }
}
