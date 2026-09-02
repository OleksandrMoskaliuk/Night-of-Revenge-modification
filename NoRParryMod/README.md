# NoR Parry Mod

A BepInEx plugin for **Night of Revenge** that improves block and parry mechanics, allowing players to cancel attacks or spell casts into immediate guards and resetting guard timing on parries.

---

## Features

- **Attack & Spell Cancels**: Instantly cancel attack animations and magic casting to immediately enter a guard state.
- **Improved Parry Responsiveness**: Prevents guard break and skip states on parry.
- **Guard Time Reset**: Parrying successfully resets the guard duration, keeping the player safe from incoming damage.

---

## Prerequisites

- **[BepInEx v5.4.23.5](https://github.com/bepinex/bepinex/releases)**: Requires the **x86 (32-bit)** version for Windows. Note: The x64 (64-bit) version is not supported.

---

## Installation

1. Download and install **BepInEx v5.4.23.5 (x86)** into your game directory.
2. Run the game once to allow BepInEx to generate its folder structure.
3. Place `NoRParryMod.dll` into the `BepInEx/plugins` directory.

---

## Configuration

After launching the game once with the mod installed, a configuration file named `NoRParryMod.cfg` will be generated in `BepInEx/config/`.

Open this file in any text editor to customize your block and parry thresholds and timing settings.