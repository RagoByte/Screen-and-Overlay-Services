# 🚀 **Why It’s Useful**

This system simplifies working with UI in Unity. It has **two key services**:

✨ **ScreenService** — manages creating and switching screens.  
🖼️ **OverlayService** — manages creating and showing overlays (pop-ups, notifications) on top of screens.

The system allows you to:

📜 **Maintain screen history**.  
🛠️ **Flexibly structure screens and views**, allowing for complex interfaces (e.g., different UI for different player states).  
⚡ **Open and close screens and overlays asynchronously**.  
🎛️ **Manage overlay queues** so that one overlay doesn’t block another.  
💾 **Preserve overlay states** when switching screens, automatically hiding and restoring them.

### **Key Classes**

🖥️ **Screen** — the main container for a screen’s interface, managed by `ScreenService`.  
🖼️ **BaseView** — individual visual parts of a screen; multiple views can exist on one `Screen` for different states.  
📦 **BaseOverlay** — pop-up windows or notifications, managed by `OverlayService`, preserve their state when switching screens, and can open independently of the current screens.

---

# ⚙️ **Initializing the Services**

This project uses a **Service Locator (`SV`)** to register and access services.  
`ScreenService` and `OverlayService` are created from prefabs stored in `ScreenAndOverlayConfig`, registered in the service locator, and can then be accessed anywhere in the project via `SV.Get<T>()`.
<img width="1248" height="846" alt="image" src="https://github.com/user-attachments/assets/14450e17-5419-4b52-ac57-36d51b6e682c" />
<img width="1040" height="447" alt="image" src="https://github.com/user-attachments/assets/fe819afc-9479-4906-a5c8-e900ce6f12ce" />


💡 **Note:** Instead of a Service Locator, you can use any other dependency management method, such as **Dependency Injection**, if it fits your project better.

---

# 🖱️ **Creating Screens and Overlays**

### 🖥️ **Screens and Views**

1. Create prefabs for your new screen and its view.  
2. Add the screen prefab to the `ScreensPrefabs` list in `ScreenAndOverlayConfig`.  
3. Assign the main view prefab to the screen’s `defaultView` field (additional views can be handled with your own logic).  
4. To open a screen, use:
```csharp
SV.Get<ScreenService>().OpenScreen(ScreenIdentifier.YourScreenID);
```
Or use an **OpenScreenButton** and select the desired `ScreenIdentifier` in the inspector.

### 📦 **Overlays**

1. Create an overlay prefab and add it to the `OverlaysPrefabs` list in `ScreenAndOverlayConfig`.
2. To open an overlay, use:

```csharp
SV.Get<OverlayService>().OpenOverlay<YourOverlay>();
