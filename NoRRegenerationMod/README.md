# NoR Regeneration Mod

A BepInEx plugin for **Night of Revenge** that grants dynamic passive regeneration for HP, MP, SP, and Pleasure status based on character stats and encounter metrics.

---

## Features

**Dynamic Passive Regeneration**: Regenerates HP, SP, MP, and reduces bad status (pleasure) passively.
- **Scaling Sources**: Regeneration rate dynamically scales based on:
  - Player Level
  - Harami / Birth Count
  - Rape Count
  - Total Cum Volume (`NakadashiValue`)
- **Conditional Passive Regeneration**: Active only when idle (not attacking, casting magic, stepping, or acting).
- **Resource Priority & Dependencies**:
  - **HP & Pleasure**: HP regenerates first when depleted. Once HP is full, regeneration shifts to reducing Pleasure (`_BadstatusVal[0]`) provided SP is at least 99% full.
  - **SP & MP**: SP regenerates continuously when below max. Once SP reaches full capacity, remaining regeneration overflows into MP (granting both Mana and Stamina regen bonuses).
- **Mathematical Scaling**: Formula uses a custom logarithmic and square-root growth curve based on player level and experience metrics.
- **Configurable Multiplier**: Global multiplier to scale regeneration rate across all sources.

---

## Detailed Mechanics

### 1. Regeneration Formula (`RegenerationFromSource`)
The base regeneration buff value is calculated using the following mathematical function based on total source metrics:

private float RegenerationFromSource(float source)
        {
            float Regeneration = (float)(0.2f * global::System.Math.Log(0.2 * source + 1.0) *
                (1.0 * global::System.Math.Pow(source, 0.5) + 2.71828182846f) + -1.9 * global::System.Math.Pow(1.0, source) + 1.9) / 25f;
            return Regeneration;
        }

### 2. SP and MP Regeneration Rules
* **SP Regeneration**: When current SP is below maximum, SP recovers over time scaled by total max SP, $Buff$, and delta time.
* **MP Overflow Condition**: MP will **only** regenerate once SP is fully capped. When active, MP receives both Mana and additional Stamina-equivalent recovery speed.

### 3. HP and Pleasure Regeneration Rules
* **HP Regeneration**: Restores health continuously until reaching maximum HP.
* **Pleasure Reduction Condition**: Pleasure status reduces **only** when HP is 100% full **AND** SP is at 99% capacity.

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
| **RegenerationMultiplier** | `1.0` | Global scaling factor applied across all regeneration sources. |
