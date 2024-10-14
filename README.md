[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/ZUtYscbQ)

# Endless Runner Games

Endless runner games are a popular genre in mobile and casual gaming characterized by continuous gameplay where the player controls a character running through a never-ending environment. These games often involve avoiding obstacles, collecting items, and achieving high scores.

![image](https://github.com/user-attachments/assets/42269dd3-6d56-4cc1-a359-1ca7ce8007a6)

Endless runner games are an engaging and accessible genre that has captivated players around the world. With their simple mechanics, dynamic gameplay, and rewarding progression systems, they provide endless entertainment. By combining fun graphics, sound design, and intuitive controls, developers can create compelling endless runner experiences.

## Shaders

### Soft Shadow

Soft shadows are shadows that have blurred, gradual edges, as opposed to hard, sharp-edged shadows. They occur when the light source is large or diffuse, causing the shadow to fade gradually rather than creating a crisp line between the shadowed and lit areas.

![image](https://github.com/user-attachments/assets/79169173-4520-4724-a264-1d20114972e0)

Soft shadows have a penumbra, which is the partially shaded area around the core of the shadow (called the umbra). This creates a smooth transition from light to dark, where the edges of the shadow appear softer and more blended. When the light source is large (like the sun on a cloudy day) or spread out (such as light coming through a frosted window), the light rays hit the object from multiple angles. This causes the shadow edges to blur because some light can still reach areas partially blocked by the object.

### Diffuse Shading

Diffuse shading is a lighting model used in computer graphics to simulate the way light interacts with rough or matte surfaces, which scatter light in many directions. Unlike shiny surfaces, which reflect light directly (specular reflection), diffuse surfaces reflect light equally in all directions, creating a soft, uniform appearance.

![image](https://github.com/user-attachments/assets/5e285a3a-af4b-455e-bdcf-c88763e715e2)

On a diffuse surface, light hits the surface and is scattered in multiple directions, which means the color of the object doesn't change based on the viewer’s position. Also, diffuse shading depends on the angle between the surface normal (the direction perpendicular to the surface) and the light source. If the light hits the surface directly, it appears brighter; at steeper angles, it appears dimmer. 

Diffuse shading typically follows Lambert's Law, which states that the intensity of the diffuse reflection is proportional to the cosine of the angle between the light direction and the surface normal. This ensures the surface is brightest where the light hits it perpendicularly and fades gradually at angles.


## Geometry

### Procedural Generation

Procedural generation is a method in computer graphics and game design where content is created algorithmically, rather than manually. It uses predefined rules and algorithms to generate environments, levels, textures, items, and even whole worlds. This technique is widely used to create vast, diverse, and dynamic game worlds without the need for designers to build every element by hand.

Procedural generation is a key technique used to create an ongoing, infinite world that players can continuously explore as they run forward. Instead of manually designing every part of the game’s environment, procedural generation dynamically creates segments of the road, obstacles, and scenery on the fly, keeping the game world "endless" and varied.

There are some key aspects in procedural generation : 

#### Chunk Based World Creation

The environment in an endless runner is typically divided into small sections or chunks that are procedurally generated. These chunks are:
1. Segments of the road, track, or path that the player runs on.
2. Sections of obstacles (e.g., trees, rocks, walls) and collectible items (e.g., coins, power-ups).
3. Background elements like buildings, mountains, or scenery.

#### Randomized Elements

One of the most important aspects of procedural generation is its ability to randomize the placement and structure of chunks. This prevents the player from encountering the same patterns repeatedly, which keeps the game interesting and challenging.

#### Rules and Constraints

While the world is procedurally generated, it is not purely random. The game developers set up rules and constraints to ensure the generated content is logical and playable. For example : 
1. Obstacles need to be placed in ways that are challenging but not impossible to navigate.
2. Power-ups might be spread out to maintain balance.


#### Difficulty Scaling

Many endless runners use procedural generation to increase difficulty over time. As the player progresses, the procedural system can : 
1. Increase the frequency or density of obstacles.
2. Generate more complex patterns (e.g., adding sharper turns or faster-moving obstacles).
3. Place collectibles in harder-to-reach positions. This ensures the game gets more challenging the further the player advances, keeping the gameplay engaging.

### Level of Detail (LOD)

Level of Detail (LOD) is a rendering optimization technique used in 3D graphics to improve performance by reducing the complexity of objects based on their distance from the camera. The idea is that objects far from the camera do not need to be rendered with the same level of detail as objects that are closer, because distant objects appear smaller on the screen and the finer details are not visible. 

When LOD is implemented, multiple versions of a 3D model are created, each with a different level of complexity:
1. High-detail version: This version has a high polygon count, detailed textures, and high-quality materials, used when the object is close to the camera.
2. Medium-detail version: A simplified version with fewer polygons and less texture detail, used when the object is at a moderate distance from the camera.
3. Low-detail version: A very simplified version, often with significantly fewer polygons and simplified textures, used when the object is far away from the camera.
4. Billboard or Imposter version: For very distant objects, a 2D texture or a flat, simplified model (known as a billboard) can be used to represent the object without rendering any 3D geometry at all.

## Lighting

### Directional Lighting

Directional lighting is a type of lighting in computer graphics that simulates light coming from a distant, infinitely large source, like the sun. It is often used to illuminate large scenes in a uniform manner, as the light rays are parallel and hit all objects at the same angle, regardless of their position in the scene.

![image](https://github.com/user-attachments/assets/acf307a3-6902-4e0c-980a-84e7c4e60cc7)

Since the light source is considered infinitely far away, the rays are parallel when they reach objects in the scene. This makes the lighting consistent across large areas. Unlike point or spotlights, where the intensity of light diminishes with distance from the light source (falloff), directional lighting has no falloff. The light intensity remains constant across the entire scene. Directional lights are ideal for simulating sunlight or moonlight in outdoor environments, as these lights cover large areas evenly without needing to account for the distance between objects and the light source.

### Real-time Lighting

Real-time lighting is a crucial aspect of game design, particularly in endless runner games, where visual quality and player experience are essential. It refers to lighting calculations that are processed during gameplay, allowing dynamic changes in lighting conditions, such as time of day or player-triggered events.

![image](https://github.com/user-attachments/assets/9e224fde-a0a0-45de-9ef8-375b893120b3)

Real-time lighting uses dynamic light sources that can move and change over time. This can include point lights, spotlights, and directional lights. In an endless runner, these lights can simulate various environmental conditions, like day/night cycles or moving objects casting shadows.

## Animation

### Character Animation

Character animation is the process of creating and manipulating the movement of characters in films, video games, and other forms of media. It involves bringing characters to life by making them move, express emotions, and interact with their environment. This can include both 2D and 3D animation techniques, though the principles often overlap.

![image](https://github.com/user-attachments/assets/d2eaa33e-6e32-43f2-b26d-ae3f5c122e44)

One of the key aspects for character animation is rigging. Rigging is the process of creating a skeletal structure for a character. This skeleton consists of bones and joints that define how the character moves. The character model is then bound to this skeleton, allowing animators to manipulate the rig to create movement.

## User Interface (UI) Interaction

### Interactive UI Elements

Interactive UI elements are components in a user interface that allow players to engage with the game or application directly. In the context of video games, especially endless runners, these elements are essential for providing feedback, facilitating user interactions, and enhancing the overall player experience.

### Heads-Up Display

A HUD (Heads-Up Display) is an interface element used in video games, applications, and various digital environments that presents crucial information to the player or user without obstructing their view of the main content. The term originally comes from aviation, where it refers to a transparent display that presents data directly in the pilot's line of sight, allowing them to maintain situational awareness.

![image](https://github.com/user-attachments/assets/1e149573-17ab-4a2a-9300-d45878581633)

In an endless runner game, the HUD (Heads-Up Display) plays a crucial role in keeping players informed and engaged while maintaining their focus on the fast-paced action. Given the nature of endless runners, where players are constantly moving forward and facing various challenges, the HUD should be designed to present essential information clearly and efficiently.

### Touch Input and Gestures

In endless runner games, touch input and gestures play a critical role in enabling player interactions. Given that these games are often played on mobile devices, understanding how to effectively implement touch controls is essential for creating a responsive and enjoyable gameplay experience.

![image](https://github.com/user-attachments/assets/368231a1-1900-47e0-a497-23956a25358e)

Touch input refers to the actions players take on a touchscreen device, such as tapping, swiping, or holding a finger on the screen. Unity provides built-in support for touch input, allowing developers to capture and respond to these actions easily. Gesture recognition involves interpreting the player's touch actions to perform specific commands. This can enhance gameplay by making controls more intuitive and fluid. Here are a few common gestures used in endless runners:

## Summary

In a game like Temple Run, Unity's advanced graphical techniques—shaders, optimized geometry, dynamic lighting, realistic animations, and responsive user interfaces—work together to create an interactive and visually engaging experience. The fast-paced nature of the game demands efficient rendering and interaction, ensuring smooth gameplay without sacrificing visual quality.
