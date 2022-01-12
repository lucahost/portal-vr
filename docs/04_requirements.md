# Requirements

## Functional Requirements

### REQ-0X - Starting / Ending

This is all about starting a new game and ending the app / game

#### REQ-01 - App Start

|                           |                                                                                       |
| ------------------------: | :------------------------------------------------------------------------------------ |
|                **Target** | If the app is installed on the Oculus Quest 2 ®️, opening the app should start the app |
|                **Result** | The app should be started without an exception                                        |
|          **Precondition** | The user has the app installed on their Oculus Quest 2 ®️                              |
|               **Process** | 1. The user opens the app                                                             |
| **Postcondition Success** | The user is in the main menu (**OR**) The game started                                |
|   **Postcondition Error** | The app cannot start, the logs should tell more                                       |
|        **Classification** | **_functional_**, **_must_**                                                          |
|                **Effort** | **_easy_**                                                                            |

#### REQ-02 - Game Start

|                           |                                                                                 |
| ------------------------: | :------------------------------------------------------------------------------ |
|                **Target** | Once the app is started, the user can start a new game                          |
|                **Result** | The first level is initiated and the user can start to move                     |
|          **Precondition** | -                                                                               |
|               **Process** | 1. The user started a new game                                                  |
| **Postcondition Success** | The new level started                                                           |
|   **Postcondition Error** | 1. The level could not be loaded <br /> 2. The user should see an error message |
|        **Classification** | **_functional_**, **_must_**                                                    |
|                **Effort** | **_easy_**                                                                      |

#### REQ-03 - Game End

|                           |                                                                           |
| ------------------------: | :------------------------------------------------------------------------ |
|                **Target** | Using the game menu, the user should be able to go back to the main scene |
|                **Result** | The level ends                                                            |
|          **Precondition** | The game is running [REQ-02](#### REQ-02 - Game Start)                    |
|               **Process** | 1. The user opens the game menu <br /> 2. The user clicks "[Go To Lobby]" |
| **Postcondition Success** | The user lands back in the main menu                                      |
|   **Postcondition Error** | The game could not be ended, the user should see an error message         |
|        **Classification** | **_functional_**, **_nice to have_**                                      |
|                **Effort** | **_easy_**                                                                |

### REQ-1X - Game Requirements

#### REQ-10 - Locomotion

|                           |                                                                                                   |
| ------------------------: | :------------------------------------------------------------------------------------------------ |
|                **Target** | The user can walk in the level using a controller or teleportation                                |
|                **Result** | The main camera moves with the player                                                             |
|          **Precondition** | The game is running                                                                               |
|               **Process** | 1a. the user moves the right joystick <br /> 1b. the user can teleport using a teleportation area |
| **Postcondition Success** | The main camera moved correctly                                                                   |
|   **Postcondition Error** | The main camera did not move                                                                      |
|        **Classification** | **_functional_**, **_must_**                                                                      |
|                **Effort** | **_medium_**                                                                                      |

#### REQ-11 - Shoot a portal

|                           |                                                                                                                              |
| ------------------------: | :--------------------------------------------------------------------------------------------------------------------------- |
|                **Target** | The player can shoot a portal                                                                                                |
|                **Result** | A portal is projected on the target area                                                                                     |
|          **Precondition** | The target area is of layer teleportation area                                                                               |
|               **Process** | 1. The player points the raycast to a teleportation area <br /> 2. the player presses the right grip or right trigger button |
| **Postcondition Success** | The portal gets projected on the teleportation area                                                                          |
|   **Postcondition Error** | There is no portal                                                                                                           |
|        **Classification** | **_functional_**, **_must_**                                                                                                 |
|                **Effort** | **_medium_**                                                                                                                 |

#### REQ-12 - Walk through a portal

|                           |                                                                         |
| ------------------------: | :---------------------------------------------------------------------- |
|                **Target** | Walking through a portal will teleport the player to the next portal    |
|                **Result** | The main camera moves to the next portal                                |
|          **Precondition** | There are 2 portals (orange / blue)                                     |
|               **Process** | 1. the player walks into the portal                                     |
| **Postcondition Success** | the player including the main camera are teleported to the other portal |
|   **Postcondition Error** | no teleportation happened                                               |
|        **Classification** | **_functional_**, **_must_**                                            |
|                **Effort** | **_hard_**                                                              |

#### REQ-13 - Ending a level

|                           |                                                                   |
| ------------------------: | :---------------------------------------------------------------- |
|                **Target** | The player walks through the exit-door                            |
|                **Result** | The player is teleported back to lobby                            |
|          **Precondition** | -                                                                 |
|               **Process** | 1. The player started the game <br /> 2. The player is in a level |
| **Postcondition Success** | The player is now in the lobby                                    |
|   **Postcondition Error** | The player is stuck in the level                                  |
|        **Classification** | **_functional_**, **_must_**                                      |
|                **Effort** | **_easy_**                                                        |


#### REQ-14 - Deathzone

|                           |                                                                                                     |
| ------------------------: | :-------------------------------------------------------------------------------------------------- |
|                **Target** | The player walks in the deathzone                                                                   |
|                **Result** | He dies, he will be reseted to the starting position                                                |
|          **Precondition** | The player is able to move ([REQ-02](#### REQ-02 - Game Start), [REQ-10](#### REQ-10 - Locomotion)) |
|               **Process** | 1. The player started the game <br /> 2. The player walked in the deathzone                         |
| **Postcondition Success** | The player is reseted to the starting position                                                      |
|   **Postcondition Error** | Nothing happens                                                                                     |
|        **Classification** | **_functional_**, **_must_**                                                                        |
|                **Effort** | **_medium_**                                                                                        |

