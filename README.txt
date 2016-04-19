Included is the modified C# program used to control NCSU Gait Lab's
Powered Exoskeleton through a desktop. Properly connect the motor to
desktop and run EX3_BasicMoves.exe

Dekstop-Motor data communication is handled in JSON format. Smoothing of
sensor data can be done with Kalman Filters or similar.

Note: You'll need a Maxon brushless DC motor to properly initiate the
program. Other motors have not been tested. The code modifies current
flow so PLEASE, be extremely cautious even if you have the same motor.