# **WPlugins**

A plugin bundle for PMX Editor  
Developed by Wampa842

---

#### Table of contents

1. [Features](#features)
	- [Wavefront OBJ importer](#wavefront-obj-importer)
2. [Installation](#installation)
3. [Requirements](#requirements)  
4. [Troubleshooting and compatibility](#troubleshooting-and-compatibility)
5. [Contribute](#contribute)
6. [License](#license)
7. [Planned features](#planned-features)

------
## Features

#### Wavefront OBJ importer
&nbsp;&nbsp;&nbsp;&nbsp;Allows you to import Wavefront Object models and their material libraries to PMX Editor.  
&nbsp;&nbsp;&nbsp;&nbsp;Dialog with various settings.  
&nbsp;&nbsp;&nbsp;&nbsp;Settings can be saved as default or into a job file.  
&nbsp;&nbsp;&nbsp;&nbsp;Job files help streamline the import process for files that you have to import frequently (e.g. works in progress).  

------
## Installation
1. Download the latest release from the [Releases](#todo) page.
2. If your system blocks executable files downloaded from the internet, make sure you unblock the ZIP archives or the individual DLL files (right click > Properties > Unblock)  
3. Copy the WPlugins directory to &lt;PMX folder&gt;\\\_plugin\\User

## Requirements

PMX Editor: [[website]](http://kkhk22.seesaa.net/)  
At present, the plugins don't work with legacy PMD Editor releases.

.NET Framework:  
- On Windows 8 and later, .NET Framework is automatically installed and updated by Windows Update.  
- Manual download for Windows 7 and earlier: [[download page]](https://www.microsoft.com/net/download/dotnet-framework-runtime)

------
## Links and download

#### [[Releases]](https://github.com/wampa842/wplugins/releases) (download from here)  

##### [[Project website]](https://wampa842.github.io/wplugins) [[GitHub repository]](https://github.com/wampa842/wplugins) [[Issues]](https://github.com/wampa842/wplugins/issues)  

------
## Troubleshooting and compatibility

#### Which PMX Version is this compatible with?  
&nbsp;&nbsp;&nbsp;&nbsp;**0.2.3.2d and newer**. It should be compatible with earlier releases too.

#### Is the English translation supported?  
&nbsp;&nbsp;&nbsp;&nbsp;It's probably compatible, but I can't provide any support for it since it was decompiled to IL code and then rebuilt. *If you encounter an issue in the English translation, try to reproduce it in the official Japanese release before reporting it.*

#### Is the legacy PMD Editor supported?  
&nbsp;&nbsp;&nbsp;&nbsp;At present, **no.** PMD Editor uses an entirely different programming interface, `PEPlugin.Pmd`, but my plugins currently only use `PEPlugin.Pmx`. I might try to explore legacy support in the future.

#### What can I do if I encounter an issue?  
&nbsp;&nbsp;&nbsp;&nbsp;Try to reproduce it, narrow down the possible sources. Most of the errors will produce an error message which will help you hunt down the cause.  
&nbsp;&nbsp;&nbsp;&nbsp;If you can't solve the issue yourself, encounter a repeating problem, or it seems to be my fault, you can leave a bug report on the [Issues](#todo) page, or [contact me](#todo).

### Frequent issues:

#### Error message that says you're missing an assembly  
&nbsp;&nbsp;&nbsp;&nbsp;This usually happens when .NET Framework is outdated or missing, or a DLL file is missing. [Install or update](#requirements) .NET Framework, [reinstall](#installation) the plugin, and make sure other applications (e.g. an antivirus) aren't trying to delete the DLL files.

#### An error message in Japanese is shown, and you can't find the plugins  
&nbsp;&nbsp;&nbsp;&nbsp;For security reasons, Windows blocks executables downloaded from the internet and PMX Editor couldn't execute the plugin's files. Make sure they're not blocked ([installation](#installation) step 2) and that other applications (e.g. an antivirus) are not blocking their execution.

#### Unhandled exceptions  
&nbsp;&nbsp;&nbsp;&nbsp;I try to handle as many exceptions as I can, but some might slip through the cracks. If an unhandled exception occurs, click on "Details", copy the text you find below, and leave a bug report on the [Issues](#todo) page or [contact me](#todo).  
&nbsp;&nbsp;&nbsp;&nbsp;You can also fix it yourself - see how you can [contribute](#contribute).

#### Errors related to files  
&nbsp;&nbsp;&nbsp;&nbsp;Many of the plugins write their default settings to `settings.xml`, which is located in the same directory as the DLL files. If PMX is installed in a location where special privilege is needed to make changes (e.g. Program Files), users who are not administrators might be denied write access to the files. The only way to fix this is either to install PMX Editor to a location where the user has write access, or ask the administrator for access.  
&nbsp;&nbsp;&nbsp;&nbsp;Another issue might arise if a file is opened by an application while a plugin is trying to write to it. Make sure the file isn't kept open by editors, other applications or other instances of PMX Editor.

#### Errors related to models - unexpected or incorrect results  
&nbsp;&nbsp;&nbsp;&nbsp;Every model is different, and while I can try to anticipate edge cases, some models present problems that my plugins can't handle. If that happens, first try to play around with the plugin's settings. If that doesn't help, try to simplify things - remove complex features from your model that you think might be causing problems (such as PMX 2.1 features, which are only supported by [MMM](https://sites.google.com/site/mikumikumoving/)).

#### Errors related to numbers and locale
&nbsp;&nbsp;&nbsp;&nbsp;PMX Editor has a well-known bug that arises from the system locale's definition of what the decimal separator character should be. I'll always try to proactively avoid this, but if it does happen, you can do one of two things: 1, try using a different decimal character (e.g. dot instead of comma), or 2, look up how to change the decimal character in Windows' settings.

#### Errors related to model size/complexity and performance  
&nbsp;&nbsp;&nbsp;&nbsp;Some operations performed by the plugins can be costly in terms of performance and computer resources. I'll try to move such operations to other threads with a handy progress bar, but if a plugin causes PMX to hang and not respond, just wait it out. In case of an infinite loop, the best thing to do is to kill the process from Task Manager.

#### A plugin caused a file to become corrupted or otherwise lost  
&nbsp;&nbsp;&nbsp;&nbsp;I don't mean to sound callous, but it's the user's responsibility to save often and make backups. If the issue was caused by a plugin, file a report on the [Issues](#todo) page or [contact me](#todo).

------
## Contribute

TBD

------
## License

TBD

------
## Planned features

- OBJ Export: an export plugin that saves the scene as an OBJ+MTL file.  
- SafeWeld: a tool that merges vertices with respect to UV boundaries, materials, vertex normal angles and various conditions.  
- Apply Morph: apply a vertex/UV morph (or its inverse) to the scene.  
- Scale Morph: scale a morph by a scalar, with shortcuts to inverse.  
- Name Utils: translate and edit material/bones/etc names in bulk using a `sed`-like tool.  
- Material Merge: combine materials with respect to various conditions.
