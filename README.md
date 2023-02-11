# LiteNinja GameStarterKit

LiteNinja GameStarterKit (GSK) is a Unity3D project that provides developers with a quick start for prototyping mobile game concepts. It includes pre-made assets, scripts, and tools from the LiteNinja libraries to simplify and streamline game development.

## Features

- Pre-made assets, including characters, environments, and UI elements
- Scripts and tools from the LiteNinja libraries, including:
  - [LiteNinja Common](https://github.com/sponticelli/LiteNinja-Common) (common code used by other LiteNinja libraries)
  - [LiteNinja SOA](https://github.com/sponticelli/LiteNinja-SOA) (Scriptable Object Architecture)
  - [LiteNinja Pooling](https://github.com/sponticelli/LiteNinja-Pooling)
  - [LiteNinja DI](https://github.com/sponticelli/LiteNinja-DI) (Dependency Injection)
  - [LiteNinja Data Persistence](https://github.com/sponticelli/LiteNinja-DataPersistence)
  - [LiteNinja Cameras](https://github.com/sponticelli/LiteNinja-Cameras)
  - [LiteNinja Audio](https://github.com/sponticelli/LiteNinja-Audio)
  - [LiteNinja Actions](https://github.com/sponticelli/LiteNinja-Actions)
- A starting point for game development that saves time on initial setup

## Getting Started

To get started with GSK, simply download the project and open it in Unity3D. You can then begin experimenting with the pre-made assets and tools, and start building your game concept.

### Scenes
GSK has 4 pre-configured scenes:
- Bootstrap: the splash screen. In the build flow, it loads the Systems scene and then open the Home scene
- Systems: it contains the systems used in all the other scenes such as the AudioSystem or the PoolingSystem. All the scenes contain a prefab (LoadSystems) that load the Systems scene, so you can edit and test every scene without starting from Bootstrap
- Home: A simple scene that allows to launch the Game scene and the settings popup
- Game: this is your job!


### Systems
TODO explain LoadSystems prefab and the game event 
TODO for each system


### Sample Game
TODO Link to a sample game

## Requirements

- Unity3D 2021.3+
- LiteNinja libraries (included in the project)
- [DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676  )

## License

GameStarterKit is open source and free to use under the [MIT License](https://github.com/sponticelli/LiteNinja-GameStarterKit/blob/main/LICENSE).

## Contributions

Contributions are always welcome! If you'd like to contribute to GSK, please open a pull request with your changes.

## Credits

### Fonts
- Bungee by [David Jonathan Ross](https://fonts.google.com/specimen/Bungee)
- Roboto Flex by [Font Bureau](https://fonts.google.com/specimen/Roboto+Flex?query=robot)