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

As stated above, there are 4 different types of agents involved in this simulation, each one with their own motives and possible actions.

In this section we'll go over all of them in more detail, listing their goals and the sequence of actions that need to take place in order to fulfil them.

### ⚔ Warrior

Warriors play a major role in the coliseum, as they'll be the ones to actually engage into fights to entertain the public.

This is the list of their main goals, as well as the sequence of actions that have to transpire to reach them:

#### 1. Fight

- **Pre-conditions**:
    - Warrior is full of stamina
    - There are free arena slots

- **Actions**:
    1. Go to arena (move towards free arena slot)
    2. Get ready to fight (wait for an opponent to show up)
    3. Fight (deal damage during a specific time slot, the one who deals a deathly blow will win)

![Preview of fight action sequence](./Screenshots/fight-flow-preview.gif)

#### 2. Train

- **Pre-conditions**:
    - Warrior is full of stamina

- **Actions**:
    1. Train (go to train spot and remain there)

![Preview of train action sequence](./Screenshots/train-flow-preview.gif)

#### 3. Recover stamina (A)

- **Pre-conditions**:
    - Warrior is exhausted
    - There are free beds

- **Actions**:
    1. Rest (go to bed and spend a while there)

![Preview of rest action sequence](./Screenshots/rest-flow-preview.gif)
#### 3. Recover stamina (B)

- **Pre-conditions**:
    - Warrior is defeated
    - Assistant picked up the warrior

- **Actions**:
    1. Be carried (follow the assistant to assigned bed)
    2. Get healed (get treated by a healer)

![Preview of recover action sequence](./Screenshots/recover-flow-preview.gif)

### 🚑 Assistant

Assistants are part of the staff of the arena, and their aim is to guide the warriors that are defeated to a bed, where they can be taken care of.

This is the list of their goals, as well as the sequence of actions that have to transpire to reach them:

#### 1. Carry the wounded

- **Pre-conditions**:
    - There are free beds
    - There are defeated warriors

- **Actions**:
    1. Patrol (wander around until a defeated warrior is on any area)
    2. Pick up defeated (assign bed to the defeated and go towards him)
    3. Carry defeated (guide wounded towards their bed)

![Preview of carry the wounded action sequence](./Screenshots/carry-wounded-flow-preview.gif)

#### 2. Recover stamina

- **Pre-conditions**:
    - Assistant is exhausted
    - There are free beds

- **Actions**:
    1. Rest (go to bed and spend a while there)

### 🏥 Healer

Healers are responsible of healing warriors that have been defeated, so that they can return to battle again.

This is the list of their goals, as well as the sequence of actions that have to transpire to reach them:

#### 1. Heal the wounded

- **Pre-conditions**:
    - There are warriors awaiting to be healed

- **Actions**:
    1. Patrol (wander around until a defeated warrior is awaiting in bed)
    2. Heal (go towards warrior and restore his health)

![Preview of heal action sequence](./Screenshots/heal-flow-preview.gif)

#### 2. Recover stamina

- **Pre-conditions**:
    - Assistant is exhausted
    - There are free beds

- **Actions**:
    1. Rest (go to bed and spend a while there)

### 🎭 Audience

Audience's only aim is to pass some time of the arena, and then return home.

This is the list of their goals, as well as the sequence of actions that have to transpire to reach them:

#### 1. Get entertained

- **Pre-conditions**:
    - There are available seats

- **Actions**:
    1. Get seat (go towards a free seat)
    2. Watch (remain on the seat for a while looking at the arena)
    3. Go home (return home after having watched for a while)

![Preview of watch arena flow](./Screenshots/watch-flow-preview.gif)

## Additional information

### 🖥️ Project specs

- **Unity:** 2021.3.26f1 Personal
- **Operating System:** Windows 10, 64 bits

### 🎨 Resources

- [Newbie & Friends](https://assetstore.unity.com/packages/3d/characters/newbie-friends-208112)
- [Mega Fantasy Props Pack](https://assetstore.unity.com/packages/3d/environments/fantasy/mega-fantasy-props-pack-87811)

### 🔗 References

- [Unity Learn: Introduction to GOAP](https://learn.unity.com/tutorial/an-introduction-to-goap)