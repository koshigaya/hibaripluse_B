#define SENSOR 0
int val = 0;

void setup() {
  Serial.begin(9600);
}

void loop() {
  if(Serial.available()>0) {
    val = analogRead(SENSOR);
    Serial.println(val);
    delay(10);
  }
}
