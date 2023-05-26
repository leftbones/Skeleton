using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.TraceLogLevel;

using Skeleton.Widgets;
using Skeleton.Events;

namespace Skeleton;

class Program {
    static void Main(string[] args) {
        ////
        // Setup
        var WindowSize = new Vector2(1280, 720);

        SetTraceLogLevel(LOG_WARNING | LOG_ERROR | LOG_FATAL);
        InitWindow((int)WindowSize.X, (int)WindowSize.Y, "Skeleton Test");
        SetTargetFPS(144);

        var Skeleton = new Skeleton(WindowSize);
        var Container1 = new Container(
            position: new Vector2(10.0f, 10.0f),
            size: new Vector2(400.0f, 250.0f)
        );

        Container1.MatchContentSize = true;

        int LabelCount = 0;
        var Button1 = new Button("Do not click this button!", () => {
            LabelCount++;
            Console.WriteLine($"Button has been clicked {LabelCount} times!");
            var NewLabel = new Label($"Label #{LabelCount}");
            Container1.AddWidget(NewLabel);
        });

        var Button2 = new Button("Click to erase history", () => {
            LabelCount = 0;
            for (int i = Container1.Widgets.Count() - 1; i >= 0; i--) {
                var W = Container1.Widgets[i];
                if (W is Label)
                    Container1.Widgets.Remove(W);
	        }
        });

        Button1.Padding = 40;
        Button2.Padding = 40;

        Container1.AddWidget(Button1);
        Container1.AddWidget(Button2);

        Skeleton.AddContainer(Container1);

        ////
        // Main Loop
        while (!WindowShouldClose()) {
            // Input
            if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) {
                var Event = new MouseLeftEvent(GetMousePosition());
                Skeleton.HandleEvent(Event);
	        }

            float MouseWheel = GetMouseWheelMove();
            if (MouseWheel != 0.0f) {
                var Event = new MouseWheelEvent(MouseWheel);
                Skeleton.HandleEvent(Event);
	        }

            // Update
            Skeleton.Update();

            // Draw
            BeginDrawing();
            ClearBackground(Color.GRAY);
            Skeleton.Draw();
            EndDrawing();
	    }

        ////
        // Exit
        CloseWindow();
    }
}
