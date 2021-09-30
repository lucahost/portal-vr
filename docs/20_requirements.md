# Requirements

## Functional Requirements

### REQ-0X - Starting / Ending

This is all about starting a new game and ending the app / game

#### REQ-01 - App Start

|                           |                                                                                        |
| ------------------------: | :------------------------------------------------------------------------------------- |
|                **Target** | If the app is installed on the Oculus Quest 2 ®️, opening the app should start the app |
|                **Result** | The app should be started without an exception                                         |
|          **Precondition** | The user has the app installed on their Oculus Quest 2 ®️                              |
|               **Process** | 1. The user opens the app                                                              |
| **Postcondition Success** | The user is in the main menu (**OR**) The game started                                 |
|   **Postcondition Error** | The app cannot start, the logs should tell more                                        |
|        **Classification** | **_functional_**, **_must_**                                                           |
|                **Effort** | **_easy_**                                                                             |

#### REQ-02 - Game Start

|                           |                                                                                   |
| ------------------------: | :-------------------------------------------------------------------------------- |
|                **Target** | Once the app is started, the user can start a new game                            |
|                **Result** | The first level is initiated and the user can start to move                       |
|          **Precondition** | The User clicked start in the Main Menu (**OR**) The app is installed and started |
|               **Process** | 1. The user started a new game                                                    |
| **Postcondition Success** | The new level started                                                             |
|   **Postcondition Error** | 1. The level could not be loaded <br /> 2. The user should see an error message   |
|        **Classification** | **_functional_**, **_must_**                                                      |
|                **Effort** | **_easy_**                                                                        |

#### REQ-03 - Game End

|                           |                                                                                                               |
| ------------------------: | :------------------------------------------------------------------------------------------------------------ |
|                **Target** | Using the game menu, the user should be able to end a running game                                            |
|                **Result** | The game ends                                                                                                 |
|          **Precondition** | The game is running [REQ-02](#### REQ-02 - Game Start)                                                        |
|               **Process** | 1. The user opens the game menu <br /> 2. The user clicks "[End game]" <br /> 3. The user confirms his choice |
| **Postcondition Success** | The user lands back in the main menu                                                                          |
|   **Postcondition Error** | The game could not be ended, the user should see an error message                                             |
|        **Classification** | **_functional_**, **_nice to have_**                                                                          |
|                **Effort** | **_easy_**                                                                                                    |

### REQ-1X - Game Requirements

#### REQ-10 - Move in space

|                           |                              |
| ------------------------: | :--------------------------- |
|                **Target** |                              |
|                **Result** |                              |
|          **Precondition** |                              |
|               **Process** |                              |
| **Postcondition Success** |                              |
|   **Postcondition Error** |                              |
|        **Classification** | **_functional_**, **_must_** |
|                **Effort** | **_medium_**                 |

#### REQ-11 - Shoot a portal

|                           |                              |
| ------------------------: | :--------------------------- |
|                **Target** |                              |
|                **Result** |                              |
|          **Precondition** |                              |
|               **Process** |                              |
| **Postcondition Success** |                              |
|   **Postcondition Error** |                              |
|        **Classification** | **_functional_**, **_must_** |
|                **Effort** | **_medium_**                 |

#### REQ-12 - Walk through a portal

|                           |                              |
| ------------------------: | :--------------------------- |
|                **Target** |                              |
|                **Result** |                              |
|          **Precondition** |                              |
|               **Process** |                              |
| **Postcondition Success** |                              |
|   **Postcondition Error** |                              |
|        **Classification** | **_functional_**, **_must_** |
|                **Effort** | **_hard_**                   |

#### REQ-13 - Ending a level

|                           |                              |
| ------------------------: | :--------------------------- |
|                **Target** |                              |
|                **Result** |                              |
|          **Precondition** |                              |
|               **Process** |                              |
| **Postcondition Success** |                              |
|   **Postcondition Error** |                              |
|        **Classification** | **_functional_**, **_must_** |
|                **Effort** | **_easy_**                   |

### REQ-2X - Dying / Invalid Moves

#### REQ-20 - Invalid move (Out of bounds)

|                           |                              |
| ------------------------: | :--------------------------- |
|                **Target** |                              |
|                **Result** |                              |
|          **Precondition** |                              |
|               **Process** |                              |
| **Postcondition Success** |                              |
|   **Postcondition Error** |                              |
|        **Classification** | **_functional_**, **_must_** |
|                **Effort** | **_easy_**                   |

#### REQ-21 - Invalid move (Dying)

|                           |                                                                                                        |
| ------------------------: | :----------------------------------------------------------------------------------------------------- |
|                **Target** | The player walks in the river / lava                                                                   |
|                **Result** | He dies, the level is failed                                                                           |
|          **Precondition** | The player is able to move ([REQ-02](#### REQ-02 - Game Start), [REQ-10](#### REQ-10 - Move in space)) |
|               **Process** | 1. The player started the game <br /> 2. The player walked in the river / lava                         |
| **Postcondition Success** | The player sees a message that he died, the game will end                                              |
|   **Postcondition Error** | The message won't be displayed                                                                         |
|        **Classification** | **_functional_**, **_must_**                                                                           |
|                **Effort** | **_medium_**                                                                                           |

## Non Functional Requirements

### Usability / User Experience

|                    |                                                                                                                |
| -----------------: | :------------------------------------------------------------------------------------------------------------- |
|         **Target** | The user should have a welcoming and intuitive experience                                                      |
|    **Description** | The menu should be styled, the messages should come clear <br /> There should not be needs for a documentation |
| **Classification** | **_non-functional_**, **_must_**                                                                               |
|         **Effort** | **_medium_**                                                                                                   |

### I18N

|                    |                                                                                                      |
| -----------------: | :--------------------------------------------------------------------------------------------------- |
|         **Target** | Players over the world can enjoy "Portal VR" in their language                                       |
|    **Description** | Currently the game will be developed in english. The goal would be to have all in multiple languages |
| **Classification** | **_non-functional_**, **_nice to have_**                                                             |
|         **Effort** | **_easy_**                                                                                           |

### Functional Tests / Unit Tests

|                    |                                                                   |
| -----------------: | :---------------------------------------------------------------- |
|         **Target** | The controller / script methods in `C#` should all be unit-tested |
|    **Description** | The unit-test coverage for the `C#` code should be over 75%       |
| **Classification** | **_non-functional_**, **_nice to have_**                          |
|         **Effort** | **_medium_**                                                      |
