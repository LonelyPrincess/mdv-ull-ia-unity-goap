# Artificial Inteligence in Videogames: GOAP Simulation

This project contains a simulation developed using the GOAP (a.k.a. _Goal-Oriented Action Planning_) technique in Unity. In this AI technique, multiple agents will make decisions in real-time to satisfy their own goals.

Each individual agent can have a set of goals for different priorities, and a varied range of actions they can perform. A goal can be reached by executing one or more sequences of these actions, and it's the GOAP's behaviour planner which will determine what's the best course of action for each agent based on the current state of the world.

The presented simulation was created for the subject _"Artificial Inteligence in Videogames"_ in the videogame development's degree of the University of La Laguna.

## 🏛 Simulation overview

The presented simulation portrays a battle arena, in which the primary focus is for **warriors** to fight with each other. As part of the staff, we will also encounter **assistants** and **healers**. The first group of people will be in charge of carrying the wounded, while the second will effectively tend to their wounds. Last, but not least, we have a fourth group which are the **audience**, people who pass by to enjoy the show for a while.

There are three main type of shared resources in this simulation, which are the different **arena slots**, the available **seats** on them and also the **beds** to rest. Availability or lack of this resources at a given time will have an impact in how the agents behave, as some actions will require usage of one of them.

The image below illustrates the result of this simulation, where we can see the different agent types interacting with each other and seeking their destinations.

![Preview of the simulation](./Screenshots/simulation-preview.gif)

## 🤖 Agents involved in the simulation

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

### 🔗 References

- [Unity Learn: Introduction to GOAP](https://learn.unity.com/tutorial/an-introduction-to-goap)