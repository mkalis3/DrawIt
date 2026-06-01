# Architecture

DrawIt is a Unity shape-tracing puzzle game. The scene-facing components keep their Unity class names, while gameplay behavior is grouped into focused partial files and small tested services.

## Runtime Flow

1. `MainScript2` initializes scene references, challenge state, score state, and the opening sequence.
2. `MainScriptGameLoop` coordinates the menu transition, active drawing phase, pass feedback, strike feedback, and game-over transition.
3. `DrawLine` owns line rendering, boundary checks, path tracking, and self-intersection validation.
4. `MouseDrag` translates pointer movement into pen movement.
5. `End` detects the finish-point collision and completes the current shape.

## Source Layout

- `MainScript2.cs` - component identity and shared game state.
- `MainScriptParts` - lifecycle, game loop, scoring, challenge flow, shapes, menus, and utilities.
- `DrawLine.cs` - component identity and shared drawing state.
- `DrawLineParts` - setup, drawing loop, pass/strike flow, geometry, and utilities.
- `Services` - challenge catalog, timer formatting, and color formatting.
- `Tests/EditMode` - service and utility tests.

## Testable Rules

- Challenge copy and target scores live in `ChallengeCatalog`.
- Timer text lives in `GameClock`.
- Color hex formatting lives in `ColorHex`.
- Self-intersection validation is isolated under `DrawLineGeometry`.
