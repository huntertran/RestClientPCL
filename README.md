# RestClientPCL
A Portable Class Library for rest consuming

![Rest](https://github.com/cuoilennaocacban/RestClientPCL/raw/master/restclient%20icon.png)

Most of the projects I'm working on are using their own implementation to request data from API, then convert the return to Object

If you find this is your case, then you can use this library to do that automatically for you

The only thing this lib will do is send requests and receive responses.

If you want more functions (OAuth, Download File, etc.), feel free to create an extension to this lib or fork it to modify for your own needs.

ALL KIND OF CONTRIBUTIONS ARE WELCOME

# To Build package

```cmd
D:Path/to/folder/that/have/csproj file>msbuild /t:pack /p:Configuration=Release
```
