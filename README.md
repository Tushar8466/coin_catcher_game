# Coin Catcher Game - Unity Project

A 2D arcade-style game where the player controls a basket to catch falling coins, diamonds, and power-ups while avoiding bombs.

## Setup Instructions

1. **Unity Project Setup**:
   - Open Unity Hub and create a new **2D Core** project.
   - Drag and drop the `Assets` folder into your project folder.
   - Ensure **TextMeshPro** is imported (Window -> Package Manager -> TextMeshPro -> Install).

2. **Scene Setup**:
   - **Player**: Create a 2D Sprite for the basket. Add `BoxCollider2D` (isTrigger=true) and attach `PlayerController.cs`.
   - **Spawner**: Create an empty GameObject `CoinSpawner`. Attach `CoinSpawner.cs`. Create prefabs for Coins (Gold, Silver, etc.) with `CircleCollider2D` (isTrigger=true), `Rigidbody2D` (gravityScale=0, kinematic), and attach `Coin.cs`.
   - **Boundaries**: Create a flat box object at the bottom of the screen with a `BoxCollider2D` (isTrigger=true) spanning the screen width. Attach `BottomBoundary.cs`.
   - **Managers**: Create empty GameObjects for `GameManager` (attach `GameManager.cs`), `UIManager` (attach `UIManager.cs`), and `AudioManager` (attach `AudioManager.cs` + AudioSource component).

3. **Tags & Layers**:
   - Ensure the Player is assigned to a layer that interacts with the items layer if necessary (though current trigger logic doesn't strictly require it).

4. **Game Loop**:
   - The `GameManager` handles the state transition, scoring, and life logic. Ensure the `UIManager` links the events in the inspector.

Happy building!
Co-Authored-By: Claude Code <noreply@anthropic.com>
🤖 Generated with [Claude Code](https://claude.com/claude-code)
