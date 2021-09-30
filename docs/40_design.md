# Design

## Architecture

### Game Loop inputs and outputs

#### inputs

- VR-Controller
- VR-Sensors
- GPS Information (for area-control)

#### outputs

- graphics
- audio (if there is enough time)
- music (DOOM)
- "rumble" effect on controller
- game-data to watch on mobile phone

### Time

- a counter measures the time (seconds) needed for a level

### Game Objects

#### updated and drawn

- player
- portal-Gun
- portal "orange"
- portal "blue"
- exit (waiting, finish)

#### only drawn - static objects

- room
- obstacles
- death zone

#### only update

- time-counter
- camera
