# DrawIt

DrawIt is a Unity shape-tracing puzzle game. Players guide a pen around randomized outlines, avoid leaving the shape boundary, and complete progressive challenge objectives.

This repository contains the C# gameplay source, Unity project settings, package manifest, EditMode tests, and repository checks. Art, fonts, audio, and store assets are kept outside the repository.

## Features

- Shape-tracing gameplay with randomized round selection
- Twenty challenge objectives across score, timed, no-strike, no-lift, and repeat-shape modes
- Physics2D boundary validation while drawing
- Line self-intersection detection
- Three-strike game-over flow with pass and fail feedback
- Saved high score and challenge progress through PlayerPrefs
- Camera aspect handling for 16:9 layouts
- Android touch input and Windows mouse input

## Tech Stack

- Unity 2022.3.0f1
- C#
- Unity UI
- Physics2D
- LineRenderer
- Unity Test Framework

## Project Structure

```text
Assets/
  Scripts/
    MainScript2.cs
    MainScriptParts/
    DrawLine.cs
    DrawLineParts/
    Services/
    MouseDrag.cs
    End.cs
  Tests/
    EditMode/
docs/
Packages/
ProjectSettings/
```

## Architecture

The gameplay code is organized around scene-facing Unity components and tested service classes.

- `MainScript2` manages game state, scoring, challenge progress, menu flow, and shape selection.
- `DrawLine` manages drawing input, line rendering, boundary checks, and self-intersection validation.
- `ChallengeCatalog`, `GameClock`, and `ColorHex` hold small rules that are covered by EditMode tests.

More detail is available in [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md).

## Running Locally

1. Open the repository in Unity Hub with Unity 2022.3.0f1 or a compatible 2022.3 LTS editor.
2. Let Unity restore packages from `Packages/manifest.json`.
3. Open the gameplay scene used by the project.
4. Press Play in the editor.

## Tests and Checks

- Run EditMode tests from Unity Test Runner.
- Run `python scripts/check_project.py` for repository checks.
- GitHub Actions runs the repository checks on push and pull request.

Manual QA coverage is listed in [`docs/QA.md`](docs/QA.md).

## License

MIT License. See [`LICENSE`](LICENSE).
