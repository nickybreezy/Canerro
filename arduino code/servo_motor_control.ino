// Chapter 5 - Motor Control
// Controlling Speed
// By Cornel Amariei for Packt Publishing

// Include the Servo library
#include <Servo.h> 

// Declare the Servo pin
int servoPin = 3;
// Create a servo object
Servo Servo1;

void setup() {
  // We need to attach the servo to the used pin number
  Servo1.attach(servoPin);
  Serial.begin(9600);
}

void loop(){
  // Make servo go to 0 degrees
  Servo1.write(0);
  Serial.println("test");
  delay(1000);
  // Make servo go to 90 degrees
  Servo1.write(90);
  Serial.println("test1");
  delay(1000);
  // Make servo go to 180 degrees
  Servo1.write(180);
  Serial.println("test2");
  delay(1000);
}
