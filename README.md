



# 🚀 **Why It’s Useful**
In Unity, the default way of building UI is to place elements on a Canvas and show or hide them with `SetActive()`.  
This works for small projects, but as complexity grows it becomes messy and hard to maintain:

- 🧩 **Hard to manage screens** — you must manually show and hide objects in the right order.  
- ⏪ **No screen history** — you have to write your own logic to go back.  
- 🔀 **Complex states are tricky** — e.g., one screen with multiple views (UI walking/driving).  
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

# ⚡ **Initializing the Services**

This project uses a **Service Locator (`SV`)** to register and access services.  
`ScreenService` and `OverlayService` are created from prefabs stored in `ScreenAndOverlayConfig`, registered in the service locator, and can then be accessed anywhere in the project via `SV.Get<T>()`.
<img width="930" height="638" alt="{E72FF53C-8D9D-4B1A-B2FE-3A95791ADCE6}" src="https://github.com/user-attachments/assets/4a726d40-caa3-43fd-9105-225eff3a98e9" />

💡 **Note:** Instead of a Service Locator, you can use any other dependency management method, such as **Dependency Injection**, if it fits your project better.

---

# 🖱️ **Creating Screens and Overlays**

### 🖥️ **Screens and Views**

1. Add a new your own value to the enum **ScreenIdentifier**. (In my example **Settings**)
<img width="430" height="155" alt="{051DBF5C-FB01-407A-AE30-74CDEA1713AA}" src="https://github.com/user-attachments/assets/685c72c5-94ae-4c00-995e-9a19fe0179d2" />

2. Create prefabs for your new screen and its view.
<img width="995" height="145" alt="{A1F1D3DB-6198-42F4-82CB-ADE78953E08E}" src="https://github.com/user-attachments/assets/2119dab7-20a7-4c34-8e5e-6446655b41b9" />
<img width="523" height="41" alt="{8D920F17-B1D2-4AEC-AF2E-C2B76EF1D026}" src="https://github.com/user-attachments/assets/ef9aedd0-031d-4a03-9eaa-ebcc8b7c7b56" />

3. Assign the main view prefab to the screen’s `defaultView` field (additional views can be handled with your own logic).  
![Unity_ZHZMyUoejQ](https://github.com/user-attachments/assets/48a09559-92a2-4b2f-ab86-ddb00a781f1f)

4. Add the screen prefab to the `ScreensPrefabs` list in **`ScreenAndOverlayConfig`**.
  
5. To open a screen, use:
```csharp
SV.Get<ScreenService>().OpenScreen(ScreenIdentifier.YourScreenID);
```
Or use an **OpenScreenButton** and select the desired `ScreenIdentifier` in the inspector.
<img width="977" height="253" alt="{086ED0C3-1CDE-48F0-B81B-C3A74CCE787A}" src="https://github.com/user-attachments/assets/3b3de08c-680f-4083-866f-fde9c6461614" />

---
### Use an **OpenPreviousScreenButton** to open previous screen.
<img width="957" height="86" alt="{78423E98-4B48-4089-B859-C39C78ABAADE}" src="https://github.com/user-attachments/assets/087254d8-6bdd-461a-9053-87ad4f6c4195" />

---
### 📦 **Overlays**
You can create your own overlays, but do not delele **LoadingOverlay** class and prefab. This overlay is essential for displaying loading between screen transitions. The only things you can change there are the view and the duration of the animation of this loading overlay
1. Create an overlay prefab and add it to the `OverlaysPrefabs` list in `ScreenAndOverlayConfig`.
2. To open an overlay, use:

```csharp
SV.Get<OverlayService>().OpenOverlay<YourOverlay>();
```
**Pass true as an argument to open the overlay immediately, bypassing the queue. By default (false), the overlay will wait if another overlay is still open.**

---
