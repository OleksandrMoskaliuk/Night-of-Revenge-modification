# NoR Elite Enemies Mod

A BepInEx plugin for **Night of Revenge** that introduces elite enemies with enhanced health, increased experience rewards, and custom tinting options.

---

## Features

- **Dynamic Elite Spawning**: Chance-based elite enemy spawns configured via percentage.
- **Level-Scaled Health**: Elite health scales dynamically based on the player's level and a customizable multiplier.
- **Increased Experience**: Defeating elite enemies yields extra experience points on top of base rewards.
- **Custom Visuals**: Elite enemies feature customizable color tinting.

---

## Prerequisites

- **[BepInEx v5.4.23.5](https://github.com/bepinex/bepinex/releases)**: Requires the **x86 (32-bit)** version for Windows. Note: The x64 (64-bit) version is not supported.

---

## Installation

1. Download and install **BepInEx v5.4.23.5 (x86)** into your game directory.
2. Run the game once to allow BepInEx to generate its folder structure.
3. Place `NoREliteEnemies.dll` into the `BepInEx/plugins` directory.

---

## Configuration

After launching the game once with the mod installed, a configuration file named `NoREliteEnemiesMod.cfg` will be generated in `BepInEx/config/`.

### Config Options

| Setting | Default | Description |
| :--- | :--- | :--- |
| **EliteSpawnChance** | `0.2` | Chance for an enemy to spawn as an elite (`0.0` = 0%, `1.0` = 100%). |
| **EliteHPMult** | `1.0` | Health multiplier for elite enemies, scaling with player level. |
| **EliteXpMult** | `1.5` | Experience multiplier rewarded for killing elite enemies. |
| **Color** | `#ffffff` | Hex color tint applied to elite enemies. |