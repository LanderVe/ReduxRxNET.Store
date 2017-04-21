using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace ReduxRxNET.Store.Tests.Reducers
{
  class ComplexObjectReducer : Reducer<ComplexObjectReducer.ApplicationState>
  {
    public static readonly ApplicationState initialState = new ApplicationState(
      ui: new UIState(isVisible: false),
      data: new DataState(
         entities1: ImmutableSortedDictionary<int, Entitiy1>.Empty,
         entities2: ImmutableSortedDictionary<int, Entitiy2>.Empty
      )
    );

    public override ApplicationState Reduce(ApplicationState state = null, object action = null)
    {
      if (state == null)
        return initialState;

      var toggleVisibilityAction = action as ToggleVisibilityAction;
      if (toggleVisibilityAction != null)
      {
        return new ApplicationState(
          ui: new UIState(isVisible: !state.UI.IsVisible),
          data: state.Data
        );
      }

      var addEntity1Action = action as AddEntity1Action;
      if (addEntity1Action != null)
      {
        var newEntity1 = new Entitiy1(addEntity1Action.Id, addEntity1Action.Value);
        return new ApplicationState(
            ui: state.UI,
            data: new DataState(
              entities1: state.Data.Entities1.Add(addEntity1Action.Id, newEntity1),
              entities2: state.Data.Entities2
            )
          );
      }

      var addEntity2Action = action as AddEntity2Action;
      if (addEntity2Action != null)
      {
        var newEntity2 = new Entitiy2(addEntity2Action.Id, addEntity2Action.Value);
        return new ApplicationState(
            ui: state.UI,
            data: new DataState(
              entities1: state.Data.Entities1,
              entities2: state.Data.Entities2.Add(addEntity2Action.Id, newEntity2)
            )
          );
      }

      return state;
    }

    //actions
    internal class ToggleVisibilityAction { }

    internal class AddEntity1Action
    {
      private readonly int id;
      public int Id => id;
      private readonly string value;
      public string Value => value;

      public AddEntity1Action(int id, string value)
      {
        this.id = id;
        this.value = value;
      }
    }

    internal class AddEntity2Action
    {
      private readonly int id;
      public int Id => id;
      private readonly string value;
      public string Value => value;

      public AddEntity2Action(int id, string value)
      {
        this.id = id;
        this.value = value;
      }
    }

    //object
    internal class ApplicationState
    {
      private readonly UIState ui;
      public UIState UI => ui;

      private readonly DataState data;
      public DataState Data => data;

      public ApplicationState(UIState ui, DataState data)
      {
        this.ui = ui;
        this.data = data;
      }
    }

    internal class UIState
    {
      private readonly bool isVisible;
      public bool IsVisible => isVisible;

      public UIState(bool isVisible)
      {
        this.isVisible = isVisible;
      }
    }

    internal class DataState
    {
      private readonly ImmutableSortedDictionary<int, Entitiy1> entities1;
      public ImmutableSortedDictionary<int, Entitiy1> Entities1 => entities1;

      private readonly ImmutableSortedDictionary<int, Entitiy2> entities2;
      public ImmutableSortedDictionary<int, Entitiy2> Entities2 => entities2;

      public DataState(ImmutableSortedDictionary<int, Entitiy1> entities1, ImmutableSortedDictionary<int, Entitiy2> entities2)
      {
        this.entities1 = entities1;
        this.entities2 = entities2;
      }
    }

    internal class Entitiy1
    {
      private readonly int id;
      public int Id => id;

      private readonly string value;
      public string Value => value;

      public Entitiy1(int id, string value)
      {
        this.id = id;
        this.value = value;
      }
    }

    internal class Entitiy2
    {
      private readonly int id;
      public int Id => id;

      private readonly string value;
      public string Value => value;

      public Entitiy2(int id, string value)
      {
        this.id = id;
        this.value = value;
      }
    }

  }
}
