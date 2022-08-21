# Command shell

### Commands list


| Command | Description                                                    |
|---------|----------------------------------------------------------------|
| attrs   | Print file attributes                                          |
| cat     | Print file                                                     |
| cd      | Change current directory                                       |
| cls     | Clear console                                                  |
| copy    | Copy file or directory                                         |
| del     | Delete file or directory                                       |
| dir     | List files                                                     |
| exit    | Exit from program                                              |
| find    | Recursive find files and directories using regular expressions |
| help    | Print commands list with description                           |
| history | Print last used commands                                       |
| mkdir   | Create new directory                                           |
| move    | Move file or directory                                         |
| rename  | Rename files and directories by regex pattern                  |
| size    | Print size file or directory                                   |
| touch   | Create new file                                                |

## Creating Commands

For create custom commands you need create class ```Commands/{CommandName}Command``` and inherit from the abstract class ```Command```

You must implement the following abstract methods:

- ```void HelpShort()```
- ```void Help()```
- ```void Run(Arguments args)```

No further action is required, the command will be added automatically