from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]

REQUIRED_PATHS = [
    "README.md",
    "LICENSE",
    ".editorconfig",
    ".gitattributes",
    "docs/ARCHITECTURE.md",
    "docs/QA.md",
    "Packages/manifest.json",
    "Packages/packages-lock.json",
    "ProjectSettings/ProjectVersion.txt",
    "Assets/Scripts/MainScript2.cs",
    "Assets/Scripts/MainScriptParts/MainScriptLifecycle.cs",
    "Assets/Scripts/MainScriptParts/MainScriptGameLoop.cs",
    "Assets/Scripts/MainScriptParts/MainScriptChallenges.cs",
    "Assets/Scripts/MainScriptParts/MainScriptScoring.cs",
    "Assets/Scripts/MainScriptParts/MainScriptShapes.cs",
    "Assets/Scripts/MainScriptParts/MainScriptMenu.cs",
    "Assets/Scripts/MainScriptParts/MainScriptUtilities.cs",
    "Assets/Scripts/DrawLine.cs",
    "Assets/Scripts/DrawLineParts/DrawLineSetup.cs",
    "Assets/Scripts/DrawLineParts/DrawLineLoop.cs",
    "Assets/Scripts/DrawLineParts/DrawLineFlow.cs",
    "Assets/Scripts/DrawLineParts/DrawLineGeometry.cs",
    "Assets/Scripts/DrawLineParts/DrawLineUtilities.cs",
    "Assets/Scripts/Services/ChallengeCatalog.cs",
    "Assets/Scripts/Services/ColorHex.cs",
    "Assets/Scripts/Services/GameClock.cs",
    "Assets/Tests/EditMode/ChallengeCatalogTests.cs",
    "Assets/Tests/EditMode/ColorUtilityTests.cs",
    "Assets/Tests/EditMode/GameClockTests.cs",
]

FORBIDDEN_PATHS = [
    "Library",
    "Temp",
    "Obj",
    "Build",
    "Builds",
    "Logs",
    "UserSettings",
]

LINE_LIMITS = {
    "Assets/Scripts/MainScript2.cs": 80,
    "Assets/Scripts/DrawLine.cs": 80,
    "Assets/Scripts/MainScriptParts/MainScriptLifecycle.cs": 140,
    "Assets/Scripts/MainScriptParts/MainScriptGameLoop.cs": 220,
    "Assets/Scripts/MainScriptParts/MainScriptChallenges.cs": 80,
    "Assets/Scripts/MainScriptParts/MainScriptScoring.cs": 160,
    "Assets/Scripts/MainScriptParts/MainScriptShapes.cs": 320,
    "Assets/Scripts/MainScriptParts/MainScriptMenu.cs": 80,
    "Assets/Scripts/MainScriptParts/MainScriptUtilities.cs": 120,
    "Assets/Scripts/DrawLineParts/DrawLineSetup.cs": 100,
    "Assets/Scripts/DrawLineParts/DrawLineLoop.cs": 220,
    "Assets/Scripts/DrawLineParts/DrawLineFlow.cs": 140,
    "Assets/Scripts/DrawLineParts/DrawLineGeometry.cs": 90,
    "Assets/Scripts/DrawLineParts/DrawLineUtilities.cs": 60,
    "Assets/Scripts/Services/ChallengeCatalog.cs": 90,
}


def fail(message):
    print(message)
    return 1


def has_comment_syntax(text):
    in_string = False
    in_char = False
    i = 0
    while i < len(text) - 1:
        current = text[i]
        next_char = text[i + 1]

        if in_string:
            if current == "\\":
                i += 2
                continue
            if current == '"':
                in_string = False
        elif in_char:
            if current == "\\":
                i += 2
                continue
            if current == "'":
                in_char = False
        else:
            if current == '"':
                in_string = True
            elif current == "'":
                in_char = True
            elif current == "/" and next_char in {"/", "*"}:
                return True

        i += 1

    return False


def main():
    for relative_path in REQUIRED_PATHS:
        if not (ROOT / relative_path).exists():
            return fail(f"Missing required path: {relative_path}")

    for relative_path in FORBIDDEN_PATHS:
        if (ROOT / relative_path).exists():
            return fail(f"Unity output folder should not be committed: {relative_path}")

    for relative_path, max_lines in LINE_LIMITS.items():
        path = ROOT / relative_path
        line_count = len(path.read_text(encoding="utf-8", errors="ignore").splitlines())
        if line_count > max_lines:
            return fail(f"{relative_path} has {line_count} lines; limit is {max_lines}")

    for path in (ROOT / "Assets" / "Scripts").rglob("*.cs"):
        text = path.read_text(encoding="utf-8", errors="ignore")
        if has_comment_syntax(text):
            return fail(f"Comment syntax found in {path.relative_to(ROOT)}")

    return 0


if __name__ == "__main__":
    sys.exit(main())
