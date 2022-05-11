  
#include <ESP8266WiFi.h">     // #include <WiFi.h>    misschien werkt dit wel
#include <<span class="TextRun Highlight BCX0 SCXW174472232" lang="EN-US" xml:lang="EN-US" data-contrast="auto"><span class="SpellingError BCX0 SCXW174472232">FirebaseArduino.h></span></span>
// Set these to run example. 
#define FIREBASE_HOST "https://prullenbak-database-default-rtdb.firebaseio.com/" 
#define FIREBASE_AUTH "fTCamglTuTFmWP2IDZtmvcfBMEauBbA7mFlzln2z" 
#define WIFI_SSID "Teun's iPhone"
#define WIFI_PASSWORD "12345678" 
void setup() { 
 Serial.begin(9600); 
 // connect to wifi. 
 WiFi.begin(WIFI_SSID, WIFI_PASSWORD); 
 Serial.print("connecting"); 
 while (WiFi.status() != WL_CONNECTED) { 
   Serial.print("."); 
   delay(500); 
 } 
 Serial.println(); 
 Serial.print("connected: "); 
 Serial.println(WiFi.localIP()); 
 Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH); 
} 
int n = 0; 
void loop() { 
 // set value 
 Firebase.setFloat("number", 42.0); 
 // handle error 
 if (Firebase.failed()) { 
     Serial.print("setting /number failed:"); 
     Serial.println(Firebase.error());   
     return; 
 } 
 delay(1000); 
 // update value 
 Firebase.setFloat("number", 43.0); 
 // handle error 
 if (Firebase.failed()) { 
     Serial.print("setting /number failed:"); 
     Serial.println(Firebase.error());   
     return; 
 } 
 delay(1000); 
 // get value  
 Serial.print("number: "); 
 Serial.println(Firebase.getFloat("number")); 
 delay(1000); 
 // remove value 
 Firebase.remove("number"); 
 delay(1000); 
 // set string value 
 Firebase.setString("message", "hello world"); 
 // handle error 
 if (Firebase.failed()) { 
     Serial.print("setting /message failed:"); 
     Serial.println(Firebase.error());   
     return; 
 } 
 delay(1000); 
 // set bool value 
 Firebase.setBool("truth", false); 
 // handle error 
 if (Firebase.failed()) { 
     Serial.print("setting /truth failed:"); 
     Serial.println(Firebase.error());   
     return; 
 } 
 delay(1000); 
 // append a new value to /logs 
 String name = Firebase.pushInt("logs", n++); 
 // handle error 
 if (Firebase.failed()) { 
     Serial.print("pushing /logs failed:"); 
     Serial.println(Firebase.error());   
     return; 
 } 
 Serial.print("pushed: /logs/"); 
 Serial.println(name); 
 delay(1000); 
} 
