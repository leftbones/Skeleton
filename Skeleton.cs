using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Skeleton;

public class Skeleton {
    public Vector2 WindowSize { get; private set; }
    public List<Container> Containers { get; private set; }
    public Style? GlobalStyle { get; set; }

    public Skeleton(Vector2 window_size, Style? global_style=null) {
        WindowSize = window_size;
        GlobalStyle = global_style;

        Containers = new List<Container>();
    }

    // Add a container to the interface if the contianer isn't already a child of the interface
    public bool AddContainer(Container c) {
        if (Containers.Contains(c))
	        return false;

        c.Parent = this;
        Containers.Add(c);
        return true;
    }

    // Send an event to all children, return true if the event was handled
    public bool HandleEvent(Event e) {
        foreach (var C in Containers) {
            if (C.Active && C.FireEvent(e))
                return true;
	    }

        return false;
    }

    // Update all containers and their elements
    public void Update() {
        // If GlobalStyle is set, make sure it's applied to all children
        if (GlobalStyle is not null) {
			foreach (var C in Containers) {
                // Container
                if (C.Active && !C.IgnoreGlobalStyle && C.Style != GlobalStyle)
                    C.Style = GlobalStyle;

                // Widgets
			    foreach (var W in C.Widgets) {
                    if (!W.IgnoreGlobalStyle && W.Style != GlobalStyle)
                        W.Style = GlobalStyle;
				}
		    }
        }

        // Update all containers and their elements
        foreach (var C in Containers) {
            if (C.Active)
			    C.Update();
        }
    }

    // Draw all containers and their elements
    public void Draw() {
        foreach (var C in Containers) {
            if (C.Active)
			    C.Draw();
	    }
    }
}
