# Artificial Inteligence in Videogames: GOAP Simulation

This project contains a simulation using GOAP (a.k.a. _Goal-Oriented Action Planning_), in which multiple agents will make decisions in real-time to satisfy their own goals. More specifically, this simulation has been built by using Unity.

The presented simulation is based on a coliseum.

:memo: TODO

## Agents involved in the simulation

For this simulation, we've defined 4 different types of agents, each one with their own motives and possible actions.

### Warrior

Warriors play a major role in the coliseum, as they'll be the ones to actually engage into fights to entertain the public. Warriors will be split into two different teams, and they'll aim to win as many battles as possible.

#### Actions

#### 1. Go to arena

- Pre-conditions:
    - Free slot for team in arena.
    - Health is full. (?)
- After effects:
    - Reduce amount of free slots for team.
    - Set belief to awaiting opponent.

#### 2. Await for opponent

- Pre-conditions:
    - Other warrior in same arena is awaiting opponent.
- After effects:
    - Set belief to ready to fight.

#### 3. Fight

- Pre-conditions:
    - Ready to fight.
- After effects:
    - Reduce amount of free slots for team.
    - Set belief to ready to fight.

## Additional information

### 🖥️ Project specs

- **Unity:** 2021.3.26f1 Personal
- **Operating System:** Windows 10, 64 bits

### 🎨 Resources

- [Newbie & Friends](https://assetstore.unity.com/packages/3d/characters/newbie-friends-208112)
- [Mega Fantasy Props Pack](https://assetstore.unity.com/packages/3d/environments/fantasy/mega-fantasy-props-pack-87811)
