# Overview
The SF Core package contains utility functions and commonly used UI Toolkit assets used in all other SF Packages.
It also is useful as a standalone package because of the amount of helper methods and tools in it.

For anything UI related this package and all other SF packages only use UI Toolkit.
None of them use IMGUI or UGUI.

Shatter Fantasy studio is only doing helper method for the modern RenderGraph is anyone is using the render API utilities.
This is because Unity already has a version that removes the older API. I don't want technical debt to slow down
progress on the tools.

The abvoe means I only have helper methods for Scriptable Render Pipelines based API.

## Requirements
Minimum Supported Unity Version: 6.3 LTS patch 2 
Currently Unity 6.3 is the supported LTS and earliest version of Unity Shatter Fantasy supports.
As of January 8 everything can work for Unity 6, but nothing older than that.
I am only doing bug reports for Unity 6.3 and newer though.

## Side Notes:
To lower the amount of package dependcies that might not be needed for all projects some specific 
methods are in other standalone packages.

### SF Metroidvania Toolkit package
This is a major package with over 200 scripts in it to create a Metroidvania game using Unity's Low Level Physics API.
It uses Burst Compiler to help speed up supported code logic. This is meant for creating a Metroidvania project with high
customization for physics, tilemaps, game data, and rendering.

### SF Sprite Tools
Warning some of the custom editors are early wip.
This is a seperate package with extra 2D tools with sprites, tilemaps, and a few other things.

# Donations help make new features.
If anyone wants to help I do accept donations. Donations go toward helping ad new features and maintining the packages.
https://ko-fi.com/8bitsperplay

Please read the LICENSE.md for information regarding uses of the package.

# SF Git Hub Links
https://github.com/Shatter-Fantasy

## Example SF Package built with the SF Core
https://github.com/Shatter-Fantasy/SF-Metroidvania

