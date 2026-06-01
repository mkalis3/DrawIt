# QA Notes

## Automated Checks

- GitHub Actions validates repository layout and Unity project metadata.
- `scripts/check_project.py` blocks Unity build output, missing docs, missing tests, and oversized source files.
- EditMode tests cover challenge configuration, timer formatting, and color formatting.

## Manual Smoke Test

Run these checks in Unity 2022.3.0f1:

1. Open the project from Unity Hub.
2. Confirm packages restore without console errors.
3. Open the main gameplay scene.
4. Press Play.
5. Start a round, trace a valid shape, and confirm the pass feedback appears.
6. Move outside the shape and confirm a strike is recorded.
7. Cross the current line and confirm self-intersection creates a strike.
8. Complete enough shapes to advance a challenge.
9. Restart Play Mode and confirm high score and challenge progress persist.

## Coverage To Add Next

- PlayMode tests for menu transitions and challenge progression.
- Scene smoke tests for missing references on `MainScript2`, `DrawLine`, `MouseDrag`, and `End`.
- A small screenshot or gameplay clip in the repository README once visual assets are available.
