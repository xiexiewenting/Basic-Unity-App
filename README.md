### INFO 5340 / CS 5650: Virtual and Augmented Reality - Fall 2019

# Assignment 1

<hr>

### Student Name:

Wenting Xie


### Student NetID:

wx95

<hr>

### Solution

**Screen Recording: Part 1**

https://drive.google.com/file/d/12IDs3enDV76qxPLElOKmBZC4r8znXjus
Filename: a1-2019-part1-wx95.*

**Screen Recording: Part 2**

https://drive.google.com/file/d/1qy0JLdU_i_kBzx-BvCa05uZjqClZ3Erx
Filename: a1-2019-part2-wx95.*

**Screen Recording: Part 3**

https://drive.google.com/file/d/1Fm3JUdO-tcChy69RxyhJH7v5OHcoukUx
Filename: a1-2019-part3-wx95.*

**Screen Recording: Part 4**

https://drive.google.com/file/d/1zcrY4NAOYMfWAloXf5IWaFIYZDYY6sEC
Filename: a1-2019-part4-wx95*

**Screen Recording: Part 5**

https://drive.google.com/open?id=1GN37OCpMJQo2JIOdNHd3JR7eYDhekUc0
Filename: a1-2019-part5-wx95.*

<hr>

### Writeup

**Work Summary**

My main approach to this assignment was to very closely follow directions in the first 3 sections (which were very detailed) and then using my newfound knowledge to apply to sections 4 and 5. Whenever there were similarities in between what was currently being asked and what I had done in an earlier phase, I would copy+paste the relevant code block and modify it.  After repeated use of functions, I really started feeling like I understood what was happening in the scene.

In "Brand New World," I created scripts components for each platform which handled the mouse click interaction to start the movement. Platforms A and C were relatively straight-forward to implement (only one needed motion), but Platform D also needed a size increase before the movement.  In addition, the bridge and Platform B (in their final state) was blocking the path for Platform D to get to the trophy.  For those cases, I chose to implement a slight delay after the PlayerSphere got passed to the next stage and move the platform/bridge out of the way, and Platform D was able to track two mouse clicks (one for sizing up and one for elevating).

To track the player progress in the level, I created a script attached to PlayerSphere called PointTracker.  PointTracker uses booleans to store whether the PlayerSphere has made it to which platforms in the level and upon collision with any platform/bridge, it checks whether it has touched the prerequisite platforms (e.g. when at C, it checks whether A and B were reached).  If this condition was not met, the level would be restarted.   

Most of my main challenges really centered around my lack of familiarity with Unity and the hierarchy of objects and components and how they related to each other.  Initially, I had a lot of difficulty figuring out the final positions of my GameObjects in the scene because I struggled with even rotating my perspective of the scene to even see where the GameObjects were. I also would forget to modify some of the public variables from the default 0 because I was unused to being able to change variables outside the script, causing me to panic when my code did not execute as expected.  Finally, it was sometimes difficult to check whether my scripts were working properly since it would require me to wait 15 seconds for the first part of the scene to execute before getting to the part I wanted to work on.

Overall, I felt that this assignment was successful in helping me learn the ropes of Unity, and I look forward to the next assignments incorporating augmented/virtual reality :).


**Final Five**

I chose to focus on trying to improve the player experience.
1. I added an instructions panel that outlines briefly what the objective is and how to accomplish it.  The instructions panel also "moves" with the camera so it is always visible on screen.
2. When the ball reaches an objective, the platform text for it changes to a ":)" in black and the banner text of the next platform the ball should reach becomes bigger and cyan and does small rotations (to attract attention).
3. Upon falling down from the platforms, the camera stops following the PlayerSphere, and there is a text that pops up informing the player that the game will restart in 2 seconds.
4. Successful completion of the level results in a mini-explosion when the trophy disappears, a big text box pops up congratulating the player.  The player has the option to hit space-bar to restart the level (this only works upon successful completion of the level).
