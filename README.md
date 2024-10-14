[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/ZUtYscbQ)

# Temple Run

In a game like Temple Run, the focus on interactive graphics is critical for delivering a visually immersive and responsive experience. Here's an overview of key techniques used in the Unity game engine, focusing on shaders, geometry, lighting, animation, and user interface (UI) interaction:

## Shaders

Shaders in Unity are crucial for defining the visual appearance of objects in a game like Temple Run, especially since the game emphasizes fast-paced environments and dynamic scenes.

1. Vertex and Fragment Shaders: Used for dynamic surface effects like reflections, water shaders, and environmental interactions. For example, creating a reflective water surface or smooth transitions in environments as the player runs.
2. Custom Shaders: You can create custom shaders for specific effects, such as motion blur (to emphasize speed) or toon shading for a more stylized look. These shaders are optimized to run efficiently, even on mobile platforms.
3. Lighting and Shadow Mapping Shaders: Used to create depth and realism in the game world, with dynamic shadows that move as the character runs through the environment.

## Geometry

The game's geometry typically consists of endless paths, obstacles, and environment assets like trees and rocks.

1. Level-of-Detail (LOD) Techniques: As the player moves quickly, objects far in the distance can have reduced detail (fewer polygons) while nearby objects maintain high detail. This ensures good performance without sacrificing visual quality.
2. Mesh Optimization: Reducing the polygon count for certain assets while maintaining their visual appearance is crucial for mobile performance, which is essential in an endless runner game.
3. Procedural Generation: The environments in games like Temple Run are often procedurally generated. Unity can spawn new sections of the track, varying terrain, obstacles, and structures as the player progresses, ensuring smooth transitions and continuous gameplay.

## Lighting

Lighting in Temple Run-like games plays a key role in creating depth and atmosphere, particularly in outdoor and semi-lit temple environments.

1. Real-Time Lighting: Since the game is fast-paced, real-time lighting helps objects, characters, and environments react dynamically to the player’s movement.
2. Global Illumination (GI): Although expensive on performance, it can be used selectively for soft, realistic light bounces, especially around temple environments or tunnels where light interacts with surfaces and objects.
3. Light Probes and Reflection Probes: These are used to capture lighting information and reflections dynamically, ensuring that moving objects, such as the player and enemies, are lit realistically as they pass through the environment.
4. Ambient Occlusion: To enhance depth perception, Unity uses this technique to darken crevices and corners, giving objects more visual weight and realism.

## Animation

Animation is a core element in maintaining the game's energy and excitement as the player navigates obstacles and avoids traps.

1. Character Animation: Unity's Animator Controller is used to blend various animations such as running, jumping, sliding, and turning. Animation transitions are smooth, keeping the player's experience fluid.
2. Root Motion: Allows character movement to be driven directly by the animation, keeping the character aligned with the running track.
3. Physics-Based Animations: While most of the animations are pre-authored, Unity’s physics system can be used to simulate object collisions or ragdoll effects when the character crashes into obstacles.
4. Inverse Kinematics (IK): Useful for making sure the character’s limbs (e.g., legs and arms) adjust naturally based on the environment and movements (like running up or down uneven surfaces).

## User Interface (UI) Interaction

The user interface (UI) plays an important role in providing players with feedback, scores, power-ups, and pause functionality.

1. Interactive UI Elements: Unity's UI system allows for interactive buttons and menus that trigger game events. In Temple Run, power-ups, in-game purchases, and pause menus are seamlessly integrated into the gameplay.
2. HUD (Heads-Up Display): The HUD constantly displays real-time information, such as distance run, score, coins collected, and available power-ups. This is implemented through Unity's Canvas system.
3. Responsive Design: Unity supports dynamic scaling and anchoring to ensure the UI looks great on all device sizes, from mobile phones to tablets.
4. Touch Input and Gestures: Since Temple Run is often played on mobile, Unity uses touch input to allow for intuitive gestures, like swiping to change direction or jump. The input system processes finger gestures, making the interaction seamless.

## Summary

In a game like Temple Run, Unity's advanced graphical techniques—shaders, optimized geometry, dynamic lighting, realistic animations, and responsive user interfaces—work together to create an interactive and visually engaging experience. The fast-paced nature of the game demands efficient rendering and interaction, ensuring smooth gameplay without sacrificing visual quality.
