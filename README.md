# KeyHandler
Ever written a C# application and needed to capture user input from the keyboard that occurs either outside or inside of the application? This happens to me from time to time. The Windows API exposes a function to do this called `GetAsyncKeyState`. It's inconvenient to use; you typically have to import it from `user32.dll` and then have to figure out which virtual key (VK_KEY) codes have to be passed to `GetAsyncKeyState` and then figure out what the output means via bit magic. The purpose of this project is to provide a thin wrapper on top of this feature. We define a `KeyHandler` which will determine if a provided `Key` is currently down, and we provide a function called `GetPressedKeys` which will provide a collection of Keys which are currently being pressed down.

# Install
## With dotnet
`dotnet add package KeyHandler --version 1.0.2`

## With PackageReference
`<PackageReference Include="KeyHandler" Version="1.0.2" />`

## With NuGet Package Manager
`Install-Package KeyHandler -Version 1.0.2`

# Example

Get all keys being pressed.<br>
`
var keys = KeyHandler.KeyHandler.GetPressedKeys();
`
<br>
Print each key that's being pressed.
<br>
`
foreach (var key in keys)
{
    Console.Write(key + " ");
}
`
