
# 🪙 Coin Catcher

A fast, arcade-style 2D coin catching game built in **Unity 6**. Move your basket, catch falling coins and gems, dodge the bombs, and chain catches for a score multiplier of up to 5x.

<!-- Add a screenshot or GIF here after you record one:
![Gameplay](Docs/gameplay.gif)
-->

## Features

- **Smooth basket control** with keyboard (A/D or Left/Right arrows) or optional mouse tracking
- **Screen-bound movement**: the basket is clamped to the camera edges and never leaves the screen
- **Multiple item types**: Gold Coins, Silver Coins, Diamonds, Magnets and Bombs
- **Weighted spawning**: common coins appear often, while diamonds, magnets and bombs show up as rare high-risk, high-reward events
- **Combo multiplier**: consecutive catches boost your score multiplier up to 5x
- **Lives system**: start with 3 lives, and lose one each time you miss a coin
- **Game Over screen** with a restart button
- **Live HUD** showing score and lives (TextMeshPro)
- **Centralized audio manager** for sound effects

## Tech Stack

| | |
|---|---|
| Engine | Unity 6 (6000.x) |
| Language | C# |
| Template | 2D (Universal Render Pipeline) |
| UI | TextMeshPro |

## Controls

| Action | Input |
|---|---|
| Move left | `A` or `←` |
| Move right | `D` or `→` |
| Mouse control | Enable **Use Mouse Control** on the Player |

## Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- Unity 6 editor (the project was built with 6000.6.7f1; a nearby 6000.x version should also work)

### Run the project

1. Clone the repository:
   ```bash
   git clone https://github.com/YOUR-USERNAME/coin-catcher-game.git
   ```
2. Open **Unity Hub** → **Add** → **Add project from disk**, and select the cloned folder.
3. Open the project with Unity 6 and wait for the first import to finish.
4. Open `Assets/Scenes/SampleScene`.
5. Press **Play**.

> **Input setting:** the scripts use the classic `Input` class. If you see an `InvalidOperationException` about input, go to **Edit → Project Settings → Player → Other Settings → Active Input Handling** and set it to **Both**.

## Project Structure

```
Assets/
├── Prefabs/          # Coin prefab(s)
├── Scenes/           # SampleScene
└── Scripts/
    ├── PlayerController.cs   # Basket movement and screen clamping
    ├── Coin.cs               # Falling, spinning, item types, catch events
    ├── CoinSpawner.cs        # Weighted random spawning
    ├── GameManager.cs        # Score, lives, combo multiplier, game state
    ├── UIManager.cs          # HUD and Game Over panel
    ├── AudioManager.cs       # Sound effect playback
    └── BottomBoundary.cs     # Cleans up missed items and registers misses
```

## How the Game Works

| Item | Effect |
|---|---|
| 🟡 Gold Coin | Standard points, appears most often |
| ⚪ Silver Coin | Standard points |
| 💎 Diamond | Large bonus, rare |
| 🧲 Magnet | Power-up, rare |
| 💣 Bomb | Penalty, avoid it |

Missing a coin costs a life. Catching coins back to back increases your combo multiplier, and the multiplier resets when you miss. When lives reach zero the game ends and the Game Over panel appears.

## Scene Setup (for contributors)

If you rebuild the scene from scratch, you need these objects:

1. **Player**: Sprite with a `BoxCollider2D` (Is Trigger), `PlayerController`, and the `Player` tag
2. **CoinSpawner**: Empty object with `CoinSpawner`; add item prefabs to the **Spawn List** with a **Spawn Weight** above 0
3. **BottomBoundary**: Wide, thin trigger `BoxCollider2D` below the screen with `BottomBoundary`
4. **GameManager**: Empty object with `GameManager` (singleton, must exist in the scene)
5. **AudioManager**: Empty object with `AudioManager`
6. **Canvas**: TextMeshPro texts for Score and Lives, plus a Game Over panel (hidden by default) with a Restart button
7. **UIManager**: Empty object with `UIManager`; assign the Score text, Lives text and Game Over panel

Each item prefab needs a `SpriteRenderer`, a `CircleCollider2D` (Is Trigger), a `Rigidbody2D`, and the `Coin` script.

## Roadmap

- [ ] Particle effects and sound effects for catches
- [ ] High score saved between sessions
- [ ] Difficulty that scales over time
- [ ] Touch controls for mobile
- [ ] Main menu and pause screen

## Contributing

Pull requests are welcome. For larger changes, please open an issue first to discuss what you would like to change.

## License

Add a license of your choice (for example [MIT](https://choosealicense.com/licenses/mit/)) and update this section.

---

Made with Unity and C#.
