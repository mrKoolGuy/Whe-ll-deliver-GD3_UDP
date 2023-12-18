# Whe-ll-deliver-GD3_UDP
This is a small Delivery game where you play a person in a wheelchair that has to deliver packages to wheelchair unfriendly neighbourhoods.

## How to run
For running The Game, please open the Main Scene:
```
Assets/Whe-ll-deliver/My Assets/Scenes/Completed/MainScene.unity
```
Play the scene. You will see the main menu. The controls are illustrated in the options menu, where you will also find the volume control. With "New Game", You can start the game from the beginning. If you press on "Select Level" you can skip to the different levels.

### Cheating
Because we have a lot more than 2 minutes of gameplay we included shortcuts to try out different parts of the levels without placing the interactables yourself.

### Cheat Keys:
- G Player to Goal
- H Player back to start
- 1 First Step 
- 2 Second Step
- 3 Third Step
- 4 Fourth Step
- 0 Level interactables reset

## 3rd party sources:

### Code Sources:
- Bootloader/GameLayout/GameLevel/GameScene from the class, but modified for additional features we needed, for example Callbacks when all Scenes are loaded
- Game Events Handler from the class extended with Priorities


### Material Assets
- Pro Builder. It has included their material in our game. It is not used in the finish game.

### Sound Assets: 
- birds:  Jack whistling
- pigeons flapping wing: https://freesound.org/people/tigersound/sounds/9329/
- bushhit: https://pixabay.com/de/sound-effects/bushhitwav-14661/
- lantern sound effects are based on this sound: https://pixabay.com/de/sound-effects/place-glass-object-81857/
- PL 6: https://freesound.org/people/newlocknew/sounds/715789/
- PL 7: https://freesound.org/people/tommy_mooney/sounds/386712/
- PL 8: https://freesound.org/people/SpliceSound/sounds/218301/

### Texture Assets:
- 2D Casual UI HD is in the Menu UIs https://assetstore.unity.com/packages/2d/gui/icons/2d-casual-ui-hd-82080

### Model Asset:
- We use of the Skybox and Clouds out of the asset pack Simple Sky: [https://assetstore.unity.com/packages/3d/environments/simple-sky-cartoon-assets-42373](https://assetstore.unity.com/packages/3d/environments/simple-sky-cartoon-assets-42373 "https://assetstore.unity.com/packages/3d/environments/simple-sky-cartoon-assets-42373") 


### Shaders:
- Quick Outline gets used for the silhouette for the player and selectable Objects [https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488](https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488 "https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488")
- Our Vertex Wave Shader uses the script from the example as a base but got modified to fit more our purpose.   https://www.youtube.com/watch?v=L_Bzcw9tqTc
- we use the URP settings from the class with activated Antialiasing to get softer edges.
