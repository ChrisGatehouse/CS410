## Dragon FTP - The Best FTP Client Ever Made!
---

### Table of Contents
+ [Requirements](#requirements)
+ [Installation Instructions](#installation-instructions)
+ [Usage Instructions](#instructions)
+ [Troubleshooting](#troubleshooting)
+ [Notes and Miscellaneous](#notes)
+ [Credits](#credits)

---
### <a name="requirements">Requirements</a>
1. Windows
2. .Net 4.5

---
### <a name="installation-instructions">Installation Instructions</a>
...

---
### <a name="instructions">Usage Instructions</a>
Dragon FTP can be used through its GUI or CLI.

#### GUI
By default, running ```./DragonFTP.exe```
without any arguments runs the client's GUI. However, you can also start the GUI
from its launcher icon.

When you first launch the GUI you will be prompted to login via the login
screen.

![Login Screen Image](https://github.com/ChrisGatehouse/CS410/blob/master/images/login-screen.png "Login Screen")

Once you've logged in, the main screen appears and is populated with the remote
servers directory and the local directory.

![Application Screen Image](https://github.com/ChrisGatehouse/CS410/blob/master/images/app-screen.png "Application Screen")

#### CLI
The CLI provides a quick alternative to the GUI for uploading and dowloading
files, provided you know which directory to look in.

##### Downloading Files
```./DragonFTP.exe --download="path/example.txt" --path="/home/john-smith/Documents/"```
In the above example, the 'path' option is used to specify the target folder to
download the file in.

##### Uploading Files
```./DragonFTP.exe --upload=example.txt --path="path\\"```
In the above example, the 'path' option is used to specify the target folder to
upload the file in.

##### Additional Features
To view all available CLI commands you can simply run the following:
```./DragonFTP.exe -?```

Also, Dragon FTP supports verbose mode, you can specify this option as follows:
```./DragonFTP.exe -v```

---
### <a name="troubleshooting">Troubleshooting</a>
Dragon FTP is the best client ever, if there is a problem it is likely due to
user error...

---
### <a name="notes">Notes and Miscellaneous</a>
* The Font and Colorscheme for the GUI is customizable.
* When you first run ```./DragonFTP.exe``` from the CLI it will store your login
  data in a .cred file within the working directory. Subsequent uses will take
  login credentials from this file.

---
### <a name="credits">Credits</a>
Dragon FTP was originally developed by the following students from Portland
State University:
* Ben Lawrence
* Chris Gatehouse
* Jonathan Hasbun
* Miles Sanguinetti
* Mohammed Inoue
