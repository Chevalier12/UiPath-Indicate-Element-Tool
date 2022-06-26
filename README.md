# UiPath-Indicate-Element-Tool

This tool is a quicker (but not better) implementation of the UiPath Studio **Indicate Element**, it does fetch the selector quite quickly, but creating a custom selector isn't really possible without UiExplorer which can show you all of the attributes you can add to your current selector, the best I could do is browse through all the attributes of the selector and display them, but that beats the purpose of everything being quicker and easier.

Anchors are pretty much impossible too, you need to use AnchorBase in your code because adding Anchors with the Core Activities in code is impossible, I have no idea how they managed to do it but I believe it is hard-coded in the UiExplorer application from UiPath Studio.
