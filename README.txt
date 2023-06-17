# Pang

Extra Credit
1. Architecture designed with MVC paradigm +++
2. Three or more distinct consecutive levels, with increasing difficulty
3. Custom soundtracks and SFX 

About the system

--AttackSystem--
Fire abstract class
- when hitting an object from tag type ball it explode it (can be override like in RopeFire)
AttackSystem managing the fires
- ObjectPool
- attack function that connect the input
- functions for features like multiple attaks and change current fire
- easy way to add unlimited options of fire
----------------------------------------------------------------------------
--Ball System--
Ball
- physics for unlimited jumping
- have size,velocity and position for initializing
- Invoke OnExplode when Fire object explode it

Ball Generator managing the balls
- listen to onExplode
    - calls the factory to create 2 more child balls
    - it invoke when no balls remains

Ball Factory
- factory contains ObjectPool
----------------------------------------------------------------------------
--Level Creator System--
How To Use It
1. go to Level scene
2. place ball prefabs (later can add stones too) around the game area
3. click on editor window called LevelGenerator
4. type the level name and the seconds it should last
5. add the Scriptable Object that created to the GenerateLevel component under Level-Controller-LevelManager
6. Enjoy.

GenerateLevel
- read the scriptable object that contain list of balls infor (position,velocity,size)
- create them via the ballFactory

-----------------------------------------------------------------------------
--Loot System--
- hold list of objects from type Loot
- listen to on explode
    - for each explode there is X% chance to loot being droped
- loot disapear after 3 seconds using scripts FadeOut
