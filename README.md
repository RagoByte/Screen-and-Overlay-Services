



# 🚀 **Why It’s Useful**
In Unity, the default way of building UI is to place elements on a Canvas and show or hide them with `SetActive()`.  
This works for small projects, but as complexity grows it becomes messy and hard to maintain:

- 🧩 **Hard to manage screens** — you must manually show and hide objects in the right order.  
- ⏪ **No screen history** — you have to write your own logic to go back.  
- 🔀 **Complex states are tricky** — e.g., one screen with multiple views (UI when driving vs. walking).  
- 📚 **Overlays can overlap** or behave inconsistently without extra management.  

This system solves those issues by:

✅ **Splitting UI into Screens and Overlays** for better structure and control.  
✅ **Keeping screen history** so navigation back is simple and automatic.  
✅ **Preserving overlay states** when switching screens, hiding and restoring them automatically.  
✅ **Managing an overlay queue** so pop-ups don’t block or overwrite each other.  
✅ **Centralizing UI logic** inside dedicated services, making the project easier to maintain and scale.  
### This system simplifies working with UI in Unity and provides two core services:

✨ **ScreenService** — manages creating and switching screens.  
🖼️ **OverlayService** — manages creating and showing overlays (pop-ups, notifications) on top of screens.  

### Key Classes

- 🖥️ **Screen** — main container for a screen’s interface, managed by `ScreenService`.  
- 🖼️ **BaseView** — a visual part of a screen. A single Screen can have multiple different views, but only one can be active at a time. If you need to switch between views, implement this logic in your Screen subclass: hide or destroy the current view, create the new one, and assign it to `_currentView`.  
- 📦 **BaseOverlay** — pop-ups or notifications, managed by `OverlayService`, keep their state when switching screens and can open independently.

The system allows you to:

📜 **Maintain screen history**  
🛠️ **Structure screens and views flexibly**, enabling complex interfaces (e.g., different UI for different player states)  
⚡ **Open and close screens and overlays asynchronously**  
🎛️ **Control overlay queues**, so one overlay doesn’t block another  
💾 **Preserve overlay states** when switching screens, automatically hiding and restoring them  

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

<img width="520" height="653" alt="{105FF612-53E9-4C71-8C65-51F54C77E0A7}" src="https://github.com/user-attachments/assets/ac82cea0-45d0-4853-9cc7-7beb6e2367a3" />


1. Create prefabs for your new screen and its view.  
2. Add the screen prefab to the `ScreensPrefabs` list in `ScreenAndOverlayConfig`.  
3. Assign the main view prefab to the screen’s `defaultView` field (additional views can be handled with your own logic).  
![Unity_qCbJSgOqHo](https://github.com/user-attachments/assets/b0cfcbcc-decc-4e75-a5ff-39d20e1fe4ba)

4. To open a screen, use:
```csharp
SV.Get<ScreenService>().OpenScreen(ScreenIdentifier.YourScreenID);
```
Or use an **OpenScreenButton** and select the desired `ScreenIdentifier` in the inspector.
<img width="1010" height="237" alt="{171D8A23-1F2B-4BBE-9AB0-04FF25F9FED8}" src="https://github.com/user-attachments/assets/3d87232a-97a7-46d8-891d-6b9788482cb4" />


Also you can use an **OpenPreviousScreenButton** to open previous screen.
<img width="1049" height="302" alt="{5582D812-39E4-4B7E-BFCA-5BE71A123B7C}" src="https://github.com/user-attachments/assets/a03df106-f24d-4b1f-a0df-825f7bfc97a3" />



### 📦 **Overlays**
You can create your own overlays, but do not delele **LoadingOverlay** class and prefab. This overlay is essential for displaying loading between screen transitions. The only things you can change there are the view and the duration of the animation of this loading overlay
1. Create an overlay prefab and add it to the `OverlaysPrefabs` list in `ScreenAndOverlayConfig`.
2. To open an overlay, use:

```csharp
SV.Get<OverlayService>().OpenOverlay<YourOverlay>();
