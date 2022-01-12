# Design

## Architecture

### Game Loop inputs and outputs

#### inputs

- VR-Controller
- VR-Sensors

#### outputs

- graphics
- audio (Pew Pew, DOOM)
- <del>"rumble" effect on controller</del>
- <del>game-data to watch on mobile phone</del>

### Time

- <del>a timer to measures the time (seconds) needed for a level</del>

### Game Objects

#### updated and drawn

- player
- portal-Gun
- portal "orange"
- portal "blue"
- doors
- wristwatch-menu

#### only drawn - static objects

- room
- obstacles
- deathzone

#### only update

- camera
