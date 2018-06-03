# **WPlugins**

A plugin bundle for PMX Editor  
Developed by Wampa842

---

#### Table of contents

1. [Features](#features)
	- [Wavefront OBJ importer](#wavefront-obj-importer)
	- [Wavefront OBJ exporter](#wavefront-obj-exporter)
2. [Installation](#installation)
3. [Requirements](#requirements)  
4. [Links and download](#links-and-download)  
5. [Troubleshooting and compatibility](#troubleshooting-and-compatibility)
6. [Contribute](#contribute)
7. [License & Copying](#license-copying)
8. [Planned features](#planned-features)

------
## Features

#### Wavefront OBJ importer
- Allows you to import Wavefront Object models and their material libraries to PMX Editor.  
- Dialog with various settings.  
- Settings can be saved as default or into a job file.  
- Job files help streamline the import process for files that you have to import frequently (e.g. works in progress).  

#### Wavefront OBJ exporter
- Exports the PMX scene as a Wavefront Object file with its material library  
- Dialog and default/job settings similar to the OBJ importer  
- Optionally copy texture files to the output directory

------
## Installation
1. Download the latest release from the [Releases](#links-and-download) page.
2. If your system blocks executable files downloaded from the internet, make sure you unblock the ZIP archives or the individual DLL files (right click > Properties > Unblock)  
3. Copy the WPlugins directory to &lt;PMX folder&gt;\\\_plugin\\User

### Updating
Close PMX Editor. Follow the [installation](#installation) steps, overwrite all files (except `settings.xml` to keep your preferences).

## Requirements

#### PMX Editor: [[website]](http://kkhk22.seesaa.net/)  
At present, the plugins don't work with legacy PMD Editor releases.

#### .NET Framework 4.5 or later:  
- On Windows 8 and later, .NET Framework is automatically installed and updated by Windows Update.  
- If not, download an installer here: [[download page]](https://www.microsoft.com/net/download/dotnet-framework-runtime)

------
## Links and download

#### **[[Download the latest release]](https://github.com/wampa842/wplugins/releases/latest)**

[[All releases]](https://github.com/wampa842/wplugins/releases)  
[[GitHub repository]](https://github.com/wampa842/wplugins)  
[[Issues]](https://github.com/wampa842/wplugins/issues)  
[[Project website]](https://wampa842.github.io/wplugins)

------
## Troubleshooting and compatibility

#### Which PMX Version is this compatible with?  
- **0.2.3.2d and newer**. It should be compatible with earlier releases too.

#### Is the English translation supported?  
- It's probably compatible, but I can't provide any support for it since it was decompiled to IL code and then rebuilt. *If you encounter an issue in the English translation, try to reproduce it in the official Japanese release before reporting it.*

#### Is the legacy PMD Editor supported?  
- At present, **no.** PMD Editor uses an entirely different programming interface, `PEPlugin.Pmd`, but my plugins currently only use `PEPlugin.Pmx`. I might try to explore legacy support in the future.

#### What can I do if I encounter an issue?  
- Try to reproduce it, narrow down the possible sources. Most of the errors will produce an error message which will help you hunt down the cause.  
- If you can't solve the issue yourself, encounter a repeating problem, or it seems to be my fault, you can leave a bug report on the [Issues](https://github.com/Wampa842/wPlugins/issues) page, or [contact me](#contact).

### Frequent issues:

#### Error message that says you're missing an assembly  
- This usually happens when .NET Framework is outdated or missing, or a DLL file is missing. [Install or update](#requirements) .NET Framework, [reinstall](#installation) the plugin, and make sure other applications (e.g. an antivirus) aren't trying to delete the DLL files.

#### An error message in Japanese is shown, and you can't find the plugins  
- For security reasons, Windows blocks executables downloaded from the internet and PMX Editor couldn't execute the plugin's files. Make sure they're not blocked ([installation](#installation) step 2) and that other applications (e.g. an antivirus) are not blocking their execution.

#### Unhandled exceptions  
- I try to handle as many exceptions as I can, but some might slip through the cracks. If an unhandled exception occurs, click on "Details", copy the text you find below, and leave a bug report on the [Issues](https://github.com/Wampa842/wPlugins/issues) page or [contact me](#contact).  
- You can also fix it yourself - see how you can [contribute](#contribute).

#### Errors related to files  
- Many of the plugins write their default settings to `settings.xml`, which is located in the same directory as the DLL files. If PMX is installed in a location where special privilege is needed to make changes (e.g. Program Files), users who are not administrators might be denied write access to the files. The only way to fix this is either to install PMX Editor to a location where the user has write access, or ask the administrator for access.  
- Another issue might arise if a file is opened by an application while a plugin is trying to write to it. Make sure the file isn't kept open by editors, other applications or other instances of PMX Editor.

#### Errors related to models - unexpected or incorrect results  
- Every model is different, and while I can try to anticipate edge cases, some models present problems that my plugins can't handle. If that happens, first try to play around with the plugin's settings. If that doesn't help, try to simplify things - remove complex features from your model that you think might be causing problems (such as PMX 2.1 features, which are only supported by [MMM](https://sites.google.com/site/mikumikumoving/)).

#### Errors related to numbers and locale
- PMX Editor has a well-known bug that arises from the system locale's definition of what the decimal separator character should be. I'll always try to proactively avoid this, but if it does happen, you can do one of two things: 1, try using a different decimal character (e.g. dot instead of comma), or 2, look up how to change the decimal character in Windows' settings.

#### Errors related to model size/complexity and performance  
- Some operations performed by the plugins can be costly in terms of performance and computer resources. I'll try to move such operations to other threads with a handy progress bar, but if a plugin causes PMX to hang and not respond, just wait it out. In case of an infinite loop, the best thing to do is to kill the process from Task Manager.

#### A plugin caused a file to become corrupted or otherwise lost  
- I don't mean to sound callous, but it's the user's responsibility to save often and make backups. If the issue was caused by a plugin, file a report on the [Issues](https://github.com/Wampa842/wPlugins/issues) page or [contact me](#contact).

------
## Contribute

I've always believed in the importance of free and open software. For that reason, WPlugins is licensed under GNU GPL-3.0 or later (see the [next section](#license-copying)). I encourage anyone who's interested to tinker with, fork, modify and re-release my code and/or executables, as long as GPL-3.0's conditions are followed (see `LICENSE.MD` for the full license, or <https://choosealicense.com/licenses/gpl-3.0/> for a brief summary).

In short, you are allowed to copy, use, modify and convey/distribute the software on the following conditions:  
- The modified software is licensed under GNU GPL-3.0 or later, or another compatible license;
- The modified source code is made available to the public;
- Credit is given to contributors; and
- Significant changes are clearly stated.

If you have ideas, fixes or other changes that you've implemented, but don't want to release the modified software yourself, you can go to the [GitHub repository](https://github.com/wampa842/wplugins), fork the source code, implement the changes, and [create a pull request](https://github.com/Wampa842/wPlugins/pulls) to allow me to review and merge the forked branch.

If you have an idea for a feature or improvement, you can post it on the [Issues](https://github.com/Wampa842/wPlugins/issues) page.

------
## License & Copying

![gpl-3.0 logo](https://www.gnu.org/graphics/gplv3-127x51.png)

##### WPlugins and all associated source code files are licensed under **GNU GPL-3.0-or-later**.

Copyright (C) 2018 Wampa842

WPlugins is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

WPlugins is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with WPlugins.  If not, see <http://www.gnu.org/licenses/>.

------
## Planned features

- OBJ Export: an export plugin that saves the scene as an OBJ+MTL file.  
- SafeWeld: a tool that merges vertices with respect to UV boundaries, materials, vertex normal angles and various conditions.  
- Apply Morph: apply a vertex/UV morph (or its inverse) to the scene.  
- Scale Morph: scale a morph by a scalar, with shortcuts to inverse.  
- Name Utils: translate and edit material/bones/etc names in bulk using a `sed`-like tool.  
- Material Merge: combine materials with respect to various conditions.

------
## Contact

GitHub: [Wampa842](https://github.com/Wampa842)  
DeviantArt: [Wampa842](https://wampa842.deviantart.com)  
Twitter: [Wampa_842](https://twitter.com/wampa_842)  
Email: [wampa842@gmail.com](mailto:wampa842@gmail.com?subject=%5BWPlugins%5D)  
Discord: Wampa842#7496

------