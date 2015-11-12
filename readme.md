De4dotShell
===========

Introduction
------------

De4dotShell is a small utility (inspired by idea of de4dotUI by Yashar Mamoudnida) created in C#, which provides a small and easy to use GUI for de4dot, where you can invoke de4dot from context menu, ad parameters/switches directly from GUI interface and watch it work. Thing are done out-of-the-box.

See the screenshot below:

![Configuration Form](https://raw.githubusercontent.com/levisre/de4dotShell/master/screenshots/configform.png)

![Deobfuscation Windows](https://raw.githubusercontent.com/levisre/de4dotShell/master/screenshots/deobform.png)

This is a small update of my old project, which is abandoned for a while due to my busy work in real life.
Someone reported that this works fine in Windows 7, but not in 8/8.1 and Windwos 10. So here is the fix for that issues.

How to use
----------
Download the source code and use Visual Studio, or SharpDevelop (i prefer this) to compile and it's up for you to use.

Place the compiled de4dotShell.exe into the de4dot's folder, run it with admin privilege, tick the checkbox in the small window appeared

Enjoy, now you have de4dot on everywhere you go.

Right click on a .NET PE File, an entry named "de4dotShell" in the context menu, click on it, then now you're ready to interact with de4dot, put some params and click the button.

Changelog:
----------

**Version 0.1b**
> - UPdate compability to work with Windows 8/8.1 and Windows 10
> - Tidy up code
> - Add new Icon
> - Change font and color for the output Richtextbox
> - Update Readme.md file

**Version 0.1**
> - Initial Release

Disclaimer
----------
This project is just a hobby project, so except bugs. The source is simple and open, so you can do whatever you want.

Credits
-------
Greetz fly out to:

- 0xd4d (author of de4dot): https://github.com/0xd4d
- Yashar Mamoudnida
- Members of B@S, Tus4you, Exetools, REPT, Cin1 and all my friends