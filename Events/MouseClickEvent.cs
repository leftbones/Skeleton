using System.Numerics;
using Raylib_cs;

namespace Skeleton.Events;

public class MouseLeftEvent : Event {
    public Vector2 Position { get; private set; }

    public MouseLeftEvent(Vector2 position) {
        Position = position;
    }
}

public class MouseRightEvent : Event {
    public Vector2 Position { get; private set; }

    public MouseRightEvent(Vector2 position) {
        Position = position;
    }
}
