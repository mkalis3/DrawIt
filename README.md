DrawIt

A 2D shape-tracing puzzle game built with Unity (C#). Players drag a pen along the outline of randomized shapes, staying within bounds to score points across 20 progressive challenges.

Built for Android and Windows.

Art assets, fonts, 3D models, and audio are excluded from this repository to keep it lightweight. This repo contains the full game source code, project configuration, and build settings.


Features

- 9 unique shapes with randomized selection each round
- 20 challenge levels with 5 distinct challenge types:
    Score targets - reach a specific score (Challenges 1, 4, 8, 13)
    Timed runs - hit the target before time expires (Challenges 2, 10, 14)
    No-strike mode - any mistake ends the game (Challenges 6, 9, 16, 19)
    No-lift mode - continuous drawing required, lifting = instant fail (Challenges 7, 11, 17, 20)
    Same-shape repetition - draw the same shape N times (Challenges 3, 5, 12, 15, 18)
- Physics2D raycast validation - pen must stay within shape boundaries
- Line self-intersection detection - crossing your own line triggers a strike
- Grid-based coverage tracking - 10x10 zone division for shape validation
- 3-strike system - visual feedback per strike, game over on 3rd
- High score persistence via PlayerPrefs
- Challenge progression saved across sessions
- Book-opening menu animation with camera zoom and page-flip transitions
- Countdown timer for timed challenges
- 16:9 aspect ratio enforcement with letterbox/pillarbox
- Opening video cutscene on first launch (Android/Windows builds)
- Cross-platform input - touch (Android) and mouse (Windows)


Tech Stack

Engine: Unity 2022.3.0f1 (LTS)
Language: C#
Platforms: Android, Windows
Physics: Physics2D raycasting for boundary validation
Rendering: LineRenderer for real-time drawing
UI: Unity Canvas + TextMeshPro
Animation: Animator controllers for menu transitions


Architecture

Assets/Scripts/

MainScript2.cs - Game manager (1000 lines)
  State machine with 6 stages:
    0: Menu (book closed)
    1: Shape fade-in animation
    2: Active drawing phase
    3: Strike feedback (fade out)
    4: Game over, close book, return to menu
    5: Pass feedback (fade out)
  Challenge system (20 levels, 5 types)
  Score tracking, high score persistence
  Shape selection, pen/endpoint positioning
  Aspect ratio enforcement

DrawLine.cs - Line rendering + drawing validation (577 lines)
  LineRenderer management (real-time path drawing)
  Physics2D.Raycast boundary checking
  Line self-intersection detection
  Grid-based shape coverage (10x10 zones)
  Platform-specific input (touch vs mouse)
  CanvasScaler-aware coordinate conversion

MouseDrag.cs - Pen input handler (68 lines)
  Screen-to-world coordinate translation
  Drag delta tracking for pen movement
  CanvasScaler compensation for scaling

End.cs - Finish-point collision (21 lines)
  Detects pen reaching the endpoint
  Triggers DrawLine.Pass(), awards points


How Drawing Validation Works

The game uses a layered validation approach:

1. Boundary checking: On each frame while drawing, a Physics2D.Raycast fires from the pen position downward. If it doesn't hit the shape's PolygonCollider2D, the pen is out of bounds and triggers a strike.

2. Line self-intersection: Each new line segment is tested against all previous segments using bounding-box overlap detection. Crossing your own path is flagged.

3. Coverage tracking: The shape bounding box is divided into a 10x10 grid. As the pen moves, it marks which X and Y zones it has visited. This was designed for "draw enough of the shape" validation.

4. Endpoint collision: The finish point has a BoxCollider. When the pen's collider overlaps it, End.cs fires OnCollisionEnter which calls DrawLine.Pass() and the score is awarded.


State Machine Flow

Menu -> Play -> Shape Fade-in -> Drawing Phase

From Drawing Phase:
  Strike -> Fade + New Shape -> If 3 strikes -> Game Over -> Close Book -> Menu
  Reach End -> Pass -> Challenge Check
  Time Out -> Strike -> If 3 strikes -> Game Over -> Close Book -> Menu


Challenge System

Challenge 1: Score - Reach 2 points
Challenge 2: Timed - Score 2 in 40 seconds
Challenge 3: Repeat - Same shape 2 times
Challenge 4: Score - Reach 5 points
Challenge 5: Repeat - Same shape 5 times
Challenge 6: No-strike - Score 3 with zero strikes
Challenge 7: No-lift - Score 2 without lifting finger
Challenge 8: Score - Reach 10 points
Challenge 9: No-strike - Score 5 with zero strikes
Challenge 10: Timed - Score 12 in 500 seconds
Challenge 11: No-lift - Score 8 without lifting finger
Challenge 12: Repeat - Same shape 10 times
Challenge 13: Score - Reach 20 points
Challenge 14: Timed - Score 20 in 800 seconds
Challenge 15: Repeat - Same shape 15 times
Challenge 16: No-strike - Score 10 with zero strikes
Challenge 17: No-lift - Score 12 without lifting finger
Challenge 18: Repeat - Same shape 20 times
Challenge 19: No-strike - Score 15 with zero strikes
Challenge 20: No-lift - Score 15 without lifting finger


Setup

Prerequisites:
- Unity 2022.3.0f1 (LTS) or compatible 2022.3.x
- Android SDK for mobile builds

Running Locally:
1. Clone the repo
2. Open in Unity Hub
3. Import your art/audio assets into Assets/
4. Open Assets/scene2save.unity
5. Hit Play

The game runs without art assets. Shapes will show as missing sprites, but all logic, physics, and state management work.

Building:
Android: File, Build Settings, Android, Switch Platform, Build
Windows: File, Build Settings, PC Mac and Linux, Build


License

MIT License. See LICENSE for details.