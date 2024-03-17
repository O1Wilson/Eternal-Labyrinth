# Eternal Labyrinth
 2D rougelike/action-platformer. This game explores complex systems in C# using the Unity Engine, Featuring a sophisticated movement system, diverse characters with unique abilities, custom items each with their own interaction + synergy, and animation + SFX implementation.(Coming Soon). 
# Code Snippets
Below I have attached various code snippets which I feel best showcase this project, please explore the unique systems in full for a better understanding of the skills that I can provide! 
### Character Abilites
![PrimaryCode](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/fbd4d2cf-ad18-4a83-ac5b-91948f9d44a8)

Above is the code I use for the players main attack. This attack is rather simple and uses a collider sphere to detect enemies inside a radius. If there are enemies inside the collider the "TakeDamage()" method will be called inside the enemies script with the correct damage information.

![SecondaryCode](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/24fd6260-a5bc-478e-970d-6f1c43869fc1)
![SecondaryPrefabScript](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/1d547a60-239f-408c-9608-cf7f57e98c00)

Above is are the two scripts I use to instantiate a Wave Prefab. 

You can see in the first snippet the code I use to scale the prefab using a lerp function that is based around a multiplier calculated elsewhere in the script, You can see that I have set scale factors in order to limit the size of the prefab. 

In the second snippet you can see the code that actually registers and damges enemies, additionally it will reset the "bloodGauge" variable which is used to determine the player multiplier. These snippets combined will allow the player to shoot a scaling wave projectile.

![UtilityCalled](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/9f16e5d8-533a-444b-9f49-b50282b96983)
![UtilityCode](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/0618be98-8b5f-4c6e-8558-61c9e0f62afe)
![BloodGauge](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/13cd213b-a801-4450-8c43-fce533de0ead)

Above is a three part system which in short allows for the player to drain their "bloodGauge" for damage immunity. Before explaining the code, bloodGauge refers to resources dropped from slain enemies, and caps at default 100. 

The first Code Snippet is the method I use to begin the Immunity Coroutine, there are three parameters that need to be set inorder to run the coroutine, Cooldown, Blood Storage, Input. I also added a feature to end the coroutine early inorder to save resources. 

The second snippet is the core function for the actual ability. You can see at the top I set two bools to true, "isDraining" is used to determine when the coroutine is actually running, and damageImmune prevents the player from taking damage in another method. Afterwards I start a while loop which drains the bloodGauge by a specific amount aslong as there is value to drain from. Then once the value has been depleted it set the bools back to false and sets the ability on cooldown. 

Finaly in the third snippet I have attached the actual code which determines the Gauges. The blood gained is determined on the enemy script once it dies, but in this script I use a lerp function to interpolate between a damage multiplier of 1 and 10 based on the percentage of the Gauge.

### UI and Movement
![LevelCalc](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/11f1206b-7618-4f64-a9cc-b3150db9b645)
![LevelScaleCode](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/c45a4ef2-9c1d-4b5b-be08-8796bc459548)

Above are the two snippets I use to calculate level, and scale based on that calculation

The first code snippet is rather simple, I use the MathPow Function to exponentially scale the level based on the amount of xp. So each level interval is progressivley harder to reach

The second snippet is also simpler than it seems, inside the method I set static variables which are used to multiply the level and add it towards the players stats, additionaly I have set the "priorLevel" variable to prevent the values from repeatedly being applied

![PlayerUIscript](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/e181d259-170a-4407-870c-656427081032)

Above is how I display the character information from the player scripts into a Unity Canvas.

![JumpingCode](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/c2504272-c317-4a91-9e4a-8ffba6d93f66)

Above you can see the implementation of CoyoteTime, and Jump buffering. I have added these features to improve user input, allowing for more seamless gameplay.

![WallSlideCode](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/1ad8d77a-266f-46ba-8294-39e811499334)
![WallJumpCode](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/d590053d-1d0a-45da-9d0e-01666ed82636)

Above is my code for Wall Jumping. You can see how ive implemented jump duration, counters, and power which again allows for more seamless gameplay with wall jumps.


### Enemy
![EnemyScript](https://github.com/O1Wilson/Eternal-Labyrinth/assets/158622394/d581eae2-36c3-451b-86dc-7596cddf3da2)

Above is the code I use to damage and kill an enemy.
