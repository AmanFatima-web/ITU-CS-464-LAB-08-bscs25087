# CS464 – Lab 08
## Audio Systems, Events and UI Integration
- **Student name:** Aman Fatima 
- **Student Roll Number:** BSCS25087  
- **Project Name:** CS464 Lab 08  


---

## 1. Project Overview

This project extends Lab 07 by implementing audio systems, event-driven gameplay, asynchronous scene loading, and UI interaction.

The project includes:

- Loading screen with asynchronous scene loading.
- Main menu and gameplay scene navigation.
- Pause, resume, restart, and result screens.
- UI sound effects and gameplay sound effects.
- Background music and Audio Mixer.
- Master, Music, SFX, and UI volume controls.
- C# events with independent event listeners.
- Responsive UI and screen navigation.

## 2. Scenes and UI Flow

The project contains the following screens and scenes:

- **Main Menu:** Starting point of the game.
- **character panel:** choose character
- **levelselection panel:** choose level
- **Loading Screen:** Displays loading progress while the gameplay scene loads asynchronously.
- **Gameplay Scene:** Main playable game scene.
- **Pause Panel:** Provides Resume, Restart, and Menu options.
- **Settings Panel:** Contains audio volume controls.
- **Win Panel:** Displays when the player wins.
- **Lose Panel:** Displays when the player loses.
- **Result Panel:** Displays the final game result.
- **Credits Panel:** shows the credits
## 3. Loading System

The loading system uses asynchronous scene loading.

- Loads the gameplay scene asynchronously.
- Displays loading progress.
- Uses `SceneManager.LoadSceneAsync()` to load the gameplay scene.

## 4. Audio System

The project includes a reusable UI audio manager and gameplay audio sources.

### UI Sound Effects

- UI Hover
- UI Button Click
- UI Back
- Pause Button

### Gameplay Sound Effects

- Gameplay Sound
- Player Hit Sound
- Enemy Hit Sound
- Win Panel Sound
- Lose Panel Sound

### Audio Features

- Uses `PlayOneShot()` for short sound effects.
- Uses AudioSources for audio playback.
- Separates UI and gameplay audio through Audio Mixer groups.
- Provides separate volume controls for different audio categories.

## 5. Audio Mixer

**Audio Mixer Name:** MainAudioMixer

The Audio Mixer contains four groups:

| Group | Purpose |
|---|---|
| Master | Controls overall audio volume |
| Music | Controls background music |
| SFX | Controls gameplay sound effects |
| UI | Controls UI sound effects |

### Exposed Parameters

| Group | Exposed Parameter |
|---|---|
| Master | MyExposedParam |
| Music | MyExposedParam 1 |
| SFX | MyExposedParam 2 |
| UI | MyExposedParam 3 |

### Volume Controls

The Settings Panel contains four volume sliders:

- Master Volume
- Music Volume
- SFX Volume
- UI Volume

Volume settings use logarithmic decibel conversion and are saved using `PlayerPrefs`.

## 6. Event System

The project uses C# events to communicate between gameplay systems and UI components.

### Events

- `Damaged`
- `Died`
- `Won`
- `Lost`
- `Paused`
- `Resumed`

### Event Listeners

| Listener | Responsibility |
|---|---|
| HealthUIListener | Updates the health UI |
| ResultEventListener | Handles win and lose events |
| GameStatusListener | Handles pause and resume events |

All listeners subscribe in `OnEnable()` and unsubscribe in `OnDisable()`.

## 7. Game Manager

The GameManager controls the main gameplay flow.

Its responsibilities include:

- Managing the game timer.
- Handling player death.
- Triggering win and lose events.
- Pausing and resuming gameplay.
- Restarting the current scene.
- Returning to the menu.

## 8. Project Demo Video

**Demo Video:** (https://drive.google.com/file/d/1f2eH9c0hK5aMZAlDvmC4HUlwCOFGX7v_/view?usp=sharing)

The demo video shows the main menu, loading screen, gameplay, pause and settings panels, audio controls, and win/lose screens.

## 9. Required Submission Evidence

### 1. Audio Mixer Screenshot


<img width="1917" height="1007" alt="image" src="https://github.com/user-attachments/assets/16dc11b3-e390-43de-876e-a5a5d6daca48" />


Shows the `MainAudioMixer` with Master, Music, SFX, and UI groups and their exposed parameters.

### 2. C# Event Code Evidence

**GameEvents.cs – Event Declaration and Invocation**

```csharp
public static event Action<int> Damaged;

public static void OnDamaged(int health)
{
    Damaged?.Invoke(health);
}
```

**HealthUIListener.cs – Event Subscription and Unsubscription**

```csharp
void OnEnable()
{
    GameEvents.Damaged += UpdateHealth;
}

void OnDisable()
{
    GameEvents.Damaged -= UpdateHealth;
}
```

## 10. Asset Credits

### Island Environment Asset

- **Asset Name:** Island Assets
- **Creator / Publisher:** Lylek Games
- **Source:** Unity Asset Store
- **Asset Link:** https://assetstore.unity.com/packages/3d/environments/island-assets-56989
- **Licence:** Standard Unity Asset Store EULA

### Background Music And every sound effect used the same website Pixabay


- **Source:** Pixabay
- **Website:** https://pixabay.com/music/
- **Licence:** Pixabay Content License





### Game Engine

- **Engine:** Unity
- **Developer:** Unity Technologies
- **Website:** https://unity.com/

## 11. Technologies Used

- Unity
- C#
- Unity Audio Mixer
- Unity UI
- Scene Management
- C# Events and Delegates
- PlayerPrefs
- Git and GitHub



