# NoR_BerserkMode

## Features

- **Berserk Mode**: Dynamically boosts player stats as health drops, using linear scaling from 1.0 at full health up to maximum multipliers at 0% health.
  - Increased stamina regeneration (scales at low stamina).
  - Increased attack speed and damage dealt.
  - Increased damage resistance.
  - Increased dash range.
  - **Pleasure Reduction on Hit**: Successful attacks reduce pleasure buildup on the pleasure bar, helping prevent heroine immobilization.
- **Configurable Settings**: Custom multiplier values and scaling limits can be adjusted via the configuration file after launching the game once.

## Prerequisites

- **[BepInEx v5.4.23.5](https://github.com/bepinex/bepinex/releases)**: Requires the **x86 (32-bit)** version for Windows. Note: The x64 (64-bit) version is not supported.

## Installation

1. Download and install **BepInEx v5.4.23.5 (x86)** into your game directory.
2. Run the game once to allow BepInEx to generate its folder structure.
3. Place `NoRBerserkMod.dll` into the `BepInEx/plugins` directory.

## Configuration

- After launching the game with the mod installed, a configuration file named `NoRBerserkMod.cfg` will be generated in:
  `BepInEx/config/NoRBerserkMod.cfg`
- Open this file in any text editor to modify the multipliers and stat thresholds to your preference.