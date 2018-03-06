# Tic-Tac-Toe Starter Project
Udacity VR Developer NanoDegree : Project 6 Tic-Tac-Toe by Helen Nicholson

This project is part of [Udacity](https://www.udacity.com "Udacity - Be in demand")'s [VR Developer Nanodegree](https://www.udacity.com/course/vr-developer-nanodegree--nd017).

## Versions
- Unity 2017.1.0
- GVR Unity SDK v1.70.0
- tested on iPhone7

Performance Optimisations
1. High polygon models swapped for low polygon models
2. Individual materials for objects replaced with provided atlas.
3. Static objects set to static
4. Lighting in the scene set to baked
5. Scripts - holdpiece.cs - physics to hover selected counter - moved to FixedUpdate() from Update()
6. Particles on grid plates altered

Possible future enhancements
1. Script - holdpiece.cs - implement lerp instead of AddForce for physics movement - hover counter on click select
2. Script - GameLogic - checkForVictory() - use 2D array matching instead of single array - matrix matching


