# Changelog

## [0.0.6] - WIP 1/8/2026

Fixed:
- SFCommonStyleSheet not loading automatrically
It just needed the path to the sheet used in the variable updated after SF UI Elements became a sub package of SF Core.


## [0.0.5] - 1/7/2026
This version merged the SF UI Elements and the SF Utilities into a single package 
that is now the SF Core package.

This is done for the following reasons:
- Lower the amount of packages and dependencies for all other SF packages.
- Improve user install workflow
- Lower amount of repos needing to have focus split.
- To sync changes between the combined packages with bigger complete toolkit 
packages like SF Metroidvania and SF Sprite Editor.