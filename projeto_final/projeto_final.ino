int const active_chan1 = 7;
int const active_chan2 = 6;
int const active_chan3 = 5;
long thr = 0;
long thm = 0;
long thl = 0;
const int vibrateTime = 1000;
const int buzzerPin = 3;
bool playSong = false;

void setup() {
  Serial.begin(19200);
  pinMode(active_chan1,OUTPUT);
  pinMode(active_chan2,OUTPUT);
  pinMode(active_chan3,OUTPUT);
}

void loop() {

  if(Serial.available() > 0){
    String s = Serial.readStringUntil(':');
    //Serial.println(s);
    if(s == "hl"){
      //Serial.println("hr");
      digitalWrite(active_chan1, HIGH); 
      thr = millis() + vibrateTime;
      //Serial.println(millis());
      //Serial.println(thr);
      //playSong = true;
    }  
    else if(s == "hm"){
      //Serial.println("hm");
      digitalWrite(active_chan2, HIGH); 
      thm = millis() + vibrateTime;
    }  
    else if(s == "hr"){
      //Serial.println("hl");
      digitalWrite(active_chan3, HIGH); 
      thl = millis() + vibrateTime;
    }  
    else{
      //Serial.println("no");
    }
  }

  if (thr < millis() and thr > 0){
    thr = -1;
    digitalWrite(active_chan1, LOW);  
    playSong = false;
    //analogWrite(buzzerPin, 0);
  }
  if (thm < millis() and thm > 0){
    thm = -1;
    digitalWrite(active_chan2, LOW);  
  }
  if (thl < millis() and thl > 0){
    thl = -1;
    digitalWrite(active_chan3, LOW);  
  }

  if (playSong){
    analogWrite(buzzerPin, 400);
  }

}
