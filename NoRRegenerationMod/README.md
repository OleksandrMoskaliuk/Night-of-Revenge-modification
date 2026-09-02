# NoR Regeneration Mod

A BepInEx plugin for **Night of Revenge** that grants passive HP, MP, SP, and pleasure status regeneration based on player level, birth count, rape count, and total cum volume.

---

## Features

- **Dynamic Passive Regeneration**: Regenerates HP, SP, MP, and reduces bad status (pleasure) passively during out-of-combat/idle states.
- **Scaling Sources**: Regeneration rate dynamically scales based on:
  - Player Level
  - Harami / Birth Count
  - Rape Count
  - Total Cum Volume (`NakadashiValue`)
- **Exponential Curve**: Formula utilizes logarithmic and power scaling so regeneration grows as the heroine overcomes difficult encounters.
- **Configurable Multiplier**: Easily scale overall regeneration strength via the configuration file.

---

## Prerequisites

- **[BepInEx v5.4.23.5](https://github.com/bepinex/bepinex/releases)**: Requires the **x86 (32-bit)** version for Windows. Note: The x64 (64-bit) version is not supported.

---

## Installation

1. Download and install **BepInEx v5.4.23.5 (x86)** into your game directory.
2. Run the game once to allow BepInEx to generate its folder structure.
3. Place `NoRregeneration.dll` into the `BepInEx/plugins` directory.

---

## Configuration

After launching the game once with the mod installed, a configuration file named `NoRregeneration.cfg` will be generated in `BepInEx/config/`.

### Config Options

| Setting | Default | Description |
| :--- | :--- | :--- |
| **RegenerationMultiplier** | `1.0` | Global multiplier affecting regeneration scaling from all sources (Level, Birth Count, Rape Count, Cum Volume). |
