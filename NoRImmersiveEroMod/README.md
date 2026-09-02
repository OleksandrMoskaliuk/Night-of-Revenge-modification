# NoR Immersive Ero Mod

A BepInEx plugin for **Night of Revenge** that overhauls combat, pleasure status, elite enemy dynamics, and encounter mechanics for a more challenging and immersive experience.

---

## Features

- **Elite Enemies System**:
  - Chance-based elite spawns with randomized HP multipliers, increased movement/attack speeds, custom color tinting, and boosted EXP yield.
  - Elite enemies can regenerate HP upon hitting the player.
- **Pleasure Status Dynamics**:
  - Scaled damage taken based on current pleasure level.
  - Scaled player attack damage and attack speed based on pleasure level.
  - Passive pleasure decay over time.
- **Enhanced Rape & Down State Mechanics**:
  - Configurable pleasure gain multiplier when a rape scene initiates.
  - Wounded enemies can drain a percentage of the player's current health during cum events.
  - Modified Stamina (SP) regeneration rates while in a knocked-down state.

---

## Prerequisites

- **[BepInEx v5.4.23.5](https://github.com/bepinex/bepinex/releases)**: Requires the **x86 (32-bit)** version for Windows.
- **MMHOOK**: Requires `MMHOOK_Assembly-CSharp.dll` for method hooking.
- **BoneDMod**: Requires `org.bonedhg.plugins.nor_bonedmod` as a hard dependency.

---

## Installation

1. Download and install **BepInEx v5.4.23.5 (x86)** into your game directory.
2. Run the game once to allow BepInEx to generate its folder structure.
3. Place `MMHOOK_Assembly-CSharp.dll` into the `BepInEx/plugins` directory.
4. Place `NoRImmersiveEroMod.dll` into the `BepInEx/plugins` directory.

---

## Configuration

After launching the game once with the mod installed, a configuration file named `NoRImmersiveEroMod.cfg` will be generated in `BepInEx/config/`.

### Config Options

#### Enemies
| Setting | Default | Acceptable Range | Description |
| :--- | :--- | :--- | :--- |
| **SpawnChance** | `0.3` | `0.0 - 1.0` | Chance for an enemy to spawn as an elite. |
| **HPMultiplier (Min)** | `0.5` | `0.1 - 1.0` | Minimum random health multiplier for elite enemies. |
| **HPMultiplier (Max)** | `4.0` | `1.0 - 10.0` | Maximum random health multiplier for elite enemies. |
| **EXPMultiplier** | `4.0` | N/A | Experience multiplier rewarded for killing elites. |
| **SpeedMultiplier** | `1.5` | `0.5 - 1.5` | Movement/attack speed multiplier for elite enemies. |
| **Color** | `#ffffff` | Hex Code | Visual color tint applied to elite enemies. |
| **CanEnemyReganerate** | `true` | `true / false` | Allows enemies to regenerate HP after hitting the player. |
| **EnemyRegenerationMultiplier** | `0.01` | `0.01 - 2.0` | Multiplier for enemy health regeneration on hit. |

#### Pleasure Status
| Setting | Default | Description |
| :--- | :--- | :--- |
| **EnemyAttackMultiplierMin** | `1.0` | Damage multiplier taken by player at **0%** pleasure. |
| **EnemyAttackMultiplierMax** | `2.0` | Damage multiplier taken by player at **100%** pleasure. |
| **PlayerAttackMultiplierMin** | `1.0` | Player attack damage multiplier at **0%** pleasure. |
| **PlayerAttackMultiplierMax** | `0.3` | Player attack damage multiplier at **100%** pleasure. |
| **PlayerAttackSpeedMultiplierMin** | `1.3` | Player attack speed multiplier at **0%** pleasure. |
| **PlayerAttackSpeedMultiplierMax** | `0.7` | Player attack speed multiplier at **100%** pleasure. |
| **pleasureOnRapeGainMultiplier** | `1.0` | Multiplier for pleasure gained when rape starts (`0.1 - 2.0`). |
| **SPRegenOnDownState** | `1.0` | Stamina regeneration multiplier during knockdown (`0.1 - 10.0`). |

#### Rape Mechanics
| Setting | Default | Range | Description |
| :--- | :--- | :--- | :--- |
| **EnemyMinCurrentPlayerHealthDrainOnCum** | `0.1` | `0.1 - 1.0` | Minimum % of player current HP drained when wounded enemy cums (0.1 = 10%). |
| **EnemyMaxCurrentPlayerHealthDrainOnCum** | `0.5` | `0.1 - 1.0` | Maximum % of player current HP drained when wounded enemy cums (0.5 = 50%). |